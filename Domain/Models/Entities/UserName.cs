using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models.Entities
{
    public class UserName
    {
        public int UserNameId { get; set; }

        public string Name { get; set; }
        public string CPF { get; set; }
        public string RG { get; set; }

        public int MaritalStatusId { get; set; }
        public string MeritalStatus { get; set; }

        public int GenderId { get; set; }
        public string Gender { get; set; }

        public DateTime BirthDate { get; set; }
        public string CellPhone { get; set; }
        public string Phone { get; set; }

        public int FlagActive { get; set; }

        public Company Company { get; set; }

        public Login Login { get; set; }
    }
}
