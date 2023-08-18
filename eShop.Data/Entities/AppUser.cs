using Microsoft.AspNetCore.Identity;

namespace eShop.Data.Entities
{
    public class AppUser: IdentityUser<Guid>
    {
        public string FirtName { get; set; } 
        public string LastName { get; set; } 
        public DateTime Dob { get; set; } 
    }
}
