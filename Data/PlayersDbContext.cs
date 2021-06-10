using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using WebCoreMvcGitExercise.Models;

namespace WebCoreMvcGitExercise.Data
{
    public class PlayersDbContext : DbContext
    {
        public PlayersDbContext (DbContextOptions<PlayersDbContext> options)
            : base(options)
        {
        }

        public DbSet<WebCoreMvcGitExercise.Models.PlayerClass> PlayerClass { get; set; }
    }
}
