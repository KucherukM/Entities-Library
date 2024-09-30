public class Book
{
    public int BookId { get; set; }
    public string Title { get; set; }
    public int Pages { get; set; }
    public int Year { get; set; }
    public decimal CostPrice { get; set; }
    public decimal SalePrice { get; set; }
    public bool IsSequel { get; set; }
    public int? PreviousBookId { get; set; }  // Nullable
    public int AuthorId { get; set; }
    public int PublisherId { get; set; }
    public int GenreId { get; set; }
    public int? SaleId { get; set; }  // Зробіть це поле Nullable
    public int? ReservedCustomerId { get; set; }  // Nullable
    public bool IsWrittenOff { get; set; }
    public bool IsSold { get; set; }
    public int SalesCount { get; set; }

    public Author Author { get; set; }
    public Publisher Publisher { get; set; }
    public Genre Genre { get; set; }
    public Book PreviousBook { get; set; }
    public Sales Sale { get; set; }
}