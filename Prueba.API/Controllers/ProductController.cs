using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Prueba.Domain.Interfaces;
using Prueba.Domain.Mapping.Request;
using Prueba.Domain.Mapping.Response;
using Prueba.Infraestructure.Models;
using SnapshotRequest = Prueba.Domain.Mapping.Request.SnapshotRequest;

namespace Prueba.API.Controllers
{
    [Route("api/v1/products")]
    [ApiController]
    public class ProductController : ControllerBase
    {

        private IProductDomain _productDomain;
        private ISnapshotDomain _snapshotDomain;
        private IMapper _mapper;
        
        public ProductController(IProductDomain productDomain, IMapper mapper, ISnapshotDomain snapshotDomain)
        {
            _productDomain = productDomain;
            _snapshotDomain = snapshotDomain;
            _mapper = mapper;
        }

        // GET: api/v1/products/{id}
        [HttpGet("{id}", Name = "Get")]
        public ProductResponse Get(int id)
        {
            return _productDomain.GetById(id);
        }

        // POST: api/v1/products
        [HttpPost]
        public Product Post([FromBody] ProductRequest productRequest)
        {
            return _productDomain.Create(productRequest);
        }

        // POST: api/v1/products/{productId}/snapshots
        [HttpPost("{productId}/snapshots")]
        public Snapshot AddSnapshot(int productId, [FromBody] SnapshotRequest snapshotRequest)
        {
            return _snapshotDomain.Create(snapshotRequest, productId);
        }
        
        // GET: api/v1/products/{productId}/snapshots
        [HttpGet("{productId}/snapshots")]
        public List<Snapshot> GetSnapshots(int productId)
        {
            return _snapshotDomain.GetSnapshotsByProductId(productId);
        }
        

    }
}
