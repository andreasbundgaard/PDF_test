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
        private List<List<string>> TempList = new List<List<string>>();
        public List<Invoice> InvoiceList = new List<Invoice>();

        public int invoice_start_line;
        public int invoice_break_line;
        public int invoice_end_line;
        public int invoice_pages;

        public void GetPage(int start, int end)
        {
            List<string> returnlist = new List<string>();
            returnlist = Lines.GetRange(start, (end - start + 1));
            TempList.Add(returnlist);
        }

        public List<Invoice> GetInvoices()
        {
            return InvoiceList;
        }

        public void ReadLines(string input)
        {
            foreach (string line in File.ReadAllLines(input))
            {
                Lines.Add(line);
            }
        }
        public List<string> ReadAllLines(string input)
        {
            List<string> returnlist = new List<string>();
            foreach (string line in File.ReadAllLines(input))
            {
                returnlist.Add(line);
            }
            return returnlist;
        }

        public void CreateInvoice(string Name, int No, DateTime Date, int CVR, int Customer, int Order, int Count)
        {
            Invoice i = new Invoice(Name, No, Date, CVR, Customer, Order, Count, TempList);
            InvoiceList.Add(i);
            //Console.WriteLine(TempList);
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
        public DateTime GetInvoiceDate(string input)
        {
            //string format = "d";
            return DateTime.Parse(input.Substring(62, 9), CultureInfo.InstalledUICulture);
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
