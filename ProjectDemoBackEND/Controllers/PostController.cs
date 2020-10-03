using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ProjectDemoBackEND.Data.DomainClasses;
using ProjectDemoBackEND.Data.IRepositories;
using ProjectDemoBackEND.DTOs;

namespace ProjectDemoBackEND.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class PostController : ControllerBase
    {
        private readonly IPostRepo _repo;
        public PostController(IPostRepo repo)
        {
            this._repo = repo;
        }

        [HttpGet("ShowAllThePost")]
        public async Task<IActionResult> GetAll()
        {
            var data = await _repo.GetAll();

            List<PostResponseDTO> postListToReturn = new List<PostResponseDTO>();
            
            foreach(var item in data)
            {
                PostResponseDTO postToReturn = new PostResponseDTO();

                postToReturn.PostContent = item.PostContent;
                postToReturn.CreationTime = item.PostCreationTime;
                postToReturn.UserName = await _repo.GetUserName(item.UserId);
                postToReturn.TotalComments = await _repo.GetTotalComment(item.Id);

                var comm = await _repo.GetComments(item.Id);

                List<CommentDTO> commentList = new List<CommentDTO>();

                foreach(var x in comm)
                {
                    CommentDTO c = new CommentDTO();

                    c.CommentContent = x.CommentContent;
                    c.CreationTime = x.CommentCreationTime;
                    c.UserName = await _repo.GetUserName(x.UserId);
                    c.TotalLikes = await _repo.FindTotalLike(x.Id, x.UserId);
                    c.TotalDisLikes = await _repo.FindTotalDisLike(x.Id, x.UserId);
                    commentList.Add(c);
                }

                postToReturn.Comments = commentList;

                postListToReturn.Add(postToReturn);
            }

            return Ok(postListToReturn);
        }
        
        [HttpGet("ShowPostsByPaging")]
        public async Task<IActionResult> GetPostbyPaging(int pageNumber, int takeNumber)
        {
            int skipPost = pageNumber * takeNumber;
            skipPost = skipPost - takeNumber;

            var posts = await _repo.GetPostforPaging(skipPost,takeNumber);

            List<PostResponseDTO> postListToReturn = new List<PostResponseDTO>();
            
            foreach(var item in posts)
            {
                PostResponseDTO postToReturn = new PostResponseDTO();

                postToReturn.PostContent = item.PostContent;
                postToReturn.CreationTime = item.PostCreationTime;
                postToReturn.UserName = await _repo.GetUserName(item.UserId);
                postToReturn.TotalComments = await _repo.GetTotalComment(item.Id);

                var comm = await _repo.GetComments(item.Id);

                List<CommentDTO> commentList = new List<CommentDTO>();

                foreach(var x in comm)
                {
                    CommentDTO c = new CommentDTO();

                    c.CommentContent = x.CommentContent;
                    c.CreationTime = x.CommentCreationTime;
                    c.UserName = await _repo.GetUserName(x.UserId);
                    c.TotalLikes = await _repo.FindTotalLike(x.Id, x.UserId);
                    c.TotalDisLikes = await _repo.FindTotalDisLike(x.Id, x.UserId);
                    commentList.Add(c);
                }

                postToReturn.Comments = commentList;

                postListToReturn.Add(postToReturn);
            }

            return Ok(postListToReturn);
        }


        [HttpGet("SearchPost")]
        public async Task<IActionResult> GetPostSearch(string keyword)
        {
            var posts = await _repo.GetPostSearch(keyword);

            List<PostResponseDTO> postListToReturn = new List<PostResponseDTO>();
            
            foreach(var item in posts)
            {
                PostResponseDTO postToReturn = new PostResponseDTO();

                postToReturn.PostContent = item.PostContent;
                postToReturn.CreationTime = item.PostCreationTime;
                postToReturn.UserName = await _repo.GetUserName(item.UserId);
                postToReturn.TotalComments = await _repo.GetTotalComment(item.Id);

                var comm = await _repo.GetComments(item.Id);

                List<CommentDTO> commentList = new List<CommentDTO>();

                foreach(var x in comm)
                {
                    CommentDTO c = new CommentDTO();

                    c.CommentContent = x.CommentContent;
                    c.CreationTime = x.CommentCreationTime;
                    c.UserName = await _repo.GetUserName(x.UserId);
                    c.TotalLikes = await _repo.FindTotalLike(x.Id, x.UserId);
                    c.TotalDisLikes = await _repo.FindTotalDisLike(x.Id, x.UserId);
                    commentList.Add(c);
                }

                postToReturn.Comments = commentList;

                postListToReturn.Add(postToReturn);
            }

            return Ok(postListToReturn);
        }
    
    }
}