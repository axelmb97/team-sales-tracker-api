using System.Net;

namespace TeamSalesTrackerApi.Results
{
    public class BaseResult
    {
        public bool Ok { get; set; } = true;
        public string Error { get; set; } = "";
        public HttpStatusCode StatusCode { get; set; } = HttpStatusCode.OK;
        public string Message { get; set; } = "";

        public void SetError(string error, HttpStatusCode statusCode) {
            Ok = false;
            Error = error;
            StatusCode = statusCode;
        }
    }
}
