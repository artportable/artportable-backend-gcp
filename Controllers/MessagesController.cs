using System;
using System.Threading.Tasks;
using Artportable.API.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

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
            try
            {
                var token = _messageService.ConnectUser(userId);

                return Ok(token);
            }
            catch (Exception e)
            {
                Console.WriteLine("Something went wrong, {0}", e);
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        [AllowAnonymous]
        [HttpGet("purchaserequest")]
        public async Task<ActionResult<string>> PurchaseRequest(
            string email,
            string message,
            string artworkUrl,
            string artworkName,
            string artistId,
            string artworkImageUrl,
            string recaptchaToken
        )
        {
            // Block certain emails
            if (
                email == "jb7660575@gmail.com"
                || email == "rmbl.fish@gmail.com"
                || email == "davidewong33@gmail.com"
                || email == "bijon651@gmail.com"
                || email == "rmbl.fish@gmail.com"
                || email == "robarpepper@gmail.com"
                || email == "nicolesusantriston@gmail.com"
                || email == "jurgenhamilton95@gmail.com"
                || email == "connordylan52@gmail.com"
                || email == "Jerry@k39.se"
                || email == "jurgenhamilton95@gmail.com"
            )
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }

            // Validate reCAPTCHA
            var isRecaptchaValid = await ValidateRecaptchaAsync(recaptchaToken);
            if (!isRecaptchaValid)
            {
                return BadRequest("Invalid reCAPTCHA.");
            }

            try
            {
                _messageService.PurchaseRequest(
                    email,
                    message,
                    artworkUrl,
                    artworkName,
                    artistId,
                    artworkImageUrl
                );
                return Ok();
            }
            catch (Exception e)
            {
                Console.WriteLine("Something went wrong, {0}", e);
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        [AllowAnonymous]
        [HttpGet("emailmessgerequest")]
        public async Task<ActionResult<string>> EmailMessageRequest(
            string email,
            string message,
            string username,
            string recaptchaToken
        )
        {
            // Block certain emails
            if (
                email == "jb7660575@gmail.com"
                || email == "rmbl.fish@gmail.com"
                || email == "davidewong33@gmail.com"
                || email == "bijon651@gmail.com"
                || email == "rmbl.fish@gmail.com"
                || email == "Clairewilliams3214@gmail.com"
                || email == "brianarmstrongbitcoin01@gmail.com"
            )
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
            // Validate reCAPTCHA
            var isRecaptchaValid = await ValidateRecaptchaAsync(recaptchaToken);
            if (!isRecaptchaValid)
            {
                return BadRequest("Invalid reCAPTCHA.");
            }

            try
            {
                _messageService.EmailMessageRequest(email, message, username);
                return Ok();
            }
            catch (Exception e)
            {
                Console.WriteLine("Something went wrong, {0}", e);
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        // Validate reCAPTCHA token
        private async Task<bool> ValidateRecaptchaAsync(string recaptchaToken)
        {
            var secretKey = "6LcJCDkqAAAAAKrq0Lcl8AbzwKLuTGekuPUa8hbL";

            var httpClient = new System.Net.Http.HttpClient();
            var response = await httpClient.PostAsync(
                $"https://www.google.com/recaptcha/api/siteverify?secret={secretKey}&response={recaptchaToken}",
                null
            );

            if (!response.IsSuccessStatusCode)
                return false;

            var resultContent = await response.Content.ReadAsStringAsync();
            var recaptchaResult = JsonConvert.DeserializeObject<RecaptchaResponse>(resultContent);

            return recaptchaResult.Success;
        }

        private class RecaptchaResponse
        {
            [JsonProperty("success")]
            public bool Success { get; set; }
        }
    }
}
