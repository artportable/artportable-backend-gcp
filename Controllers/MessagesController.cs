using System;
using Artportable.API.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Artportable.API.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  // [Authorize]
  public class MessagesController : ControllerBase
  {
    private readonly IMessageService _messageService;

    public MessagesController(IMessageService messageService)
    {
      _messageService = messageService;
    }

    /// <summary>
    /// TEST: Register user
    /// </summary>
    [HttpGet("connect")]
    public ActionResult<string> Connect(string username)
    {
      try {
        var token = _messageService.ConnectUser(username);

        return Ok(token);
      }
      catch (Exception e) {
        Console.WriteLine("Something went wrong, {0}", e);
        return StatusCode(StatusCodes.Status500InternalServerError);
      }
    }
  }
}
