using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

public class Sales
{

    public int SaleId { get; set; }


    public string SaleName { get; set; }


    public decimal Discount { get; set; }

    public ICollection<Book> BooksOnSale { get; set; }
}
