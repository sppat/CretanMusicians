using Microsoft.AspNetCore.Identity;

namespace CretanMusicians.API.Data
{
    public class ApiUser : IdentityUser
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Role { get; set; }
    }
}
