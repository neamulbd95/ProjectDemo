using System;

namespace ProjectDemoBackEND.DTOs
{
    public class CommentDTO
    {
        public string CommentContent { get; set; }
        public string UserName { get; set; }
        public DateTime CreationTime { get; set; }
        public int TotalLikes { get; set; }
        public int TotalDisLikes { get; set; }
    }
}