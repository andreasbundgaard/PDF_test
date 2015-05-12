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
        public List<string> ReadAllLines(string input)
        {
            List<string> returnlist = new List<string>();
            foreach (string line in File.ReadAllLines(input));
            {
                returnlist.Add(line);
            }
        }
    }
}
