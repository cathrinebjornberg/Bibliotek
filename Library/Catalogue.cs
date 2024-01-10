using System.Text.Json;

public class Catalogue
{
    // -----Listor--------------

    private List<Book> books = new List<Book>();

    private List<AudioBook> audioBooks = new List<AudioBook>();

    private List<Magazine> magazines = new List<Magazine>();


    // -----------Metoder Add------------//

    public void AddBook(Book book)
    {
        books.Add(book);
    }

    public void AddAudioBook(AudioBook audioBook)
    {
        audioBooks.Add(audioBook);
    }

    public void AddMagazine(Magazine magazine)
    {
        magazines.Add(magazine);
    }

    // ------ Metoder Hämta lista ----//

    public List<Book> GetAllBooks()
    {
        return books;
    }
    public List<AudioBook> GetAllAudioBooks()
    {
        return audioBooks;
    }
    public List<Magazine> GetAllMagazines()
    {
        return magazines;
    }

    // ----- Metoder Söka ----//

    public List<Book> SearchForBook(string searchText)
    {
        List<Book> foundBooks = new();

        foreach (Book item in books)
        {
            if (item.Id.ToString().Contains(searchText, StringComparison.InvariantCultureIgnoreCase))
            {
                foundBooks.Add(item);
            }
            else if (item.Title.Contains(searchText, StringComparison.InvariantCultureIgnoreCase))
            {
                foundBooks.Add(item);
            }
            else if (item.Author.Contains(searchText, StringComparison.InvariantCultureIgnoreCase))
            {
                foundBooks.Add(item);
            }
        }

        return foundBooks;
    }
    public List<AudioBook> SearchForAudioBook(string searchText)
    {
        List<AudioBook> foundAudioBooks = new();

        foreach (AudioBook item in audioBooks)
        {
            if (item.Id.ToString().Contains(searchText, StringComparison.InvariantCultureIgnoreCase))
            {
                foundAudioBooks.Add(item);
            }
            else if (item.Title.Contains(searchText, StringComparison.InvariantCultureIgnoreCase))
            {
                foundAudioBooks.Add(item);
            }
            else if (item.Author.Contains(searchText, StringComparison.InvariantCultureIgnoreCase))
            {
                foundAudioBooks.Add(item);
            }
        }

        return foundAudioBooks;
    }
    public List<Magazine> SearchForMagazine(string searchText)
    {
        List<Magazine> foundMagazines = new();

        foreach (Magazine item in magazines)
        {

            if (item.Id.ToString().Contains(searchText, StringComparison.InvariantCultureIgnoreCase))
            {
                foundMagazines.Add(item);
            }
            else if (item.Title.Contains(searchText, StringComparison.InvariantCultureIgnoreCase))
            {
                foundMagazines.Add(item);
            }

        }

        return foundMagazines;
    }

    // ------ Metoder Json -------//

    public void SaveBooksToJson()
    {
        string data = JsonSerializer.Serialize(books);
        File.WriteAllText("books.json", data);
    }
    public void SaveAudioBooksToJson()
    {
        string data = JsonSerializer.Serialize(audioBooks);
        File.WriteAllText("audioBooks.json", data);
    }
    public void SaveMagazinesToJson()
    {
        string data = JsonSerializer.Serialize(magazines);
        File.WriteAllText("magazines.json", data);
    }

    public List<Book> GetJsonDataFromFileBooks(string jsonAsString)
    {
        List<Book> downloadedBooks = JsonSerializer.Deserialize<List<Book>>(jsonAsString);

        return downloadedBooks;

    }

    public List<AudioBook> GetJsonDataFromFileAudioBooks(string jsonAsString)
    {
        List<AudioBook> downloadedAudioBooks = JsonSerializer.Deserialize<List<AudioBook>>(jsonAsString);

        return downloadedAudioBooks;

    }

    public List<Magazine> GetJsonDataFromFileMagazines(string jsonAsString)
    {
        List<Magazine> downloadedMagazines = JsonSerializer.Deserialize<List<Magazine>>(jsonAsString);

        return downloadedMagazines;

    }
}