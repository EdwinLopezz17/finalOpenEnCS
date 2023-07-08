using Prueba.Infraestructure.Models;

namespace Prueba.Infraestructure.Interfaces;

public interface ISnapshotInfrastructure
{
    List<Snapshot> GetAllByProductId(int id);
    public Snapshot Create(Snapshot snapshot);
}