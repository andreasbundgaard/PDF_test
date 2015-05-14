using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace PDF_Test
{
    class ReaderController
    {
        public List<string> Lines = new List<string>();

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
            DateTime output;
            output = DateTime.Parse(input.Substring(62, 9));
            return output;
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
