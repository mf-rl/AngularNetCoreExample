using System.Collections.Generic;

namespace MarshallsLLC.Application.Dto.Wrappers
{
    public class BaseResponseDto<TEntity>
    {
        public TEntity Data { get; set; }
        public ResultDto ValidationResult { get; set; }
    }
    public class ResultDto
    {
        public bool IsValid { get; set; }
        public IEnumerable<ErrorDto> Errors { get; set; }
    }
    public class ErrorDto
    {
        public string Message { get; set; }
    }
}
