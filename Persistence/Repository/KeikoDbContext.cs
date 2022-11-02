using Keiko.Application.Interfaces.Repository;
using Keiko.Domain.Models.Product;
using Microsoft.EntityFrameworkCore;

namespace Persistence.Repository;

public class KeikoDbContext : DbContext, IKeikoDbContext
{
    public KeikoDbContext(DbContextOptions<KeikoDbContext> options) : base(options) {}
    
    public DbSet<CategoryProduct> CategoryProducts { get; set; }
}