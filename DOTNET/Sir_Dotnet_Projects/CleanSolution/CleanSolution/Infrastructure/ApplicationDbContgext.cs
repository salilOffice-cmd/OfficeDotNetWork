using Application;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure
{
    public class ApplicationDbContgext : DbContext, IApplicationDbContext
    {
        public ApplicationDbContgext(DbContextOptions<ApplicationDbContgext> dbContextOptions):base(dbContextOptions) { }

        public DbSet<Person> Person => Set<Person>();
    }
}
