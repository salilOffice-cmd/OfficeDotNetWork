using System.Collections.Generic;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Application
{
    public interface IApplicationDbContext
    {
        DbSet<Person> Person { get; }
    }
}
