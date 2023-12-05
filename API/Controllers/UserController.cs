using API.Data;
using API.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Cryptography.X509Certificates;

namespace API.Controllers;

[Authorize]
public class UserController : BaseApiController
{
    private readonly DataContext _context;

    public UserController(DataContext context)
    {
        _context = context;
    }

    [AllowAnonymous]
    [HttpGet]
    public ActionResult<IEnumerable<AppUser>> GetUsers()
    {

        var users = _context.Users.ToList();
        return users;
    }

  
    [HttpGet("{id}")] // api/users/2
    public ActionResult<AppUser> GetUser(int id)
    {
        return _context.Users.Find(id);

    }
}
