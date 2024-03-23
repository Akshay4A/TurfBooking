using System.Collections.Generic;
using TurfBooking.Models;

namespace TurfBooking.Services
{
    public interface IUserService
    {
        IEnumerable<User> GetUsers();
        User GetUser(int id);
        void AddUser(User user);
        void UpdateUser(User user);
        void DeleteUser(int id);
    }
}
