using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using WeatherReport.Classes;
using WeatherReport.Models;

namespace WeatherReport
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        DataResponse response;

        public MainWindow()
        {
            InitializeComponent();
            Init();
        }

        public async void Init()
        {
            response = await GetWeather.Get(58.009671f, 56.226184f);
        }

        public void Create(int idForecast)
        {

        }

        private void SelectDay(object sender, SelectionChangedEventArgs e)
        {

        }

        private void Refresh(object sender, RoutedEventArgs e)
        {
            Init();
        }
    }
}