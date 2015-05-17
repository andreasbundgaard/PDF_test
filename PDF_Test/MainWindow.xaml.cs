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

        public MainWindow()
        {
            InitializeComponent();
            _RDR = new ReaderController();
        }

        public bool CheckBoxes { get; set; }

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

                _RDR.ReadLines(inputfile);

                foreach (string test in _RDR.Lines)
                {
                    if (test.Contains("F A K T U R A"))
                    {
                        
                        _RDR.invoice_start_line = _RDR.Lines.IndexOf(test);
                        /*
                        _RDR.GetCompany(_RDR.Lines[_RDR.invoice_start_line]);
                        _RDR.GetInvoiceNo(_RDR.Lines[_RDR.invoice_start_line + 1]);
                        _RDR.GetInvoiceDate(_RDR.Lines[_RDR.invoice_start_line + 2]);
                        _RDR.GetCVRNo(_RDR.Lines[_RDR.invoice_start_line + 3]);
                        _RDR.GetCustomerNo(_RDR.Lines[_RDR.invoice_start_line + 4]);
                        _RDR.GetOrderNo(_RDR.Lines[_RDR.invoice_start_line + 6]);
                        */
                        //_RDR.invoice_pages = 1;
                    }
                    else if (test.Contains("Transport"))
                    {
                        _RDR.invoice_break_line = _RDR.Lines.IndexOf(test);
                        _RDR.invoice_pages = 2;
                        _RDR.GetPage(_RDR.invoice_start_line, _RDR.invoice_break_line);
                    }
                    else if (test.Contains("SUBTOTAL"))
                    {
                        _RDR.invoice_end_line = _RDR.Lines.IndexOf(test);
                        _RDR.GetPage(_RDR.invoice_start_line, _RDR.invoice_end_line);
                        _RDR.CreateInvoice(_RDR.GetCompany(_RDR.Lines[_RDR.invoice_start_line]),
                            _RDR.GetInvoiceNo(_RDR.Lines[_RDR.invoice_start_line + 1]),
                            _RDR.GetInvoiceDate(_RDR.Lines[_RDR.invoice_start_line + 2]),
                            _RDR.GetCVRNo(_RDR.Lines[_RDR.invoice_start_line + 3]),
                            _RDR.GetCustomerNo(_RDR.Lines[_RDR.invoice_start_line + 4]),
                            _RDR.GetOrderNo(_RDR.Lines[_RDR.invoice_start_line + 6]),
                            _RDR.invoice_pages);
                            _RDR.invoice_pages = 1;
                            _RDR.invoice_start_line = 0;
                            _RDR.invoice_end_line = 0;
                    }
                }

                Invoice_ListView.ItemsSource = _RDR.InvoiceList;
                
                /*
                foreach (Invoice i in _RDR.InvoiceList)
                {
                    Invoice_ListView.Items.Add(i);
                }

                
                */

                /*
                foreach (string test in File.ReadAllLines(inputfile))
                {
                    //lines.Add(test);
                }
                */


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

                //pdf.Save("Faktura.pdf");
                readFile.Close();
                readFile = null;
                //Process.Start("Faktura.pdf");

            }
            catch (Exception ex)
            {
                System.Windows.MessageBox.Show(ex.ToString());
            }
        }
    }
}