using System.Collections.Generic;
using API.UserModel;

namespace API.Business.IService
{
    public interface IUserService
    {
        public void add(User user);
        public IEnumerable<User> GetAll();
       public  User Find(string key);
        public void Remove(string Id);
        

        public string test();
    }
}