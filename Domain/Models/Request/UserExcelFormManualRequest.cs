﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models.Request
{
    public class UserExcelFormManualRequest : BaseRequest
    {
        public string Nome { get; set; }

        public string Email { get; set; }
    }
}