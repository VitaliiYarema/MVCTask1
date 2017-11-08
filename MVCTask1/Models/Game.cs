using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MVCTask1.Models
{
    [Table("Game")]
    public class Game
    {
        public int Id { get; set; }
        [Index(IsUnique =true)]
        [StringLength(50)]
        public string Key { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public virtual ICollection<Comment> Comments { get; set; }
        public virtual ICollection<GameGenre> Genres { get; set; }
        public virtual ICollection<GamePlatformType> PlatformTypes { get; set; }
    }
}