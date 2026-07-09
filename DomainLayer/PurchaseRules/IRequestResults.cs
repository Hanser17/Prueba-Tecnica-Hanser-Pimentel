using DomainLayer.Entities;
using DomainLayer.ResultsWrapper;

namespace DomainLayer.PurchaseRules
{
    public interface IRequestResults
    {
        bool Rule(PurchaseRequest purchaseRequest);

        OperationsResults GetOperationsResults(PurchaseRequest purchaseRequest);
    }
}
