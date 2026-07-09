using DomainLayer.DomainRules;
using DomainLayer.Entities;
using DomainLayer.Enums;
using DomainLayer.PurchaseRules.Rules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainLayerTests
{
    public class SeniorEmployeeRuleTest
    {

        [Fact]
        public void IsApplicable_ShouldReturnApproved_When_employeeSeniority_isOver10_and_amount_is_Less_than_2000()
        {
            // Arrange
            var rule = new SeniorEmployeeRule();

            var request = new PurchaseRequest(
              amount: 500,
              department: Department.Technology,
              employeeSeniority: 11,
              purchaseType: PurchaseType.Software,
              availableBudget: 2000);

            // Act
            var result = rule.Rule(request);

            // Assert
            Assert.True(result);
        }
    }
}
