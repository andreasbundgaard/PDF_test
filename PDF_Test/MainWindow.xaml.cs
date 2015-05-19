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
using PdfSharp;
using PdfSharp.Drawing;
using PdfSharp.Pdf;
using System.IO;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Diagnostics;
using System.Windows.Forms;

namespace PDF_Test
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    ///Hej 

    public partial class MainWindow : Window
    {
        ReaderController _RDR;
        PdfController _PDF;

        public MainWindow()
        {
            InitializeComponent();
            _RDR = new ReaderController();
            _PDF = new PdfController();
        }

        string inputfile = "Text.txt";
        TextReader readFile = new StreamReader("Text.txt");
        public List<int> selectedIndexes = new List<int>();

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                _RDR.Parse(inputfile);
                Invoice_ListView.ItemsSource = _RDR.InvoiceList;
            }
            catch (Exception ex)
            {
                System.Windows.MessageBox.Show(ex.ToString());
            }
        }

        private void Test_Button_Click(object sender, RoutedEventArgs e)
        {
            _PDF.CreateInvoice(Invoice_ListView.SelectedIndex, _RDR.InvoiceList);
        }
    }
}