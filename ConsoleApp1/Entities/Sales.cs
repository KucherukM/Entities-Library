﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

public class Sales
{
    [Key]
    public int SaleId { get; set; }
    public string Name { get; set; }  // Ця властивість має бути тут
    public decimal DiscountPercentage { get; set; }  // І ця
    public List<Book> BooksOnSale { get; set; } = new List<Book>();
}
