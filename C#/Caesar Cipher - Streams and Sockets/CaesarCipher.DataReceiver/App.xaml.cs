using System.Net;
using System.Windows;
using iQuest.CaesarCipher.DataReceiver.Business;
using iQuest.CaesarCipher.DataReceiver.Presentation.ViewModels;
using iQuest.CaesarCipher.DataReceiver.Presentation.Views;

namespace iQuest.CaesarCipher.DataReceiver
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private void App_OnStartup(object sender, StartupEventArgs e)
        {
            DataProcessor dataProcessor = new DataProcessor
            {
                IpAddress = DataReceiverConfiguration.IpAddress,
                Port = DataReceiverConfiguration.Port
            };

            MainWindow = new DataReceiverWindow
            {
                DataContext = new DataReceiverViewModel(dataProcessor)
            };

            MainWindow.Show();
        }
    }
}
