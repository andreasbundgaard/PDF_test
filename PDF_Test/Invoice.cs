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
        public string InvoiceDate { get; set; }
        public int CVRNo { get; set; }
        public int CustomerNo { get; set; }
        public int OrderNo { get; set; }
        public int PageCount { get; set; }

        public List<List<string>> Pages = new List<List<string>>();

        public Invoice(string CompanyName, int InvoiceNo, string InvoiceDate, int CVRNo, int CustomerNo, int OrderNo, int PageCount, List<List<string>> Pages)
        {
            this.CompanyName = CompanyName;
            this.InvoiceNo = InvoiceNo;
            this.InvoiceDate = InvoiceDate;
            this.CVRNo = CVRNo;
            this.CustomerNo = CustomerNo;
            this.OrderNo = OrderNo;
            this.PageCount = PageCount;
            this.Pages = Pages;
        }
    }
}