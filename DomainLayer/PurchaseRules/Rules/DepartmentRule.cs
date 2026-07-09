using DomainLayer.Entities;
using DomainLayer.Enums;
using DomainLayer.ResultsWrapper;

namespace DomainLayer.PurchaseRules.Rules
{
    public class DepartmentRule : IRequestResults
    {
        public OperationsResults GetOperationsResults(PurchaseRequest purchaseRequest)
        {
            return new OperationsResults(Results.Manual, "Finance department requests over 1000 required manual approval.");
        }

        public bool Rule(PurchaseRequest purchaseRequest)
        {
            return purchaseRequest.Department.ToString().Equals("Finance", StringComparison.CurrentCultureIgnoreCase) 
                   && purchaseRequest.Amount > 1000;
        }
    }
}
