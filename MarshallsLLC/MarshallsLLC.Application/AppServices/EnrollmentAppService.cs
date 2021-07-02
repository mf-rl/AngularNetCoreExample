using System;
using AutoMapper;
using System.Threading.Tasks;
using System.Collections.Generic;
using MarshallsLLC.Application.Dto;
using MarshallsLLC.Domain.Entities;
using MarshallsLLC.Application.Interfaces;
using MarshallsLLC.Application.Dto.Wrappers;
using MarshallsLLC.Domain.Interfaces.Service;
using MarshallsLLC.Application.AppServices.Common;
using System.Linq;

namespace MarshallsLLC.Application.AppServices
{
    public class EnrollmentAppService : AppService<EnrollmentDto>, IEnrollmentAppService
    {
        private readonly IEnrollmentService _service;
        private readonly IEmployeeService _employeeService;
        private readonly IOfficeService _officeService;
        private readonly IDivisionService _divisionService;
        private readonly IPositionService _positionService;
        private readonly IMapper _mapper;

        public EnrollmentAppService(
            IEnrollmentService enrollmentService, 
            IEmployeeService employeeService,
            IOfficeService officeService,
            IDivisionService divisionService,
            IPositionService positionService,
            IMapper mapper, 
            IUriAppService uriService) : base(uriService)
        {
            _service = enrollmentService;
            _employeeService = employeeService;
            _divisionService = divisionService;
            _officeService = officeService;
            _positionService = positionService;
            _mapper = mapper;
        }
        public async Task<PagedResponse<IEnumerable<EnrollmentDto>>> Get(EnrollmentDto filter, PaginationFilter pageFilter, string route)
        {
            var res = await _service.GetEnrollments(_mapper.Map<Enrollment>(filter));
            var p_res = PaginateData(_mapper.Map<IEnumerable<EnrollmentDto>>(res.Data), pageFilter, route);
            p_res.ValidationResult = _mapper.Map<ResultDto>(res.ValidationResult);
            return p_res;
        }
        public async Task<BaseResponseDto<EnrollmentDto>> GetCurrent(EnrollmentDto filter)
        {
            var res = await _service.GetEnrollments(_mapper.Map<Enrollment>(filter));
            var p_res = new BaseResponseDto<EnrollmentDto> { 
                Data = _mapper.Map<EnrollmentDto>(res.Data.OrderByDescending(d => d.BeginDate).FirstOrDefault()),
                ValidationResult = _mapper.Map<ResultDto>(res.ValidationResult)
            };
            p_res.Data.Employee = _mapper.Map<EmployeeDto>((await _employeeService.GetEmployees(new Employee { Id = p_res.Data.Employee.Id })).Data.FirstOrDefault());
            p_res.Data.Division = _mapper.Map<DivisionDto>((await _divisionService.GetDivisions(new Division { Id = p_res.Data.Division.Id })).Data.FirstOrDefault());
            p_res.Data.Office = _mapper.Map<OfficeDto>((await _officeService.GetOffices(new Office { Id = p_res.Data.Office.Id })).Data.FirstOrDefault());
            p_res.Data.Position = _mapper.Map<PositionDto>((await _positionService.GetPositions(new Position { Id = p_res.Data.Position.Id })).Data.FirstOrDefault());
            return p_res;
        }

        public async Task<BaseResponseDto<EnrollmentDto>> Create(EnrollmentDto enrollment)
        {
            return _mapper.Map<BaseResponseDto<EnrollmentDto>>(await _service.AddEnrollment(_mapper.Map<Enrollment>(enrollment)));
        }
        public async Task<BaseResponseDto<EnrollmentDto>> Update(EnrollmentDto enrollment)
        {
            return _mapper.Map<BaseResponseDto<EnrollmentDto>>(await _service.UpdateEnrollment(_mapper.Map<Enrollment>(enrollment)));
        }
        public async Task<BaseResponseDto<EnrollmentDto>> Remove(int id)
        {
            return _mapper.Map<BaseResponseDto<EnrollmentDto>>(await _service.DeleteEnrollment(id));
        }
        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }
    }
}
