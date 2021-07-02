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
    public class SalaryDetailAppService : AppService<SalaryDetailDto>, ISalaryDetailAppService
    {
        private readonly ISalaryDetailService _service;
        private readonly IMapper _mapper;

        public SalaryDetailAppService(ISalaryDetailService salaryDetailService, IMapper mapper, IUriAppService uriService) : base(uriService)
        {
            _service = salaryDetailService;
            _mapper = mapper;
        }
        public async Task<PagedResponse<IEnumerable<SalaryDetailDto>>> Get(SalaryDetailDto filter, PaginationFilter pageFilter, string route)
        {
            var res = await _service.GetSalaryDetails(_mapper.Map<SalaryDetail>(filter));
            var p_res = PaginateData(_mapper.Map<IEnumerable<SalaryDetailDto>>(res.Data), pageFilter, route);
            p_res.ValidationResult = _mapper.Map<ResultDto>(res.ValidationResult);
            return p_res;
        }
        public async Task<BaseResponseDto<SalaryDetailDto>> Create(SalaryDetailDto salaryDetail)
        {
            var res = await _service.AddSalaryDetail(_mapper.Map<SalaryDetail>(salaryDetail));
            var res_val = _mapper.Map<ResultDto>(res.ValidationResult);
            var res_dat = res.Data != null ? _mapper.Map<SalaryDetailDto>(res.Data) : null;
            if (res_dat != null ) res_dat.Enrollment = null;
            return new BaseResponseDto<SalaryDetailDto> { 
                Data = res_dat,
                ValidationResult = res_val
            };
        }

        public async Task<BaseResponseDto<SalaryDetailDto>> Update(SalaryDetailDto salaryDetail)
        {
            return _mapper.Map<BaseResponseDto<SalaryDetailDto>>(await _service.UpdateSalaryDetail(_mapper.Map<SalaryDetail>(salaryDetail)));
        }

        public async Task<BaseResponseDto<SalaryDetailDto>> Remove(int id)
        {
            return _mapper.Map<BaseResponseDto<SalaryDetailDto>>(await _service.Delete(new SalaryDetail { Id = id }));
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }
    }
}
