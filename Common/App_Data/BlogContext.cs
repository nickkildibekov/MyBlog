using System.Data.Entity;
using Common.Models;
using Microsoft.AspNet.Identity.EntityFramework;

namespace Common.App_Data
{
    public class BlogContext : IdentityDbContext<ApplicationUser>
    {
        public BlogContext() : base("BlogContext")
        {
        }

        public static BlogContext Create()
        {
            Database.SetInitializer( new BlogContextInitializer() );
            return new BlogContext();
        }

        public DbSet<Post> Posts { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Comment> Comments { get; set; }


        protected override void OnModelCreating( DbModelBuilder modelBuilder )
        {
            base.OnModelCreating( modelBuilder );

            modelBuilder.Configurations.Add( new PostConfiguration() );
            modelBuilder.Configurations.Add( new CategoryConfiguration() );
            modelBuilder.Configurations.Add( new CommentConfiguration());

            modelBuilder.Entity<Comment>()
                .HasRequired<Post>(c => c.CurrentPost)
                .WithMany(p => p.Comments)
                .HasForeignKey<int>(c => c.CurrentPostId);

            modelBuilder.Entity<Post>()
                .HasMany<Comment>( p => p.Comments )
                .WithRequired( c => c.CurrentPost )
                .WillCascadeOnDelete();

        }

    }
}