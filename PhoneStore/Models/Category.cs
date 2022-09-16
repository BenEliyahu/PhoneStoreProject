using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PhoneStore.Models
{
    [Table("Categories")]
    public class Category
    {
        [Key, Column(Order = 1)]
        public int? CategoryId { get; set; }
        [DisplayName("Category Name")]
        public string? Name { get; set; }
        public ICollection<Phone>?Phones { get; set; }
    }
}
