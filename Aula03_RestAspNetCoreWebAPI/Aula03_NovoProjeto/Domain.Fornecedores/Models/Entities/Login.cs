using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Fornecedores.Models.Entities
{
    public class Login
    {
        public int LoginId { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }

        public int GroupId { get; set; }
        public string GroupName { get; set; }

        public int AccessTypeId { get; set; }

        public bool IsSalesRepresentant { get; set; }

        public int RepresentantId { get; set; }
        public bool HasTwoFactorAuthetication { get; set; }
        public string TwoFactorAuthenticationKey { get; set; }
        public int HoraDeaAcesso { get; set; }
        public int MyProperty { get; set; }
    }
}
