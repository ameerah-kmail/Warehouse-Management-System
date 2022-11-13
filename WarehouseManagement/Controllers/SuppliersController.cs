using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using WarehouseManagement.Entits;
using WarehouseManagement.Models;
using WarehouseManagement.Services;

namespace WarehouseManagement.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class SuppliersController : ControllerBase
    {
        private readonly ISupplierRepository _repository;
        private IMapper _mapper;
        public SuppliersController(ISupplierRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        [HttpGet("{supplierId}")]
        public async Task<ActionResult<List<Package>>> GetPackagesForSupplier(int supplierId)
        {
            if (!await _repository.AnySupplierExists(supplierId))
                return NotFound();
            var packagesForSupplierEntity = _repository
                .GetPackagesForSupplier(supplierId);
           // return Ok(_mapper.Map<List<PackageDto>>(packagesForSupplierEntity));
            return Ok((packagesForSupplierEntity));

        }
    }
}
