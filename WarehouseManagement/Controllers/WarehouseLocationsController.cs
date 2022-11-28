using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Hosting;
using System.Drawing;
using WarehouseManagement.Entits;
using WarehouseManagement.Models;
using WarehouseManagement.Services;

namespace WarehouseManagement.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class WarehouseLocationsController : ControllerBase
    {
        private readonly IWarehouseLocationRepository _repository;
        private readonly IMapper _mapper;

        public WarehouseLocationsController(IWarehouseLocationRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
  
        }
        [HttpGet]
        public async Task<ActionResult<List<WarehouseLocationDto>>> GetFreeWarehouseLocationsToday()
        {
            var WarehouseLocationEntities =  _repository.GetFreeWarehouseLocationsToday();
            var WarehouseLocations = _mapper.Map<List<WarehouseLocationDto>>(WarehouseLocationEntities);
            return Ok(WarehouseLocations);

        } 
        [HttpGet]
        public async Task<ActionResult<List<WarehouseLocationDto>>> GetFreeWarehouseLocationsInSpecificDate(DateTime specificDate)
        {
            var WarehouseLocationEntities = await _repository.GetFreeWarehouseLocationsInSpecificDate(specificDate);
            var WarehouseLocations = _mapper.Map<List<WarehouseLocationDto>>(WarehouseLocationEntities);
            return Ok(WarehouseLocations);
        }



    }
}
