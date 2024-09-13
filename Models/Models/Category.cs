using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace Models.Models
{
    public class Category
    {
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage = "Please enter the category name.")]
        [DisplayName("Category Name")]
        [MaxLength(30, ErrorMessage = "The category name cannot be greater than 30.")]
        public string Name { get; set; }
        [Required]
        [DisplayName("Display Order")]
        [Range(1, 100, ErrorMessage = "The display order should lie between 1 - 100, both inclusive.")]
        public int DisplayOrder { get; set; }
    }
}