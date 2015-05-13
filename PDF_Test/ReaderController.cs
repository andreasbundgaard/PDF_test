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
            output.Replace("  ", string.Empty);
            return output;
        }

        private static StringBuilder TrimEnd(this StringBuilder sb)
        {
            if (sb == null || sb.Length == 0)
                return sb;

            int i = sb.Length - 1;
            for (; i >= 0; i--)
                if (!char.IsWhiteSpace(sb[i]))
                    break;

            if (i < sb.Length - 1)
                sb.Length = i + 1;

            return sb;
        }
    }
}
