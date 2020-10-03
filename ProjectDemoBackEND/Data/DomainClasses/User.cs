using System.Collections.Generic;

namespace ProjectDemoBackEND.Data.DomainClasses
{
    public class User
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public byte[] PasswordHash { get; set; }
        public byte[] PasswordSalt { get; set; }
        public ICollection<Post> posts { get; set; }
        public ICollection<Comment> comments { get; set; }
    }
}