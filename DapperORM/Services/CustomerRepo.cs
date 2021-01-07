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
    public class CustomerRepo : BaseRepo, ICustomerRepo
    {

        private readonly ICustomerQuery _customerQuery;

        public CustomerRepo(IConfiguration configuration, ICustomerQuery customerQuery) : base(configuration)
        {
            _customerQuery = customerQuery;
        }

        public async Task AddCustomer(Customers entity)
        {
            await WithConnection(async conn =>
            {
                var query = await conn.QueryFirstOrDefaultAsync<Customers>(_customerQuery.CheckExistingCustomer, new { EmailAddress = entity.EmailAddress });

                if (query == null)
                {
                   await conn.ExecuteAsync(_customerQuery.AddCustomer,
                   new
                   {
                       FirstName = entity.FirstName,
                       LastName = entity.LastName,
                       PhoneNumber = entity.PhoneNumber,
                       EmailAddress = entity.EmailAddress
                   });
                }
            });

        }

        public async Task<IEnumerable<Customers>> GetAllCustomers()
        {
            return await WithConnection(async conn =>
            {
                var query = await conn.QueryAsync<Customers>(_customerQuery.GetCustomers);
                return query;
            });
        }

        public async ValueTask<Customers> GetById(int id)
        {
            return await WithConnection(async conn =>
            {
                var query = await conn.QueryFirstOrDefaultAsync<Customers>(_customerQuery.GetCustomerById, new { Id = id });
                return query;
            });
        }

        public async Task RemoveCustomer(int id)
        {
            await WithConnection(async conn =>
            {
                await conn.ExecuteAsync(_customerQuery.RemoveCustomer, new { Id = id });
            });
        }

        public async Task UpdateCustomer(Customers entity, int id)
        {
            await WithConnection(async conn =>
            {
                await conn.ExecuteAsync(_customerQuery.UpdateCustomer,
                    new
                    {
                        FirstName = entity.FirstName,
                        LastName = entity.LastName,
                        PhoneNumber = entity.PhoneNumber,
                        EmailAddress = entity.EmailAddress,
                        Id = id
                    });
            });
        }
    }
}
