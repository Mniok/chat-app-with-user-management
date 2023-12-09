﻿namespace musicCatalogDotNetAPI.Models
{
    public class ChatMessage
    {
        public int MessageId { get; set; }

        public string Content { get; set; }

        public int TimePosted { get; set; }   // UnixTime, should be using DateTime CreatedAt for this but this should make it simpler

        public DateTime CreatedAt { get; set; }

        public bool WasEdited { get; set; }

        public bool WasRemoved { get; set; }



        public ChatMessage(int Id, string Content, int TimePosted)
        {
            this.MessageId = Id;
            this.Content = Content;
            this.TimePosted = TimePosted;
            this.CreatedAt = DateTime.Now;

            /*this.UserId = Uploader.UserId;
            this.UploadedBy = Uploader;*/

            this.WasEdited = false; // post couldn't have been made edited already
            this.WasRemoved = false;
        }

        public ChatMessage() { }





        public int UserId { get; set; }

        public User UploadedBy { get; set; }
    }
}
