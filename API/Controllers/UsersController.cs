using API.Data;
using API.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API
{
    [ApiController]
    [Route("api/[controller]")]
    public class UsersController(DataContext context) : ControllerBase
    {

        [HttpGet]//api/users
        public async Task<ActionResult<IEnumerable<AppUser>>> GetUsers()
        {
            var user = await context.Users.ToListAsync();
            return user;
        }

        [HttpGet("{Id:int}")]//api/users/id(1,2,3)
        public async Task<ActionResult<AppUser>>GetUsers(int Id)
        {
            var user = await context.Users.FindAsync(Id);
            if(user==null) return NotFound(Id);
            return user;
        }
    }

}
