using System;
using System.Collections.Generic;
using System.Linq;

class Program
{
    static void Main(string[] args)
    {
        var context = new BookStoreContext();
        var bookStoreService = new BookStoreService(context);

        while (true)
        {
            Console.WriteLine("Меню:");
            Console.WriteLine("1. Додати автора");
            Console.WriteLine("2. Додати видавництво");
            Console.WriteLine("3. Додати жанр");
            Console.WriteLine("4. Додати книгу");
            Console.WriteLine("5. Оновити книгу");
            Console.WriteLine("6. Видалити книгу");
            Console.WriteLine("7. Пошук книг за назвою");
            Console.WriteLine("8. Пошук книг за автором");
            Console.WriteLine("9. Пошук книг за жанром");
            Console.WriteLine("10. Продати книгу");
            Console.WriteLine("11. Списати книгу");
            Console.WriteLine("12. Відкласти книгу для покупця");
            Console.WriteLine("13. Отримати новинки");
            Console.WriteLine("14. Отримати топ-продажі");
            Console.WriteLine("15. Вийти");

            var choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    Console.Write("Введіть ім'я автора: ");
                    var authorName = Console.ReadLine();
                    bookStoreService.AddAuthor(new Author { FullName = authorName });
                    Console.WriteLine("Автор додано.");
                    break;

                case "2":
                    Console.Write("Введіть назву видавництва: ");
                    var publisherName = Console.ReadLine();
                    bookStoreService.AddPublisher(new Publisher { Name = publisherName });
                    Console.WriteLine("Видавництво додано.");
                    break;

                case "3":
                    Console.Write("Введіть назву жанру: ");
                    var genreName = Console.ReadLine();
                    bookStoreService.AddGenre(new Genre { Name = genreName });
                    Console.WriteLine("Жанр додано.");
                    break;

                case "4":
                    Console.Write("Введіть назву книги: ");
                    var bookTitle = Console.ReadLine();
                    Console.Write("Введіть кількість сторінок: ");
                    var pages = int.Parse(Console.ReadLine());
                    Console.Write("Введіть рік видання: ");
                    var year = int.Parse(Console.ReadLine());
                    Console.Write("Введіть ціну закупки: ");
                    var costPrice = decimal.Parse(Console.ReadLine());
                    Console.Write("Введіть ціну продажу: ");
                    var salePrice = decimal.Parse(Console.ReadLine());
                    Console.Write("Введіть ID автора: ");
                    var authorId = int.Parse(Console.ReadLine());
                    Console.Write("Введіть ID видавництва: ");
                    var publisherId = int.Parse(Console.ReadLine());
                    Console.Write("Введіть ID жанру: ");
                    var genreId = int.Parse(Console.ReadLine());

                    var newBook = new Book
                    {
                        Title = bookTitle,
                        Pages = pages,
                        Year = year,
                        CostPrice = costPrice,
                        SalePrice = salePrice,
                        AuthorId = authorId,
                        PublisherId = publisherId,
                        GenreId = genreId,
                        IsSequel = false,
                        SalesCount = 0
                    };

                    bookStoreService.AddBook(newBook);
                    Console.WriteLine("Книга додана.");
                    break;

                case "5":
                    Console.Write("Введіть ID книги для редагування: ");
                    var bookIdToEdit = int.Parse(Console.ReadLine());
                    Console.Write("Введіть нову назву книги: ");
                    var updatedBookTitle = Console.ReadLine();
                    Console.Write("Введіть нову кількість сторінок: ");
                    var updatedPages = int.Parse(Console.ReadLine());
                    Console.Write("Введіть новий рік видання: ");
                    var updatedYear = int.Parse(Console.ReadLine());
                    Console.Write("Введіть нову ціну закупки: ");
                    var updatedCostPrice = decimal.Parse(Console.ReadLine());
                    Console.Write("Введіть нову ціну продажу: ");
                    var updatedSalePrice = decimal.Parse(Console.ReadLine());
                    Console.Write("Введіть новий ID автора: ");
                    var updatedAuthorId = int.Parse(Console.ReadLine());
                    Console.Write("Введіть новий ID видавництва: ");
                    var updatedPublisherId = int.Parse(Console.ReadLine());
                    Console.Write("Введіть новий ID жанру: ");
                    var updatedGenreId = int.Parse(Console.ReadLine());

                    var updatedBook = new Book
                    {
                        Title = updatedBookTitle,
                        Pages = updatedPages,
                        Year = updatedYear,
                        CostPrice = updatedCostPrice,
                        SalePrice = updatedSalePrice,
                        AuthorId = updatedAuthorId,
                        PublisherId = updatedPublisherId,
                        GenreId = updatedGenreId,
                        IsSequel = false,
                        
                        SalesCount = 0
                    };

                    bookStoreService.EditBook(bookIdToEdit, updatedBook);
                    Console.WriteLine("Книга оновлена.");
                    break;

                case "6":
                    Console.Write("Введіть ID книги для видалення: ");
                    var bookIdToDelete = int.Parse(Console.ReadLine());
                    bookStoreService.DeleteBook(bookIdToDelete);
                    Console.WriteLine("Книга видалена.");
                    break;

                case "7":
                    Console.Write("Введіть назву для пошуку: ");
                    var titleToSearch = Console.ReadLine();
                    var foundBooksByTitle = bookStoreService.SearchBooksByTitle(titleToSearch);
                    Console.WriteLine("Книги з назвою:");
                    foreach (var book in foundBooksByTitle)
                    {
                        Console.WriteLine($"- {book.Title}");
                    }
                    break;

                case "8":
                    Console.Write("Введіть ім'я автора для пошуку: ");
                    var authorNameToSearch = Console.ReadLine();
                    var foundBooksByAuthor = bookStoreService.SearchBooksByAuthor(authorNameToSearch);
                    Console.WriteLine("Книги автора:");
                    foreach (var book in foundBooksByAuthor)
                    {
                        Console.WriteLine($"- {book.Title}");
                    }
                    break;

                case "9":
                    Console.Write("Введіть назву жанру для пошуку: ");
                    var genreNameToSearch = Console.ReadLine();
                    var foundBooksByGenre = bookStoreService.SearchBooksByGenre(genreNameToSearch);
                    Console.WriteLine("Книги жанру:");
                    foreach (var book in foundBooksByGenre)
                    {
                        Console.WriteLine($"- {book.Title}");
                    }
                    break;

                case "10":
                    Console.Write("Введіть ID книги для продажу: ");
                    var bookIdToSell = int.Parse(Console.ReadLine());
                    bookStoreService.SellBook(bookIdToSell);
                    Console.WriteLine("Книга продана.");
                    break;

                case "11":
                    Console.Write("Введіть ID книги для списання: ");
                    var bookIdToWriteOff = int.Parse(Console.ReadLine());
                    bookStoreService.WriteOffBook(bookIdToWriteOff);
                    Console.WriteLine("Книга списана.");
                    break;

                case "12":
                    Console.Write("Введіть ID книги для відкладення: ");
                    var bookIdToHold = int.Parse(Console.ReadLine());
                    bookStoreService.HoldBookForCustomer(bookIdToHold);
                    break;

                case "13":
                    var newArrivals = bookStoreService.GetNewArrivals();
                    Console.WriteLine("Новинки:");
                    foreach (var book in newArrivals)
                    {
                        Console.WriteLine($"- {book.Title}");
                    }
                    break;

                case "14":
                    var topSellingBooks = bookStoreService.GetTopSellingBooks();
                    Console.WriteLine("Топ-продажі:");
                    foreach (var book in topSellingBooks)
                    {
                        Console.WriteLine($"- {book.Title}");
                    }
                    break;

                case "15":
                    return;

                default:
                    Console.WriteLine("Невірний вибір. Спробуйте ще раз.");
                    break;
            }
        }
    }
}
