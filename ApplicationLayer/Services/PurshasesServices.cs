using ApplicationLayer.Dto_s;
using ApplicationLayer.Interfaces;
using DomainLayer.Entities;
using DomainLayer.PurchaseRules;
using DomainLayer.ResultsWrapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationLayer.Services
{
    public class PurshasesServices : IPurshasesServices
    {
        private readonly RulesExecuter _rulesExecuter;
        public PurshasesServices(RulesExecuter rulesExecuter)
        {
            _rulesExecuter = rulesExecuter;
        }
        public async Task<OperationResultDTO> CreatPurchasesService(SavePurchasesDTO savePurchasesDTO)
        {
            PurchaseRequest purchaseRequestToSave = new PurchaseRequest
            (
                savePurchasesDTO.Amount,
                savePurchasesDTO.Department,
                savePurchasesDTO.EmployeeSeniority,
                savePurchasesDTO.PurchaseType,
                savePurchasesDTO.AvailableBudget

            );

            var results = _rulesExecuter.ExecuteRules(purchaseRequestToSave);

            OperationResultDTO resultDTO = new OperationResultDTO
                (
                  results.Status,
                  results.Reason
                );
            return resultDTO;
            //ToDo llamada al Repo para guardar la Endity 
        }
    }
}
