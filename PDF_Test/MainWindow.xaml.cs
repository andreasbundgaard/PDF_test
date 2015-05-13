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

namespace PDF_Test
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    ///Hej 

    public partial class MainWindow : Window
    {
        ReaderController _RDR;

        public MainWindow()
        {
            InitializeComponent();
            _RDR = new ReaderController();
        }

        TextReader readFile = new StreamReader("Text.txt");


        private string ReadInvoice()
        {
            string returnstring = "";
            returnstring = readFile.ReadToEnd();
            return returnstring;
        }

        private List<string> ReadAllLines()
        {
            List<string> returnlist = new List<string>();
            return returnlist;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                string inputfile = "Text.txt";
                StreamReader readFile = new StreamReader(inputfile);
                int counter = 0;
                string line;
                int yPoint = 0;
                List<string> lines = new List<string>();
                PdfDocument pdf = new PdfDocument();
                pdf.Info.Title = "TXT to PDF";
                PdfPage pdfPage = pdf.AddPage();
                XImage background = XImage.FromFile("C:\\Fakturapapir.jpg");
                XGraphics graph = XGraphics.FromPdfPage(pdfPage);
                graph.DrawImage(background, new XPoint(0, 0));
                XFont font = new XFont("Courier New", 11, XFontStyle.Regular);
                //_RDR.ReadAllLines(inputfile);
                int invoice_start_line;
                int invoice_end_line;
                int invoice_pages;


                _RDR.ReadLines(inputfile);

                foreach (string test in _RDR.Lines)
                {
                    if (test.Contains("F A K T U R A"))
                    {
                        invoice_start_line = _RDR.Lines.IndexOf(test);
                        _RDR.GetCompany(_RDR.Lines[invoice_start_line]);
                    }
                    if (test.Contains("Transport"))
                    {
                        invoice_end_line = _RDR.Lines.IndexOf(test);
                    }
                    if (test.Contains("/ 2"))
                    {
                        invoice_pages = 2;
                    }
                }

                foreach (string test in File.ReadAllLines(inputfile))
                {
                    //lines.Add(test);
                }

                while ((line = readFile.ReadLine()) != null)
                {
                    //foreach 
                    //line = readFile.ReadToEnd();
                    lines.Add(line);

                    if (line.Contains(""))
                    {
                        //Console.WriteLine("Succes");
                        counter++;
                    }
                    else
                    {
                        graph.DrawString(line, font, XBrushes.Black, new XRect(40, yPoint, pdfPage.Width.Point, pdfPage.Height.Point), XStringFormats.TopLeft);
                        yPoint = yPoint + 10;
                    }
                }

                Console.WriteLine(lines.ToString());

                pdf.Save("Faktura.pdf");
                readFile.Close();
                readFile = null;
                Process.Start("Faktura.pdf");

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
    }
}