public class Book
{
 
        public int BookId { get; set; }
        public string Title { get; set; }
        public int Pages { get; set; }
        public int Year { get; set; }
        public decimal CostPrice { get; set; }
        public decimal SalePrice { get; set; }
        public bool IsSequel { get; set; }
        public int? PreviousBookId { get; set; }
        public int AuthorId { get; set; }
        public int PublisherId { get; set; }
        public int GenreId { get; set; }
    public int SalesCount { get; set; } // Додаємо цю властивість
    public List<Sales> Sales { get; set; } = new List<Sales>();  // Додаємо цю властивість
    


    // Navigation properties
    public Author Author { get; set; }
    public Publisher Publisher { get; set; }
    public Genre Genre { get; set; }
    public Book PreviousBook { get; set; }
}