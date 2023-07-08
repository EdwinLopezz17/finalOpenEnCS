using AutoMapper;
using Prueba.Domain.Mapping.Response;
using Prueba.Infraestructure.Models;

namespace Prueba.Domain.Mapping;

public class ModelToResponse : Profile
{
    public ModelToResponse()
    {
        CreateMap<Product, ProductResponse>();
        CreateMap<Snapshot, SnapshotResponse>();
    }
}