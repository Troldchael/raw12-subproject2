using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using DataServiceLib.Framework;
using Microsoft.AspNetCore.Mvc;
using WebService.Models;

namespace WebService.Controllers
{
    // henrik example

    /*[ApiController]
    [Route("api/products")]
    public class ProductsController : ControllerBase
    {
        private readonly IDataService _dataService;
        private readonly IMapper _mapper;
        private const int MaxPageSize = 25;

        public ProductsController(IDataService dataService, IMapper mapper)
        {
            _dataService = dataService;
            _mapper = mapper;
        }

        [HttpGet(Name = nameof(GetProducts))]
        public IActionResult GetProducts(int page = 0, int pageSize = 10)
        {
            pageSize = CheckPageSize(pageSize);

            var products = _dataService.GetProducts(page, pageSize);

            var result = CreateResult(page, pageSize, products);

            return Ok(result);
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


        private ExampleDto CreateProductElementDto(Product product)
        {
            var dto = _mapper.Map<ExampleDto>(product);
            dto.Url = Url.Link(nameof(GetProduct), new { product.Id });
            return dto;
        }

        
        
         //Helpers


        private int CheckPageSize(int pageSize)
        {
            return pageSize > MaxPageSize ? MaxPageSize : pageSize;
        }

        private (string prev, string cur, string next) CreatePagingNavigation(int page, int pageSize, int count)
        {
            string prev = null;

            if (page > 0)
            {
                prev = Url.Link(nameof(GetProducts), new { page = page - 1, pageSize });
            }

            string next = null;

            if (page < (int)Math.Ceiling((double)count / pageSize) - 1)
                next = Url.Link(nameof(GetProducts), new { page = page + 1, pageSize });

            var cur = Url.Link(nameof(GetProducts), new { page, pageSize });

            return (prev, cur, next);
        }

        private object CreateResult(int page, int pageSize, IList<Product> products)
        {
            var items = products.Select(CreateProductElementDto);

            var count = _dataService.NumberOfProducts();

            var navigationUrls = CreatePagingNavigation(page, pageSize, count);


            var result = new
            {
                navigationUrls.prev,
                navigationUrls.cur,
                navigationUrls.next,
                count,
                items
            };
            return result;
    */
        


    
}
