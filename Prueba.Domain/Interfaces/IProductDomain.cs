using Prueba.Domain.Mapping.Request;
using Prueba.Domain.Mapping.Response;
using Prueba.Infraestructure.Models;

namespace Prueba.Domain.Interfaces;

public interface IProductDomain
{
    public ProductResponse GetById(int id);
    public Product Create(ProductRequest productRequest);
}