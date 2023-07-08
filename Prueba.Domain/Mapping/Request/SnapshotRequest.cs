namespace Prueba.Domain.Mapping.Request;

public class SnapshotRequest
{
    public double temperature { get; set; }
    public double energy { get; set; }
    public int leakage { get; set; }
}