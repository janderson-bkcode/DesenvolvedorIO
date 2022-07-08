using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Fornecedores.Models.Entities
{
    public class Company
    {
        public int CompanyId { get; set; }
        public int ResponsibleCompanyId { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Fone { get; set; }
        public string DocumentNumber { get; set; }
        public string NameFile { get; set; }
        public bool MainCompany { get; set; }
        public bool FlagActive { get; set; }
        public string SiteMarketing { get; set; }
        public string ShortName { get; set; }
        //public int CompanyIdDigitalAccount { get; set; }
    }
}
