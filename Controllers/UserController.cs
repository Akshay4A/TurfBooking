using Microsoft.AspNetCore.Mvc;
using TurfBooking.Models;
using TurfBooking.Services;

namespace TurfBooking.Controllers
{
    
        [Route("api/[controller]")]
        [ApiController]
        public class UserController : ControllerBase
        {
            // Assuming a UserService is injected for data access
            private readonly IUserService _userService;

            public UserController(IUserService userService)
            {
                _userService = userService;
            }
        // GET: api/User
        [HttpGet]
        public ActionResult<IEnumerable<User>> GetUsers()
        {
            var users = _userService.GetUsers();
            if (users == null)
            {
                return NotFound(); // Return a NotFoundResult if no users are found
            }
            return Ok(users); // Wrap the IEnumerable<User> in an OkObjectResult
        }


        // GET: api/User/5
        [HttpGet("{id}")]
            public ActionResult<User> GetUser(int id)
            {
                var user = _userService.GetUser(id);

                if (user == null)
                {
                    return NotFound();
                }

                return user;
            }

            // POST: api/User
            [HttpPost]
            public ActionResult<User> PostUser(User user)
            {
                _userService.AddUser(user);
                return CreatedAtAction("GetUser", new { id = user.Id }, user);
            }

            // PUT: api/User/5
            [HttpPut("{id}")]
            public IActionResult PutUser(int id, User user)
            {
                if (id != user.Id)
                {
                    return BadRequest();
                }

                _userService.UpdateUser(user);

                return NoContent();
            }

            // DELETE: api/User/5
            [HttpDelete("{id}")]
            public IActionResult DeleteUser(int id)
            {
                _userService.DeleteUser(id);
                return NoContent();
            }
        }
}

