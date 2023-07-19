namespace UserCloneApp.Domain.Models.LogModels
{
    public class LogModel
    {
        public long ElapsedTimeMilliseconds { get; set; }

        public string RequestID { get; set; }

        public string ServiceName { get; set; }

        public string UserEmail { get; set; }

        public string IpAddress { get; set; }

        public RequestLogModel Request { get; set; }

        public ResponseLogModel Response { get; set; }

        public ErrorLogModel? Error { get; set; }

        public LogModel(long elapsedTimeMilliseconds, string requestID, string serviceName, string userEmail, string ipAddress, RequestLogModel request, ResponseLogModel response, ErrorLogModel? error)
        {
            ElapsedTimeMilliseconds = elapsedTimeMilliseconds;
            RequestID = requestID;
            ServiceName = serviceName;
            UserEmail = userEmail;
            IpAddress = ipAddress;
            Request = request;
            Response = response;
            Error = error;
        }
    }
}
