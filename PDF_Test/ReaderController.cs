using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Globalization;

namespace PDF_Test
{
    class ReaderController
    {
        public List<string> Lines = new List<string>();
        public List<Invoice> InvoiceList = new List<Invoice>();
        private List<List<string>> TempList = new List<List<string>>();
        private List<List<string>> TempList2 = new List<List<string>>();

        public int invoice_start_line;
        public int invoice_break_line;
        public int invoice_end_line;
        public int invoice_pages;
        public bool inputLoaded = false;
        //public string textFile;

        public void Parse(string input)
        {
            foreach (string line in File.ReadAllLines(input))
            {
                Lines.Add(line);
            }
            foreach (string test in Lines)
            {
                if (test.Contains("FAKTURANR."))
                {
                    invoice_start_line = (Lines.IndexOf(test) - 1);
                }
                else if (test.Contains("Transport"))
                {
                    invoice_break_line = Lines.IndexOf(test) - 1;
                    invoice_pages = 2;
                    GetPage(invoice_start_line, invoice_break_line);
                }
                else if (test.Contains("SUBTOTAL"))
                {
                    invoice_end_line = Lines.IndexOf(test) - 1;
                    GetPage(invoice_start_line, invoice_end_line);
                    CreateInvoice(GetCompany(Lines[invoice_start_line]),
                    GetInvoiceNo(Lines[invoice_start_line + 1]),
                    GetInvoiceDate(Lines[invoice_start_line + 2]),
                    GetCVRNo(Lines[invoice_start_line + 3]),
                        GetCustomerNo(Lines[invoice_start_line + 4]),
                        GetOrderNo(Lines[invoice_start_line + 6]),
                        invoice_pages);
                    invoice_pages = 1;
                    invoice_start_line = 0;
                    invoice_end_line = 0;
                }
            }
        }

        public void GetPage(int start, int end)
        {
            List<string> returnlist = new List<string>();
            returnlist = Lines.GetRange(start, (end - start + 2));
            TempList.Add(returnlist);
        }

        public void CreateInvoice(string Name, int No, string Date, int CVR, int Customer, int Order, int Count)
        {
            TempList2 = TempList.ToList();
            Invoice i = new Invoice(Name, No, Date, CVR, Customer, Order, Count, TempList2);
            InvoiceList.Add(i);
            TempList.Clear();
        }

        public string GetCompany(string input)
        {
            string output;
            output = input.Substring(7, 20);
            return output.Trim();
        }
        public int GetInvoiceNo(string input)
        {
            int output;
            output = int.Parse(input.Substring(61, 7));
            return output;
        }

        public string GetInvoiceDate(string input)
        {
            var date = DateTime.Parse(input.Substring(62, 9), CultureInfo.InstalledUICulture);
            return date.ToShortDateString();
        }
        public int GetCVRNo(string input)
        {
            int output;
            output = int.Parse(input.Substring(62, 9));
            return output;
        }
        public int GetCustomerNo(string input)
        {
            int output;
            output = int.Parse(input.Substring(62, 9));
            return output;
        }
        public int GetOrderNo(string input)
        {
            int output;
            output = int.Parse(input.Substring(65, 6));
            return output;
        }
    }
}
