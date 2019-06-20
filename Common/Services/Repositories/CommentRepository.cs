using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using Common.App_Data;
using Common.Models;

namespace Common.Services.Repositories
{
    public class CommentRepository : IRepository<Comment>, IDisposable
    {
        private BlogContext db;

        public CommentRepository( BlogContext context )
        {
            db = context;
        }


        public IEnumerable<Comment> GetList()
        {
            return db.Comments.ToList();
        }

        public Comment Get( int? id )
        {
            return db.Comments.Find(id);
        }

        public void Create( Comment comment ) // create object--Action : Posts/Create
        {
            db.Comments.Add( comment );
        }

        public void Delete( Comment comment ) // delete object --Action : Posts/Delete 
        {
            if (comment == null)
                return;
            db.Comments.Remove( comment );
        }

        public void Edit( Comment comment ) // edit object--Action : Posts/Edit
        {
            db.Entry( comment ).State = EntityState.Modified;
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
            Dispose( true );
            GC.SuppressFinalize( this );
        }


    }
}
