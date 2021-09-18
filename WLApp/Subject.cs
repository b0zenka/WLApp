using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WLApp
{
    public class Subject
    {
        // Nie wyświetlam wszystkich wartości, bo na cele zadania są one zbędne :)

        public string Name { get; set; }
        public string Nip { get; set; }
        public List<string> AccountNumbers { get; set; }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine(Name);

            foreach (var accountNumber in AccountNumbers)
            {
                sb.AppendLine($"\tNumer konta bankowego: {accountNumber}");
            }

            return sb.ToString();
        }
    }
}
