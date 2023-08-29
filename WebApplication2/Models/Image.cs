using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplication2.Models
{
    public class Image
    {
        [Key]
        public int id { get; set; }
        public Byte[] image  { get; set; }
        public string ContentType { get; set; }
        public bool ToDelete {get ; set; }
        [ForeignKey("News")]
        public int NewsId { get; set; }

        public News News { get; set; }
    }
}
