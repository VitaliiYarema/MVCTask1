using MVCTask1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVCTask1.DAL
{
    public class UnitOfWork : IDisposable
    {
        private MVCTask1Context context = new MVCTask1Context();
        private GenericRepository<Game> gameRepository;
        private GenericRepository<Comment> commentRepository;

        public GenericRepository<Game> GameRepository
        {
            get
            {
                return this.gameRepository ?? new GenericRepository<Game>(context);
            }
        }

        public GenericRepository<Comment> CommentRepository
        {
            get
            {
                return this.commentRepository ?? new GenericRepository<Comment>(context);
            }
        }

        public void Save()
        {
            context.SaveChanges();
        }

        private bool disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    context.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}