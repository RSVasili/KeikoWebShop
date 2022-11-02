using Keiko.Domain.Models.Product;
using Microsoft.EntityFrameworkCore;

namespace Keiko.Application.Interfaces.Repository;

public interface IKeikoDbContext
{
    DbSet<CategoryProduct> CategoryProducts { get; set; }
}