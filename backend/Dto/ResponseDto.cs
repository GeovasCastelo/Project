using System.Collections.Generic;

namespace APIBackend.Dto
{
    public class ResponseDto
    {
        public bool IsSuccess { get; set; } = true;
        public object Result{ get; set; }
        public string Message { get; set; }
        public List<string> Error { get; set; }
    }
}
