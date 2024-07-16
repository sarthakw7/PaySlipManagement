namespace PaySlipManagement.API.Data
{
    public class ExceptionLog
    {
        public int Id { get; set; }
        public string ExceptionType { get; set; }
        public string ExceptionMessage { get; set; }
        public string StackTrace { get; set; }
        public DateTime LoggedAt { get; set; }
    }
}
