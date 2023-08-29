using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplication2.Models
{
	public class UserRead
	{
        [ForeignKey("UserModel")]
        public string UserId { get; set; }
		public UserModel User { get; set; }

        [ForeignKey("News")]
        public int NewsId { get; set; }
		public News News { get; set; }
	}
}
