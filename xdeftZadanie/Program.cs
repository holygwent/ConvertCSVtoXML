using xdeftZadanie.Services;

TowarService towarService = new  TowarService();
string option;
bool end = true;
string phrase="";
decimal cena;
string cenaToConvert;
string path;
bool correctPath;

ChooseFile:
Console.WriteLine("Podaj ścieżke:");
 path = "";
correctPath = false;


while (path == "" | correctPath == false)
{
    path = Console.ReadLine();
    correctPath= towarService.ReadCsvFile(path);
}



Console.WriteLine("Wybierz opcje:");
Console.WriteLine("1-zapisz plik do xml posortowane według nazwy");
Console.WriteLine("2-zapisz plik do xml gdzie cena większa od podanej");
Console.WriteLine("3-wyszukaj fraze w rekordach");
Console.WriteLine("4-zmien plik");
Console.WriteLine("5-dodaj rekord");
Console.WriteLine("6- END");




while (end)
{
ChooseOption:
    Console.WriteLine("Opcja:");
    option = Console.ReadLine();
    
    switch (option)
    {
        case "1":
            towarService.SaveToXMLRecordsOrderByName();
            goto ChooseOption;
            break;
        case "2":
            SetPrice:
            Console.WriteLine("Podaj cene:");
            cenaToConvert = Console.ReadLine();

            if (decimal.TryParse(cenaToConvert, out cena))
            {
                towarService.SaveToXMLRecordsWherePriceGreaterFrom(cena);

            }
            else
            {
                goto SetPrice;
            }
            goto ChooseOption;
            break;
        case "3":
            Console.WriteLine("Podaj fraze:");
            while(phrase=="")
            {
                phrase = Console.ReadLine();
            }
            towarService.SearchPhraseInOption(phrase);
            phrase = "";
            goto ChooseOption;
            break;
        case "4":
            goto ChooseFile;
            break;
        case "5":
            Console.Write("Nazwa:");
            string nazwa = Console.ReadLine();
            Console.Write("Cena:");
            cenaToConvert = Console.ReadLine();
            if (!decimal.TryParse(cenaToConvert, out cena))
            {
                Console.WriteLine("zła cena ");
                goto ChooseOption;
            }
            Console.Write("OpisA:");
            string opisA = Console.ReadLine();
            Console.Write("OpisB:");
            string opisB = Console.ReadLine();
            try
            {
                towarService.AddRecord(nazwa, cena, opisA, opisB);
            }
            catch (Exception e)
            {

                Console.WriteLine("nie udało sie dodać rekordu");
            }
        
            goto ChooseOption;
            break;
        case "6":
            end = false;
            break;


        default:
            Console.WriteLine("Nie ma takiej opcji wybierz ponownie.");
            goto ChooseOption;
            break;
    }

}



