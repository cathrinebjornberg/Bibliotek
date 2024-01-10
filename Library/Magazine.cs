public class Magazine : Media
{
    // Fyra egenskaper
    public int Id { get; private set; }
    public string Title { get; set; }
    public int Issue { get; set; }
    public string YearOfPublication { get; set; }

    // Kontruktor
    public Magazine(string title, int issue, string yearOfPublication)
    {
        Id = nextId++;
        Title = title;
        Issue = issue;
        YearOfPublication = yearOfPublication;
    }

    public override string ToString()
    {
        return $"Id: {Id}, Tidskrift: {Title}, Nummer: {Issue}, Utgivningsår: {YearOfPublication}";
    }

}