using CaseStudy.API.Controllers;
using CaseStudy.Core.DTOs;
using CaseStudy.Core.Services;
using CaseStudy.Service.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace CaseStudy.WebApi.Controllers
{
    public class ProductController : CustomBaseController
    {
        private readonly IProductService _productService;

        public ProductController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpGet]
        [Route("[action]")]
        public async Task<IActionResult> List()
        {
            var result = await _productService.GetAllProducts();
            return CreateActionResult(CustomResponseDto<List<ProductDto>>.Success(HttpStatusCode.OK, result));
        }

        [HttpGet]
        [Route("[action]/{id}")]
        public async Task<IActionResult> Detail(int id)
        {
            var result = await _productService.GetProductById(id);
            return CreateActionResult(CustomResponseDto<ProductDto>.Success(HttpStatusCode.OK, result));
        }
    }
}
