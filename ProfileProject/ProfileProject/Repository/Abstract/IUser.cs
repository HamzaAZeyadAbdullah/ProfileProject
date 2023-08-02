using ProfileProject.Models.Domain;
using ProfileProject.Models.DTO;

namespace ProfileProject.Repository.Abstract
{
    public interface IUser
    {
        IList<RegistrationModel> Information();
        void Update(string id, ApplicationUser newUser);
    }
}
