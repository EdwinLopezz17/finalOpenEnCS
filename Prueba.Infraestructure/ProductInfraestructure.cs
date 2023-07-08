using Prueba.Infraestructure.Context;
using Prueba.Infraestructure.Interfaces;
using Prueba.Infraestructure.Models;

namespace Prueba.Infraestructure;

public class ProductInfraestructure: IProductInfrastructure
{
    private PruebaDBContext _pruebaDbContext;
    
    public ProductInfraestructure(PruebaDBContext context)
    {
        _pruebaDbContext = context;
    }

    
    public Product GetById(int id)
    {
        return _pruebaDbContext.Products.Find(id);
    }

    public Product Create(Product product)
    {
        _pruebaDbContext.Products.Add(product);
        _pruebaDbContext.SaveChanges();
        return product;
    }
}