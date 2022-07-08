using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Fornecedores.Models.Request
{
    public class PaginationRequest : BaseRequest
    {
        /// <summary>
        /// Número da pagina (começando em 0)
        /// </summary>
        /// <example>0</example>
        [Required(ErrorMessage = "Informe o número da página")]
        public int Page { get; set; }

        /// <summary>
        /// Quantidade de registros a ser retornada por página
        /// </summary>
        /// <example>10</example>
        [Required(ErrorMessage = "Informe a quantidade de registros")]
        [Range(1, 100)]
        public int PageSize { get; set; }
    }
}
