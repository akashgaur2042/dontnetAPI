using API.Business.IService;
using System.Collections.Generic;
using System.Linq;
using API.UserModel;
using API.DataContext;

namespace API.Business.Service
{
    public class UserService : IUserService
    {
        static List<User> UsersList = new List<User>();
         private readonly EmpManagementContext _empManagementContext;
        
        public UserService (EmpManagementContext empManagementContext){
            this._empManagementContext = empManagementContext;
        }

        public void add(User user)
        {
            UsersList.Add(user);
        }
        public void userLogin()
        {
                User user=new User();
               
                this.add(user);

        }

        public User Find(string key)
        {
             return this._empManagementContext
                .User
                .Where(e => e.username.Equals(key))
                .FirstOrDefault();
        }

        public IEnumerable<User> GetAll()
        {
             IEnumerable<User> users = this._empManagementContext.User.AsEnumerable();
             return users;
        }

        public void Remove(string Id)
        {
             var userToRemove =this._empManagementContext.User.SingleOrDefault(r => r.username == Id);
            if (userToRemove != null)
                UsersList.Remove(userToRemove);   
        }

       

    }
}