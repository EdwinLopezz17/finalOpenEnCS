using AutoMapper;
using Prueba.Domain.Interfaces;
using Prueba.Domain.Mapping.Request;
using Prueba.Domain.Mapping.Response;
using Prueba.Infraestructure.Interfaces;
using Prueba.Infraestructure.Models;

namespace Prueba.Domain;

public class ProductDomain: IProductDomain
{
    private IProductInfrastructure _productInfrastructure;
    private IMapper _mapper;
    
    public ProductDomain(IProductInfrastructure productInfrastructure, IMapper mapper)
    {
        _productInfrastructure = productInfrastructure;
        _mapper = mapper;
    }

    public ProductResponse GetById(int id)
    {
        Product product = _productInfrastructure.GetById(id);
        return _mapper.Map<Product, ProductResponse>(product);
    }

    public Product Create(ProductRequest productRequest)
    {
        Product product = _mapper.Map<ProductRequest, Product>(productRequest);
        return _productInfrastructure.Create(product);
    }
}