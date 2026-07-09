using DomainLayer.Entities;
using DomainLayer.Enums;
using DomainLayer.PurchaseRules;
using DomainLayer.ResultsWrapper;

namespace DomainLayer.DomainRules
{
    public class BudgetExceededRule : IRequestResults
    {
        public bool Rule(PurchaseRequest purchaseRequest)
        {
            return purchaseRequest.Amount > purchaseRequest.AvailableBudget;
        }
        public OperationsResults GetOperationsResults(PurchaseRequest purchaseRequest)
        {
            return new OperationsResults(Results.Rejected, "Budget exceeded.");
        }

        
    }
}
