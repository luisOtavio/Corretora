namespace Corretora.Api.Controllers.Sbp
{
    public class NewSbpEventRequest
    {
        public string Event { get; set; }
        public TargetRequest Target { get; set; }
        public OriginRequest Origin { get; set; }
        public decimal Amount { get; set; }
    }

    public class TargetRequest
    {
        public string Bank { get; set; }
        public string Branch { get; set; }
        public string Account { get; set; }
    }

    public class OriginRequest
    {
        public string Bank { get; set; }
        public string Branch { get; set; }
        public string Cpf { get; set; }
    }
}
