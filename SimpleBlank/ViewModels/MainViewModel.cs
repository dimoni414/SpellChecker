using Mvvm.Core.Services;
using Mvvm.Core.ViewModels;
using SimpleBlank.Services;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Input;

namespace ViewModels
{
    internal class MainViewModel : ViewModelBase
    {
        #region Propertys

        public int CaretIndex
        {
            get { return _caretIndex; }
            set
            {
                UpdateValue(value, ref _caretIndex);
                SupplementWord(_supplementWordService.GetCurrentWord(_inputingText, _caretIndex));
            }
        }

        public string InputingText
        {
            get { return _inputingText; }
            set { UpdateValue(value, ref _inputingText); }
        }

        public string GoodSupplementWord
        {
            get { return _goodSupplementWord; }
            set
            {
                _supplementWordService.ReplaceSupplamentWord(this, value);
                MessageBox.Show("!!!!!");
                ListSupplements.Clear();
                
            }
        }

        public List<string> ListSupplements { get; set; }

        #endregion Propertys

        #region Commands

        public ICommand LearnDictionaryCommand { get; set; }

        #endregion Commands

        #region Constructor

        public MainViewModel(RelayCommandFactory commandFactory
                           , SupplementWordService supplementWordService
                           , SpellCheckerService spellCheckerService
            , LearningDictionaryService learningDictionaryService)
        {
            _supplementWordService = supplementWordService;
            _spellCheckerService = spellCheckerService;
            _learningDictionaryService = learningDictionaryService;
            LearnDictionaryCommand = commandFactory.CreateCommand(_learningDictionaryService.LearnByBook);
        }

        #endregion Constructor

        #region Methods

        private void SupplementWord(string word)
        {
            //var last = _inputingText.LastIndexOf(' ') + 1;
            //var length = _inputingText.Length - last;
            //var lastWord = _inputingText.Substring(last, length);
            ListSupplements = _supplementWordService.Supplement(word);
            RaisePropertyChanged(nameof(ListSupplements));
        }

        #endregion Methods

        #region Fields

        private string _inputingText;
        private SupplementWordService _supplementWordService;
        private SpellCheckerService _spellCheckerService;
        private LearningDictionaryService _learningDictionaryService;
        private int _caretIndex;
        private string _goodSupplementWord;

        #endregion Fields
    }
}