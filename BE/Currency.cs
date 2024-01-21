using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
    public class Currency
    {
        public int CurrencyId { get; set; }
        public string Country { get; set; }
        public string CurrencyName { get; set; }
        public string CurrencyAbbreviation { get; set; }
    }
}
