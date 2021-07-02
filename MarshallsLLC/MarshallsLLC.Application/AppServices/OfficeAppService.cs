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
    public class OfficeAppService : AppService<OfficeDto>, IOfficeAppService
    {
        private readonly IOfficeService _service;
        private readonly IMapper _mapper;

        public OfficeAppService(IOfficeService OfficeService, IMapper mapper, IUriAppService uriService) : base(uriService)
        {
            _service = OfficeService;
            _mapper = mapper;
        }
        public async Task<BaseResponseDto<IEnumerable<OfficeDto>>> Get(OfficeDto filter)
        {
            var res = await _service.GetOffices(_mapper.Map<Office>(filter));
            var p_res = new BaseResponseDto<IEnumerable<OfficeDto>>
            {
                Data = _mapper.Map<IEnumerable<OfficeDto>>(res.Data),
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
