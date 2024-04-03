using App.Users.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace App.Users.Data
{
    public class UsersContext : ModelContext
    {
        
        public UsersContext(DbContextOptions<UsersContext> options) : base(options)
        {
            
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
