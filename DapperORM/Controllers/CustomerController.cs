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
    public class CustomerController : ControllerBase
    {
        private readonly ICustomerRepo _customerRepo;

        public CustomerController(ICustomerRepo customerRepo)
        {
            _customerRepo = customerRepo;
        }

        [HttpGet("allCustomers")]
        public async Task<ActionResult<Customers>> GellAll()
        {
            var customers = await _customerRepo.GetAllCustomers();
            return Ok(customers);
        }

        [HttpGet("customerById")]
        public async Task<ActionResult<Customers>> GetById(int id)
        {
            var customers = await _customerRepo.GetById(id);
            return Ok(customers);
        }
        [HttpPost("create")]
        public async Task<ActionResult> AddProduct(Customers entity)
        {
            await _customerRepo.AddCustomer(entity);
            return Ok(entity);
        }
        [HttpPut("update")]
        public async Task<ActionResult<Customers>> Update(Customers entity, int id)
        {
            await _customerRepo.UpdateCustomer(entity, id);
            return Ok(entity);
        }
        [HttpDelete("delete")]
        public async Task<ActionResult> Delete(int id)
        {
            await _customerRepo.RemoveCustomer(id);
            return Ok();
        }
    }
}
