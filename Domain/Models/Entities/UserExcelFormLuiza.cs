﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models.Entities
{
    public class UserExcelFormLuiza
    {
        [Key]
        public int UserId { get; set; }

        public string Nome { get; set; }

        public string Email { get; set; }

    }
}