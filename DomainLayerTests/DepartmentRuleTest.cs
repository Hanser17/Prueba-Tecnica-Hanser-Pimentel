

using DomainLayer.Entities;
using DomainLayer.Enums;
using DomainLayer.PurchaseRules.Rules;

namespace DomainLayerTests
{
    
    public class DepartmentRuleTest
    {
        [Fact]
        public virtual void DepartmentRule_ShouldReturnTrue_WhenDeparmentis_Finance_and_AmoundOver_1000()
        {
            // Arrange
           var rule = new DepartmentRule();

            var request = new PurchaseRequest(
                amount: 4000,
                department: Department.Finance,
                employeeSeniority: 5,
                purchaseType: PurchaseType.Software,
                availableBudget: 5000);

            // Act
            var result = rule.Rule(request);

            // Assert
            Assert.True(result);
        }
    }
}
