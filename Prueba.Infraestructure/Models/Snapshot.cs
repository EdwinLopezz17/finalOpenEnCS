namespace Prueba.Infraestructure.Models;

public class Snapshot
{
   public int id { get; set; }
   public string productSerialNumber { get; set; }
   public double temperature { get; set; }
   public double energy { get; set; }
   public int leakage { get; set; }
}