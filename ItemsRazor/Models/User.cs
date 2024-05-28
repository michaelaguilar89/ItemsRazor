using Microsoft.AspNetCore.Identity;

namespace ItemsRazor.Models
{
    public class User:IdentityUser
    {
        public DateTime RegisterDate { get; set; } 
    }
}
