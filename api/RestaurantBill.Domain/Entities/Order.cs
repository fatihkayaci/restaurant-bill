using RestaurantBill.Domain.Enums;

namespace RestaurantBill.Domain.Entities
{
    public class Order
    {
        public int Id { get; set; }
        public int TableId { get; set; }
        public Table Table { get; set; } // Hangi masa?
        
        public decimal TotalAmount { get; set; } = 0;
        
        public OrderStatus Status { get; set; } = OrderStatus.Active;
        
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public DateTime? ClosedAt { get; set; }

        // Bir adisyonda birden çok kalem (Hamburger, Kola vs.) olur
        public List<OrderItem> Items { get; set; } = new List<OrderItem>();
    }
}