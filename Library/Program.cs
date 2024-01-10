using System.Text;
using System.Text.Json;

internal class Program
{
    private static void Main(string[] args)
    {
        try
        {
            Console.InputEncoding = Encoding.Unicode;

            Catalogue catalogue = new();
            catalogue.AddBook(new Book("Botgöraren", "Vivica Steen", "2022"));
            catalogue.AddBook(new Book("Offermakaren", "Annicka Steen", "2020"));
            catalogue.AddMagazine(new Magazine("VOUGE", 5, "2001"));
            catalogue.AddAudioBook(new AudioBook("Botgöraren", "Viviva Steen", 300));
            catalogue.AddAudioBook(new AudioBook("Jävla Karlar", "Andrev Walden", 150));
            catalogue.AddMagazine(new Magazine("NY Times", 213, "2009"));

            // reset jsonfile
            catalogue.SaveBooksToJson();
            catalogue.SaveAudioBooksToJson();
            catalogue.SaveMagazinesToJson();

            while (true)
            {
                Console.Clear();
                ShowMenu();
                string userChoice = Console.ReadLine();


                switch (userChoice)
                {
                    case "1":
                        {
                            //Registrera 
                            Console.Clear();
                            ShowMediaMenu("Vilken media vill du registrera?");
                            Console.Write("> ");
                            userChoice = Console.ReadLine();
                            switch (userChoice)
                            {
                                case "1": Register("book", catalogue); break;
                                case "2": Register("audiobook", catalogue); break;
                                case "3": Register("magazine", catalogue); break;
                                default: Console.WriteLine("felaktig input"); break;
                            }

                        }
                        break;
                    case "2":
                        {
                            //Katalog
                            while (true)
                            {
                                Console.Clear();
                                ShowMediaMenu("Vilken media vill du visa?");
                                Console.WriteLine("[4] All media");
                                Console.Write("> ");
                                userChoice = Console.ReadLine();

                                if (userChoice == "1")
                                {
                                    Console.Clear();
                                    Console.WriteLine("Alla böcker: ");

                                    foreach (Book item in catalogue.GetAllBooks())
                                    {
                                        Console.WriteLine(item);
                                    }
                                    Console.ReadLine();
                                    break;
                                }
                                else if (userChoice == "2")
                                {
                                    Console.Clear();
                                    Console.WriteLine("Alla Ljudböcker: ");

                                    foreach (AudioBook item in catalogue.GetAllAudioBooks())
                                    {
                                        Console.WriteLine(item);
                                    }
                                    Console.ReadLine();
                                    break;
                                }
                                else if (userChoice == "3")
                                {
                                    Console.Clear();
                                    Console.WriteLine("Alla Tidskrifter: ");

                                    foreach (Magazine item in catalogue.GetAllMagazines())
                                    {
                                        Console.WriteLine(item);
                                    }
                                    Console.ReadLine();
                                    break;
                                }
                                else if (userChoice == "4")
                                {
                                    Console.Clear();
                                    Console.WriteLine("All Media \n");
                                    foreach (Book item in catalogue.GetAllBooks())
                                    {
                                        Console.WriteLine(item);
                                    }

                                    foreach (AudioBook item in catalogue.GetAllAudioBooks())
                                    {
                                        Console.WriteLine(item);
                                    }

                                    foreach (Magazine item in catalogue.GetAllMagazines())
                                    {
                                        Console.WriteLine(item);
                                    }
                                    Console.ReadLine();
                                    break;

                                }
                                else
                                {
                                    Console.WriteLine("Ogiltligt val. Försök igen");
                                    Console.ReadLine();
                                }
                            }
                        }
                        break;
                    case "3":
                        {
                            Console.Clear();
                            Search(catalogue);
                            Console.ReadLine();
                        }
                        break;
                    default: break;
                }
            }
        }
        catch (System.Exception)
        {
            throw;
        }
    }
    public static void Search(Catalogue catalogue)
    {
        Console.Write("Sök: ");
        string searchText = Console.ReadLine();

        List<Book> foundbooks = new();
        List<AudioBook> foundAudioBooks = new();
        List<Magazine> foundMagazines = new();

        foundbooks = catalogue.SearchForBook(searchText);
        foundAudioBooks = catalogue.SearchForAudioBook(searchText);
        foundMagazines = catalogue.SearchForMagazine(searchText);
        // Om alla listor är tomma skriv ut. Ingen träff. Annars 

        if (foundbooks.Count() == 0 && foundAudioBooks.Count() == 0 && foundMagazines.Count() == 0)
        {
            Console.WriteLine("Ingen träff");
        }

        // Visa media som hittats
        foreach (Book item in foundbooks)
        {
            Console.WriteLine(item);
        }

        foreach (AudioBook item in foundAudioBooks)
        {
            Console.WriteLine(item);
        }

        foreach (Magazine item in foundMagazines)
        {
            Console.WriteLine(item);
        }

    }

    public static void ShowMenu()
    {
        Console.WriteLine("\n Bibiotek Markusvägen 1.0 \n");
        Console.WriteLine("Meny \n");
        Console.WriteLine("[1] Registrera");
        Console.WriteLine("[2] Katalog");
        Console.WriteLine("[3] Sök");
    }
    public static void ShowMediaMenu(string message)
    {
        Console.WriteLine(message + "\n");
        Console.WriteLine("[1] Böcker");
        Console.WriteLine("[2] Ljudböcker");
        Console.WriteLine("[3] Tidskrifter");
    }
    public static void Register(string typAvMedia, Catalogue catalogue)
    {
        string name = "";
        string author = "";
        string year = "";

        if (typAvMedia == "book")
        {

            Console.Write("Bokens namn: ");
            name = Console.ReadLine();

            Console.Write("Skriv in författare: ");
            author = Console.ReadLine();

            Console.Write("Ange utgivningsår: ");
            year = Console.ReadLine();

            catalogue.AddBook(new Book(name, author, year));
            catalogue.SaveBooksToJson();
        }
        else if (typAvMedia == "audiobook")
        {
            Console.Write("Ljudbokens namn: ");
            name = Console.ReadLine();

            Console.Write("Skriv in författare: ");
            author = Console.ReadLine();

            while (true)
            {
                Console.Write("Ange ljudbokens längd i minuter: ");

                if (int.TryParse(Console.ReadLine(), out int minutes))
                {
                    catalogue.AddAudioBook(new AudioBook(name, author, minutes));
                    catalogue.SaveAudioBooksToJson();
                    break;
                }
                else
                {
                    Console.WriteLine("Du angav inte ett giltigt tal");
                }
            }

        }
        // Registrera Tidskrift
        else if (typAvMedia == "magazine")
        {
            Console.WriteLine("Tidskrift \n");
            Console.Write("Ange namn: ");
            name = Console.ReadLine();

            Console.Write("Ange utgivningasår: ");
            year = Console.ReadLine();

            while (true)
            {
                Console.Write("Ange nummer: ");
                if (int.TryParse(Console.ReadLine(), out int number))
                {
                    catalogue.AddMagazine(new Magazine(name, number, year));
                    catalogue.SaveMagazinesToJson();
                    break;
                }
                else
                {
                    Console.WriteLine("Du har inte angett en siffra");
                    Console.ReadKey();
                }
            }

        }
    }

}

