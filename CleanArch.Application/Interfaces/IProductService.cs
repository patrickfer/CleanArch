using CleanArch.Application.DTOs;

namespace CleanArch.Application.Interfaces
{
    public interface IProductService
    {
        Task<IEnumerable<ProductDTO>> GetAllProducts();
        Task<ProductDTO> GetById(int? id);
        Task<IEnumerable<ProductDTO>> GetProductsByCategory(int? categoryId);
        Task Add(ProductDTO productDto);
        Task Update(ProductDTO productDto);
        Task Delete(int? id);
    }
}
