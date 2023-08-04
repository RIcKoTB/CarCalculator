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
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace CarCalculator
{
    /// <summary>
    /// Логика взаимодействия для SignUpWindow.xaml
    /// </summary>
    public partial class SignUpWindow : Window
    {
        public SignUpWindow()
        {
            InitializeComponent();
        }

        private const string pathToData = @"Data";

        public static string UserName = "";
        public static string UserPassword = "";

        private void btnSignUp_Click(object sender, RoutedEventArgs e)
        {
            if (!Directory.Exists(pathToData + "\\Users"))
            {
                Directory.CreateDirectory(pathToData + "\\Users");
            }

            UserName = txtbUserName.Text;

            if (UserName.Length == 0) // Перевірка на пусте поле
            {
                MessageBox.Show("Заповніть поле логіну");
                return;
            }

            UserPassword = pswbPassword.Password;

            if (UserPassword.Length == 0) // Перевірка на пусте поле
            {
                MessageBox.Show("Заповніть поле паролю");
                return;
            }


            if (Directory.Exists(pathToData + "\\Users\\" + UserName))
            {
                MessageBox.Show("Користувач вже інсує");
                return;
            }

            Directory.CreateDirectory(pathToData + "\\Users\\" + UserName);

            string hashOfPassword = BCrypt.Net.BCrypt.HashPassword(UserPassword);

            File.WriteAllText(pathToData + "\\Users\\" + UserName + "\\Info.txt", hashOfPassword);
            MessageBox.Show("Реєстрація успішна!");
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
            this.Close();
        }

        private void btnSignInWay_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
            this.Close();
        }
    }
}
