using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using API.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers
{ 
    [ApiController]
    [Route("api/[controller]")] // GET /api/users/
    public class UsersController : ControllerBase
    {
        private readonly DataContext _context;

            public UsersController(DataContext context)
            {
                _context = context;
            }

            [HttpGet]
            public async Task<ActionResult<IEnumerable<Entities.AppUser>>> GetUsers()
            {
                var users = await _context.Users.ToListAsync();
                return users;
            }

            [HttpGet("{id}")] // /api/users/2
            public async Task<ActionResult<Entities.AppUser>> GetUser(int id)
            {
                return await _context.Users.FindAsync(id);
                //var user = _context.Users.Find(id);

                //return _context.Users.Find(id);
            }    
    }    
}

    
 
