using API.Business.IService;
using System.Collections.Generic;
using System.Linq;
using API.UserModel;

namespace API.Business.Service
{
    public class UserService : IUserService
    {
        static List<User> UsersList = new List<User>();
        
        public string test(){
            return "Hello";
        }

        public void add(User user)
        {
            UsersList.Add(user);
        }

        public User Find(string key)
        {
             return UsersList
                .Where(e => e.username.Equals(key))
                .SingleOrDefault();
        }

        public IEnumerable<User> GetAll()
        {
            return UsersList;
        }

        public void Remove(string Id)
        {
             var userToRemove = UsersList.SingleOrDefault(r => r.username == Id);
            if (userToRemove != null)
                UsersList.Remove(userToRemove);   
        }

       

    }
}