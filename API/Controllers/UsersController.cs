using API.Data;
using API.Models;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;


[ApiController]
[Route("api/[controller]")] // /api/users
public class UsersController(DataContext context) : ControllerBase
{
	[HttpGet]
	public ActionResult<IEnumerable<AppUser>> GetUsers()
	{
		var users = context.Users.ToList();

		return Ok(users);
	}

	[HttpGet("{id:int}")] // /api/users/3
	public ActionResult<AppUser> GetUser(int id)
	{
		var user = context.Users.Find(id);

		if (user == null) return NotFound();

		return Ok(user);
	}
}

