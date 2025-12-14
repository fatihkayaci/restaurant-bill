namespace RestaurantBill.Domain.Enums
{
    public enum OrderItemStatus
    {
        Queued = 1,        // Sırada
        SentToKitchen = 2, // Mutfağa iletildi
        Cooking = 3,       // Hazırlanıyor
        Ready = 4,         // Hazır
        Served = 5         // Masaya kondu
    }
}