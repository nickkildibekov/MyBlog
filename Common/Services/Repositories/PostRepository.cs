using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using Common.App_Data;
using Common.Models;

namespace Common.Services.Repositories
{
    public class PostRepository : IRepository<Post>, IDisposable
    {
        private BlogContext db;

        public PostRepository( BlogContext context)
        {
            db = context;
        }


        public IEnumerable<Post> GetList()
        {
            return db.Posts.ToList();
        }

        public Post Get(int? id)
        {
            return db.Posts.Find( id );
        }

        public void Create( Post post ) // create object--Action : Posts/Create
        {
            post.PostedDateTime = DateTime.Now;
            db.Posts.Add( post );
        }

        public void Delete( Post post ) // delete object --Action : Posts/Delete 
        {
            if (post == null) return;
            db.Posts.Remove(post);
        }

        public void Edit( Post post ) // edit object--Action : Posts/Edit
        {
            post.ModifiedDateTime = DateTime.Now;
            db.Entry( post ).State = EntityState.Modified;
        }
       
       private bool disposed = false;
        public virtual void Dispose( bool disposing )
        {
            if (!disposed)
            {
                if (disposing)
                {
                    db.Dispose();
                }
                disposed = true;
            }
        }
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize( this );
        }

       
    }
}
