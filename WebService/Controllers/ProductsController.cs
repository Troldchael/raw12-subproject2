using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using DataServiceLib;
using Microsoft.AspNetCore.Mvc;
using WebService.Models;

namespace WebService.Controllers
{
    [ApiController]
    [Route("api/products")]
    public class ProductsController : ControllerBase
    {
        private readonly IDataService _dataService;
        private readonly IMapper _mapper;

        public ProductsController(IDataService dataService, IMapper mapper)
        {
            _dataService = dataService;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult GetProducts(int page = 0, int pageSize = 10)
        {
            var products = _dataService.GetProducts(page, pageSize);

            var items = products.Select(CreateProductElementDto);

            
            return Ok(items);
        }

        [HttpGet("{id}", Name = nameof(GetProduct))]
        public IActionResult GetProduct(int id)
        {
            var product = _dataService.GetProduct(id);
            if (product == null)
            {
                return NotFound();
            }

            var dto = _mapper.Map<ProductDetailsDto>(product);
            dto.Url = Url.Link(nameof(GetProduct), new { id });
            dto.CategoryUrl = Url.Link(nameof(CategoriesController.GetCategory), new { Id = product.Category.Id });

            return Ok(dto);
        }


        private ProductListElementDto CreateProductElementDto(Product product)
        {
            var dto = _mapper.Map<ProductListElementDto>(product);
            dto.Url = Url.Link(nameof(GetProduct), new {product.Id});
            return dto;
        }

    }
}
