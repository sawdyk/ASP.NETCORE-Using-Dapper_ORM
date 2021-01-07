using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dapper;
using DapperORM.Entities;
using DapperORM.Services.Queries;
using Microsoft.Extensions.Configuration;

namespace DapperORM.Services
{
    public class ProductRepo : BaseRepo, IProductRepo
    {
        private readonly ICommandText _commandText;

        public ProductRepo(IConfiguration configuration, ICommandText commandText) : base(configuration)
        {
            _commandText = commandText;

        }
        public async Task<IEnumerable<Products>> GetAllProducts()
        {
            return await WithConnection(async conn =>
            {
                var query = await conn.QueryAsync<Products>(_commandText.GetProducts);
                return query;
            });

        }

        public async ValueTask<Products> GetById(int id)
        {
            return await WithConnection(async conn =>
            {
                var query = await conn.QueryFirstOrDefaultAsync<Products>(_commandText.GetProductById, new { Id = id });
                return query;
            });

        }

        public async Task AddProduct(Products entity)
        {
            await WithConnection(async conn =>
            {
                await conn.ExecuteAsync(_commandText.AddProduct,
                    new { Name = entity.Name, Cost = entity.Cost, CreatedDate = entity.CreatedDate });
            });

        }
        public async Task UpdateProduct(Products entity, int id)
        {
            await WithConnection(async conn =>
            {
                await conn.ExecuteAsync(_commandText.UpdateProduct,
                    new { Name = entity.Name, Cost = entity.Cost, Id = id });
            });
        }

        public async Task RemoveProduct(int id)
        {
            await WithConnection(async conn =>
            {
                await conn.ExecuteAsync(_commandText.RemoveProduct, new { Id = id });
            });
        }

    }
}
