using MVCTask1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVCTask1.DAL
{
    public interface IGameRepository : IDisposable
    {
        IEnumerable<Game> GetGames();
        Game GetGameByID(int gameId);
        void InsertGame(Game game);
        void DeleteGame(int gameId);
        void UpdateGame(Game game);
        void Save();
    }
}
