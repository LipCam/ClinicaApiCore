using System.Net;

namespace ClinicaApiCore.DTOs
{
    public class ResponseDTO
    {
        public HttpStatusCode StatusCode { get; set; }
        public string? Message { get; set; }
    }
}
