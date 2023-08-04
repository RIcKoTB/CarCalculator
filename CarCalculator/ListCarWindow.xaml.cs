using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace CarCalculator
{
    /// <summary>
    /// Логика взаимодействия для ListCarWindow.xaml
    /// </summary>
    public partial class ListCarWindow : Window
    {
        public ListCarWindow()
        {
            InitializeComponent();
            readFile();
        }


        List<MyData> data = new List<MyData>();

        private const string pathToConfig = @"Data\\Configurations\\config.txt";

        public void readFile()
        {
            string[] lines = File.ReadAllLines(pathToConfig);

            foreach (string line in lines)
            {
                string[] values = line.Split('|'); // розділення елементів роздільним знаком

                // додавання нового рядка до DataGrid
                data.Add(new MyData(values[0], values[1], values[2], values[3], values[4], values[5]));
            }

            dgTable.ItemsSource = data;
        }

        public class MyData
        {
            public string Engine { get; set; }
            public string Color { get; set; }
            public string ColorOutside { get; set; }
            public string Complect { get; set; }
            public string Shifter { get; set; }
            public string TotalPrice { get; set; }

            public MyData(string enigine, string color, string colorOutside, string complect, string shifter, string totalPrice)
            {
                Engine = enigine;
                Color = color;
                ColorOutside = colorOutside;
                Complect = complect;
                Shifter = shifter;
                TotalPrice = totalPrice;
            }
        }

        private void btnExit_Click(object sender, RoutedEventArgs e)
        {
            MainMenuWindow mainMenuWindow = new MainMenuWindow();
            mainMenuWindow.Show();
            this.Close();
        }
    }
}
