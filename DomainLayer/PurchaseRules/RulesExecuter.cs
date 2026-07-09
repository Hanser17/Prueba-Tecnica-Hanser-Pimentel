using DomainLayer.Entities;
using DomainLayer.Enums;
using DomainLayer.ResultsWrapper;

namespace DomainLayer.PurchaseRules
{
    public class RulesExecuter
    {
        private readonly IEnumerable<IRequestResults> _rules;
        public RulesExecuter(IEnumerable<IRequestResults> rules)
        {
            _rules = rules;
        }
        public OperationsResults ExecuteRules(PurchaseRequest purchaseRequest)
        {
            foreach (var rule in _rules)
            {
                if (rule.Rule(purchaseRequest))
                {
                    return rule.GetOperationsResults(purchaseRequest);
                }
               
            }
            return new OperationsResults(Results.Approved, "Request Approved");
        }
    }
}
