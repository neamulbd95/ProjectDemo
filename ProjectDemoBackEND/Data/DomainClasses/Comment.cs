using System;
using System.Collections.Generic;

namespace ProjectDemoBackEND.Data.DomainClasses
{
    public class Comment
    {
        public int Id { get; set; }
        public string CommentContent { get; set; }
        public int UserId { get; set; }
        public int PostId { get; set; }
        public DateTime CommentCreationTime { get; set; }
        public User user { get; set; }
        public Post post { get; set; }
        public ICollection<CommentLike> commentLikes { get; set; }
    }
}