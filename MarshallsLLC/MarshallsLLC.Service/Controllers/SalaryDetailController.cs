using AutoMapper;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using MarshallsLLC.Application.Dto;
using Microsoft.Extensions.Logging;
using MarshallsLLC.Application.Interfaces;
using MarshallsLLC.Application.Dto.Wrappers;

namespace MarshallsLLC.Service.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class SalaryDetailController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly ILogger<SalaryDetailController> _logger;
        private readonly ISalaryDetailAppService _appService;
        public SalaryDetailController(ILogger<SalaryDetailController> logger, ISalaryDetailAppService service, IMapper mapper)
        {
            _logger = logger;
            _mapper = mapper;
            _appService = service ?? throw new System.ArgumentNullException(nameof(service));
        }

        [HttpGet]
        [Route("Get/{employeeid:int}/{enrollmentid:int}/{id}")]
        [ProducesResponseType(typeof(PagedResponse<IEnumerable<SalaryDetailDto>>), 200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(500)]
        public async Task<IActionResult> Get(
            [FromRoute] int employeeid, [FromRoute] int enrollmentid, [FromRoute] int id,
                [FromQuery] PaginationFilter filter)
        {
            return Ok(await _appService.Get(
                new SalaryDetailDto
                {
                    Id = id,
                    Enrollment = new EnrollmentDto
                    {
                        Id = enrollmentid,
                        Employee = new EmployeeDto
                        {
                            Id = employeeid
                        }
                    }
                },
                new PaginationFilter(filter.PageNumber, filter.PageSize), Request.Path.Value));
        }

        [HttpPost]
        [Route("Add")]
        [ProducesResponseType(typeof(BaseResponseDto<SalaryDetailDto>), 200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(500)]
        public async Task<IActionResult> Create([FromBody] SalaryDto salaryDetailDto)
        {
            return Ok(await _appService.Create(_mapper.Map<SalaryDetailDto>(salaryDetailDto)));
        }

        [HttpPost]
        [Route("Update")]
        [ProducesResponseType(typeof(BaseResponseDto<SalaryDetailDto>), 200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(500)]
        public async Task<IActionResult> Update([FromForm] SalaryDetailDto salaryDetailDto)
        {
            return Ok(await _appService.Update(salaryDetailDto));
        }

        [HttpDelete]
        [Route("Delete/{id}")]
        [ProducesResponseType(typeof(BaseResponseDto<SalaryDetailDto>), 200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(500)]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            return Ok(await _appService.Remove(id));
        }
    }
}
