using AutoMapper;
using Microsoft.AspNetCore.Identity;
using ProfileProject.Models.Domain;
using ProfileProject.Models.DTO;
using ProfileProject.Repository.Abstract;
using System.Security.Claims;

namespace ProfileProject.Repository.Implementation;

public class UserAuthenticationService : IUserAuthenticationService
{
    private readonly SignInManager<ApplicationUser> signInManager;
    private readonly UserManager<ApplicationUser> userManager;
    private readonly RoleManager<IdentityRole> roleManager;
    private readonly IMapper _mapper;


    public UserAuthenticationService(SignInManager<ApplicationUser> signInManager,
                                     UserManager<ApplicationUser> userManager,
                                     RoleManager<IdentityRole> roleManager,
                                     IMapper mapper)
    {
        this.signInManager = signInManager;
        this.userManager = userManager;
        this.roleManager = roleManager;
        _mapper = mapper;
    }

    

    public async Task<Status> LoginAsync(LogInModel model)
    {

        var status = new Status();
        var user = await userManager.FindByNameAsync(model.UserName);
        if (user == null)
        {
            status.StatusCode = 0;
            status.Message = "Invalid username";
            return status;
        }
        //we will match password 
        if(!await userManager.CheckPasswordAsync(user, model.Password))
        {
            status.StatusCode = 0;
            status.Message = "Invalid password";
            return status;
        }
        var signResult = await signInManager.PasswordSignInAsync(user, model.Password,
                                                                 false,
                                                                 true);

        if (signResult.Succeeded)
        {
            var userRole=await userManager.GetRolesAsync(user);
            var authClaims = new List<Claim>
            {
                new Claim(ClaimTypes.Name,user.UserName)
            };
            foreach(var userRoles in userRole)
            {
                authClaims.Add(new Claim(ClaimTypes.Role,userRoles));
            }
            status.StatusCode = 1;
            status.Message = "Logged in successfully";
            return status;
        }
        else if(signResult.IsLockedOut)
        {
            status.StatusCode = 0;
            status.Message = "User locked out";
            return status;
        }
        else
        {
            status.StatusCode = 0;
            status.Message = "Error on login ";
            return status;
        }
    }

    public async Task LogoutAsync()
    {
        await signInManager.SignOutAsync(); 
    }

    public async Task<Status> RegtirationAsync(RegistrationModel model)
    {
        var status=new Status();
        var userExists = await userManager.FindByNameAsync(model.UserName);
            if(userExists!=null)
        {
            status.StatusCode = 0;
            status.Message = "User alredy exists";
            return status;
        }

        ApplicationUser user = new ApplicationUser()
        {
            SecurityStamp=Guid.NewGuid().ToString(),
            Name = model.Name,
            Email = model.Email,
            UserName=model.UserName,
            PhoneNumber=model.PhoneNumber,
            EmailConfirmed=true,
        };
        var result =await userManager.CreateAsync(user,model.Password);
        if(!result.Succeeded)
        {
            status.StatusCode = 0;
            status.Message = "User creation faild";
            return status;
        }
        //role Management
        if (!await roleManager.RoleExistsAsync(model.Role))
            await roleManager.CreateAsync(new IdentityRole());

        if(await roleManager.RoleExistsAsync(model.Role))
        {
            await userManager.AddToRoleAsync(user, model.Role);
        }

        status.StatusCode = 1;
        status.Message = "User has registerd successfully";
        return status;


    }



    public async Task<Status> ChangePasswordAsync(ChangePasswordModel model, string username)
    {
        var status = new Status();

        var user = await userManager.FindByNameAsync(username);
        if (user == null)
        {
            status.Message = "User does not exist";
            status.StatusCode = 0;
            return status;
        }
        var result = await userManager.ChangePasswordAsync(user, model.CurrentPassword, model.NewPassword);
        if (result.Succeeded)
        {
            status.Message = "Password has updated successfully";
            status.StatusCode = 1;
        }
        else
        {
            status.Message = "Some error occcured";
            status.StatusCode = 0;
        }
        return status;
    }
}
