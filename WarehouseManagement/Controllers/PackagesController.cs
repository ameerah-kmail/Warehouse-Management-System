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
        public async Task<ActionResult<List<PackageDto>>> GetAllPackagesIn()
        {
             var PackagesInEntities = await _repository.GetAllPackagesIn();
             var Packages = _mapper.Map<List<PackageDto>>(PackagesInEntities);
             return Ok( Packages);

        }
        [HttpGet("~/Get All Packages Out")]
        public async Task<ActionResult<List<PackageDto>>> GetAllPackagesOut()
        {
            var PackagesOutEntities = await _repository.GetAllPackagesOut();
            var Packages = _mapper.Map<List<PackageDto>>(PackagesOutEntities);
            return Ok(Packages);
        }

        [HttpGet("~/Get Packages In Certain Period")]
        public  List<CustomerPackages>
        GetPackagesInPeriodGroupByCustomer
           (DateTime periodStart, DateTime periodEnd)
        {
            var PackagesOutEntities =  _repository.GetPackagesInPeriodGroupByCustomer(periodStart, periodEnd);
            var Packages = _mapper.Map<List<CustomerPackages>>(PackagesOutEntities);
            return Packages;
        }
    }
}
