using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Fornecedores.Models.Entities
{
    public class EstablishmentAddress
    {
        public int AddressId { get; set; }
        public string Address { get; set; }
        public int? Number { get; set; }
        public string Neighborhood { get; set; }
        public string ZipCode { get; set; }
        public string Observation { get; set; }

        public string StateCountryId { get; set; }
        public string CityName { get; set; }

        public double Latitude { get; set; }
        public double Longitude { get; set; }
    }
}
