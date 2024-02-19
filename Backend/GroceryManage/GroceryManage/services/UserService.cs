using GroceryManage.DataAccess;
using GroceryManage.models;
using GroceryManage.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GroceryManage.services
{
    public class UserService : IUserService
    {
        private GroceryDbContext _context;
        public Response DeleteEmployee(int userId)
        {
            Response model = new Response();
            try
            {
                UserModel _temp = GetUserDetailsById(userId);
                if (_temp != null)
                {
                    _context.Remove<UserModel>(_temp);
                    _context.SaveChanges();
                    model.IsSuccess = true;
                    model.Messsage = "User Deleted Successfully";
                }
                else
                {
                    model.IsSuccess = false;
                    model.Messsage = "Employee Not Found";
                }
            }
            catch (Exception ex)
            {
                model.IsSuccess = false;
                model.Messsage = "Error : " + ex.Message;
            }
            return model;
        }

        public UserModel GetUserDetailsById(int userId)
        {
            UserModel usr;
            try
            {
                usr = _context.Find<UserModel>(userId);
            }
            catch (Exception)
            {
                throw;
            }
            return usr;
        }

        public List<UserModel> GetUserList()
        {
            List<UserModel> userList;
            try
            {
                userList = _context.Set<UserModel>().ToList();
            }
            catch (Exception)
            {
                throw;
            }
            return userList;
        }

        public Response SaveUser(UserModel userModel)
        {
            Response model = new Response();
            try
            {
                UserModel _temp = GetUserDetailsById(userModel.UserId);
                if (_temp != null)
                {
                    
                    _temp.UserName = userModel.UserName;
                    _temp.UserMail = userModel.UserMail;
                    _temp.Password = userModel.Password;
                    _context.Update<UserModel>(_temp);
                    model.Messsage = "User details Update Successfully";
                }
                else
                {
                    _context.Add<UserModel>(userModel);
                    model.Messsage = "User Inserted Successfully";
                }
                _context.SaveChanges();
                model.IsSuccess = true;
            }
            catch (Exception ex)
            {
                model.IsSuccess = false;
                model.Messsage = "Error : " + ex.Message;
            }
            return model;
        }
    }
}

