using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using PhoneStore.Models;

namespace PhoneStore.Data
{
    public class PhoneContext : IdentityDbContext<IdentityUser>
    {
        public PhoneContext(DbContextOptions<PhoneContext> options) : base(options)
        {
        }
        public DbSet<Phone>? Phones { get; set; }
        public DbSet<Category>? Categories { get; set; }
        public DbSet<Comment>? Comments { get; set; }
    }
}
