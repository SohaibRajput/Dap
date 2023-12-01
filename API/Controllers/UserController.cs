using API.Data;
using API.Entities;
using Microsoft.AspNetCore.Mvc;
using System.Security.Cryptography.X509Certificates;

namespace API.Controllers;

[ApiController]
[Route("api/[controller]")]  //api/user
public class UserController : ControllerBase
{
    private readonly DataContext _context;

    public UserController(DataContext context)
    {
        _context = context;
    }

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
