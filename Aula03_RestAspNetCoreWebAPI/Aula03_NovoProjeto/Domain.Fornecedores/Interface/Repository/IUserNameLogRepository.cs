
using Domain.Fornecedores.Models.Request;
using Domain.Fornecedores.Models.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;




namespace Domain.Fornecedores.Interface
{
    public interface IUsernameLogRepository
    {
        Task<BaseResponse> Insert(UsernameLogRequest request);
    }
}

