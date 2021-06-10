using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace WebCoreMvcGitExercise.Models
{
    [Table("Players")]
    public class PlayerClass
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Team { get; set; }
    }
}
