using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using Microsoft.Extensions.Logging;
using MarshallsLLC.Application.Dto;
using MarshallsLLC.Application.Interfaces;
using MarshallsLLC.Application.Dto.Wrappers;

namespace MarshallsLLC.Service.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class EmployeeController : ControllerBase
    {
        private readonly ILogger<EmployeeController> _logger;
        private readonly IEmployeeAppService _appService;
        public EmployeeController(ILogger<EmployeeController> logger, IEmployeeAppService service)
        {
            _logger = logger;
            _appService = service ?? throw new System.ArgumentNullException(nameof(service));
        }

        [HttpGet]
        [Route("Get/{id:int}/{name?}/{codigo?}")]
        [ProducesResponseType(typeof(PagedResponse<IEnumerable<EmployeeDto>>), 200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(500)]
        public async Task<IActionResult> Get([FromRoute] int id, [FromRoute] string name, [FromRoute] string codigo, [FromQuery] PaginationFilter filter)
        {
            name = string.IsNullOrEmpty(name) ? string.Empty : name.Trim().ToLower();
            codigo = string.IsNullOrEmpty(codigo) ? string.Empty : codigo.Trim().ToLower();
            return Ok(await _appService.Get(new EmployeeDto { 
                Id = id, 
                EmployeeName = name, 
                EmployeeSurname = name,
                EmployeeCode = codigo
            }, new PaginationFilter(filter.PageNumber, filter.PageSize), Request.Path.Value));
        }

        [HttpPost]
        [Route("Add")]
        [ProducesResponseType(typeof(BaseResponseDto<EmployeeDto>), 200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(500)]
        public async Task<IActionResult> Create([FromForm] EmployeeDto employee)
        {
            return Ok(await _appService.Create(employee));
        }

        [HttpPost]
        [Route("Update")]
        [ProducesResponseType(typeof(BaseResponseDto<EmployeeDto>), 200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(500)]
        public async Task<IActionResult> Update([FromForm] EmployeeDto employee)
        {
            return Ok(await _appService.Update(employee));
        }

        [HttpDelete]
        [Route("Delete/{id}")]
        [ProducesResponseType(typeof(BaseResponseDto<EmployeeDto>), 200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(500)]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            return Ok(await _appService.Remove(id));
        }
    }
}
