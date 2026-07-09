using DomainLayer.Entities;
using DomainLayer.ResultsWrapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainLayer.PurchaseRules
{
    public interface IRuleExecuter
    {
        OperationsResults ExecuteRules(PurchaseRequest purchaseRequest);
    }
}
