using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Lab_3_AsadullinaD.D._БПИ_23_01
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window, INotifyPropertyChanged
    {
        private string currentTopic = "ColdTopic";

        public string Image1 { get; set; } = "/Resource/Task1.png";
        public string Image2 { get; set; } = "/Resource/Task2.png";
        public string Image3 { get; set; } = "/Resource/Task3.png";
        public string Image4 { get; set; } = "/Resource/Task4.png";
        public string Image5 { get; set; } = "/Resource/Task5.png";

        public List<string> Listf1 { get; set; }
        public List<string> Listf2 { get; set; }
        public List<string> Listc1 { get; set; }
        public List<string> Listc2 { get; set; }
        public List<string> Listd { get; set; }
        public List<string> ListN { get; set; }
        public List<string> ListK { get; set; }

        private string _result;
        public string Result
        {
            get => _result;
            set { _result = value; OnPropertyChanged(); }
        }

        public MainWindow()
        {
            InitializeComponent();
            InitializeListBoxes();
            DataContext = this;
            LoadInitialTopic();
        }

        private void LoadInitialTopic()
        {
            try
            {
                var uri = new Uri("/Topics/" + currentTopic + ".xaml", UriKind.Relative);
                ResourceDictionary resourceDict = Application.LoadComponent(uri) as ResourceDictionary;
                Application.Current.Resources.Clear();
                Application.Current.Resources.MergedDictionaries.Add(resourceDict);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при загрузке начальной темы: {ex.Message}", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void InitializeListBoxes()
        {
            Listf1 = new List<string> { "4", "5", "6", "7", "8", "9" };
            Listf2 = new List<string> { "10", "20", "30", "40" };
            Listc1 = new List<string> { "0", "1" };
            Listc2 = new List<string> { "0", "1", "2", "3", "4", "5" };
            Listd = new List<string> { "-1", "0", "1" };
            ListN = new List<string> { "1", "2", "3", "4", "5" };
            ListK = new List<string> { "1", "2", "3", "4", "5" };
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Calculation calculation = null;

                if (Radio1.IsChecked == true)
                {
                    double a = double.Parse(R1TextA.Text);
                    double f = double.Parse(R1ComboF.SelectedItem as string);
                    calculation = new Task1Calculation(a, f);
                }
                else if (Radio2.IsChecked == true)
                {
                    double a = double.Parse(R2TextA.Text);
                    double b = double.Parse(R2TextB.Text);
                    double f = double.Parse(R2ComboF.SelectedItem as string);
                    calculation = new Task2Calculation(a, b, f);
                }
                else if (Radio3.IsChecked == true)
                {
                    double a = double.Parse(R3TextA.Text);
                    double b = double.Parse(R3TextB.Text);
                    double c = double.Parse(R3ComboC.SelectedItem as string);
                    double d = double.Parse(R3ComboD.SelectedItem as string);
                    calculation = new Task3Calculation(a, b, c, d);
                }
                else if (Radio4.IsChecked == true)
                {
                    double a = double.Parse(R4TextA.Text);
                    double c = double.Parse(R4ComboC.SelectedItem as string);
                    double d = 7;
                    calculation = new Task4Calculation(a, c, d);
                }
                else if (Radio5.IsChecked == true)
                {
                    double x = double.Parse(R5TextX.Text);
                    double y = double.Parse(R5TextY.Text);
                    double t = double.Parse(R5TextT.Text);
                    double j = double.Parse(R5TextJ.Text);
                    int N = int.Parse(R5ComboN.SelectedItem as string);
                    int K = int.Parse(R5ComboK.SelectedItem as string);
                    calculation = new Task5Calculation(x, y, t, j, N, K);
                }

                if (calculation != null)
                {
                    double result = calculation.Calculate();
                    Result = $"Результат: {result:F6}";
                    Title = Result;
                }
            }
            catch (Exception ex)
            {
                Result = $"Ошибка: {ex.Message}";
                Title = Result;
            }
        }

        private void TopicButton_Click(object sender, RoutedEventArgs e)
        {
            if (currentTopic == "ColdTopic")
                currentTopic = "WarmTopic";
            else
                currentTopic = "ColdTopic";

            try
            {
                var uri = new Uri("/Topics/" + currentTopic + ".xaml", UriKind.Relative);
                ResourceDictionary resourceDict = Application.LoadComponent(uri) as ResourceDictionary;
                Application.Current.Resources.Clear();
                Application.Current.Resources.MergedDictionaries.Add(resourceDict);

                Title = $"Calculator - {currentTopic}";
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при загрузке темы: {ex.Message}", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void NumberValidationTextBox(object sender, TextCompositionEventArgs e)
        {
            foreach (char c in e.Text)
            {
                if (!char.IsDigit(c) && c != ',' && c != '-')
                {
                    e.Handled = true;
                    return;
                }
            }

            TextBox textBox = sender as TextBox;
            if (e.Text == "-" && textBox != null)
            {
                if (textBox.Text.Length > 0 && textBox.SelectionStart != 0)
                {
                    e.Handled = true;
                }
            }

            if (e.Text == "," && textBox != null)
            {
                if (textBox.Text.Contains(","))
                {
                    e.Handled = true;
                }
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }

}
