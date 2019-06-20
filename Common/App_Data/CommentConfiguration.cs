using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common.Models;

namespace Common.App_Data
{
    public class CommentConfiguration : EntityTypeConfiguration<Comment>
    {
        public CommentConfiguration()
        {
            ToTable( "Comments" );
            Property( p => p.Author ).IsOptional();
            Property( p => p.Content ).HasMaxLength( 1500 );

        }
    }
}
