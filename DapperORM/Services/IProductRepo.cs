using DapperORM.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DapperORM.Services
{
    public interface IProductRepo
    {
        ValueTask<Products> GetById(int id);
        Task AddProduct(Products entity);
        Task UpdateProduct(Products entity, int id);
        Task RemoveProduct(int id);
        Task<IEnumerable<Products>> GetAllProducts();
    }
}
