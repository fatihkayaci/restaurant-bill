using System.ComponentModel.DataAnnotations;

namespace RestaurantBill.Domain.Entities
{
    public class Table
    {
        public int Id { get; set; }
        
        [Required]
        public string TableName { get; set; } // "Bahçe 1", "Teras 3"
        
        public bool IsOccupied { get; set; } = false; // Masa dolu mu?
        
        // O an masada aktif bir sipariş varsa ID'si burada durur
        public int? CurrentOrderId { get; set; }
    }
}