﻿namespace Prueba.Domain.Mapping.Request;

public class ProductRequest
{
    public string brand { get; set; }
    public string model { get; set; }
    public string serialNumber { get; set; }
    public int monitoringLevel { get; set; }
}