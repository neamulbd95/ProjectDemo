using System.Threading.Tasks;
using ProjectDemoBackEND.Data.DomainClasses;

namespace ProjectDemoBackEND.Data.IRepositories
{
    public interface IUserAuthRepo : IGenericRepository<User>
    {
         Task<bool> Register(User user, string password);
         Task<User> Login(string userName, string password);
         Task<bool> UserExits(string userName);
    }
}