using System.Windows.Controls;
using WeatherReport.Models;

namespace WeatherReport.Elements
{
    /// <summary>
    /// Логика взаимодействия для Item.xaml
    /// </summary>
    public partial class Item : UserControl
    {
        public Item(Hour hour)
        {
            InitializeComponent();

            lDay.Text = hour.time.Day.ToString();
            lMonth.Text = GetMonth(hour.time.Month) + ",";
            lToday.Text = hour.time.ToString("HH:mm");

            lTemp.Text = FormatTemp(hour.temp);
            lCondition.Text = hour.description;
            lPressure.Text = hour.pressure.ToString();
            lHumidity.Text = hour.humidity + "%";
            lFeels.Text = FormatTemp(hour.feels_like);
        }

        private string GetMonth(int month)
        {
            string[] months = { "января", "февраля", "марта", "апреля", "мая", "июня", "июля", "августа", "сентября", "октября", "ноября", "декабря" };
            return months[month - 1];
        }

        private string FormatTemp(double temp)
        {
            int t = (int)Math.Round(temp);
            if (t > 0)
            {
                return $"+{t}°";
            }
            else
            {
                return $"{t}°";
            }
        }
    }
}