using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Net;
using TeamSalesTrackerApi.Business.Queries;
using TeamSalesTrackerApi.Data;
using TeamSalesTrackerApi.Results.Products;

namespace TeamSalesTrackerApi.Business.Handlers
{
    public class GetAllProductHandler : IRequestHandler<GetAllProductsQuery, ProductsResult>
    {
        private readonly SalesTrackerDB _data;
        private readonly IMapper _mapper;
        public GetAllProductHandler(SalesTrackerDB data, IMapper mapper)
        {
            _data = data;
            _mapper = mapper;
        }
        public async Task<ProductsResult> Handle(GetAllProductsQuery request, CancellationToken cancellationToken)
        {
            var result = new ProductsResult();
            var products = await _data.Products.ToListAsync();
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
