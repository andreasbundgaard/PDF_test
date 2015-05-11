using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PDF_Test
{
    class Invoice
    {
        public List<string> Lines = new List<string>();
        public int PageCount { get; set; }
        public string Invoice_no { get; set; }
        public string Company_no { get; set; }
        public string CVR_no { get; set; }
        public string Order_no { get; set; }
        public DateTime Deliver_date { get; set; }

    }
}
