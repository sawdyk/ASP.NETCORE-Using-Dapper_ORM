using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DapperORM.Services.Queries
{
    public interface ICommandText
    {
        string GetProducts { get; }
        string GetProductById { get; }
        string AddProduct { get; }
        string UpdateProduct { get; }
        string RemoveProduct { get; }
    }

    public class CommandText : ICommandText
    {
        public string GetProducts => "Select * From Products";
        public string GetProductById => "Select * From Products Where Id= @Id";
        public string AddProduct => "Insert Into  Products (Name, Cost, CreatedDate) Values (@Name, @Cost, @CreatedDate)";
        public string UpdateProduct => "Update Products set Name = @Name, Cost = @Cost, CreatedDate = GETDATE() Where Id =@Id";
        public string RemoveProduct => "Delete From Products Where Id= @Id";
    }
}
