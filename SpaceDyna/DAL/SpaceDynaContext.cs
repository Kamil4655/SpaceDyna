using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using SpaceDyna.Models;

namespace SpaceDyna.DAL
{
    public class SpaceDynaContext : IdentityDbContext
    {
        public SpaceDynaContext(DbContextOptions options) : base(options)
        {

        }

        public DbSet<Agency> Agencies{ get; set; }
    }
}
