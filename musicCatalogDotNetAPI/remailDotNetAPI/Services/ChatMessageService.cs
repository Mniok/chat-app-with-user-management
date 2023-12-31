using System.Collections.Generic;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;

using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using musicCatalogDotNetAPI.Models;
using musicCatalogDotNetAPI.Controllers;
///using Microsoft.AspNetCore.Mvc;

namespace musicCatalogDotNetAPI.Services
{
    public interface IChatMessageService
    {
        Models.ChatMessage CreateChatMessage(string content, Int64 timePosted, string uploaderName);  //notice: should be async! Not async for now
        Models.ChatMessage CleanupChatMessage(Models.ChatMessage chatMessage);

        // TODO: edit message
    }

    public class ChatMessageService : IChatMessageService
    {
        private readonly ILogger<ChatMessageService> _logger;
        private readonly DBService _context;

        public ChatMessageService(ILogger<ChatMessageService> logger, DBService context)
        {
            _logger = logger;
            _context = context;
        }


        public Models.ChatMessage CreateChatMessage(string content, Int64 timePosted, string uploaderName)
        {
            int newId = _context.ChatMessage.Count() + 1;


            User uploader = _context.User.Include(b => b.postedMessages).Where(b => b.UserName == uploaderName).First();

            Models.ChatMessage newChatMessage = new Models.ChatMessage(newId,
                                        content,
                                        timePosted);

            uploader.postedMessages.Add(newChatMessage);

            _context.ChatMessage.Add(newChatMessage);
            _context.SaveChanges();

            return newChatMessage;

        }

        public Models.ChatMessage CleanupChatMessage(Models.ChatMessage chatMessage)
        {   // ONLY FOR RETURNNG THROUGH API! THIS DOESN'T AFFECT DATA IN DATABASE!
            chatMessage.UploadedBy.Password = "***";
            chatMessage.UploadedBy.uploadedSongs.Clear(); // to reduce circular references
            chatMessage.UploadedBy.postedMessages.Clear();

            return chatMessage;
        }

    }

}