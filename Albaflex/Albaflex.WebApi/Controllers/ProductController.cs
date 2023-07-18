using Albaflex.CrossCutting.Models;
using Albaflex.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Albaflex.WebApi.Controllers
{
    [Route("api/v1/product")]
    [ApiController]
    public class ProductController
    {
        private readonly IProductService _productService;

        public ProductController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpPost]
        public async Task Post([FromBody] CreateProductInputModel body)
            => await _productService.CreateAsync(body);
    }
}
