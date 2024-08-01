using System;
using Artportable.API.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Artportable.API.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  [Authorize]
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
    public ActionResult<string> Connect(string userId)
    {
      try {
        var token = _messageService.ConnectUser(userId);

        return Ok(token);
      }
      catch (Exception e) {
        Console.WriteLine("Something went wrong, {0}", e);
        return StatusCode(StatusCodes.Status500InternalServerError);
      }
    }

    [AllowAnonymous]
    [HttpGet("purchaserequest")]
    public ActionResult<string> PurchaseRequest(string email, string message, string artworkUrl, string artworkName, string artistId, string artworkImageUrl)
    {

      if(email == "jb7660575@gmail.com" || "rmbl.fish@gmail.com") {
        return StatusCode(StatusCodes.Status500InternalServerError);
      }
      try{
        _messageService.PurchaseRequest(email,message,artworkUrl,artworkName,artistId,artworkImageUrl);

        return Ok();
      }
      catch (Exception e){
        Console.WriteLine("Something went wrong, {0}", e);
        return StatusCode(StatusCodes.Status500InternalServerError);
      }
    }
  }
}
