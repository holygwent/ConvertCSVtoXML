using xdeftZadanie.Services;

TowarService towarService = new  TowarService();
UserCommunicationService userCommunicationService = new UserCommunicationService();
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
            break;
        case "2":
            Console.WriteLine("Podaj cene:");
          
            towarService.SaveToXMLRecordsWherePriceGreaterFrom(userCommunicationService.GetPrice(Console.ReadLine()));
            break;
        case "3":
            Console.WriteLine("Podaj fraze:");
    
            towarService.SearchPhraseInOption(userCommunicationService.GetPhrase(Console.ReadLine()));
            phrase = "";
        
            break;
        case "4":
            goto ChooseFile;
            break;
        case "5":
           
            try
            {
                towarService.AddRecord(userCommunicationService.GetRecord());
            }
            catch (Exception e)
            {

                Console.WriteLine("nie udało sie dodać rekordu");
            }
        
            break;
        case "6":
            end = false;
            break;

        default:
            Console.WriteLine("Nie ma takiej opcji wybierz ponownie.");
    
            break;
    }

}



