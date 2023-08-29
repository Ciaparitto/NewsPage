using System.ComponentModel.DataAnnotations;
using System.Data;

namespace WebApplication2.Models
{
    public class News
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string? Title { get; set; }
        [Required]
        public string? Content { get; set; }
        [Required]
        public string? Category { get; set; }
        //public List<int>? IdImageRemove { get; set; }
        [Required]
        public DateTime createdate { get; set; } = DateTime.Now;

        public List<Comment> Comments { get; set; }

        public  List<Image>? Images { get; set; }

        
        public string? newCommentText { get; set; }

		
	}
}
