using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplication2.Models
{
    public class UserModel : IdentityUser
    {
		public List<UserRead> ReadNews { get; set; } = new List<UserRead>();
		public bool IsAdmin { get; set; }

		
	}
}
