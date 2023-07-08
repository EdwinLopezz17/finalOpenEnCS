using AutoMapper;
using Prueba.Domain.Interfaces;
using Prueba.Domain.Mapping.Request;
using Prueba.Infraestructure.Interfaces;
using Prueba.Infraestructure.Models;

namespace Prueba.Domain;

public class SnapshotDomain: ISnapshotDomain
{
    private ISnapshotInfrastructure _snapshotInfrastructure;
    private IProductInfrastructure _productInfrastructure;
    private IMapper _mapper;
    
    public SnapshotDomain(ISnapshotInfrastructure snapshotInfrastructure, IMapper mapper, IProductInfrastructure productInfrastructure)
    {
        _snapshotInfrastructure = snapshotInfrastructure;
        _mapper = mapper;
        _productInfrastructure = productInfrastructure;
    }

    public Snapshot Create(SnapshotRequest snapshotRequest, int productId)
    {
        Product product = _productInfrastructure.GetById(productId);
        Snapshot snapshot = _mapper.Map<SnapshotRequest, Snapshot>(snapshotRequest);
        /*Snapshot snapshot = new Snapshot()
        {
            temperature = snapshotRequest.temperature,
            energy = snapshotRequest.energy,
            leakage = snapshotRequest.leakage,
        };*/
        snapshot.productSerialNumber = product.serialNumber;
        return _snapshotInfrastructure.Create(snapshot);
    }

    public List<Snapshot> GetSnapshotsByProductId(int id)
    {
        return _snapshotInfrastructure.GetAllByProductId(id);
    }
}