using Microsoft.EntityFrameworkCore;
using TurfBooking.Models;
namespace TurfBooking.Services
{
    public class UserService : IUserService
    {
        private readonly TurfBookingContext _context;

        public UserService(TurfBookingContext context)
        {
            _context = context;
        }

        public IEnumerable<User> GetUsers()
        {
            return _context.Users.ToList();
        }

        public User GetUser(int id)
        {
            return _context.Users.Find(id);
        }

        public void AddUser(User user)
        {
            var newuser = new User
            {
                // Set other properties but do not set Id
                Name = user.Name,
                Email = user.Email,
                Password = user.Password
            };

            _context.Users.Add(newuser);
            _context.SaveChanges();
        }

        public void UpdateUser(User user)
        {
            var updateuser = new User
            {
                // Set other properties but do not set Id
                Name = user.Name,
                Email = user.Email,
                Password = user.Password
            };
            _context.Entry(user).State = EntityState.Modified;
            //_context.Users.Update(updateuser);
            _context.SaveChanges();
        }

        public void DeleteUser(int id)
        {
            var user = _context.Users.Find(id);
            if (user != null)
            {
                _context.Users.Remove(user);
                _context.SaveChanges();
            }
        }
    }
}
