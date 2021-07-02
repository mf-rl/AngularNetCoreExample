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
    public class EnrollmentController : ControllerBase
    {
        private readonly ILogger<EnrollmentController> _logger;
        private readonly IEnrollmentAppService _appService;
        public EnrollmentController(ILogger<EnrollmentController> logger, IEnrollmentAppService service)
        {
            _logger = logger;
            _appService = service ?? throw new System.ArgumentNullException(nameof(service));
        }

        [HttpGet]
        [Route("Get/{employeeid:int}/{id}")]
        [ProducesResponseType(typeof(PagedResponse<IEnumerable<EnrollmentDto>>), 200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(500)]
        public async Task<IActionResult> Get([FromRoute] int employeeid, [FromRoute] int id, [FromQuery] PaginationFilter filter)
        {
            return Ok(await _appService.Get(new EnrollmentDto { Id = id, Employee = new EmployeeDto { Id = employeeid } },
                new PaginationFilter(filter.PageNumber, filter.PageSize), Request.Path.Value));
        }

        [HttpGet]
        [Route("GetCurrent/{employeeid:int}")]
        [ProducesResponseType(typeof(PagedResponse<IEnumerable<EnrollmentDto>>), 200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(500)]
        public async Task<IActionResult> GetCurrent([FromRoute] int employeeid)
        {
            return Ok(await _appService.GetCurrent(new EnrollmentDto { Employee = new EmployeeDto { Id = employeeid } }));
        }

        [HttpPost]
        [Route("Add")]
        [ProducesResponseType(typeof(BaseResponseDto<EnrollmentDto>), 200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(500)]
        public async Task<IActionResult> Create([FromForm] EnrollmentDto enrollment)
        {
            return Ok(await _appService.Create(enrollment));
        }

        [HttpPost]
        [Route("Update")]
        [ProducesResponseType(typeof(BaseResponseDto<EnrollmentDto>), 200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(500)]
        public async Task<IActionResult> Update([FromForm] EnrollmentDto enrollment)
        {
            return Ok(await _appService.Update(enrollment));
        }

        [HttpDelete]
        [Route("Delete/{id}")]
        [ProducesResponseType(typeof(BaseResponseDto<EnrollmentDto>), 200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(500)]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            return Ok(await _appService.Remove(id));
        }
    }
}
