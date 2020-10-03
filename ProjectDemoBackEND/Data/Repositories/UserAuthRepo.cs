using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ProjectDemoBackEND.Data.DataContextClass;
using ProjectDemoBackEND.Data.DomainClasses;
using ProjectDemoBackEND.Data.IRepositories;
using ProjectDemoBackEND.Security.Hashing;

namespace ProjectDemoBackEND.Data.Repositories
{
    public class UserAuthRepo : GenericRepository<User>, IUserAuthRepo
    {
        public UserAuthRepo(DataContext context) : base(context)
        {
            
        }
        public async Task<User> Login(string userName, string password)
        {
            var user = await DataContext.Users.FirstOrDefaultAsync(x => x.UserName.ToLower() == userName.ToLower());

            if(user == null)
                return null;

            if(!HashingPassword.checkPassword(password, user.PasswordHash, user.PasswordSalt))
                return null;
            
            return user;
        }

        public async Task<bool> Register(User user, string password)
        {
            try
            {
                byte[] passwordHash, passwordSalt;
                HashingPassword.CreatePassword(password, out passwordHash, out passwordSalt);

                user.PasswordHash = passwordHash;
                user.PasswordSalt = passwordSalt;

                await DataContext.Users.AddAsync(user); 
                await DataContext.SaveChangesAsync();
                
                return true;
            }
            catch
            {
                return false;
            }            
        }

        public async Task<bool> UserExits(string userName)
        {
            if( await DataContext.Users.AnyAsync(x => x.UserName.ToLower() == userName.ToLower()))
                return true;
            
            return false;
        }

        public DataContext DataContext
        {
            get { return _context as DataContext; }
        }
    }
}