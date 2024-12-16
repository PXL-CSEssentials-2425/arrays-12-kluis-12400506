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

namespace Kluis
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        int attemps = 0;
        int[] number = {3,4,9,7,2,1};
        int amount = 0;
        StringBuilder code = new StringBuilder();


        public MainWindow()
        {
            InitializeComponent();
        }

        private void nulButton_Click(object sender, RoutedEventArgs e)
        {
            Button btn = (Button)sender;

            if (amount < 6)
            { 
                 int getal = int.Parse(btn.Content.ToString());
                 string result = code.Append($"{getal}").ToString();
                invoerTextBox.Text += "*";
                amount++;
            }

            if (amount == 6)
            {
                ControlNumber();
                amount = 0;
            }

        }

        private void ControlNumber()
        {
            string ingevoerdeCode = code.ToString(); // Haal de ingevoerde code op
            string juisteCode = string.Join("", number); // Vorm de array om naar een string

            if (ingevoerdeCode == juisteCode)
            {
                MessageBox.Show("Code correct! Kluis geopend.", "Succes", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            else
            {
                MessageBox.Show("Foutieve code! Probeer opnieuw.", "Fout", MessageBoxButton.OK, MessageBoxImage.Error);
                ResetCode();
            }
        }

        private void ResetCode()
        {
            code.Clear();
            invoerTextBox.Text = "";

            if (attemps == 2)
            {
                MessageBox.Show($"helaas je hebt de code niet gekraakt sluit da klote ding af", "Fout", MessageBoxButton.OK, MessageBoxImage.Error);
                Close();
            }
            else
            {
                attemps++;
                MessageBox.Show($" je hebt nog {3-attemps} pogingen over");
            }
        }

    }
}