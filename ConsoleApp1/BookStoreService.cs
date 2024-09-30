using System.Linq.Expressions;

public class BookStoreService
{
    private readonly BookStoreContext _context;

    public BookStoreService(BookStoreContext context)
    {
        _context = context;
    }

    public void AddAuthor(Author author)
    {
        try
        {
            _context.Authors.Add(author);
            _context.SaveChanges();
        }
        catch (Exception ex)
        {
            Console.WriteLine("Помилка при додаванні автора\t");
            Console.WriteLine(ex.ToString());
        }
    }
    public void DisplayAllData()
    {
        try
        {
            Console.WriteLine("Authors:");
            var authors = _context.Authors.ToList();
            foreach (var author in authors)
            {
                Console.WriteLine($"AuthorId: {author.AuthorId}, FullName: {author.FullName}");
            }

            Console.WriteLine(); 

      
            Console.WriteLine("Publishers:");
            var publishers = _context.Publishers.ToList();
            foreach (var publisher in publishers)
            {
                Console.WriteLine($"PublisherId: {publisher.PublisherId}, Name: {publisher.Name}");
            }

            Console.WriteLine(); 

            
            Console.WriteLine("Genres:");
            var genres = _context.Genres.ToList();
            foreach (var genre in genres)
            {
                Console.WriteLine($"GenreId: {genre.GenreId}, Name: {genre.Name}");
            }

            Console.WriteLine(); 

            
            Console.WriteLine("Books:");
            var books = _context.Books.ToList();
            foreach (var book in books)
            {
                Console.WriteLine($"BookId: {book.BookId}, Title: {book.Title}, Pages: {book.Pages}, Year: {book.Year}, CostPrice: {book.CostPrice}, SalePrice: {book.SalePrice}, IsSequel: {book.IsSequel}, AuthorId: {book.AuthorId}, PublisherId: {book.PublisherId}, GenreId: {book.GenreId}");
            }

            Console.WriteLine(); 

            Console.WriteLine("Sales:");
            var sales = _context.Sales.ToList();
            foreach (var sale in sales)
            {
                Console.WriteLine($"SaleId: {sale.SaleId}, Name: {sale.Name}, DiscountPercentage: {sale.DiscountPercentage}");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Помилка при отриманні даних: {ex.Message}");
        }
    }

    public void AddPublisher(Publisher publisher)
    {
        try
        {
            _context.Publishers.Add(publisher);
            _context.SaveChanges();
        }
        catch (Exception ex)
        {
            Console.WriteLine("Помилка при додаванні видавництва\t");
            Console.WriteLine(ex.ToString());
        }
    }

    public void AddGenre(Genre genre)
    {
        try
        {
            _context.Genres.Add(genre);
            _context.SaveChanges();
        }
        catch (Exception ex)
        {
            Console.WriteLine("Помилка при додаванні жанру\t");
            Console.WriteLine(ex.ToString());
        }
        }

    public void AddBook(Book newBook)
    {
        try
        {
            _context.Books.Add(newBook);
            _context.SaveChanges();
        }
        catch (Exception ex)
        {
            Console.WriteLine("Помилка при додаванні жанру\t");
            Console.WriteLine(ex.ToString());
        }
        }

    public void EditBook(int bookId, Book updatedBook)
    {
        try
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
                

                _context.SaveChanges();
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Помилка при редагуванні книги\t");
            Console.WriteLine(ex.ToString());
        }
    }

    public void DeleteBook(int bookId)
    {
        try
        {
            var book = _context.Books.Find(bookId);
            if (book != null)
            {
                _context.Books.Remove(book);
                _context.SaveChanges();
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Помилка при редагуванні книги\t");
            Console.WriteLine(ex.ToString());
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
        try
        {
            var book = _context.Books.Find(bookId);
            if (book != null)
            {
                _context.Books.Remove(book);
                _context.SaveChanges();
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Помилка при продажі книги\t");
            Console.WriteLine(ex.ToString());
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
            Name = saleName,  
            DiscountPercentage = discountPercentage
        };
        _context.Sales.Add(sale);
        _context.SaveChanges();
        foreach (var bookId in bookIds)
        {
            var book = _context.Books.Find(bookId);
            if (book != null)
            {
                book.Sales.Add(sale); 
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
