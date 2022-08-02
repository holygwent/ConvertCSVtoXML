using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using xdeftZadanie.Entities;

namespace xdeftZadanie.Services
{
    public class UserCommunicationService
    {
        private readonly TowarService _towarService;
        public UserCommunicationService()
        {
            _towarService = new TowarService();
        }
        public void DownloadFile(string path)
        {
            bool correctPath = false;
            while (path == "" | correctPath == false)
            {
                path = Console.ReadLine();
                correctPath = _towarService.ReadCsvFile(path);
            }
        }

        public decimal GetPrice(string priceToConvert)
        {
            decimal cena;

            while (!decimal.TryParse(priceToConvert, out cena))
            {
               priceToConvert = Console.ReadLine();

            }
            return cena;

        }
        public string GetPhrase(string phrase)
        {
            while (phrase == "")
            {
                phrase = Console.ReadLine();
            }
            return phrase;
        }
        public Towar GetRecord()
        {
            decimal cena;

            Console.Write("Nazwa:");
            string nazwa = Console.ReadLine();
            while(nazwa=="")
            {
                nazwa = Console.ReadLine();
            }

            Console.Write("Cena:");
            string cenaToConvert = Console.ReadLine();

            while (!decimal.TryParse(cenaToConvert, out cena))
            {
                Console.WriteLine("zła cena ");
                cenaToConvert = Console.ReadLine();
            }
            Console.Write("OpisA:");
            string opisA = Console.ReadLine();
            Console.Write("OpisB:");
            string opisB = Console.ReadLine();
            return new Towar() { Nazwa = nazwa, Cena = cena, Opis = new Opis { A = opisA, B = opisB } };
        }

    }
}
