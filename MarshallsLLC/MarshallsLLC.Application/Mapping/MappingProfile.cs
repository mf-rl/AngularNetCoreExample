using AutoMapper;
using MarshallsLLC.Application.Dto;
using MarshallsLLC.Application.Dto.Wrappers;
using MarshallsLLC.Domain.Entities;
using MarshallsLLC.Domain.Validation;
using System;

namespace MarshallsLLC.Application.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {

            //CreateMap< BaseResponseDto<SalaryDetailDto>, TransactionResult<SalaryDetail>>().ReverseMap();

            CreateMap<ValidationResult, ResultDto>().ReverseMap();
            CreateMap<ValidationError, ErrorDto>().ReverseMap();
            CreateMap<EmployeeDto, Employee>().ReverseMap();
            CreateMap<EnrollmentDto, Enrollment>().ReverseMap();
            CreateMap<SalaryDetailDto, SalaryDetail>().ReverseMap();
            CreateMap<EmployeeMonthlySalaryDto, EmployeeMonthlySalary>().ReverseMap();

            CreateMap<SalaryDto, SalaryDetailDto>()
                .ForMember(d => d.EnrollmentId, opt => opt.MapFrom(src => src.EnrollmentId))
                .ForMember(d => d.Year, opt => opt.MapFrom(src => Convert.ToInt32(src.YearMonth.Substring(0, 4))))
                .ForMember(d => d.Month, opt => opt.MapFrom(src => Convert.ToInt32(src.YearMonth.Replace(string.Concat(src.YearMonth.Substring(0, 4), "-"), ""))))
                .ForMember(d => d.Grade, opt => opt.MapFrom(src => src.Grade))
                .ForMember(d => d.ProductionBonus, opt => opt.MapFrom(src => src.ProductionBonus))
                .ForMember(d => d.CompensationBonus, opt => opt.MapFrom(src => src.CompensationBonus))
                .ForMember(d => d.Commission, opt => opt.MapFrom(src => src.Commission))
                .ForMember(d => d.Contributions, opt => opt.MapFrom(src => src.Contributions))
                ;

            CreateMap<DivisionDto, Division>().ReverseMap();
            CreateMap<OfficeDto, Office>().ReverseMap();
            CreateMap<PositionDto, Position>().ReverseMap();
        }
    }
}
