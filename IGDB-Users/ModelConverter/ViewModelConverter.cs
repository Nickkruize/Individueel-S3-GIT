using DAL.ContextModel;
using IGDB_Users.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IGDB_Users.ModelConverter
{
    public static class ViewModelConverter
    {
        public static User RegistrationModelToUser(RegistrationModel model)
        {
            User user = new User
            {
                Username = model.Username,
                Password = model.Password,
                Email = model.Email
            };

            return user;
        }

        public static UserResponseModel UserDTOTOUserResponseModel(User user)
        {
            UserResponseModel model = new UserResponseModel
            {
                Username = user.Username,
                Email = user.Email,
                Id = user.Id,
                RoleID = (int)user.Role
            };

            return model;
        }
    }
}
