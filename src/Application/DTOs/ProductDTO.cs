using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Application.DTOs
{
    public class ProductDTO
    {
        public Guid id { get; set; }

        [Required(ErrorMessage = "The Name is Required")]
        [DisplayName("Name")]
        [MinLength(3)]
        [MaxLength(100)]
        public string name { get; set; }

        [Required(ErrorMessage = "The Description is Required")]
        [DisplayName("Description")]
        [MinLength(5)]
        [MaxLength(100)]
        public string description { get; set; }

        [Required(ErrorMessage = "The Price is Required")]
        [Column(TypeName = "decimal(18,2)")]
        [DataType(DataType.Currency)]
        [DisplayName("Price")]
        public decimal price { get; set; }

        [Required(ErrorMessage = "The Stock is Required")]
        [Range(1, 9999)]
        [DisplayName("Stock")]
        public int stock { get; set; }

        [MaxLength(250)]
        [DisplayName("Product Image")]
        public string image { get; set; }

        public bool is_active { get; set; }

        [JsonIgnore]
        public CategoryDTO? category { get; set; }

        [DisplayName("Categories")]
        [Required(ErrorMessage = "The category is required")]
        public Guid category_id { get; set; }

        public DateTime created_at { get; set; }

        public DateTime updated_at { get; set; }
    }
}