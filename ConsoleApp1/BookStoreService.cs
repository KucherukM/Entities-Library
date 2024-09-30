public class BookStoreService
{
    private readonly BookStoreContext _context;

    public BookStoreService(BookStoreContext context)
    {
        _context = context;
    }

    public void AddAuthor(Author author)
    {
        _context.Authors.Add(author);
        _context.SaveChanges();
    }

    public void AddPublisher(Publisher publisher)
    {
        _context.Publishers.Add(publisher);
        _context.SaveChanges();
    }

    public void AddGenre(Genre genre)
    {
        _context.Genres.Add(genre);
        _context.SaveChanges();
    }

    public void AddBook(Book newBook)
    {
        _context.Books.Add(newBook);
        _context.SaveChanges();
    }

    public void EditBook(int bookId, Book updatedBook)
    {
        var existingBook = _context.Books.Find(bookId);
        if (existingBook != null)
        {
            existingBook.Title = updatedBook.Title;
            existingBook.Pages = updatedBook.Pages;
            existingBook.Year = updatedBook.Year;
            existingBook.CostPrice = updatedBook.CostPrice;
            existingBook.SalePrice = updatedBook.SalePrice;
            existingBook.IsSequel = updatedBook.IsSequel;
            existingBook.AuthorId = updatedBook.AuthorId;
            existingBook.PublisherId = updatedBook.PublisherId;
            existingBook.GenreId = updatedBook.GenreId;
            existingBook.PreviousBookId = updatedBook.PreviousBookId;

            _context.SaveChanges();
        }
    }

    public void DeleteBook(int bookId)
    {
        var book = _context.Books.Find(bookId);
        if (book != null)
        {
            _context.Books.Remove(book);
            _context.SaveChanges();
        }
    }

    public List<Book> SearchBooksByTitle(string title)
    {
        return _context.Books
            .Where(b => b.Title.Contains(title))
            .ToList();
    }

    public List<Book> SearchBooksByAuthor(string authorName)
    {
        return _context.Books
            .Where(b => b.Author.FullName.Contains(authorName))
            .ToList();
    }

    public List<Book> SearchBooksByGenre(string genreName)
    {
        return _context.Books
            .Where(b => b.Genre.Name.Contains(genreName))
            .ToList();
    }

    public void SellBook(int bookId)
    {
        var book = _context.Books.Find(bookId);
        if (book != null)
        {
            _context.Books.Remove(book);
            _context.SaveChanges();
        }
    }

    public void WriteOffBook(int bookId)
    {
        var book = _context.Books.Find(bookId);
        if (book != null)
        {
            _context.Books.Remove(book);
            _context.SaveChanges();
        }
    }

    public void CreateSale(string saleName, decimal discountPercentage, List<int> bookIds)
    {
        var sale = new Sales
        {
            Name = saleName,  // Змінюємо SaleName на Name
            DiscountPercentage = discountPercentage
        };

        _context.Sales.Add(sale);
        _context.SaveChanges();

        // Прив'язуємо книги до акції
        foreach (var bookId in bookIds)
        {
            var book = _context.Books.Find(bookId);
            if (book != null)
            {
                book.Sales.Add(sale);  // Додайте цю книгу до списку акцій
            }
        }
        _context.SaveChanges();
    }

    public void HoldBookForCustomer(int bookId)
    {
        var book = _context.Books.Find(bookId);
        if (book != null)
        {
            Console.WriteLine($"Книга '{book.Title}' відкладена для покупця.");
        }
    }

    public List<Book> GetNewArrivals()
    {
        var currentYear = DateTime.Now.Year;
        return _context.Books
            .Where(b => b.Year == currentYear)
            .ToList();
    }

    public List<Book> GetTopSellingBooks(int limit = 10)
    {
        return _context.Books
            .OrderByDescending(b => b.SalePrice)
            .Take(limit)
            .ToList();
    }

    public List<Author> GetTopAuthors(int limit = 10)
    {
        return _context.Authors
            .OrderByDescending(a => a.Books.Count)
            .Take(limit)
            .ToList();
    }

    public List<Genre> GetTopGenres(int limit = 10)
    {
        return _context.Genres
            .OrderByDescending(g => g.Books.Count)
            .Take(limit)
            .ToList();
    }
}
