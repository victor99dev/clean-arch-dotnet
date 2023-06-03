using Application.DTOs;
using Application.Interfaces;
using AutoMapper;
using Domain.Entities;
using Domain.Interfaces;

namespace Application.Services
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _productRepository;
        private readonly IMapper _mapper;
        public ProductService(IProductRepository productRepository, IMapper mapper)
        {
            _productRepository = productRepository ??
                throw new ArgumentNullException(nameof(productRepository)); 
            _mapper = mapper;
        }

        public async Task<IEnumerable<ProductDTO>> GetProductsAsync()
        {
            var productsEntity = await _productRepository.GetProductsAsync();
            return _mapper.Map<IEnumerable<ProductDTO>>(productsEntity);
        }

        public async Task<ProductDTO> GetByIdAsync(string? id)
        {
            var productEntity = await _productRepository.GetByIdAsync(id);
            return _mapper.Map<ProductDTO>(productEntity);
        }

        public async Task<ProductDTO> GetProductCategoryAsync(string? id)
        {
            var productEntity = await _productRepository.GetProductCategoryAsync(id);
            return _mapper.Map<ProductDTO>(productEntity);
        }

        public async Task CreateAsync(ProductDTO productDTO)
        {
            var productEntity = _mapper.Map<Product>(productDTO);
            await _productRepository.CreateAsync(productEntity);
        }

        public async Task UpdateAsync(ProductDTO productDTO)
        {
             var productEntity = _mapper.Map<Product>(productDTO);
            await _productRepository.CreateAsync(productEntity);
        }

        public async Task RemoveAsync(string? id)
        {
             var productEntity = _productRepository.GetByIdAsync(id).Result;
            await _productRepository.RemoveAsync(productEntity);
        }
    }
}