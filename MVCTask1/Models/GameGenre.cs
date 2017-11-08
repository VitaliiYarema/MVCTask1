using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVCTask1.Models
{
    public class GameGenre
    {
        public int Id { get; set; }
        public int GameId { get; set; }
        public int GenreId { get; set; }
    }
}