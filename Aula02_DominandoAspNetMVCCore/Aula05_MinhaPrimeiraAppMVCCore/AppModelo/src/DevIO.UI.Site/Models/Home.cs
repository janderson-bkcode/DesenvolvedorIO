using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using ikvm.runtime;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System.ComponentModel.DataAnnotations;


namespace DevIO.UI.Site.Models
{
    public class Home
    {

        public int id { get; set; }

        [Required(ErrorMessage ="O campo Titulo é obrigatório")]
        public string Titulo { get; set; }

        [DataType(DataType.DateTime,ErrorMessage ="Data em formato incorreto")]
        public DateTime DataLancamento { get; set; }

        public string Genero { get; set; }

        public decimal Valor { get; set; }

        public int Avaliacao { get; set; }





    }
}
