using CleanArch.Application.DTOs;

namespace CleanArch.Application.Interfaces
{
    public interface ICategoryService
    {
        Task<IEnumerable<CategoryDTO>> GetAllCategories();
        Task<CategoryDTO> GetById (int? id);
        Task Add (CategoryDTO categoryDto);
        Task Update(CategoryDTO categoryDto);
        Task Delete(int? id);
    }
}
