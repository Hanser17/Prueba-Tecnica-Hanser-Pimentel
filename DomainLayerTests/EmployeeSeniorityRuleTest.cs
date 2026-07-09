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
    public class EmployeeSeniorityRuleTest
    {
        [Fact]
        public void Rule_ShouldReturnTrue_WhenEmployeeHasLessThanOneYearAndAmountIsGreaterThan500()
        {
            // Arrange
            var rule = new EmployeeSeniorityRule();

            var request = new PurchaseRequest(
                amount: 600,
                department: Department.Technology,
                employeeSeniority: 0,
                purchaseType: PurchaseType.Software,
                availableBudget: 5000);

            // Act
            var result = rule.Rule(request);

            // Assert
            Assert.True(result);
        }
    }
}
