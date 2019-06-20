using System.Data.Entity;
using Common.Models;

namespace WebSite.ViewModels
{
    public class IndexViewModel 
    {
        public DbSet<Category> Categories { get; set; }
        public DbSet<Post> Posts { get; set; }
       
    }
}
