using AutoMapper;
using CleanArchitecture.Application.DTOs;
using CleanArchitecture.Application.Interfaces;
using CleanArchitecture.Domain.Entities;
using CleanArchitecture.Domain.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CleanArchitecture.Application.Services
{
    public class CategoryService: ICategoryService
    {
        private readonly ICategoryRepository _categoryRepository;
        private readonly IMapper _mapper;

        public CategoryService(ICategoryRepository categoryRepository, IMapper mapper) 
        {
            _categoryRepository = categoryRepository;
            _mapper = mapper;
        }

        public async Task Add(CategoryDTO categoryDto)
        {
            var categoryEntity = _mapper.Map<Category>(categoryDto);
            await _categoryRepository.CreateAsync(categoryEntity);
        }

        public async Task<CategoryDTO> GetById(int? id)
        {
            var categoryEntity = await _categoryRepository.GetByIdAsync(id);

            return _mapper.Map<CategoryDTO>(categoryEntity);
        }

        public async Task<IEnumerable<CategoryDTO>> GetCategories()
        {
            var categoriesEntity = await _categoryRepository.GetCategoriesAsync();

            return _mapper.Map<IEnumerable<CategoryDTO>>(categoriesEntity);
        }

        public async Task Remove(int? id)
        {
            var categoryEntity = await _categoryRepository.GetByIdAsync(id);

            await _categoryRepository.RemoveAsync(categoryEntity);
        }

        public async Task Update(CategoryDTO categoryDto)
        {
            var categoryEntity = _mapper.Map<Category>(categoryDto);

            await _categoryRepository.UpdateAsync(categoryEntity);
        }
    }
}
