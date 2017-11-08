using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MVCTask1.Models
{
    [Table("PlatformType")]
    public class PlatformType
    {
        public int Id { get; set; }
        [Index(IsUnique = true)]
        [StringLength(50)]
        public string Type { get; set; }

        public virtual ICollection<GamePlatformType> Games { get; set; }
    }
}