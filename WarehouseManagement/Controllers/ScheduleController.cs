using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using WarehouseManagement.Entits;
using WarehouseManagement.Models;
using WarehouseManagement.Services;

namespace WarehouseManagement.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
   
    public class ScheduleController : ControllerBase
    {
        private readonly IScheduleRepository _repository;
        private readonly IMapper _mapper;
        public ScheduleController(IScheduleRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        [HttpPost]
        public async Task<ActionResult> AddSchedule(ScheduleDto _ScheduleDto)
        {

            var ScheduleEntity = _mapper.Map<Schedule>(_ScheduleDto);
            await _repository.AddSchedule(ScheduleEntity);
            return Ok();

        }
    }
}
