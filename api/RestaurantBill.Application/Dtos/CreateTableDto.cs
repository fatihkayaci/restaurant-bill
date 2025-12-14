using System.ComponentModel.DataAnnotations;

namespace RestaurantBill.Application.DTOs
{
    public class CreateTableDto
    {
        [Required]
        public string TableName { get; set; }
    }
}