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
    public class CommonController : ControllerBase
    {
        private readonly ILogger<CommonController> _logger;
        private readonly IDivisionAppService _divisionAppService;
        private readonly IOfficeAppService _officeAppService;
        private readonly IPositionAppService _positionAppService;
        public CommonController(
            ILogger<CommonController> logger, 
            IDivisionAppService divisionAppService,
            IOfficeAppService officeAppService,
            IPositionAppService positionAppService)
        {
            _logger = logger;
            _divisionAppService = divisionAppService ?? throw new System.ArgumentNullException(nameof(divisionAppService));
            _officeAppService = officeAppService ?? throw new System.ArgumentNullException(nameof(officeAppService));
            _positionAppService = positionAppService ?? throw new System.ArgumentNullException(nameof(positionAppService));
        }
        [HttpGet]
        [Route("GetDivisions")]
        [ProducesResponseType(typeof(BaseResponseDto<IEnumerable<DivisionDto>>), 200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(500)]
        public async Task<IActionResult> GetDivisions()
        {
            return Ok(await _divisionAppService.Get(new DivisionDto { Id = 0 }));
        }
        [HttpGet]
        [Route("GetOffices")]
        [ProducesResponseType(typeof(BaseResponseDto<IEnumerable<OfficeDto>>), 200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(500)]
        public async Task<IActionResult> GetOffices()
        {
            return Ok(await _officeAppService.Get(new OfficeDto { Id = 0 }));
        }
        [HttpGet]
        [Route("GetPositions")]
        [ProducesResponseType(typeof(BaseResponseDto<IEnumerable<PositionDto>>), 200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(500)]
        public async Task<IActionResult> GetPositions()
        {
            return Ok(await _positionAppService.Get(new PositionDto { Id = 0 }));
        }
    }
}
