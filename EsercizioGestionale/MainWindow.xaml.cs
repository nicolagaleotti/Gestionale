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
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.IO;

namespace EsercizioGestionale
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
            string file = "Negozio.txt";
        private void btnInserisci_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                using (StreamWriter writer = new StreamWriter(file, true))
                {
                    string testo;
                    string prodotto = txtProdotto.Text;
                    double prezzo = double.Parse(txtPrezzo.Text);
                    testo = $"{prodotto}, {prezzo} €";
                    writer.WriteLine(testo);
                    writer.Flush();
                }
                txtProdotto.Clear();
                txtPrezzo.Clear();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                txtProdotto.Clear();
                txtPrezzo.Clear();
            }
        }

        private void btnSearch_Click(object sender, RoutedEventArgs e)
        {
            if(File.Exists(file))
                try
                {
                    txtCercato.Clear();
                    string nome = txtCerca.Text;
                    using (StreamReader reader = new StreamReader(file))
                    {
                        string line;
                        while ((line = reader.ReadLine()) != null)
                        {
                            if (line.Contains(nome))
                                txtCercato.Text += $"{line}\n";
                        }
                    }
                }
                catch { }
        }
    }
}
