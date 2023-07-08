using Prueba.Domain.Mapping.Request;
using Prueba.Infraestructure.Models;

namespace Prueba.Domain.Interfaces;

public interface ISnapshotDomain
{
    public Snapshot Create(SnapshotRequest snapshotRequest, int productId);
    public List<Snapshot> GetSnapshotsByProductId(int id);
}