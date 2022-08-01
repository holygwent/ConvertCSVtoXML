using CsvHelper.Configuration.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace xdeftZadanie.Entities
{
    public class Opis
    {
        [Index(2)]
        public string A { get; set; }
        [Index(3)]
        public string B { get; set; }

    }
}
