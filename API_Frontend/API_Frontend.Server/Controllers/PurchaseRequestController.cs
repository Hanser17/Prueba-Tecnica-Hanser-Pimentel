using ApplicationLayer.Dto_s;
using ApplicationLayer.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace API_Frontend.Server.Controllers
{
    /// <summary>
    /// Controlador encargado de gestionar las solicitudes de compra.
    /// </summary>
    [ApiController]
    [Route("[controller]")]
    public class PurchaseRequestController : ControllerBase
    {
        private readonly IPurshasesServices _purshasesServices;

        /// <summary>
        /// Inicializa una nueva instancia del controlador de solicitudes de compra.
        /// </summary>
        /// <param name="purshasesServices">
        /// Servicio encargado de procesar las solicitudes de compra y ejecutar las reglas de negocio.
        /// </param>
        public PurchaseRequestController(IPurshasesServices purshasesServices)
        {
            _purshasesServices = purshasesServices;
        }

        /// <summary>
        /// Crea y evalúa una nueva solicitud de compra.
        /// </summary>
        /// <param name="savePurchasesDTO">
        /// Información de la solicitud de compra a evaluar:
        /// monto, departamento, antigüedad del empleado,
        /// tipo de compra y presupuesto disponible.
        /// </param>
        /// <returns>
        /// Retorna el resultado de la evaluación de la solicitud:
        /// Aprobado, Manual o Rechazado.
        /// </returns>
        /// <response code="200">
        /// La solicitud fue procesada correctamente.
        /// </response>
        [HttpPost]
        [ProducesResponseType(typeof(OperationResultDTO), StatusCodes.Status200OK)]
        public async Task<OperationResultDTO> CreatePurchases(
            SavePurchasesDTO savePurchasesDTO)
        {
            return await _purshasesServices
                .CreatPurchasesService(savePurchasesDTO);
        }
    }
}
