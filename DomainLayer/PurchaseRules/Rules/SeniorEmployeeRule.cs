using DomainLayer.Entities;
using DomainLayer.Enums;
using DomainLayer.ResultsWrapper;

namespace DomainLayer.PurchaseRules.Rules
{
    public class SeniorEmployeeRule : IRequestResults
    {
        public OperationsResults GetOperationsResults(PurchaseRequest purchaseRequest)
        {
            return new OperationsResults(Results.Approved, "Auto Approved since employee is senior and bugget is less than 2000.00");
        }

        public bool Rule(PurchaseRequest purchaseRequest)
        {
            return purchaseRequest.EmployeeSeniority > 10 
                && purchaseRequest.Amount < 2000
                && purchaseRequest.Amount < purchaseRequest.AvailableBudget;     
        }
    }
}
