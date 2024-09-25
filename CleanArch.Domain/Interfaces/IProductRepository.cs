using CleanArch.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArch.Domain.Interfaces
{
    public interface IProductRepository :IRepository<Product>
    {
        Task<IEnumerable<Product>> GetProductsByCategoryAsync(int? id);
    }
}
