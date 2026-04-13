using HerzingProjectTemplate.Models;
using Microsoft.EntityFrameworkCore;

namespace HerzingProjectTemplate.Data
{
    public class ApplicationDbContext2 : DbContext
    {
        public ApplicationDbContext2(DbContextOptions<ApplicationDbContext2> options) : base(options)
        {
        }

        public DbSet<UserProfile> UserProfiles { get; set; }
        public DbSet<Nutrition> Nutritions { get; set; }
        public DbSet<WorkOut> WorkOuts { get; set; }
        public DbSet<Progress> Progresses { get; set; }
    }
}
