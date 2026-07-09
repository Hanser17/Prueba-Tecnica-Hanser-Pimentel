using DomainLayer.Entities;
using DomainLayer.Enums;
using DomainLayer.ResultsWrapper;

namespace DomainLayer.PurchaseRules.Rules
{
    public class EmployeeSeniorityRule : IRequestResults
    {
        public OperationsResults GetOperationsResults(PurchaseRequest purchaseRequest)
        {
            return new OperationsResults(Results.Manual, "Employee seniority is not sufficient required manual approval.");
        }

        public bool Rule(PurchaseRequest purchaseRequest)
        {
            //ToDo: Confirmar si se puede hardcoder el valor de seniority y amount, o si se debe pasar como parametro

            return purchaseRequest.EmployeeSeniority < 1 && purchaseRequest.Amount > 500; 
        }
    }
}
