using Microsoft.EntityFrameworkCore;
using ProjectDemoBackEND.Data.DomainClasses;

namespace ProjectDemoBackEND.Data.DataContextClass
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options){}

        public DbSet<User> Users { get; set; }
        public DbSet<Post> Posts { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<CommentLike> CommentLikes { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            /*
            modelBuilder.Entity<Comment>()
            .HasOne(t => t.user)
            .WithMany(t => t.comments)
            .HasForeignKey(x => x.UserId)
            .OnDelete(DeleteBehavior.Cascade);*/

        }
    }
}