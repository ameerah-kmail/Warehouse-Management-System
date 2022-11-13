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
        
        public WarehouseLocationsController(IWarehouseLocationRepository repository)
        {
            _repository = repository;
            
        }
        [HttpGet]
        public async Task<ActionResult<List<WarehouseLocation>>> GetAll()
        {
            return  Ok(await _repository.GetAllWarehouseLocationrs());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<WarehouseLocation>> Get(int id)
        {
            var _warehouseLocation =await _repository.GetWarehouseLocation(id);
            if (_warehouseLocation == null)
                return NotFound();
            return Ok(_warehouseLocation);
        }

        [HttpDelete]
        public async Task<ActionResult> Delete(WarehouseLocation _warehouseLocation)
        {
            var warehouseLocation =await _repository
                .GetWarehouseLocation(_warehouseLocation.WarehouseLocationId);
            if (warehouseLocation == null)
                return NotFound();
             _repository.DeleteWarehouseLocation(warehouseLocation);
            return Ok();
        }

        [HttpPut]
        public async Task<ActionResult> Update(WarehouseLocation _warehouseLocation)
        {
            var warehouseLocation =await _repository.GetWarehouseLocation(_warehouseLocation.WarehouseLocationId);
            if (warehouseLocation == null)
                return NotFound();
            await _repository.AddWarehouseLocation(_warehouseLocation);
            return Ok();
        }

        [HttpPost]
        public async Task<ActionResult> Create(WarehouseLocation _warehouseLocation)
        {
             
            return  Ok( _repository.AddWarehouseLocation(_warehouseLocation));

        }
        [HttpGet]
        public async Task<ActionResult<List<WarehouseLocation>>> GetAllWarehouseLocationsToday()
        {
            return Ok(await _repository.GetAllWarehouseLocationsToday());
        }
        [HttpGet]
        public async Task<ActionResult<List<WarehouseLocation>>> GetAllWarehouseLocationsInSpecificDate(DateTime specificDate)
        {
            return Ok(await _repository.GetAllWarehouseLocationsInSpecificDate(specificDate));
        }



    }
}
