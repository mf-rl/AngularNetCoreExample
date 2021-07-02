using System;
using AutoMapper;
using System.Threading.Tasks;
using System.Collections.Generic;
using MarshallsLLC.Application.Dto;
using MarshallsLLC.Domain.Entities;
using MarshallsLLC.Application.Interfaces;
using MarshallsLLC.Domain.Interfaces.Service;
using MarshallsLLC.Application.Dto.Wrappers;
using MarshallsLLC.Application.AppServices.Common;

namespace MarshallsLLC.Application.AppServices
{
    public class EmployeeMonthlySalaryAppService : AppService<EmployeeMonthlySalaryDto>, IEmployeeMonthlySalaryAppService
    {
        private readonly IEmployeeMonthlySalaryService _service;
        private readonly IMapper _mapper;
        public EmployeeMonthlySalaryAppService(IEmployeeMonthlySalaryService employeeMonthlySalaryService, IMapper mapper, IUriAppService uriService) : base(uriService)
        {
            _service = employeeMonthlySalaryService;
            _mapper = mapper;
        }
        public async Task<PagedResponse<IEnumerable<EmployeeMonthlySalaryDto>>> Get(EmployeeMonthlySalaryDto filter, PaginationFilter pageFilter, string route)
        {
            var res = await _service.GetEmployeeMonthlySalaries(_mapper.Map<EmployeeMonthlySalary>(filter));
            var p_res = PaginateData(_mapper.Map<IEnumerable<EmployeeMonthlySalaryDto>>(res.Data), pageFilter, route);
            p_res.ValidationResult = _mapper.Map<ResultDto>(res.ValidationResult);
            return p_res;
        }
        public async Task<BaseResponseDto<EmployeeMonthlySalaryDto>> Create(EmployeeMonthlySalaryDto employeeMonthlySalaryModel)
        {
            return _mapper.Map<BaseResponseDto<EmployeeMonthlySalaryDto>>(await _service.AddEmployeeMonthlySalary(_mapper.Map<EmployeeMonthlySalary>(employeeMonthlySalaryModel)));
        }
        public async Task<BaseResponseDto<EmployeeMonthlySalaryDto>> Update(EmployeeMonthlySalaryDto employeeMonthlySalaryModel)
        {
            return _mapper.Map<BaseResponseDto<EmployeeMonthlySalaryDto>>(await _service.UpdateEmployeeMonthlySalary(_mapper.Map<EmployeeMonthlySalary>(employeeMonthlySalaryModel)));
        }
        public async Task<BaseResponseDto<EmployeeMonthlySalaryDto>> Remove(int id)
        {
            return _mapper.Map<BaseResponseDto<EmployeeMonthlySalaryDto>>(await _service.DeleteEmployeeMonthlySalary(id));
        }
        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }
    }
}
