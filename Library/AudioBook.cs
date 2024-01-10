public class AudioBook : Media
{
    // Fyra egenskaper
    public int Id { get; set; }
    public string Title { get; set; }
    public string Author { get; set; }
    public int Duration { get; set; }

    // Kontruktor
    public AudioBook(string title, string author, int minutes)
    {
        Id = nextId++;
        Title = title;
        Author = author;
        Duration = minutes;

    }

    public override string ToString()
    {
        return $"Id: {Id}, Ljudbok: {Title} av {Author}. Längd: {Duration} minuter.";
    }
}