using Domain.Models.Request;
using Domain.Models.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interface.Service
{
    public interface IExcelFormLuizaService
    {
        ListResponse<UserExcelFormManualResponse> GetUsersFormExcel(UserExcelFormManualRequest request);
    }
}
