using System.ComponentModel.DataAnnotations;

namespace SmartWatchesAPI.Models
{
    public class Category
    {
        public int Id { get; set; }

        [Required]
        [StringLength(100)]
        public string Name { get; set; } = string.Empty;

        [StringLength(500)]
        public string? Description { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.Now;

        public bool IsActive { get; set; } = true;

        // Relación uno a muchos
        public virtual ICollection<Product> Products { get; set; } = new List<Product>();
    }
}