using System.ComponentModel.DataAnnotations;

namespace SumITCompOnline.Entities
{
    public class Product
    {
        [Key]
        public long Id { get; set; }

        [Required]
        [StringLength(50)]
        public string Title { get; set; }

        [StringLength(100)]
        public string Description { get; set; }

         [Required]
        public decimal? Price { get; set; }

         public long Quantity { get; set; }
    }
}