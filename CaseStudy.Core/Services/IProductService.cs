using CaseStudy.Core.DTOs;
using CaseStudy.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CaseStudy.Core.Services
{
    public interface IProductService
    {
        Task<List<ProductDto>> GetAllProducts();
        Task<ProductDto> GetProductById(int id);
    }
}
