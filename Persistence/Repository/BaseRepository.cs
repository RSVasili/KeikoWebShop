using System.Data;
using Microsoft.Extensions.Configuration;
using Npgsql;

namespace Persistence.Repository;

public abstract class BaseRepository
{
    private readonly IConfiguration _configuration;

    protected BaseRepository(IConfiguration configuration)
    {
        _configuration = configuration;
    }

    protected IDbConnection CreateDbConnection()
    {
        return new NpgsqlConnection(_configuration.GetConnectionString("DefaultConnection"));
    }
}