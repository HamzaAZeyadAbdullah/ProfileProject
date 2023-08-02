using Microsoft.AspNetCore.Mvc.ApplicationModels;
using ProfileProject.Models.Domain;
using ProfileProject.Models.DTO;
using ProfileProject.Repository.Abstract;
using static System.Reflection.Metadata.BlobBuilder;

namespace ProfileProject.Repository.Implementation
{
    public class User:IUser
    {
        public User()
        {

        }
        List<RegistrationModel> listMode;
        List<ApplicationUser> listModeApp;

        public IList<RegistrationModel> Information()
        {
            return listMode;
        }


        public ApplicationUser Find(string id)
        {
            id=Guid.NewGuid().ToString();
            var user = listModeApp.SingleOrDefault(b => b.Id == id);
            return user!;
        }



       

      

        public void Update(string id, ApplicationUser newUser)
        {
            var user = Find(id);
            user.Name = newUser.Name;
            user.UserName = newUser.UserName;
            user.PhoneNumber = newUser.PhoneNumber;
            user.Email = newUser.Email;
        }

       
    }
}
