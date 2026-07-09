using DomainLayer.Enums;
namespace DomainLayer.Entities
{
    public class PurchaseRequest
    {
        public decimal Amount { get; private set; }

        public Department Department { get; private set; }

        public decimal EmployeeSeniority { get; private set; }

        public PurchaseType PurchaseType { get; private set; }

        public decimal AvailableBudget { get; private set; }

        public PurchaseRequest(
            decimal amount,
            Department department,
            decimal employeeSeniority,
            PurchaseType purchaseType,
            decimal availableBudget)
        {
            Amount = amount;
            Department = department;
            EmployeeSeniority = employeeSeniority;
            PurchaseType = purchaseType;
            AvailableBudget = availableBudget;
        }
    }
}
