using System.Windows;
using iQuest.CaesarCipher.DataGenerator.Business;
using iQuest.CaesarCipher.DataGenerator.DataAccess;
using iQuest.CaesarCipher.DataGenerator.Presentation.ViewModels;
using iQuest.CaesarCipher.DataGenerator.Presentation.Views;

namespace iQuest.CaesarCipher.DataGenerator
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App
    {
        private void App_OnStartup(object sender, StartupEventArgs e)
        {
            QuoteRepository quoteRepository = new QuoteRepository();

            IDataSender dataSender = new TcpDataSender(quoteRepository)
            {
                IpAddress = DataGeneratorConfiguration.IpAddress,
                Port = DataGeneratorConfiguration.Port,
                Lag = DataGeneratorConfiguration.Lag
            };

            MainWindow = new DataGeneratorWindow
            {
                DataContext = new DataGeneratorViewModel(dataSender)
            };

            MainWindow.Show();
        }
    }
}