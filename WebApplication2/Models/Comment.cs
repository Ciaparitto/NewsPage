using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplication2.Models
{
    public class Comment
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string CommentText { get; set; }
        [Required]
        public string creator { get; set; }

        [ForeignKey("News")]
        public int NewsId { get; set; }
        public News News { get; set; }

    }
}
