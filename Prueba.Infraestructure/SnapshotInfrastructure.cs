using Prueba.Infraestructure.Context;
using Prueba.Infraestructure.Interfaces;

namespace Prueba.Infraestructure.Models;

public class SnapshotInfrastructure : ISnapshotInfrastructure
{
    private PruebaDBContext _pruebaDbContext;
    private IProductInfrastructure _productInfraestructure;
    
    public SnapshotInfrastructure(PruebaDBContext context, IProductInfrastructure productInfraestructure)
    {
        _pruebaDbContext = context;
        _productInfraestructure = productInfraestructure;
    }

    public List<Snapshot> GetAllByProductId(int id)
    {
        Product product = _productInfraestructure.GetById(id);

        return _pruebaDbContext.Snapshots.Where(s => s.productSerialNumber == product.serialNumber).ToList();
    }

    public Snapshot Create(Snapshot snapshot)
    {
        _pruebaDbContext.Snapshots.Add(snapshot);
        _pruebaDbContext.SaveChanges();
        return snapshot;
    }
}