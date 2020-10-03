using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ProjectDemoBackEND.Data.DataContextClass;
using ProjectDemoBackEND.Data.DomainClasses;
using ProjectDemoBackEND.Data.IRepositories;

namespace ProjectDemoBackEND.Data.Repositories
{
    public class PostRepo : GenericRepository<Post>, IPostRepo
    {
        public PostRepo(DataContext context) : base(context)
        {
            
        }
        public DataContext DataContext
        {
            get { return _context as DataContext; }
        }

        public async Task<int> FindTotalDisLike(int commentId, int userId)
        {
            return await DataContext.CommentLikes.Where(x => x.UserId == userId && x.CommentId == commentId && x.LikeStatus == -1).CountAsync();
        }

        public async Task<int> FindTotalLike(int commentId, int userId)
        {
            return await DataContext.CommentLikes.Where(x => x.UserId == userId && x.CommentId == commentId && x.LikeStatus == 1).CountAsync();
        }

        public async Task<List<Comment>> GetComments(int postid)
        {
            return await DataContext.Comments.Where(x => x.PostId == postid).ToListAsync();
        }

        public async Task<List<Post>> GetPostforPaging(int skip, int take)
        {
            return await DataContext.Posts.OrderByDescending(x=>x.Id).Skip(skip).Take(take).ToListAsync();
        }

        public Task<List<Post>> GetPostSearch(string keyword)
        {
            var response = from p in DataContext.Posts
                                where EF.Functions.Like(p.PostContent, "%"+keyword+"%")
                                select p;
            return response.ToListAsync();
        }

        public async Task<int> GetTotalComment(int postid)
        {
            //throw new System.NotImplementedException();
            return await DataContext.Comments.Where(x => x.PostId == postid).CountAsync();
        }

        public async Task<string> GetUserName(int userid)
        {
            var user = await DataContext.Users.SingleOrDefaultAsync(x => x.Id == userid);
            return user.UserName;
        }
    }
}