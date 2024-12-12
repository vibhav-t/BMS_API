namespace BMSAPI.Helpers
{
    public class ApiResponse
    {
        public int StatusCode {  get; set; }
        public string Message { get; set; }
        public ApiResponse(int statusCode, string message=null) 
        {
            StatusCode = statusCode;
            Message = message ?? GetDefaultMessageForStatusCode(statusCode);
        }
        private string GetDefaultMessageForStatusCode(int statusCode)
        {
            return statusCode switch
            {
                400 => "Bad request, you have made",
                401 => "You are not authorised",
                404 => "Blog item not found",
                500 => "Oops!!, Error occurred",
            _ => null
            };
        }
    }
}
