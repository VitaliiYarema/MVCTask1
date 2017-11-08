using MVCTask1.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace MVCTask1.DAL
{
    public class GameRepository : IGameRepository, IDisposable
    {
        private MVCTask1Context context;

        public GameRepository(MVCTask1Context context)
        {
            this.context = context;
        }

        public IEnumerable<Game> GetGames()
        {
            return context.Games.ToList();
        }

        public Game GetGameByID(int id)
        {
            return context.Games.Find(id);
        }

        public void InsertGame(Game game)
        {
            context.Games.Add(game);
        }

        public void DeleteGame(int gameID)
        {
            Game student = context.Games.Find(gameID);
            context.Games.Remove(student);
        }

        public void UpdateGame(Game game)
        {
            context.Entry(game).State = EntityState.Modified;
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