public class Book : Media
{
    // Fyra egenskaper
    public int Id { get; private set; }
    public string Title { get; set; }
    public string Author { get; set; }
    public string YearOfPublication { get; set; }

    // Konstruktor

    public Book(string title, string author, string yearOfPublication)
    {
        Id = nextId++;
        Title = title;
        Author = author;
        YearOfPublication = yearOfPublication;
    }

    public override string ToString()
    {
        return $"Id: {Id}, Bok: {Title} av {Author}. Utgiven år {YearOfPublication}";
    }
}