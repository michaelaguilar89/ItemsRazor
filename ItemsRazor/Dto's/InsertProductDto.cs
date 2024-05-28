using System.ComponentModel.DataAnnotations;

namespace ItemsRazor.Dto_s
{
    public class InsertProductDto
    {
  
        [Required, MaxLength(20)]
        public string Name { get; set; }
        [Required, MaxLength(100)]
        public string Description { get; set; }
        [Required]
        public int Price { get; set; }
        [Required]
        public int Quantity { get; set; }
        
    
    }
}
