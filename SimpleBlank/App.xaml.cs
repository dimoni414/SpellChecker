using System.Windows;
using Mvvm.Core.Services;
using SimpleBlank.Services;
using ViewModels;

namespace SimpleBlank
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            var window = new MainWindow()
            {
                DataContext = new MainViewModel(new RelayCommandFactory(),new SupplementWordService(),new SpellCheckerService(), new LearningDictionaryService())
                {
                    
                }
            };

            window.Show();
            base.OnStartup(e);
        }
        protected override void OnExit(ExitEventArgs e)
        {
            BaseDictionary.SerializeDictionary();
            base.OnExit(e);
        }
    }
}