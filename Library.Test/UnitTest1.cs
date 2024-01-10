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
}