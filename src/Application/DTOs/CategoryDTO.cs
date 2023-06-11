using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Application.DTOs
{
    public class CategoryDTO
    {
        public Guid id { get; set; }

        [Required(ErrorMessage = "The Name is Required")]
        [DisplayName("Name")]
        [MinLength(3)]
        [MaxLength(100)]
        public string name {get; set; }

        public bool is_active {get; set; }

        public DateTime created_at { get; set; }

        public DateTime updated_at { get; set; }
    }
}