using Microsoft.AspNetCore.Http;

namespace eCommerce.Errors
{
    public class ApiResponse
    {
    private string GetDefaultMessageForStatusCode(int statusCode)
    {
        return statusCode switch
        {
            400 => "Bad Request 0_0",
            401 => "Not Authorized 0v0",
            404 => "Not Found :(",
            500 => "Server Error 0<>0",
            _=> null

        };
    }
        public ApiResponse(int statusCode, string message = null)
        {
            StatusCode = statusCode;
            Message = message ?? GetDefaultMessageForStatusCode(statusCode);
        }
        public int StatusCode { get; set; }
        public string Message { get; set; }
    }
}
