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
    public class DivisionAppService : AppService<DivisionDto>, IDivisionAppService
    {
        private readonly IDivisionService _service;
        private readonly IMapper _mapper;

        public DivisionAppService(IDivisionService DivisionService, IMapper mapper, IUriAppService uriService) : base(uriService)
        {
            _service = DivisionService;
            _mapper = mapper;
        }
        public async Task<BaseResponseDto<IEnumerable<DivisionDto>>> Get(DivisionDto filter)
        {
            var res = await _service.GetDivisions(_mapper.Map<Division>(filter));
            var p_res = new BaseResponseDto<IEnumerable<DivisionDto>> { 
                Data = _mapper.Map<IEnumerable<DivisionDto>>(res.Data), 
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
