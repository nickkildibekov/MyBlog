using System.Data.Entity.ModelConfiguration;
using Common.Models;

namespace Common.App_Data
{
    public class PostConfiguration : EntityTypeConfiguration<Post>
    {
        public PostConfiguration()
        {
            ToTable( "Posts" );
            Property(p => p.ImageThumbnail).IsOptional();
            Property(p => p.ImageData).IsOptional();
            Property(p => p.Author).IsOptional();
            Property( p => p.Title ).IsRequired().HasMaxLength( 30 );
            Property( p => p.Description ).IsRequired().HasMaxLength( 150 );
            Property( p => p.Content ).HasMaxLength( 1500 );
            Property( p => p.PostedDateTime ).IsRequired();
            Property(p => p.Category).IsRequired();
        }
    }
}