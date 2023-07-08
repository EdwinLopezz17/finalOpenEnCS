using Prueba.Infraestructure.Models;

namespace Prueba.Infraestructure.Interfaces;

public interface IProductInfrastructure
{
    public Product GetById(int id);
    public Product Create(Product product);
}