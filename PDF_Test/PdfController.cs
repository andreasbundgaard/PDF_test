using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PdfSharp;
using PdfSharp.Drawing;
using PdfSharp.Pdf;
using System.Diagnostics;

namespace PDF_Test
{
    class PdfController
    {
        string invoiceName;
        string saveLocation;

        public void CreateInvoice(int index, List<Invoice> invoices)
        {
                invoiceName = invoices[index].InvoiceNo.ToString();
                string backgroundPath = "C:\\Fakturapapir.jpg";
                saveLocation = "C:\\Users/Jonas Olesen/Desktop/Fakturaer/";
                PdfDocument pdf = new PdfDocument();
                foreach (List<string> LineList in invoices[index].Pages)
                {
                    int yPoint = 160;
                    PdfPage pdfPage = pdf.AddPage();
                    XImage background = XImage.FromFile(backgroundPath);
                    XGraphics graph = XGraphics.FromPdfPage(pdfPage);
                    graph.DrawImage(background, new XPoint(0, 0));
                    XFont font = new XFont("Courier New", 11, XFontStyle.Regular);

                    foreach (string line in LineList)
                    {
                        graph.DrawString(line, font, XBrushes.Black, new XRect(40, yPoint, pdfPage.Width.Point, pdfPage.Height.Point), XStringFormats.TopLeft);
                        yPoint = yPoint + 10;
                    }
                }
                pdf.Save(saveLocation + invoiceName + ".pdf");
                Process.Start(saveLocation + invoiceName + ".pdf");
        }
    }
}