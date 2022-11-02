using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using Dapper;
using Keiko.Application.Interfaces.Repository;
using Keiko.Domain.Models.Product;
using Microsoft.Extensions.Configuration;

namespace Persistence.Repository;

public class CategoryRepository : BaseRepository, ICategoryRepository
{
    public CategoryRepository(IConfiguration configuration) : base(configuration)
    {
    }

    public async Task<List<CategoryProduct>> FindAllAsync()
    {
        try
        {
            // using (var context = CreateDbConnection())
            // {
            //     var response = (await context.QueryAsync<CategoryProduct>(@"SELECT * FROM categoryproducts")).ToList();
            //
            //     return response;
            // }

            var sql = "SELECT * FROM \"CategoryProducts\"";

            using (var context = CreateDbConnection())
            {
                var response = (await context.QueryAsync<CategoryProduct>(sql)).ToList();
                return response;
            }
        }
        catch (Exception exception)
        {
            throw new Exception(exception.Message, exception);
        }
    }

    public async Task<CategoryProduct> FindByIdAsync(Guid id)
    {
        try
        {
            var sql = "SELECT * FROM \"CategoryProducts\" WHERE \"Id\" = @Id";

            var param = new DynamicParameters();
            param.Add("Id", id, DbType.Guid);

            using (var context = CreateDbConnection())
            {
                return await context.QueryFirstAsync<CategoryProduct>(sql, param);
            }
        }
        catch (Exception exception)
        {
            throw new Exception(exception.Message, exception);
        }
    }

    public async Task<CategoryProduct> InsertAsync(CategoryProduct entity)
    {
        try
        {
            var sql =
                "INSERT INTO \"CategoryProducts\" (\"Id\", \"CategoryName\", \"CategoryDescription\", \"IsFavorite\") VALUES (@Id, @CategoryName, @CategoryDescription, @IsFavorite)";


            // using (var context = CreateDbConnection())
            // {
            //     var response = await context.QueryFirstOrDefaultAsync<CategoryProduct>(sql,
            //         new
            //         {
            //             Id = entity.Id,
            //             CategoryName = entity.CategoryName,
            //             CategoryDescription = entity.CategoryDescription,
            //             IsFavorite = entity.IsFavorite
            //             
            //         });
            //
            //     return response;
            // }

            var param = new DynamicParameters();
            param.Add("Id", entity.Id, DbType.Guid);
            param.Add("CategoryName", entity.CategoryName, DbType.String);
            param.Add("CategoryDescription", entity.CategoryDescription, DbType.String);
            param.Add("IsFavorite", entity.IsFavorite, DbType.Boolean);

            using (var context = CreateDbConnection())
            {
                return await context.QueryFirstOrDefaultAsync<CategoryProduct>(sql, param);
            }
        }
        catch (Exception exception)
        {
            throw new Exception(exception.Message, exception);
        }
    }

    public async Task<CategoryProduct> EditAsync(CategoryProduct entity)
    {
        try
        {
            var sql = "UPDATE \"CategoryProducts\" Set \"CategoryName\" = @CategoryName, " +
                      "\"CategoryDescription\" = @CategoryDescription, \"IsFavorite\" = @IsFavorite WHERE \"Id\" = @Id";

            var param = new DynamicParameters();
            param.Add("CategoryName", entity.CategoryName, DbType.String);
            param.Add("CategoryDescription", entity.CategoryDescription, DbType.String);
            param.Add("IsFavorite", entity.IsFavorite, DbType.Boolean);   
            param.Add("Id", entity.Id, DbType.Guid);


            using (var context = CreateDbConnection())
            {
                return await context.QueryFirstOrDefaultAsync<CategoryProduct>(sql, param);
            }
            
        }
        catch (Exception exception)
        {
            throw new Exception(exception.Message, exception);
        }
    }

    public async Task<CategoryProduct> DeleteAsync(CategoryProduct entity)
    {
        try
        {
            var sql = "DELETE FROM \"CategoryProducts\" WHERE \"Id\" = @Id";

            var param = new DynamicParameters();
            param.Add("Id", entity.Id, DbType.Guid);

            using (var context = CreateDbConnection())
            {
                return await context.QueryFirstOrDefaultAsync<CategoryProduct>(sql, param);
            }
        }
        catch (Exception exception)
        {
            throw new Exception(exception.Message, exception);
        }
    }
}