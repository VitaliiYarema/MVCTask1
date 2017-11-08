using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVCTask1.Models
{
    public class GamePlatformType
    {
        public int Id { get; set; }
        public int GameId { get; set; }
        public int TypeId { get; set; }
    }
}