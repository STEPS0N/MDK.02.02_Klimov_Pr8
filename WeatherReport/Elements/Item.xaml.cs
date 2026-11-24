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
        }
    }
}
