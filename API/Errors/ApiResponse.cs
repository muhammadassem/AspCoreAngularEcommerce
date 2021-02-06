public class ApiResponse
{
    public int StatusCode { get; set; }
    public string Message { get; set; }
    public string Details { get; }

    public ApiResponse(int statusCode, string message = null, string details = null)
    {
        StatusCode = statusCode;
        Message = message ?? GetDefaultMessageForStatusCode(statusCode);
        Details = details;
    }

    private string GetDefaultMessageForStatusCode(int statusCode)
    {
        return statusCode switch
        {
            400 => "Bad request",
            401 => "Not Authorized",
            500 => "Server Error",
            404 => "Not Found",
            _ => "Error"
        };
    }
}