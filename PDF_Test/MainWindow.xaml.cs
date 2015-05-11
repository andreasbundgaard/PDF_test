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
using MigraDoc.DocumentObjectModel;
using MigraDoc.Rendering;
using MigraDoc.RtfRendering;

namespace PDF_Test
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    ///Hej 

    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

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
                StreamReader readFile = new StreamReader("Text.txt");
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

                foreach (string test in File.ReadAllLines("Text.txt"))
                {
                    //Console.WriteLine(test);
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
