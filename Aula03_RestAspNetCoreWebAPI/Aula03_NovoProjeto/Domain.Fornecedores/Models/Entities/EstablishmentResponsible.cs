using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Fornecedores.Models.Entities
{
    public class EstablishmentResponsible
    {
        public int ResponsibleId { get; set; }

        public string Name { get; set; }
        public string CPF { get; set; }
        public string RG { get; set; }
        public string Email { get; set; }
        public int MaritalStatusId { get; set; }
        public int GenderId { get; set; }
        public DateTime BirthDate { get; set; }
        public string CellPhone { get; set; }
        public string Phone { get; set; }
        public bool FlagActive { get; set; }
        public Login Login { get; set; }
    }
}
