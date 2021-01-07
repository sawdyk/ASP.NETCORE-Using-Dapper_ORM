using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DapperORM.Services.Queries
{
    public interface ICustomerQuery
    {
        string GetCustomers { get; }
        string GetCustomerById { get; }
        string AddCustomer { get; }
        string UpdateCustomer { get; }
        string RemoveCustomer { get; }
        string CheckExistingCustomer { get; }
    }

    public class CustomerQuery : ICustomerQuery
    {
        public string GetCustomers => "Select * From Customers";
        public string GetCustomerById => "Select * From Customers Where Id= @Id";
        public string AddCustomer => "Insert Into  Customers (FirstName, LastName, PhoneNumber, EmailAddress) Values (@FirstName, @LastName, @PhoneNumber, @EmailAddress)";
        public string UpdateCustomer => "Update Customers set FirstName = @FirstName, LastName = @LastName, PhoneNumber = @PhoneNumber, EmailAddress = @EmailAddress Where Id =@Id";
        public string RemoveCustomer => "Delete From Customers Where Id= @Id";
        public string CheckExistingCustomer => "Select * From Customers Where EmailAddress= @EmailAddress";
    }
}
