namespace musicCatalogDotNetAPI.Models
{
    public class User
    {
        public int UserId { get; set; }

        public string UserName { get; set; }

        public string? OriginalUserName { get; set; }

        public string Password { get; set; } //probably hash or whatever, named pass for simplicity

        public DateTime CreatedAt { get; set; }

        public string? UserRole { get; set; }

        public Int64? MutedUntil { get; set; } // UnixTime timestamp

        public Int64? BannedUntil { get; set; } // same



        public User(int Id, string Name, string Pass, string Role) {
            this.UserId = Id;
            this.UserName = Name;
            this.OriginalUserName = Name;
            this.Password = Pass;
            this.CreatedAt = DateTime.Now;
            this.UserRole = Role;
            this.MutedUntil = null;
            this.BannedUntil = null;
        }

        public User() { }       //bez tego wywalało się _context.User.whatever()


        //computed się robi tak: public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);
        //public string? Summary { get; set; } /// ? - nullable



        //relacje:

        public List<Song> uploadedSongs { get; } = new();  // unused in this project!

        public List<ChatMessage> postedMessages { get; } = new();
    }
}