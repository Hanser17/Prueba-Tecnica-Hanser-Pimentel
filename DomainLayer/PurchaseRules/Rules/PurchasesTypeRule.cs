using DomainLayer.Entities;
using DomainLayer.Enums;
using DomainLayer.ResultsWrapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainLayer.PurchaseRules.Rules
{
    public class PurchasesTypeRule : IRequestResults
    {
        public OperationsResults GetOperationsResults(PurchaseRequest purchaseRequest)
        {
            return new OperationsResults(Results.Manual, "Equipment purchases required manual approval ");
        }

        public bool Rule(PurchaseRequest purchaseRequest)
        {
            return purchaseRequest.PurchaseType.ToString().Equals("EQUIPMENT", StringComparison.CurrentCultureIgnoreCase) && purchaseRequest.Amount > 3000;
        }
    }
}
