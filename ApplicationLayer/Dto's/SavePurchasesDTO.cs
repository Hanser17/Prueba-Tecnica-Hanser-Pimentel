using DomainLayer.Enums;

namespace ApplicationLayer.Dto_s
{
    using System.ComponentModel.DataAnnotations;


    public class SavePurchasesDTO
    {
        [Display(Name = "Monto")]
        [Range(0.01, double.MaxValue,
            ErrorMessage = "El monto debe ser mayor que cero.")]
        public decimal Amount { get; set; }

        [Display(Name = "Departamento")]
        [EnumDataType(typeof(Department),
            ErrorMessage = "El departamento seleccionado no es válido.")]
        public Department Department { get; set; }

        [Display(Name = "Antigüedad del empleado")]
        [Range(0.01, 100,
            ErrorMessage = "La antigüedad del empleado debe estar entre 0 y 100 años.")]
        public decimal EmployeeSeniority { get; set; }

        [Display(Name = "Tipo de compra")]
        [EnumDataType(typeof(PurchaseType),
            ErrorMessage = "El tipo de compra seleccionado no es válido.")]
        public PurchaseType PurchaseType { get; set; }

        [Display(Name = "Presupuesto disponible")]
        [Range(0.01, double.MaxValue,
            ErrorMessage = "El presupuesto disponible debe ser mayor que cero.")]
        public decimal AvailableBudget { get; set; }
    }
}
