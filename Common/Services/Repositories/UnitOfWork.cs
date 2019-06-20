using System;
using System.Data.Entity.Validation;
using System.Linq;
using Common.App_Data;

namespace Common.Services.Repositories
{
    public class UnitOfWork : IDisposable
    {
        private BlogContext db = new BlogContext();
        private PostRepository postRepository;
        private CommentRepository commentRepository;

        
        public UnitOfWork( BlogContext newdb, PostRepository newpostRepository )
        {
            db = newdb;
            postRepository = newpostRepository;
        }

        public UnitOfWork( BlogContext newdb, CommentRepository newcommentRepository )
        {
            db = newdb;
            commentRepository = newcommentRepository;
        }

        public UnitOfWork(){}

        public PostRepository Post => postRepository ?? (postRepository = new PostRepository( db ));
        public CommentRepository Comment => commentRepository ?? (commentRepository = new CommentRepository( db ));

        public void Save()
        {
            try
            {
                db.SaveChanges();
            }
            catch (DbEntityValidationException dbEx)
            {
                var raise = dbEx.EntityValidationErrors.Aggregate<DbEntityValidationResult, Exception>( dbEx, ( current1, validationErrors ) =>
                 validationErrors.ValidationErrors.Select( validationError =>
                  $"{validationErrors.Entry.Entity.ToString()}:{validationError.ErrorMessage}" ).Aggregate( current1, ( current, message ) =>
                    new InvalidOperationException( message, current ) ) );
                throw raise;
            }
        }

        private bool disposed = false;

        public virtual void Dispose( bool disposing )
        {
            if (disposed)
                return;
            if (disposing)
            {
                db.Dispose();
            }
            disposed = true;
        }

        public void Dispose()
        {
            Dispose( true );
            GC.SuppressFinalize( this );
        }
    }
}
