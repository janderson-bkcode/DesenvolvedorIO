using Domain.Interface.Service;
using Domain.Models.Request;
using Domain.Models.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Service
{
    internal class ExcelFormLuizaService : IExcelFormLuizaService
    {
        private readonly IExcelFormLuizaService _excelFormLuizaService;

        public ExcelFormLuizaService(IExcelFormLuizaService excelFormLuizaService)
        {
            _excelFormLuizaService = excelFormLuizaService;
        }
        public ListResponse<UserExcelFormManualResponse> GetUsersFormExcel(UserExcelFormManualRequest request)
        {
            return _excelFormLuizaService.GetUsersFormExcel(request);
        }
    }
}
