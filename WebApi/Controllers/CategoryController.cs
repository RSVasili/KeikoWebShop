using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using Keiko.Application.Interfaces.Repository;
using Keiko.Domain.Models.Product;
using Microsoft.AspNetCore.Mvc;
using Persistence.Repository;

namespace WebApi.Controllers;

public class CategoryController : Controller
{
    private readonly KeikoDbContext _dbContext;
    private readonly ICategoryRepository _repository;

    public CategoryController(KeikoDbContext dbContext, ICategoryRepository repository)
    {
        _dbContext = dbContext;
        _repository = repository;
    }

    public async Task<IActionResult> Index()
    {
        // await List<CategoryProduct> categoryProductsList = _repository.FindAllAsync();
        // IEnumerable<CategoryProduct> categoryProductsList = _dbContext.CategoryProducts;
        return View(await _repository.FindAllAsync());
    }

    //GET - CREATE
    public IActionResult Create()
    {
        return View();
    }


    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create(CategoryProduct categoryProduct)
    {
        try
        {
            if (ModelState.IsValid)
            {
                await _repository.InsertAsync(categoryProduct);
                return RedirectToAction(nameof(Index));
            }

            // if (ModelState.IsValid)
            // {
            //     await _dbContext.CategoryProducts.AddAsync(categoryProduct);
            //     await _dbContext.SaveChangesAsync();
            //     // await _repository.Insert(categoryProduct);
            //     return RedirectToAction(nameof(Index));
            // }
        }
        catch (Exception exception)
        {
            throw new Exception(exception.Message, exception);
        }

        return View();
    }


    public async Task<IActionResult> Edit(Guid id)
    {
        try
        {
            var entity = await _repository.FindByIdAsync(id);

            if (ModelState.IsValid)
            {
                return View(entity);
            }

            return NotFound();
        }
        catch (Exception exception)
        {
            throw new Exception(exception.Message, exception);
        }
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(CategoryProduct categoryProduct)
    {
        try
        {
            if (await TryUpdateModelAsync(categoryProduct))
            {
                await _repository.EditAsync(categoryProduct);
                return RedirectToAction(nameof(Index));
            }
        }
        catch (Exception exception)
        {
            throw new Exception(exception.Message, exception);
        }

        return View(categoryProduct);
    }

    public async Task<IActionResult> Delete(Guid id)
    {
        try
        {
            if (id == Guid.Empty)
            {
                return NotFound();
            }

            var entity = await _repository.FindByIdAsync(id);

            if (ModelState.IsValid)
            {
                return View(entity);
            }

            return View(entity);
        }
        catch (Exception exception)
        {
            throw new Exception(exception.Message, exception);
        }
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> DeletePost(Guid id)
    {
        try
        {
            var entity = await _repository.FindByIdAsync(id);
            if (ModelState.IsValid)
            {
                await _repository.DeleteAsync(entity);
                return RedirectToAction(nameof(Index));
            }

            return View(nameof(Delete));
        }
        catch (Exception exception)
        {
            throw new Exception(exception.Message, exception);
        }
    }
}