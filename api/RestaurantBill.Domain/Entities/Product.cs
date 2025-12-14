using System.ComponentModel.DataAnnotations;

namespace RestaurantBill.Domain.Entities
{
    public class Product
    {
        public int Id { get; set; }
        
        [Required]
        [MaxLength(100)]
        public string Name { get; set; }
        
        public string? Description { get; set; }
        
        public decimal Price { get; set; } // Para birimi için her zaman decimal!
        
        public bool IsAvailable { get; set; } = true; // Stok var mı?

        // İlişkiler (Foreign Key)
        public int CategoryId { get; set; }
        public Category Category { get; set; }
    }
}