using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Fornecedores.Models.Entities
{
    public class EstablishmentDataBank
    {
        public int DataBankId { get; set; }
        public int BankCode { get; set; }
        public string BankName { get; set; }
        public string Agency { get; set; }
        public string Account { get; set; }
        public int AccountTypeId { get; set; }
        public int BankId { get; set; }
        public int CompanyDataBankId { get; set; }
        public string DocumentNumber { get; set; }
        public string NameResponsible { get; set; }
    }
}
