using System;
using System.Collections.Generic;

namespace ProjectDemoBackEND.Data.DomainClasses
{
    public class Post
    {
        public int Id { get; set; }
        public string PostContent { get; set; }
        public int UserId { get; set; }
        public DateTime PostCreationTime { get; set; }
        public User user { get; set; }
        public ICollection<Comment> comments { get; set; }
    }
}