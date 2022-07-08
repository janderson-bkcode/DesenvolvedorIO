using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Fornecedores.Models.Request
{
    public class FilterUserRequest : PaginationRequest
    {
        public int UserId { get; set; }
        public string UserName { get; set; }
        public int FlagActive { get; set; }
        public int Company { get; set; }
    }
}
