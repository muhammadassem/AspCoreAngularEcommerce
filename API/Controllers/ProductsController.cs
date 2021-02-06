using System.Collections.Generic;
using System.Threading.Tasks;
using API.DTOs;
using AutoMapper;
using Core.Entities;
using Core.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductsController : ControllerBase
    {
        private readonly IProductRepository _productRepo;
        private IMapper _mapper;

        public ProductsController(IProductRepository productRepo, IMapper mapper)
        {
            _productRepo = productRepo;
            _mapper = mapper;
        }
        [HttpGet]
        public async Task<ActionResult<List<Product>>> GetProducts([FromQuery] ProductQueryDto filterDto)
        {
            var filter = _mapper.Map<ProductQueryDto, ProductQuery>(filterDto);
            var products = await _productRepo.GetAllProducts(filter);
            return Ok(_mapper.Map<QueryResult<Product>, QueryResultDto<ProductDto>>(products));
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<Product>> GetProduct(int id)
        {
            var product = await _productRepo.GetByIdAsync(id);
            return Ok(product);
        }
        //[HttpGet("brands")]
        //public async Task<ActionResult<ProductBrand>> GetProductBrands()
        //{
        //    return Ok(await _productRepo.GetProductBrandsAsync());
        //}
        //[HttpGet("types")]
        //public async Task<ActionResult<ProductType>> GetProductTypes()
        //{
        //    return Ok(await _productRepo.GetProductTypesAsync());
        //}

    }
}