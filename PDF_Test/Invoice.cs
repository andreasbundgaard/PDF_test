using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PDF_Test
{
    class Invoice
    {
        public string CompanyName { get; set; }
        public int InvoiceNo { get; set; }
        public DateTime InvoiceDate { get; set; }
        public int CVRNo { get; set; }
        public int CustomerNo { get; set; }
        public int OrderNo { get; set; }
        public int PageCount { get; set; }

        public List<List<string>> Pages = new List<List<string>>();

        public Invoice(string Name, int No, DateTime Date, int CVR, int Customer, int Order, int Count, List<List<string>> PagesList)
        {
            this.CompanyName = Name;
            this.InvoiceNo = No;
            this.InvoiceDate = Date;
            this.CVRNo = CVR;
            this.CustomerNo = Customer;
            this.OrderNo = Order;
            this.PageCount = Count;
            this.Pages = PagesList;
        }
    }
}
