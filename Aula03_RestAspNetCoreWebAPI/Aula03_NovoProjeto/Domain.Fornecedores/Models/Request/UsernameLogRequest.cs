using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Fornecedores.Models.Request
{
    public class UsernameLogRequest : BaseRequest
    {
        public int? EstablishmentId { get; set; }
        public int? ClientId { get; set; }
        public string MessageLog { get; set; }
    }
}
