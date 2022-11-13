using AutoMapper;
using Microsoft.AspNetCore.DataProtection.Repositories;
using Microsoft.AspNetCore.Mvc;
using WarehouseManagement.Entits;
using WarehouseManagement.Models;
using WarehouseManagement.Services;

namespace WarehouseManagement.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class CustomersController : ControllerBase
    {
        private readonly ICustomerRepository _repository;
        private IMapper _mapper;
        public CustomersController(ICustomerRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
         [HttpGet("{customerId}")]
         public async Task<ActionResult<List<Customer>>> GetPackagesForCustomer(int customerId)
         {
             if (!await _repository.AnyCustomerExists(customerId))
                 return NotFound();
             var packagesForCustomerEntity = _repository
                 .GetPackagesForCustomer(customerId);
             //return Ok(_mapper.Map<List<PackageDto>>(packagesForCustomerEntity));
             return Ok((packagesForCustomerEntity));

        }

    }
}
