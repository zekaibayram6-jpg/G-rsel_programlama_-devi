using System;

namespace PorscheDealership
{
    public class User
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string FullName { get; set; }
        public bool IsAdmin { get; set; }
    }

    public class Car
    {
        public int Id { get; set; }
        public string Model { get; set; }
        public int Year { get; set; }
        public decimal Price { get; set; }
        public decimal OTV { get; set; }
        public decimal KDV { get; set; }
        public int Stock { get; set; }
        public string ImagePath { get; set; }

        // Fiyat = Liste Fiyatı + ÖTV + KDV
        // Önce ÖTV eklenir, ardından ÖTV'li fiyat üzerinden KDV eklenir (Türkiye vergi sistemi)
        public decimal CalculateTotalPrice()
        {
            decimal priceWithOtv = Price + (Price * OTV);
            decimal finalPrice = priceWithOtv + (priceWithOtv * KDV);
            return finalPrice;
        }
    }

    public class Order
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int CarId { get; set; }
        public decimal TotalPrice { get; set; }
        public DateTime OrderDate { get; set; }
        public string Status { get; set; }
        
        // Navigation properties (for display)
        public string CarModel { get; set; }
    }
}
