using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Keiko.Application.Interfaces.Repository;
using Keiko.Domain.Models.Product;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Persistence.Repository;

namespace WebApi
{
    public static class Program
    {
        // ICategoryRepository _repository;
        //
        // public Program(ICategoryRepository repository)
        // {
        //     _repository = repository;
        // }
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }
        
        //Create
        // CategoryProduct categoryProduct = new CategoryProduct 
        // {
        //     Id = Guid.NewGuid(),
        //     CategoryName = "Tea",
        //     CategoryDescription = "Good tea",
        //     IsFavorite = true
        // };
        
        // Console.WriteLine(categoryProduct.Id);
        
        // CategoryRepository _categoryRepository = new CategoryRepository();
        // _categoryRepository.Creare(product);

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder => { webBuilder.UseStartup<Startup>(); });
    }
}