using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MVCTask1.Models
{
    [Table("Comment")]
    public class Comment
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Body { get; set; }
        public int GameId { get; set; }
    }
}