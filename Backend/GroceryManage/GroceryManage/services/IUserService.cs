using GroceryManage.models;
using GroceryManage.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GroceryManage.services
{
    public interface IUserService
    {
        List<UserModel> GetUserList();

        UserModel GetUserDetailsById(int userId);

        Response SaveUser(UserModel userModel);

        Response DeleteEmployee(int userId);

    }
}
