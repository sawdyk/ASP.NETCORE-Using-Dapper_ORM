using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DapperORM.Entities;
using DapperORM.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DapperORM.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductRepo _productRepo;

        public ProductController(IProductRepo productRepo)
        {
            _productRepo = productRepo;
        }

        [HttpGet("allProducts")]
        public async Task<ActionResult<Products>> GellAll()
        {
            var products = await _productRepo.GetAllProducts();
            return Ok(products);
        }

        [HttpGet("productById")]
        public async Task<ActionResult<Products>> GetById(int id)
        {
            var product = await _productRepo.GetById(id);
            return Ok(product);
        }
        [HttpPost("create")]
        public async Task<ActionResult> AddProduct(Products entity)
        {
            await _productRepo.AddProduct(entity);
            return Ok(entity);
        }
        [HttpPut("update")]
        public async Task<ActionResult<Products>> Update(Products entity, int id)
        {
            await _productRepo.UpdateProduct(entity, id);
            return Ok(entity);
        }
        [HttpDelete("delete")]
        public async Task<ActionResult> Delete(int id)
        {
            await _productRepo.RemoveProduct(id);
            return Ok();
        }
    }
}
