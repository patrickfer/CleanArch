using AutoMapper;
using CleanArch.Application.DTOs;
using CleanArch.Application.Interfaces;
using CleanArch.Application.Products.Commands;
using CleanArch.Application.Products.Queries;
using CleanArch.Domain.Entities;
using CleanArch.Domain.Interfaces;
using MediatR;

namespace CleanArch.Application.Services
{
    public class ProductService : IProductService
    {
        private readonly IMapper _mapper;
        private readonly IMediator _mediator;
        public ProductService(IMapper mapper, IMediator mediator)
        {
            _mapper = mapper;
            _mediator = mediator;
        }
        public async Task<IEnumerable<ProductDTO>> GetAllProducts()
        {
            var productsQuery = new GetProductsQuery();

            if (productsQuery is null)
            {
                throw new Exception($"Entity could not be loaded");
            }

            var result = await _mediator.Send(productsQuery);

            return _mapper.Map<IEnumerable<ProductDTO>>(result);
        }

        public async Task<ProductDTO> GetById(int? id)
        {
            var productByIdQuery = new GetProductByIdQuery(id.Value);

            if (productByIdQuery is null)
            {
                throw new Exception($"Entity could not be loaded");
            }

            var result = await _mediator.Send(productByIdQuery);

            return _mapper.Map<ProductDTO>(result);
        }

        public async Task<IEnumerable<ProductDTO>> GetProductsByCategory(int? categoryId)
        {
            var productsByCategoryIdQuery = new GetProductsByCategoryQuery(categoryId.Value);

            if (productsByCategoryIdQuery is null)
            {
                throw new Exception($"Entity could not be loaded");
            }

            var result = await _mediator.Send(productsByCategoryIdQuery);

            return _mapper.Map<IEnumerable<ProductDTO>>(result);
        }

        public async Task Add(ProductDTO productDto)
        {
           var productCreateCommand = _mapper.Map<ProductCreateCommand>(productDto);
             await _mediator.Send(productCreateCommand);
        }


        public async Task Update(ProductDTO productDto)
        {
            var productUpdateCommand = _mapper.Map<ProductUpdateCommand>(productDto);
            await _mediator.Send(productUpdateCommand);
        }
        public async Task Delete(int? id)
        {
            var productRemoveCommand = _mapper.Map<ProductRemoveCommand>(id.Value);

            if (productRemoveCommand is null)
            {
                throw new Exception($"Entity could not be loaded");
            }

            await _mediator.Send(productRemoveCommand);
        }
    }
}
