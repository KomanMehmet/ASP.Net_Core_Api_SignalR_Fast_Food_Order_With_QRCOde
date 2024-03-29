﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SignalIR.BusinessLayer.Abstract;
using SignalIR.DataAccessLayer.Abstract;
using SignalIR.DtoLayer.CategoryDtos;
using SignalR.EntityLayer.Entities;

namespace SignalRApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private readonly ICategoryService _categoryService;

        public CategoriesController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        [HttpGet]
        public IActionResult CategoryList()
        {
            var values = _categoryService.TGetListAll();

            return Ok(values);
        }

        [HttpPost]
        public IActionResult CreateCategory(CreateCategoryDto createCategoryDto)
        {
            Category category = new Category{
                CategoryName = createCategoryDto.CategoryName,
                Status = createCategoryDto.Status
            };

            _categoryService.TAdd(category);

            return Ok("Category bilgisi eklendi");
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteCategory(int id)
        {
            var values = _categoryService.TGetById(id);

            _categoryService.TDelete(values);

            return Ok("Category bilgisi silindi");
        }

        [HttpPut]
        public IActionResult UpdateCategory(UpdateCategoryDto updateCategoryDto)
        {
            Category Category = new Category
            {
                CategoryID = updateCategoryDto.CategoryID,
                Status = updateCategoryDto.Status,
                CategoryName = updateCategoryDto.CategoryName
                
            };

            _categoryService.TUpdate(Category);

            return Ok("Category bilgisi güncellendi.");
        }

        [HttpGet("{id}")]
        public IActionResult GetCategory(int id)
        {
            var value = _categoryService.TGetById(id);

            return Ok(value);
        }

        [HttpGet("CategoryCount")]
        public IActionResult CategoryCount()
        {
            return Ok(_categoryService.TCategoryCount());
        }

        [HttpGet("GetActiveCategoryCount")]
        public IActionResult GetActiveCategoryCount()
        {
            return Ok(_categoryService.TActiveCategoryCount());
        }

        [HttpGet("GetPassiveCategoryCount")]
        public IActionResult GetPassiveCategoryCount()
        {
            return Ok(_categoryService.TPassiveCategoryCount());
        }
    }
}
