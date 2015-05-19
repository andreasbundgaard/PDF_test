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
        public int ID = 0;

        public void GetPage(int start, int end)
        {
            List<string> returnlist = new List<string>();
            returnlist = Lines.GetRange(start, (end - start + 2));
            TempList.Add(returnlist);
        }

        public void ReadLines(string input)
        {
            foreach (string line in File.ReadAllLines(input))
            {
                Lines.Add(line);
            }
        }

        public void CreateInvoice(string Name, int No, string Date, int CVR, int Customer, int Order, int Count)
        {
            TempList2 = TempList.ToList();
            Invoice i = new Invoice(ID, Name, No, Date, CVR, Customer, Order, Count, TempList2);
            InvoiceList.Add(i);
            TempList.Clear();
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

        public string GetInvoiceDate(string input)
        {
            //string format = "d";
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
