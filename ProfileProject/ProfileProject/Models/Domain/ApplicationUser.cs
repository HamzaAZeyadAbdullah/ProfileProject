using Microsoft.AspNetCore.Identity;

namespace ProfileProject.Models.Domain;

public class ApplicationUser:IdentityUser
{
    public string Name { get; set; }
    public int PhoneNumber  { get; set; }

}
