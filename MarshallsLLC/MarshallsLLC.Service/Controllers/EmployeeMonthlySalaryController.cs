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
    public class EmployeeMonthlySalaryController : ControllerBase
    {
        private readonly ILogger<EmployeeMonthlySalaryController> _logger;
        private readonly IEmployeeMonthlySalaryAppService _appService;
        public EmployeeMonthlySalaryController(
            ILogger<EmployeeMonthlySalaryController> logger,
            IEmployeeMonthlySalaryAppService service)
        {
            _logger = logger;
            _appService = service ?? throw new System.ArgumentNullException(nameof(service));
        }

        [HttpGet]
        [Route("Get/{name?}")]
        [ProducesResponseType(typeof(PagedResponse<IEnumerable<EmployeeMonthlySalaryDto>>), 200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(500)]
        public async Task<IActionResult> Get([FromRoute] string name, [FromQuery] PaginationFilter filter)
        {
            name = string.IsNullOrEmpty(name) ? string.Empty : name.Trim().ToLower();
            return Ok(await _appService.Get(new EmployeeMonthlySalaryDto { 
                EmployeeName = name, EmployeeSurname = name 
            }, new PaginationFilter(filter.PageNumber, filter.PageSize), Request.Path.Value));
        }

        [HttpPost]
        [Route("Add")]
        [ProducesResponseType(typeof(BaseResponseDto<EmployeeMonthlySalaryDto>), 200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(500)]
        public async Task<IActionResult> Create([FromForm] EmployeeMonthlySalaryDto employee)
        {
            return Ok(await _appService.Create(employee));
        }

        [HttpPost]
        [Route("Update")]
        [ProducesResponseType(typeof(BaseResponseDto<EmployeeMonthlySalaryDto>), 200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(500)]
        public async Task<IActionResult> Update([FromForm] EmployeeMonthlySalaryDto employeeMonthlySalary)
        {
            return Ok(await _appService.Update(employeeMonthlySalary));
        }

        [HttpDelete]
        [Route("Delete/{id}")]
        [ProducesResponseType(typeof(BaseResponseDto<EmployeeMonthlySalaryDto>), 200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(500)]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            return Ok(await _appService.Remove(id));
        }
    }
}