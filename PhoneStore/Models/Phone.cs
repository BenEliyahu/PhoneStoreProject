using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PhoneStore.Models
{
    [Table("Phones")]
    public class Phone
    {
        [Key, Column(Order = 1)]
        [DisplayName("Phone ID")]
        public int PhoneId { get; set; }
        [Required(ErrorMessage = "Please enter a name.")]
        [StringLength(50)]
        public string? Name { get; set; }
        [Required(ErrorMessage = "Please enter series.")]
        public int Series { get; set; }
        public string? Picture { get; set; }
        [Required(ErrorMessage = "Please enter a description.")]
        public string? Description { get; set; }
        [ForeignKey("Categories")]
        public int CategoryId { get; set; }
        public Category? Categories { get; set; }
        public ICollection<Comment>?Comments { get; set; }
    }
}
