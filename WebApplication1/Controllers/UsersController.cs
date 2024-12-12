using Microsoft.AspNetCore.Mvc;
using Api.Data;
using WebApplication1.Entities;
using Microsoft.VisualBasic;
using Microsoft.EntityFrameworkCore;

namespace API;

[ApiController]
[Route("api/[controller]")] //api/users

public class UsersController(DataContext context):ControllerBase//In older version of C# UsersController:ControllerBase
{

    //In older c# versions :-
     /*   private readonly DataContext _context; //Would have written context but devs prefer and _ charcter before writing the private fields.
    
        public UsersController(DataContext context)
        {
            _context = context; //if used context, would have written this.context = context, this tells that the context is a part of the UsersController class and not the constructor.
        }
        */
    //In newer Version we can directly use the context specified in the starting
        [HttpGet] //api/users
        public async Task<ActionResult<IEnumerable<AppUser>>> GetUsers() //Synchronous without async and task
        {
            var users = await context.Users.ToListAsync();//Generating list of users, synchronous without await and used ToList()
            return users;//we can also return Http reponses like Ok,NotFound etc. as we are using ActionResult.
        }

        [HttpGet("{id:int}")] //api/users/3
        public async Task<ActionResult<AppUser>> GetUser(int id)
        {
            var user = await context.Users.FindAsync(id);

            if(user==null) return NotFound();//Beacuse of the Null Reference error
            
            return user;
        }

        
}