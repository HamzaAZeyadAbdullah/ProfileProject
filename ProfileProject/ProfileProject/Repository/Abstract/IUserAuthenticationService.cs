using ProfileProject.Models.DTO;

namespace ProfileProject.Repository.Abstract;

public interface IUserAuthenticationService
{
    Task<Status> LoginAsync(LogInModel model);
    Task<Status> RegtirationAsync(RegistrationModel model);
    Task LogoutAsync();
    Task<Status> ChangePasswordAsync(ChangePasswordModel model, string username);
}
