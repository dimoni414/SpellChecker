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
                DataContext = new MainViewModel(new RelayCommandFactory(),new SupplementWordService(),new SpellCheckerService())
                {
                    
                }
            };

            window.Show();
            base.OnStartup(e);
        }
    }
}