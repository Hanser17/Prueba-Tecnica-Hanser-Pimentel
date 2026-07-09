using DomainLayer.Enums;

namespace DomainLayer.ResultsWrapper
{
    public class OperationsResults
    {
        public Results Status { get; }

        public string Reason { get; }

        public OperationsResults(
            Results status,
            string reason = "")
        {
            Status = status;
            Reason = reason;
        }
    }
}
