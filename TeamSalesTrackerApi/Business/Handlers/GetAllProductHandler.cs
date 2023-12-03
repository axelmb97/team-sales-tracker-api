using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Net;
using TeamSalesTrackerApi.Business.Queries;
using TeamSalesTrackerApi.Data;
using TeamSalesTrackerApi.Results.Products;
using TeamSalesTrackerApi.Services.Interfaces;

namespace TeamSalesTrackerApi.Business.Handlers
{
    public class GetAllProductHandler : IRequestHandler<GetAllProductsQuery, ProductsResult>
    {
        private readonly IProductService _productService;
        public GetAllProductHandler(IProductService productService)
        {
            _productService = productService;
        }

        public async Task<ProductsResult> Handle(GetAllProductsQuery request, CancellationToken cancellationToken)
        {
            var result = new ProductsResult();
            var products = await _productService.GetAll();
            if (products == null) {
                result.SetError("No se encuentran productos disponibles", HttpStatusCode.NotFound);
                return result;
            }

            result.Products = products;
            result.Message = "Productos recuperados con éxitos";

            return result;
        }
    }
}
