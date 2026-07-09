using DomainLayer.DomainRules;
using DomainLayer.Entities;
using DomainLayer.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainLayerTests
{
    public class BudgetExceededRuleTest
    {
        [Fact]
        public void IsApplicable_ShouldReturnTrue_WhenAmountExceedsBudget()
        {
            // Arrange
            var rule = new BudgetExceededRule();

            var request = new PurchaseRequest(
              amount: 6000,
              department: Department.Technology,
              employeeSeniority: 5,
              purchaseType: PurchaseType.Equipment,
              availableBudget: 5000);

            // Act
            var result = rule.Rule(request);

            // Assert
            Assert.True(result);
        }

    }
}
