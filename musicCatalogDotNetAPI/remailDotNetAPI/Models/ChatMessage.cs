namespace musicCatalogDotNetAPI.Models
{
    public class ChatMessage
    {
        public int Id { get; set; } // property "Id" is by default set as primary key 

        public string Content { get; set; }

        public Int64 TimePosted { get; set; }   // UnixTime, should be using DateTime CreatedAt for this but this should make it simpler

        public DateTime CreatedAt { get; set; }

        public bool WasEdited { get; set; }

        public bool WasRemoved { get; set; }



        public ChatMessage(int Id, string Content, Int64 TimePosted)
        {
            this.Id = Id;
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
