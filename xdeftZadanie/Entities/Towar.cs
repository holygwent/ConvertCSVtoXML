using CsvHelper.Configuration.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace xdeftZadanie.Entities
{
    public class Towar
    {
        [Index(0)]
        public string Nazwa { get; set; }
        [Index(1)]
        public decimal Cena { get; set; }
        public Opis Opis { get; set; }
        public override string ToString()
        {
            return $"{Nazwa},{Cena}zł,Opis.A:{Opis.A},Opis.B:{Opis.B}";
        }
    }
}
