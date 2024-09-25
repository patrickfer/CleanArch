using CleanArch.Application.Products.Commands;
using CleanArch.Domain.Entities;
using CleanArch.Domain.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArch.Application.Products.Handlers
{
    public class ProductRemoveCommandHandler : IRequestHandler<ProductRemoveCommand, Product>
    {
        private readonly IProductRepository _productRepository;

        public ProductRemoveCommandHandler(IProductRepository productRepository)
        {
            _productRepository = productRepository ?? throw new
                   ArgumentNullException(nameof(productRepository));
        }

        public async Task<Product> Handle (ProductRemoveCommand request, CancellationToken cancellationToken)
        {
            var product = _productRepository.GetAsync(p => p.Id == request.Id);

            if (product is null) 
            {
                throw new ApplicationException($"Error could not be found");
            }
            else
            {
                var result = await _productRepository.DeleteAsync(product.Result);
                return result;
            }
        }
    }
}
