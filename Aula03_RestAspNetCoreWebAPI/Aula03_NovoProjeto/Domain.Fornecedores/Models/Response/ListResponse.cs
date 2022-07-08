using Domain.Fornecedores.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Fornecedores.Models.Response
{
    public class ListResponse<T> : BaseResponse
    {
        public List<T> Items { get; set; }
        public PaginationResponse Pagination { get; set; }
        public Establishment Response { get; set; }

        public ListResponse(List<T> items, PaginationResponse pagination, Establishment response)
        {
            Items = items;
            Pagination = pagination;
            Response = response;
        }
        public ListResponse()
        {
        }
    }
}
