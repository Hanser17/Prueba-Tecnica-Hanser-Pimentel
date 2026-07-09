using DomainLayer.DomainRules;
using DomainLayer.Entities;
using DomainLayer.Enums;
using DomainLayer.PurchaseRules;
using DomainLayer.PurchaseRules.Rules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainLayerTests
{
    public class RulesExecuterTests
    {
        [Fact]
        public void ExecuteRules_ShouldApprove_WhenNoRulesApply()
        {
            // Arrange
            var rules = new List<IRequestResults>
            {
             new BudgetExceededRule(),
             new SeniorEmployeeRule(),
             new DepartmentRule(),
             new EmployeeSeniorityRule(),
             new PurchasesTypeRule()
            };

            var executor = new RulesExecuter(rules);

            var request = new PurchaseRequest(
                amount: 300,
                department: Department.Technology,
                employeeSeniority: 5,
                purchaseType: PurchaseType.Services,
                availableBudget: 5000);

            // Act
            var result = executor.ExecuteRules(request);

            // Assert
            Assert.Equal(Results.Approved, result.Status);
        }
    }
}
