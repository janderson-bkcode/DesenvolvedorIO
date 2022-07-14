using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models.Response
{
    public class ListResponse<T> : BaseResponse
    {
        public List<T> Items { get; set; }
        public PaginationResponse Pagination { get; set; }

        public UserExcelFormManualResponse Response { get; set; }

        public ListResponse(List<T> items, PaginationResponse pagination, UserExcelFormManualResponse response)
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
