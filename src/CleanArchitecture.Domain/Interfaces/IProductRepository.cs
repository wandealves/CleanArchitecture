using System.Collections.Generic;
using System.Threading.Tasks;
using CleanArchitecture.Domain.Entities;

namespace CleanArchitecture.Domain.Interfaces
{
    public interface IProductRepository
    {
        Task<Product> GetByIdAsync(int? id);
        Task<IEnumerable<Product>> GetProductsAsync();
        Task<Product> CreateAsync(Product product);
        Task<Product> UpdateAsync(Product product);
        Task<Product> RemoveAsync(Product product);
    }
}