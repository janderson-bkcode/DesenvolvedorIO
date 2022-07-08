using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Fornecedores.Models.Entities
{
    public class Establishment
    {
        public int EstablishmentId { get; set; }
        public string Name { get; set; }
        public string ReducedName { get; set; }
        public string DocumentNumber { get; set; }
        public string CityName { get; set; }
        public int CompanyId { get; set; }
        public string CompanyName { get; set; }

        public DateTime CreatedAt { get; set; }
        public DateTime LastUpdate { get; set; }

        public string Project { get; set; }
        public string Acquirer { get; set; }
        public string Mid { get; set; }
        public string Tid { get; set; }
        public string Mcc { get; set; }

        public int RepresentantId { get; set; }

        public int EstablishmentType { get; set; }

        public int EstablishmentTypeId { get; set; }

        public int BlackListId { get; set; }

        public string Salesman { get; set; }

        public string Status { get; set; }

        public string Boleta { get; set; }

        public decimal CardFee { get; set; }

        public int EstablishmentCardFeeId { get; set; }

        public int DigitalAccountClientId { get; set; }
        public int EnableVoucher { get; set; }

        public decimal FeeDiscount { get; set; }

        public string ResponsibleName { get; set; }
        public string ResponsibleCellPhone { get; set; }
        public string ResponsiblePhone { get; set; }
        public string ResponsibleEmail { get; set; }

        public EstablishmentAddress Address { get; set; }

        public EstablishmentResponsible Responsible { get; set; }

        public EstablishmentDataBank DataBank { get; set; }
    }
}
