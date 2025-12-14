using System.ComponentModel.DataAnnotations;
using RestaurantBill.Domain.Enums;

namespace RestaurantBill.Domain.Entities
{
    public class User
    {
        public int Id { get; set; }
        
        [Required]
        [MaxLength(50)]
        public string UserName { get; set; }
        
        [Required]
        public string PasswordHash { get; set; }
        
        public UserRole Role { get; set; }
    }
}