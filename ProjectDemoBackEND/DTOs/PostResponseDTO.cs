using System;
using System.Collections.Generic;

namespace ProjectDemoBackEND.DTOs
{
    public class PostResponseDTO
    {
        public string PostContent { get; set; }
        public string UserName { get; set; }
        public DateTime CreationTime { get; set; }
        public int TotalComments { get; set; }

        public ICollection<CommentDTO> Comments { get; set; }
    }
}