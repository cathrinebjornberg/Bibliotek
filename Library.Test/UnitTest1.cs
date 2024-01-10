namespace Library.Test;

public class UnitTest1
{
    [Fact]
    public void AddBook_book_ShouldaddbookToList()
    {
        // arrange

        Catalogue ca = new Catalogue();
        Book book = new Book("Boken om mig", "Cathrine Bjornberg", "2024");

        //act

        ca.AddBook(book);
        List<Book> booksaddedtolibrary = ca.GetAllBooks();

        // Assert.

        Assert.True(booksaddedtolibrary.Count() == 1);
    }

    [Fact]
    public void SearchForBook_searchstring_ShouldReturnFoundBooks()
    {
        // arrange

        Catalogue ca = new Catalogue();
        ca.AddBook(new Book("saras äventyr", "kristina svensson", "2014"));
        ca.AddBook(new Book("Harry Potter den vises sten", "j.k", "2015"));
        ca.AddBook(new Book("Harry Potter - flammande bägaren", "jk", "2016"));

        int expected = 2;

        //act

        List<Book> foundbooks = ca.SearchForBook("Harry");
        int actual = foundbooks.Count();



        // Assert.

        Assert.Equal(expected, actual);

    }
}