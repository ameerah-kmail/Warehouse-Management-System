using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using WarehouseManagement.Entits;
using WarehouseManagement.Models;
using WarehouseManagement.Services;

namespace WarehouseManagement.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class PackagesController : ControllerBase
    {
        private readonly IPackageRepository _repository;
        private IMapper _mapper;
        public PackagesController(IPackageRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        
        [HttpGet("~/Get All Packages In")]
        public async Task<ActionResult<List<Package>>> GetAllPackagesIn()
        {
            return Ok(await _repository.GetAllPackagesIn());
        }
        [HttpGet("~/Get All Packages Out")]
        public async Task<ActionResult<List<Package>>> GetAllPackagesout()
        {
            return Ok(await _repository.GetAllPackagesOut());
        }
        [HttpGet("~/Get All Warehouse Location In Certain Period")]
        public async Task<ActionResult<List<WarehouseLocation>>> GetAllPackagesInCertainPeriod(DateTime periodStart, DateTime periodEnd)
        {
            return Ok(await _repository.GetAllPackagesInCertainPeriod(periodStart, periodEnd));
        }
    }
}
