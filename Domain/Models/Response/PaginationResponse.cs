using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models.Response
{
    public class PaginationResponse
    {
        /// <summary>
        /// Pagina
        /// </summary>
        /// <example>1</example>
        [JsonProperty(PropertyName = "page")]
        public int Page { get; set; }

        /// <summary>
        /// Total de páginas
        /// </summary>
        /// <example>10</example>
        [JsonProperty(PropertyName = "totalPages")]
        public int TotalPages { get; set; }

        /// <summary>
        /// Registros retornados pela consulta
        /// </summary>
        /// <example>1000</example>
        [JsonProperty(PropertyName = "entries")]
        public int Entries { get; set; }

        /// <summary>
        /// Total de registros
        /// </summary>
        /// <example>100</example>
        [JsonProperty(PropertyName = "totalEntries")]
        public int TotalEntries { get; set; }
    }
}
