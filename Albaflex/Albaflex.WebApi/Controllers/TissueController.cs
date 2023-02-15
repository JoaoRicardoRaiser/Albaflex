using Albaflex.CrossCutting.Models;
using Albaflex.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Albaflex.WebApi.Controllers
{
    [Route("api/v1/product")]
    [ApiController]
    public class TissueController
    {
        private readonly ITissueService _productService;

        public TissueController(ITissueService productService)
        {
            _productService = productService;
        }

        [HttpPost]
        public async Task Post([FromBody] CreateTissueInputModel body)
        {
            await _productService.CreateAsync(body);
        }
    }
}
