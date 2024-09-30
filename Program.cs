using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using static BookStoreContext;

class Program
{
    static void Main(string[] args)
    {
        using (var context = new BookStoreContext())
        {
            var service = new BookStoreService(context);
            if (!context.Authors.Any())
            {
                Console.WriteLine("Заповнюємо таблицю Авторів...");
                service.AddAuthor(new Author { FullName = "Джоан Роулінг" });
                service.AddAuthor(new Author { FullName = "Джордж Орвелл" });
                service.AddAuthor(new Author { FullName = "Марк Твен" });
                service.AddAuthor(new Author { FullName = "Антуан де Сент-Екзюпері" });
                service.AddAuthor(new Author { FullName = "Ернест Хемінгуей" });
                service.AddAuthor(new Author { FullName = "Федір Достоєвський" });
                service.AddAuthor(new Author { FullName = "Лев Толстой" });
                service.AddAuthor(new Author { FullName = "Олександр Пушкін" });
                service.AddAuthor(new Author { FullName = "Джек Лондон" });
                service.AddAuthor(new Author { FullName = "Габріель Гарсія Маркес" });
            }

            if (!context.Publishers.Any())
            {
                service.AddPublisher(new Publisher { Name = "Penguin Books" });
                service.AddPublisher(new Publisher { Name = "HarperCollins" });
                service.AddPublisher(new Publisher { Name = "Simon & Schuster" });
                service.AddPublisher(new Publisher { Name = "Random House" });
                service.AddPublisher(new Publisher { Name = "Hachette Book Group" });
                service.AddPublisher(new Publisher { Name = "Macmillan Publishers" });
                service.AddPublisher(new Publisher { Name = "Scholastic" });
                service.AddPublisher(new Publisher { Name = "Oxford University Press" });
                service.AddPublisher(new Publisher { Name = "Cambridge University Press" });
                service.AddPublisher(new Publisher { Name = "Vintage" });
            }

            if (!context.Genres.Any())
            {
                Console.WriteLine("Заповнюємо таблицю Жанрів...");
                service.AddGenre(new Genre { Name = "Фентезі" });
                service.AddGenre(new Genre { Name = "Наукова фантастика" });
                service.AddGenre(new Genre { Name = "Детектив" });
                service.AddGenre(new Genre { Name = "Пригоди" });
                service.AddGenre(new Genre { Name = "Драма" });
                service.AddGenre(new Genre { Name = "Роман" });
                service.AddGenre(new Genre { Name = "Трилер" });
                service.AddGenre(new Genre { Name = "Містика" });
                service.AddGenre(new Genre { Name = "Біографія" });
                service.AddGenre(new Genre { Name = "Історія" });
            }

            if (!context.Books.Any())
            {
                Console.WriteLine("Заповнюємо таблицю Книг...");
                service.AddBook(new Book { Title = "Гаррі Поттер і філософський камінь", Pages = 320, Year = 1997, CostPrice = 150, SalePrice = 200, IsSequel = false, AuthorId = 1, PublisherId = 7, GenreId = 1 });
                service.AddBook(new Book { Title = "1984", Pages = 328, Year = 1949, CostPrice = 120, SalePrice = 170, IsSequel = false, AuthorId = 2, PublisherId = 2, GenreId = 5 });
                service.AddBook(new Book { Title = "Пригоди Тома Сойєра", Pages = 274, Year = 1876, CostPrice = 100, SalePrice = 140, IsSequel = false, AuthorId = 3, PublisherId = 8, GenreId = 4 });
                service.AddBook(new Book { Title = "Маленький принц", Pages = 96, Year = 1943, CostPrice = 90, SalePrice = 120, IsSequel = false, AuthorId = 4, PublisherId = 6, GenreId = 9 });
                service.AddBook(new Book { Title = "Старий і море", Pages = 127, Year = 1952, CostPrice = 110, SalePrice = 150, IsSequel = false, AuthorId = 5, PublisherId = 4, GenreId = 5 });
                service.AddBook(new Book { Title = "Злочин і кара", Pages = 671, Year = 1866, CostPrice = 130, SalePrice = 190, IsSequel = false, AuthorId = 6, PublisherId = 9, GenreId = 5 });
                service.AddBook(new Book { Title = "Війна і мир", Pages = 1225, Year = 1869, CostPrice = 200, SalePrice = 250, IsSequel = false, AuthorId = 7, PublisherId = 9, GenreId = 10 });
                service.AddBook(new Book { Title = "Євгеній Онєгін", Pages = 384, Year = 1833, CostPrice = 140, SalePrice = 180, IsSequel = false, AuthorId = 8, PublisherId = 10, GenreId = 6 });
                service.AddBook(new Book { Title = "Поклик предків", Pages = 231, Year = 1903, CostPrice = 100, SalePrice = 140, IsSequel = false, AuthorId = 9, PublisherId = 5, GenreId = 4 });
                service.AddBook(new Book { Title = "Сто років самотності", Pages = 417, Year = 1967, CostPrice = 160, SalePrice = 210, IsSequel = false, AuthorId = 10, PublisherId = 1, GenreId = 6 });
            }

            if (!context.Sales.Any())
            {
                Console.WriteLine("Заповнюємо таблицю Акцій...");
                service.CreateSale("Новорічні знижки", 0.10m, new List<int> { 1, 2, 3 });
                service.CreateSale("Чорна п'ятниця", 0.20m, new List<int> { 4, 5, 6 });
                service.CreateSale("Весняний розпродаж", 0.15m, new List<int> { 7, 8, 9 });
                service.CreateSale("Літні знижки", 0.12m, new List<int> { 10 });
            }

            Console.WriteLine("Дані успішно додані в базу!");
        }
    }
}


public class BookStoreContext : DbContext
{
    public DbSet<Author> Authors { get; set; }
    public DbSet<Publisher> Publishers { get; set; }
    public DbSet<Genre> Genres { get; set; }
    public DbSet<Book> Books { get; set; }
    public DbSet<Sales> Sales { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=Famle;Integrated Security=True;Connect Timeout=2;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False");
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // Book entity configuration
        modelBuilder.Entity<Book>()
            .HasKey(b => b.BookId);  // Первинний ключ

        modelBuilder.Entity<Book>()
            .Property(b => b.CostPrice);


        modelBuilder.Entity<Book>()
            .Property(b => b.SalePrice);


        modelBuilder.Entity<Book>()
            .HasOne(b => b.Author)
            .WithMany(a => a.Books)
            .HasForeignKey(b => b.AuthorId)
            .OnDelete(DeleteBehavior.Cascade);  // Каскадне видалення для автора

        modelBuilder.Entity<Book>()
            .HasOne(b => b.Publisher)
            .WithMany(p => p.Books)
            .HasForeignKey(b => b.PublisherId)
            .OnDelete(DeleteBehavior.Cascade);  // Каскадне видалення для видавництва

        modelBuilder.Entity<Book>()
            .HasOne(b => b.Genre)
            .WithMany(g => g.Books)
            .HasForeignKey(b => b.GenreId)
            .OnDelete(DeleteBehavior.Cascade);  // Каскадне видалення для жанру

        modelBuilder.Entity<Book>()
            .HasOne(b => b.PreviousBook)
            .WithMany()
            .HasForeignKey(b => b.PreviousBookId)
            .OnDelete(DeleteBehavior.NoAction);  // Уникаємо циклів і конфліктів каскаду

        modelBuilder.Entity<Book>()
            .HasOne(b => b.Sale)
            .WithMany(s => s.BooksOnSale)
            .HasForeignKey(b => b.SaleId)
            .OnDelete(DeleteBehavior.SetNull);  // Якщо акцію видаляють, поле стає NULL

        // Author entity configuration
        modelBuilder.Entity<Author>()
            .HasKey(a => a.AuthorId);  // Первинний ключ

        modelBuilder.Entity<Author>()
            .Property(a => a.FullName)
            .IsRequired();  // Поле "Ім'я автора" обов'язкове

        // Publisher entity configuration
        modelBuilder.Entity<Publisher>()
            .HasKey(p => p.PublisherId);  // Первинний ключ

        modelBuilder.Entity<Publisher>()
            .Property(p => p.Name)
            .IsRequired();  // Поле "Назва видавництва" обов'язкове

        // Genre entity configuration
        modelBuilder.Entity<Genre>()
            .HasKey(g => g.GenreId);  // Первинний ключ

        modelBuilder.Entity<Genre>()
            .Property(g => g.Name)
            .IsRequired();  // Поле "Назва жанру" обов'язкове

        // Sales entity configuration
        modelBuilder.Entity<Sales>()
            .HasKey(s => s.SaleId);  // Первинний ключ для акцій

        modelBuilder.Entity<Sales>()
            .Property(s => s.Discount)
            .HasColumnType("decimal(18,2)")  // Знижка як decimal(18,2)
            .IsRequired();  // Обов'язкове поле

   
    }

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
        public void AddBook(Book book)
        {
            _context.Books.Add(book);
            _context.SaveChanges();
        }


        public void CreateSale(string saleName, decimal discountPercentage, List<int> bookIds)
        {
            var sale = new Sales
            {
                SaleName = saleName,
                Discount = discountPercentage
            };

            _context.Sales.Add(sale);
            _context.SaveChanges();

            foreach (var bookId in bookIds)
            {
                var book = _context.Books.Find(bookId);
                if (book != null)
                {
                    book.Sale= sale;

                    book.SalePrice = book.SalePrice - (book.SalePrice * sale.Discount / 100);
                }
            }
            _context.SaveChanges();
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
        public void UpdateBook(int bookId, Book updatedBook)
        {
            var book = _context.Books.Find(bookId);
            if (book != null)
            {
                book.Title = updatedBook.Title;
                book.Pages = updatedBook.Pages;
                book.Year = updatedBook.Year;
                book.CostPrice = updatedBook.CostPrice;
                book.SalePrice = updatedBook.SalePrice;
                book.IsSequel = updatedBook.IsSequel;
                book.AuthorId = updatedBook.AuthorId;
                book.PublisherId = updatedBook.PublisherId;
                book.GenreId = updatedBook.GenreId;

                _context.SaveChanges();
            }
        }
        public List<Book> SearchBooksByTitle(string title)
        {
            return _context.Books.Where(b => b.Title.Contains(title)).ToList();
        }
        public List<Book> SearchBooksByAuthor(string authorName)
        {
            return _context.Books.Where(b => b.Author.FullName.Contains(authorName)).ToList();
        }
        public List<Book> SearchBooksByGenre(string genreName)
        {
            return _context.Books.Where(b => b.Genre.Name.Contains(genreName)).ToList();
        }
        public void ReserveBook(int bookId, int customerId)
        {
            var book = _context.Books.Find(bookId);
            if (book != null && book.ReservedCustomerId == null)
            {
                book.ReservedCustomerId = customerId;
                _context.SaveChanges();
            }
        }
        public void WriteOffBook(int bookId)
        {
            var book = _context.Books.Find(bookId);
            if (book != null)
            {
                book.IsWrittenOff = true;
                _context.SaveChanges();
            }
        }
        public void SellBook(int bookId)
        {
            var book = _context.Books.Find(bookId);
            if (book != null)
            {
                book.IsSold = true;
                _context.SaveChanges();
            }
        }
        public List<Book> GetNewBooks()
        {
            return _context.Books.OrderByDescending(b => b.Year).Take(10).ToList();
        }
        public List<Book> GetTopBooks()
        {
            return _context.Books.OrderByDescending(b => b.SalesCount).Take(10).ToList();
        }

     
        public List<Author> GetTopAuthors()
        {
            return _context.Authors.OrderByDescending(a => a.Books.Count).Take(10).ToList();
        }

       
        public List<Genre> GetTopGenres()
        {
            return _context.Genres.OrderByDescending(g => g.Books.Count).Take(10).ToList();
        }
    }

}
