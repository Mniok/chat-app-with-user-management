using System;
using System.ComponentModel.DataAnnotations;
using System.Security.Claims;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using musicCatalogDotNetAPI.Infrastructure;
using musicCatalogDotNetAPI.Services;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;
using System.Data;
using Microsoft.AspNetCore.Cors;
using Microsoft.EntityFrameworkCore;
using musicCatalogDotNetAPI.Models;
using NuGet.Protocol;
using System.Linq.Expressions;
//using System.Web.Http;

namespace musicCatalogDotNetAPI.Controllers
{

    [ApiController]
    [Authorize]
    [Route("api/[controller]")]
    public class ChatMessageController : ControllerBase
    {
        private readonly ILogger<ChatMessageController> _logger;
        //private readonly IUserService _userService;
        private readonly IChatMessageService _chatMessageService;
        private readonly IJwtAuthManager _jwtAuthManager;

        private readonly DBService _context;

        public ChatMessageController(ILogger<ChatMessageController> logger, IChatMessageService chatMessageService, IJwtAuthManager jwtAuthManager, DBService context)
        {
            _logger = logger;
            _chatMessageService = chatMessageService;
            _jwtAuthManager = jwtAuthManager;
            _context = context;
        }





        ///         TEST ===========================================================================================
        [AllowAnonymous]
        [EnableCors]
        [HttpGet("testController")]
        public ActionResult TestController()
        {
            return Ok(new LoginResult { UserName = "chat message controller test", Role = "test", OriginalUserName = "controller test" });
        }


        /*/ [Authorize] /*/
        [AllowAnonymous] /**/
        [EnableCors]
        [HttpGet("messages")]
        public async Task<ActionResult<IEnumerable<ChatMessage>>> GetChatMessageList()  // TODO: get last X newest messages
        {
            var chatMessages = await _context.ChatMessage
                .Include(b => b.UploadedBy)
                .ToListAsync();

            foreach (ChatMessage message in chatMessages)
            {
                var cleanMessage = _chatMessageService.CleanupChatMessage(message);
                message.UploadedBy = cleanMessage.UploadedBy;
            }

            return chatMessages;
        }

        /*/ [Authorize] /*/
        [AllowAnonymous] /**/
        [EnableCors]
        [HttpGet("message/{id}")]
        public async Task<ActionResult<ChatMessage>> GetChatMessageById(int id)
        {

            ChatMessage message = _context.ChatMessage
                .Include(b => b.UploadedBy)
                .Where(b => b.Id == id).First();

            message = _chatMessageService.CleanupChatMessage(message);

            return message;
        }


        [Authorize]
        [EnableCors]
        [HttpPost("post")]
        public async Task<IActionResult> PostMessage([FromBody] PostMessageRequest request)
        {

            string currentUser = User.Identity?.Name;


            if (!ModelState.IsValid)
                return BadRequest(new { code = "ModelNotValid", description = "Model is not valid." });

            var createdMessage = _chatMessageService.CreateChatMessage(request.Content, request.TimePosted, currentUser);

            if (createdMessage == null)
                return BadRequest(new
                {
                    code = "Upload failed",
                    description = "For some reason the song couldn't be uploaded. Please try again later."
                });



            //var role = _userService.GetUserRole(request.UserName);      // GetUserRole po prostu zwraca UserRoles.BasicUser;

            createdMessage = _chatMessageService.CleanupChatMessage(createdMessage);

            _logger.LogInformation($"Chat message ID:[{createdMessage.Id}] was posted by user [{currentUser}].");
            return Ok(createdMessage);
        }

        // TODO: edit message, mark message as deleted

    }






    /// klasy

    public class PostMessageRequest
    {
        [Required]
        [JsonPropertyName("content")]
        public string Content { get; set; }

        [JsonPropertyName("timePosted")]
        public Int64 TimePosted { get; set; }

    }

/*      // TODO??:
    public class PaginationInfo
    {
        [JsonPropertyName("page")]
        public int Page { get; set; }

        [JsonPropertyName("pagesFromSearch")]
        public int PagesFromSearch { get; set; }

        [JsonPropertyName("pageSize")]
        public int PageSize { get; set; }

        [JsonPropertyName("resultsOnPage")]
        public int ResultsOnPage { get; set; }

        [JsonPropertyName("resultsFromSearch")]
        public int ResultsFromSearch { get; set; }

        [JsonPropertyName("songsTotal")]
        public int SongsTotal { get; set; }

    }
*/

} //end of namespace