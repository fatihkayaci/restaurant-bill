using System.ComponentModel.DataAnnotations;
using RestaurantBill.Domain.Enums;

namespace RestaurantBill.Domain.Entities
{
    public class OrderItem
    {
        public int Id { get; set; }
        
        public int OrderId { get; set; }
        public Order Order { get; set; }
        
        public int ProductId { get; set; }
        public Product Product { get; set; }
        
        public string ProductName { get; set; } // Ürün adı değişirse tarihçede kalsın diye
        public int Quantity { get; set; } // Adet
        public decimal UnitPrice { get; set; } // O anki fiyat
        
        [MaxLength(200)]
        public string? Note { get; set; } // "Soğansız olsun"
        
        public OrderItemStatus Status { get; set; } = OrderItemStatus.Queued;
    }
}