using Microsoft.AspNetCore.Mvc;

namespace backend.Controllers;
/// <summary>
/// The controller that set up the users API.
/// </summary>
[ApiController]
[Route("api/users")]
public class UserController : ControllerBase
{
    private static readonly List<User> _users = new()
    {
        new User { Id = 1, Name = "Jhon Doe" },
        new User { Id = 2, Name = "Jane Doe" }
    };
    /// <summary>
    /// Retrieves a list of all users.
    /// </summary>
    /// <returns>
    /// A list of users with their IDs and names.
    /// </returns>
    /// <response code="200">Returns the list of users.</response>
    [HttpGet]
    public IActionResult GetUsers()
    {
        // Select only the necessary properties of each user object.
        var users = _users.Select(user => new
        {
            Id = user.Id,
            Name = user.Name
        });
        // Return the list of users as a successful response
        return Ok(users);
    }
    /// <summary>
    /// Retrieves a user by their ID and returns the user's details if found, 
    /// otherwise returns a 404 Not Found status.
    /// </summary>
    /// <param name="id">The ID of the user to retrieve.</param>
    /// <returns>
    /// An HTTP 200 OK response with the user's ID and name if found, 
    /// or an HTTP 404 Not Found response if the user is not found.
    /// </returns>
    [HttpGet("{id}")]
    public IActionResult GetUser(int id)
    {
        // Find the user with the specified ID
        var user = _users.FirstOrDefault(u => u.Id == id);

        // If the user is not found, return a 404 Not Found response
        if (user == null)
            return NotFound();

        // Return the user's details as a successful response
        return Ok(new
        {
            Id = user.Id,
            Name = user.Name
        });
    }
}