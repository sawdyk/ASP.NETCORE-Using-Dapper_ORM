using DapperORM.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DapperORM.Services
{
    public interface ICustomerRepo
    {
        ValueTask<Customers> GetById(int id);
        Task AddCustomer(Customers entity);
        Task UpdateCustomer(Customers entity, int id);
        Task RemoveCustomer(int id);
        Task<IEnumerable<Customers>> GetAllCustomers();
    }
}
