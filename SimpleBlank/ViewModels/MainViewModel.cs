﻿using Mvvm.Core.Services;
using Mvvm.Core.ViewModels;
using SimpleBlank.Services;
using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Input;
using System.Windows.Interactivity;

namespace ViewModels
{
    internal class MainViewModel : ViewModelBase
    {
        #region Propertys

        //public static readonly DependencyProperty CaretIndexerProperty
        //    = DependencyProperty.Register(
        //        "CaretIndexer",
        //        typeof(int),
        //        typeof(MainViewModel),
        //        new UIPropertyMetadata(null));

        //public int CaretIndexer
        //{
        //    get { return (int)GetValue(CaretIndexerProperty); }
        //    set { SetValue(CaretIndexerProperty, value); }
        //}

        public string InputingText
        {
            get { return _inputingText; }
            set
            {
                UpdateValue(value, ref _inputingText);
                SupplementWord(_inputingText);
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
            ,LearningDictionaryService learningDictionaryService)
        {
            _supplementWordService = supplementWordService;
            _spellCheckerService = spellCheckerService;
            _learningDictionaryService = learningDictionaryService;
            LearnDictionaryCommand = commandFactory.CreateCommand(_learningDictionaryService.LearnByBook);
        }

        #endregion Constructor

        #region Methods

        private void SupplementWord(string _inputingText)
        {
            var last = _inputingText.LastIndexOf(' ')+1;
            var length = _inputingText.Length - last;
            var lastWord = _inputingText.Substring(last,length);
            ListSupplements = _supplementWordService.Supplement(lastWord);
            RaisePropertyChanged(nameof(ListSupplements));
        }



        #endregion Methods

        #region Fields

        private string _inputingText;
        private SupplementWordService _supplementWordService;
        private SpellCheckerService _spellCheckerService;
        private LearningDictionaryService _learningDictionaryService;

        #endregion Fields
    }
}