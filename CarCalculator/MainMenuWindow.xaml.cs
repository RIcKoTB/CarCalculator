using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace CarCalculator
{
    /// <summary>
    /// Логика взаимодействия для MainMenuWindow.xaml
    /// </summary>
    public partial class MainMenuWindow : Window
    {
        public MainMenuWindow()
        {
            InitializeComponent();
        }

        private void btnListCar_Click(object sender, RoutedEventArgs e)
        {
            ListCarWindow carWindow = new ListCarWindow();
            carWindow.Show();
            this.Close();
        }

        private void btnSelectCar_Click(object sender, RoutedEventArgs e)
        {
            SelectionWindow selectionWindow = new SelectionWindow();
            selectionWindow.Show();
            this.Close();
        }

        private void btnExit_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
