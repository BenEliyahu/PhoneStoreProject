using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PhoneStore.Models
{
    [Table("Comments")]
    public class Comment
    {
        [Key, Column(Order = 1)]
        public int CommentId { get; set; }
        [Required(ErrorMessage = "Please enter a comment.")]
        public string? CommentText { get; set; }
        [ForeignKey("Phones")]
        public int PhoneId { get; set; }
    }
}
