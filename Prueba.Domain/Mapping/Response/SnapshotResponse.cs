namespace Prueba.Domain.Mapping.Response;

public class SnapshotResponse
{
    public string productSerialNumber { get; set; }
    public double temperature { get; set; }
    public double energy { get; set; }
    public int leakage { get; set; }
}