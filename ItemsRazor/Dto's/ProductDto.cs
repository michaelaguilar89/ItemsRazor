using System.ComponentModel.DataAnnotations;

namespace ItemsRazor.Dto_s
{
    public class ProductDto
    {
        public int Id { get; set; }
        [Required, MaxLength(20)]
        public string Name { get; set; }
        [Required, MaxLength(100)]
        public string Description { get; set; }
        [Required]
        public int Price { get; set; }
        [Required]
        public int Quantity { get; set; }
        [Required]
        public int UpdateQuantity { get; set; }
        [Required]
        public string Comments { get; set; }
        [Required]
        public DateTime CreationDate { get; set; }
    }
}

