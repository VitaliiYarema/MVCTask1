using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MVCTask1.Models
{
    [Table("Genre")]
    public class Genre
    {
        public int Id { get; set; }
        [Index(IsUnique = true)]
        [StringLength(50)]
        public string Name { get; set; }
        public int ParentId { get; set; }

        public virtual ICollection<Genre> SubGenres { get; set; }
        public virtual ICollection<GameGenre> Games { get; set; }
    }
}