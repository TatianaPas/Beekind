using Microsoft.AspNetCore.Identity;

namespace BeekindSolution.Models
{
    public class User: IdentityUser
    {
        public string? Name { get; set; }
        public string? Phone { get; set; }
    }
}
