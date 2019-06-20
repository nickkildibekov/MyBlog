using System.Data.Entity.ModelConfiguration;
using Common.Models;

namespace Common.App_Data
{
    public class CategoryConfiguration : EntityTypeConfiguration<Category>
    {
        public CategoryConfiguration()
        {
            ToTable( "Categories" );
            Property( c => c.Name ).IsRequired().HasMaxLength( 20 );
            Property( c => c.Description ).IsRequired().HasMaxLength( 150 );
            Property( c => c.DateCreated ).IsRequired();

        }
    }
}