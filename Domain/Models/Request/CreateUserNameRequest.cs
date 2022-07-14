using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models.Request
{
    public class CreateUserNameRequest : BaseRequest
    {
        public string Name { get; set; }
        public string CPF { get; set; }
        public string RG { get; set; }
        public int MaritalStatusId { get; set; }
        public int GenderId { get; set; }
        public string BirthDate { get; set; }
        public string CellPhone { get; set; }
        public string Phone { get; set; }
        public int CompanyId { get; set; }
        public bool HasTwoFactorAuthetication { get; set; }

        public string Email { get; set; }
        public int FlagActive { get; set; }
        public int GroupAccess { get; set; }
        public int UserNameId { get; set; }
    }
}
