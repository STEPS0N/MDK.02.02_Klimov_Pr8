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
        List<List<Hour>> daysList = new List<List<Hour>>();

        public MainWindow()
        {
            InitializeComponent();
            Init();
        }

        public async void Init()
        {
            parent.Children.Clear();
            days.Items.Clear();
            daysList.Clear();

            response = await GetWeather.Get(58.009671f, 56.226184f);

            var group = response.list.GroupBy(x => DateTimeOffset.FromUnixTimeSeconds(x.dt).LocalDateTime.Date).ToList();

            foreach (var g in group)
            {
                var day = g.Select(card => new Hour
                {
                    time = DateTimeOffset.FromUnixTimeSeconds(card.dt).LocalDateTime,
                    temp = card.main.temp,
                    feels_like = card.main.feels_like,
                    humidity = card.main.humidity,
                    pressure = card.main.pressure,
                    description = card.weather.FirstOrDefault().description
                }).ToList();

                daysList.Add(day);
                days.Items.Add(g.Key.ToString("dd.MM.yyyy"));
            }

            Create(0);
        }

        public void Create(int idForecast)
        {
            parent.Children.Clear();

            foreach (var hour in daysList[idForecast])
            {
                parent.Children.Add(new Elements.Item(hour));
            }
        }

        private void SelectDay(object sender, SelectionChangedEventArgs e)
        {
            if (days.SelectedIndex >= 0)
            {
                Create(days.SelectedIndex);
            }
        }

        private void Refresh(object sender, RoutedEventArgs e)
        {
            Init();
        }
    }
}