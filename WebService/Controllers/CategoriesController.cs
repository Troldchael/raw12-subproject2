using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataServiceLib;
using Microsoft.AspNetCore.Mvc;
using WebService.Models;

namespace WebService.Controllers
{
    [ApiController]
    [Route("api/categories")]
    public class CategoriesController : ControllerBase
    {
        IDataService _dataService;

        public CategoriesController(IDataService dataService)
        {
            _dataService = dataService;
        }

        [HttpGet]
        public IActionResult GetCategories()
        {
            
            var categories = _dataService.GetCategories();

            return Ok(categories);
        }

        [HttpGet("{id}")]
        public IActionResult GetCategory(int id)
        {
            var category = _dataService.GetCategory(id);
            if (category == null)
            {
                return NotFound();
            }

            return Ok(category);
        }

        [HttpPost]
        public IActionResult CreateCategory(CategoryForCreationOrUpdateDto categoryOrUpdateDto)
        {
            var category = new Category
            {
                Name = categoryOrUpdateDto.Name,
                Description = categoryOrUpdateDto.Description
            };
            _dataService.CreateCategory(category);

            return Created("", category);
        }

        [HttpPut("{id}")]
        public IActionResult UpdateCategory(int id, CategoryForCreationOrUpdateDto categoryOrUpdateDto)
        {
            var category = new Category
            {
                Id = id,
                Name = categoryOrUpdateDto.Name,
                Description = categoryOrUpdateDto.Description
            };

            if (!_dataService.UpdateCategory(category))
            {
                return NotFound();
            }

            return NoContent();

        }

        [HttpDelete("{id}")]
        public IActionResult DeleteCategory(int id)
        {

        }
    }
}
