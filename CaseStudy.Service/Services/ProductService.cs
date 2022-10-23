using AutoMapper;
using CaseStudy.Core.DTOs;
using CaseStudy.Core.Models;
using CaseStudy.Core.Repositories;
using CaseStudy.Core.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CaseStudy.Service.Services
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _productRepository;

        private readonly IMapper _mapper;

        public ProductService(IProductRepository productRepository, IMapper mapper)
        {
            _productRepository = productRepository;
            _mapper = mapper;
        }

        public async Task<List<ProductDto>> GetAllProducts()
        {
            var result = await _productRepository.GetAllProducts();
            return _mapper.Map<List<ProductDto>>(result);
        }

        public async Task<ProductDto> GetProductById(int id)
        {
            var result = await _productRepository.GetProductById(id);
            return _mapper.Map<ProductDto>(result);
        }
    }
}
