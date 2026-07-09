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
    public class PurchasesTypeRuleTest
    {
        [Fact]
        public void Rule_ShouldReturnTrue_WhenPurchaseTypeIsEquipment()
        {
            // Arrange
            var rule = new PurchasesTypeRule();

            var request = new PurchaseRequest(
                amount: 4000,
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
