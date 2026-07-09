using DomainLayer.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace ApplicationLayer.Dto_s
{

    
    public class OperationResultDTO
    {
        public Results Status { get; }

        public string Reason { get; }

        public OperationResultDTO(
            Results status,
            string reason = "")
        {
            Status = status;
            Reason = reason;
        }
    }
}
