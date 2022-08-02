using CsvHelper;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using xdeftZadanie.Entities;
using System.Xml;
using CsvHelper.Configuration;
using System.Diagnostics;

namespace xdeftZadanie.Services
{
    public class TowarService
    {

        private List<Towar> _Towars ;

        public List<Towar> Towars
        {
             get { return _Towars; }
            private set { _Towars = value; }
        }
      
        public bool ReadCsvFile(string path)
        {
            _Towars = new List<Towar>();
            CultureInfo cultureInfo = new CultureInfo("pl-PL");
            var config = new CsvConfiguration(cultureInfo)
            {
                HasHeaderRecord = false,
                BadDataFound=null
            };
            List<Towar> towarList = new List<Towar>();
     

            try
            {
                using (var reader = new StreamReader(path,Encoding.UTF8))
                {
                    try
                    {
                        using (var csv = new CsvReader(reader, config))
                        {

                            towarList = csv.GetRecords<Towar>().ToList();
                        }
                    }
                    catch (Exception e)
                    {

                        Console.WriteLine(e.Message);
                    }

                    foreach (var record in towarList)
                    {
                        Towars.Add(record);
                    }
                    
                }

            }
            catch (Exception e)
            {

                Console.WriteLine("Error operating on csv file");
                Console.WriteLine(e.Message);
                return false;
            }

            return true;
        }
        public void SaveToXMLRecordsOrderByName()
        {
            string filePath = @"C:\Users\48502\Desktop\myXmFile.xml";
            var recordsOrderBy = Towars.OrderBy(x => x.Nazwa).ToList();
            try
            {
                MakeXMLFile(recordsOrderBy,filePath);
            }
            catch (Exception e)
            {

                Console.WriteLine("nie udało sie stworzyc pliku xml");
            }

            try
            {
                Process.Start("notepad.exe",filePath);

            }
            catch (Exception e)
            {

                Console.WriteLine("nie udało sie otworzyc pliku");
            }


        }
        public void SaveToXMLRecordsWherePriceGreaterFrom(decimal price)
        {
            string filePath = @"C:\Users\48502\Desktop\myXmFile.xml";
            var recordsGreaterFrom = Towars.Where(x => x.Cena > price).OrderByDescending(x => x.Cena).ToList();
            try
            {
                MakeXMLFile(recordsGreaterFrom, filePath);

            }
            catch (Exception e )
            {

                Console.WriteLine("nie udało sie stworzyc pliku xml");

            }

            try
            {
                Process.Start("notepad.exe", filePath);
            }
            catch (Exception e)
            {

                Console.WriteLine("nie udało sie otworzyc pliku");
            }
        }


        public void SearchPhraseInOption(string phrase)
        {
            var recordsWithPhrase = Towars.Where(x => x.Opis.A.ToLower().Contains(phrase)| x.Opis.B.ToLower().Contains(phrase)).ToList();
            foreach (var record in recordsWithPhrase)
            {
                Console.WriteLine(record.ToString());
            }
        }

        public void MakeXMLFile(List<Towar> records,string filePath)
        {
            XmlTextWriter textWriter = new XmlTextWriter(filePath, Encoding.UTF8);
            textWriter.WriteStartDocument();
            textWriter.WriteStartElement("Plik");
            textWriter.WriteStartElement("Towary");
            foreach (var record in records)
            {
                textWriter.WriteStartElement("Towar");

                textWriter.WriteStartElement("Nazwa");
                textWriter.WriteString(record.Nazwa);
                textWriter.WriteEndElement();

                textWriter.WriteStartElement("Cena");
                textWriter.WriteString(record.Cena.ToString());
                textWriter.WriteEndElement();


                textWriter.WriteStartElement("Opis");
                textWriter.WriteStartElement("A");
                textWriter.WriteString(record.Opis.A);
                textWriter.WriteEndElement();
                textWriter.WriteStartElement("B");
                textWriter.WriteString(record.Opis.B);
                textWriter.WriteEndElement();
                textWriter.WriteEndElement();

                textWriter.WriteEndElement();




            }
            textWriter.WriteEndElement();
            textWriter.WriteEndElement();
            textWriter.WriteEndDocument();
            textWriter.Close();
        }
        public void AddRecord(Towar towar)
        {
            Towars.Add(towar);
        }
    }
}
