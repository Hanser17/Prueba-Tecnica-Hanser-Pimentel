using ApplicationLayer.Dto_s;
using DomainLayer.ResultsWrapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationLayer.Interfaces
{
     public interface IPurshasesServices

     {
        Task<OperationResultDTO> CreatPurchasesService(SavePurchasesDTO savePurchasesDTO);
     }
}
