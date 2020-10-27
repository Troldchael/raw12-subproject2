using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataServiceLib;
using Microsoft.AspNetCore.Mvc;

namespace WebService.Controllers
{
    [ApiController]
    public class CategoriesController : ControllerBase
    {


        [HttpGet("api/categories")]
        public IActionResult GetCategories()
        {
            var ds = new DataService();
            var categories = ds.GetCategories();

            return Ok(categories);
        }

        [HttpGet("api/categories/{id}")]
        public IActionResult GetCategory(int id)
        {
            var ds = new DataService();
            var category = ds.GetCategory(id);
            if (category == null)
            {
                return NotFound();
            }

            return Ok(category);
        }
    }
}
