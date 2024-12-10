using Microsoft.AspNetCore.Mvc;
using TicketReservation.Application.Services;
using TicketReservation.Contracts;

namespace TicketReservation.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UsersController : ControllerBase
    {
        private readonly IUsersService _userService;

        public UsersController(IUsersService userService)
        {
            _userService = userService;
        }

        [HttpGet]
        public async Task<ActionResult<List<UsersResponse>>> GetUsers()
        {
            var users = await _userService.GetAllUsers();

            var response = users.Select(x => new UsersResponse(x.Id, x.FirstName, x.LastName, x.Email, x.Phone));

            return Ok(response);
        }

        [HttpPost]
        public async Task<ActionResult<Guid>> CreateUser([FromBody] UsersRequest request)
        {
            var (user, error) = TicketReservation.Core.Models.User.Create(
                Guid.NewGuid(),
                request.FirstName,
                request.LastName,
                request.Email,
                request.PhoneNumber
            );
            if (!string.IsNullOrEmpty(error))
            {
                return BadRequest(error);
            }

            var userId = await _userService.CreateUser(user);
            
            return Ok(userId);
        }

        [HttpPut("{id:guid}")]
        public async Task<ActionResult<Guid>> UpdateBook(Guid id, [FromBody] UsersRequest request)
        {
          var userId =  await _userService.UpdateUser(id, request.FirstName, request.LastName, request.Email, request.PhoneNumber);
          return Ok(userId);
        }

        [HttpDelete("{id:guid}")]
        public async Task<ActionResult<Guid>> DeleteBook(Guid id)
        {
            return Ok(await _userService.DeleteUser(id));
        }
    }
}
