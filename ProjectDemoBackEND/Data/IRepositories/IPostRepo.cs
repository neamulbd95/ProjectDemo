using System.Collections.Generic;
using System.Threading.Tasks;
using ProjectDemoBackEND.Data.DomainClasses;

namespace ProjectDemoBackEND.Data.IRepositories
{
    public interface IPostRepo : IGenericRepository<Post>
    {
        Task<List<Comment>> GetComments(int postid);
         Task<string> GetUserName(int userid);
         Task<int> GetTotalComment(int postid);

         Task<int> FindTotalLike(int commentId, int userId);
         Task<int> FindTotalDisLike(int commentId, int userId);

         Task<List<Post>> GetPostforPaging(int skip, int take);
         Task<List<Post>> GetPostSearch(string keyword);
    }
}