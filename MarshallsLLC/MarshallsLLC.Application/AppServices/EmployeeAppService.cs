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
    public class EmployeeAppService : AppService<EmployeeDto>, IEmployeeAppService
    {
        private readonly IEmployeeService _service;
        private readonly IMapper _mapper;
        public EmployeeAppService(IEmployeeService employeeService, IMapper mapper, IUriAppService uriService) : base(uriService)
        {
            _service = employeeService;
            _mapper = mapper;
        }
        public async Task<PagedResponse<IEnumerable<EmployeeDto>>> Get(EmployeeDto filter, PaginationFilter pageFilter, string route)
        {
            var res = await _service.GetEmployees(_mapper.Map<Employee>(filter));
            var p_res = PaginateData(_mapper.Map<IEnumerable<EmployeeDto>>(res.Data), pageFilter, route);
            p_res.ValidationResult = _mapper.Map<ResultDto>(res.ValidationResult);
            return p_res;
        }
        public async Task<BaseResponseDto<EmployeeDto>> Create(EmployeeDto employee)
        {
            return _mapper.Map<BaseResponseDto<EmployeeDto>>(await _service.AddEmployee(_mapper.Map<Employee>(employee)));
        }
        public async Task<BaseResponseDto<EmployeeDto>> Update(EmployeeDto employee)
        {
            return _mapper.Map<BaseResponseDto<EmployeeDto>>(await _service.UpdateEmployee(_mapper.Map<Employee>(employee)));
        }
        public async Task<BaseResponseDto<EmployeeDto>> Remove(int id)
        {
            return _mapper.Map<BaseResponseDto<EmployeeDto>>(await _service.DeleteEmployee(id));
        }
        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }
    }
}
