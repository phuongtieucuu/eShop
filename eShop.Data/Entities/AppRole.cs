using Microsoft.AspNetCore.Identity;

namespace eShop.Data.Entities
{
    public class AppRole : IdentityRole<Guid>
    {
        public string Desc { get; set; }
    }
}
