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
    /// Логика взаимодействия для SelectionWindow.xaml
    /// </summary>
    public partial class SelectionWindow : Window
    {
        public SelectionWindow()
        {
            InitializeComponent();
            readFile();
        }

        private const string pathToCars = @"Data\\Cars.txt";

        private const string pathToConfig = @"Data\\Configurations\\config.txt";


        public void readFile()
        {
            string[] lines = File.ReadAllLines(pathToCars);

            foreach (string line in lines)
            {
                cmbCar.Items.Add(line);
            }
        }

        public void chooseEngine(string carName)
        {
            string pathToEngine = @"Data\\" + carName + "\\Engine.txt";

            string[] lines = File.ReadAllLines(pathToEngine);

            foreach (string line in lines)
            {
                cmbEngine.Items.Add(line);
            }
        }

        public void chooseColor(string carName)
        {
            string pathToEngine = @"Data\\" + carName + "\\Color.txt";

            string[] lines = File.ReadAllLines(pathToEngine);

            foreach (string line in lines)
            {
                cmbColorCar.Items.Add(line);
            }
        }

        public void chooseColorOutside(string carName)
        {
            string pathToEngine = @"Data\\" + carName + "\\ColorOutside.txt";

            string[] lines = File.ReadAllLines(pathToEngine);

            foreach (string line in lines)
            {
                cmbColorOutside.Items.Add(line);
            }
        }

        public void chooseComplect(string carName)
        {
            string pathToEngine = @"Data\\" + carName + "\\Complect.txt";

            string[] lines = File.ReadAllLines(pathToEngine);

            foreach (string line in lines)
            {
                cmbComplectation.Items.Add(line);
            }
        }

        public void chooseShifter(string carName)
        {
            string pathToEngine = @"Data\\" + carName + "\\Shifter.txt";

            string[] lines = File.ReadAllLines(pathToEngine);

            foreach (string line in lines)
            {
                cmbTypeShifter.Items.Add(line);
            }
        }


        private void btnExit_Click(object sender, RoutedEventArgs e)
        {
            MainMenuWindow mainMenuWindow = new MainMenuWindow();
            mainMenuWindow.Show();
            this.Close();
        }

        private void btnSaveConfiguration_Click(object sender, RoutedEventArgs e)
        {
            saveConfig();
        }

        private void cmbCar_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            string carName = cmbCar.SelectedItem.ToString();

            clearCmb();
            clearAmount();
            lblPrice.Text = "Загальна вартість: 0";
            chooseEngine(carName);
            chooseComplect(carName);
            chooseShifter(carName);
            chooseColorOutside(carName);
            chooseColor(carName);
        }

        public void clearCmb()
        {
            cmbColorCar.Items.Clear();
            cmbColorOutside.Items.Clear();
            cmbComplectation.Items.Clear();
            cmbEngine.Items.Clear();
            cmbTypeShifter.Items.Clear();
        }


        private int carEngineAmount;
        private int carComplectationAmount;
        private int carColorOutsideAmount;
        private int carColorAmount;
        private int carShifterAmount;

        public void clearAmount()
        {
            carEngineAmount = 0;
            carComplectationAmount = 0;
            carColorAmount = 0;
            carShifterAmount = 0;
            carColorOutsideAmount = 0;
        }

        private void cmbEngine_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (cmbEngine.SelectedItem != null)
            {
                string carEngine = cmbEngine.SelectedItem.ToString();
                int amount = ExtractAmount(carEngine);
                carEngineAmount = amount;

                totalPrice();
            }
        }

        private void cmbComplectation_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (cmbComplectation.SelectedItem != null)
            {
                string carComplectation = cmbComplectation.SelectedItem.ToString();
                int amount = ExtractAmount(carComplectation);
                carComplectationAmount = amount;

                totalPrice();
            }
        }

        private void cmbColorOutside_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (cmbColorOutside.SelectedItem != null)
            {
                string carColorOutside = cmbColorOutside.SelectedItem.ToString();
                int amount = ExtractAmount(carColorOutside);
                carColorOutsideAmount = amount;

                totalPrice();
            }
        }

        private void cmbColorCar_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (cmbColorCar.SelectedItem != null)
            {
                string carColor = cmbColorCar.SelectedItem.ToString();
                int amount = ExtractAmount(carColor);
                carColorAmount = amount;

                totalPrice();
            }
        }

        private void cmbTypeShifter_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (cmbTypeShifter.SelectedItem != null)
            {
                string carShifter = cmbTypeShifter.SelectedItem.ToString();
                int amount = ExtractAmount(carShifter);
                carShifterAmount = amount;

                totalPrice();
            }
        }


        private int ExtractAmount(string input)
        {
            string[] parts = input.Split('|');
            string numberPart = parts[1].Trim();

            numberPart = numberPart.Replace("$", "");
            numberPart = numberPart.Replace(",", "");

            return int.Parse(numberPart);
        }

        private string ExtractName(string input)
        {
            string[] parts = input.Split('|');
            string numberPart = parts[0].Trim();

            return numberPart;
        }

        public void totalPrice()
        {
            int totalAmount = carEngineAmount + carComplectationAmount + carColorOutsideAmount + carColorAmount + carShifterAmount;
            lblPrice.Text = "Загальна вартість: " + totalAmount.ToString();
        }

        public void saveConfig()
        {
            if (cmbEngine.SelectedItem == null || cmbColorCar.SelectedItem == null || cmbColorOutside.SelectedItem == null || cmbComplectation.SelectedItem == null || cmbTypeShifter.SelectedItem == null)
            {
                MessageBox.Show("Заповніть всі поля");
            }
            else
            {
                string engineCmb = cmbEngine.SelectedItem.ToString();
                string engine = ExtractName(engineCmb);

                string colorCmb = cmbColorCar.SelectedItem.ToString();
                string color = ExtractName(colorCmb);

                string colorOutCmb = cmbColorOutside.SelectedItem.ToString();
                string colorOut = ExtractName(colorOutCmb);

                string complectCmb = cmbComplectation.SelectedItem.ToString();
                string complect = ExtractName(complectCmb);

                string shifterCmb = cmbTypeShifter.SelectedItem.ToString();
                string shifter = ExtractName(shifterCmb);

                int totalAmount = carEngineAmount + carComplectationAmount + carColorOutsideAmount + carColorAmount + carShifterAmount;

                using (StreamWriter writer = new StreamWriter(pathToConfig, true))
                {
                    writer.WriteLine($"{engine}|{color}|{colorOut}|{complect}|{shifter}|{totalAmount}");
                    MessageBox.Show("Конфігурація успішно додана");
                }
            }
        }

    }
}
