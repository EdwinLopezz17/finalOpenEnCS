using AutoMapper;
using Prueba.Domain.Mapping.Request;
using Prueba.Infraestructure.Models;

namespace Prueba.Domain.Mapping.Response;

public class RequestToModel: Profile
{
    public RequestToModel()
    {
        CreateMap<ProductRequest, Product>();
        CreateMap<SnapshotRequest, Snapshot>();
    }
}