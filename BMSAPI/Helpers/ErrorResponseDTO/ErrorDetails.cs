using Newtonsoft.Json;

namespace BMSAPI.Helpers.ErrorResponseDTO
{
    public class ErrorDetails
    {
        public int StatusCode { get; set; }
        public string? Message { get; set; }
        public override string ToString()
        {
            return JsonConvert.SerializeObject(this);
        }
    }
}
