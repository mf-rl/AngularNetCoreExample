using AutoMapper;
using MarshallsLLC.Application.AppServices.Common;
using MarshallsLLC.Application.Dto;
using MarshallsLLC.Application.Dto.Wrappers;
using MarshallsLLC.Application.Interfaces;
using MarshallsLLC.Domain.Entities;
using MarshallsLLC.Domain.Interfaces.Service;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MarshallsLLC.Application.AppServices
{
    public class PositionAppService : AppService<PositionDto>, IPositionAppService
    {
        private readonly IPositionService _service;
        private readonly IMapper _mapper;

        public PositionAppService(IPositionService PositionService, IMapper mapper, IUriAppService uriService) : base(uriService)
        {
            _service = PositionService;
            _mapper = mapper;
        }
        public async Task<BaseResponseDto<IEnumerable<PositionDto>>> Get(PositionDto filter)
        {
            var res = await _service.GetPositions(_mapper.Map<Position>(filter));
            var p_res = new BaseResponseDto<IEnumerable<PositionDto>>
            {
                Data = _mapper.Map<IEnumerable<PositionDto>>(res.Data),
                ValidationResult = _mapper.Map<ResultDto>(res.ValidationResult)
            };
            return p_res;
        }
        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }
    }
}
