using System.ComponentModel.DataAnnotations;
using System;


namespace DevIO.UI.Site.Models
{
    public class Filme
    {

        [Display(Name ="Titulo")]
        public string Titulo { get; set; }

        [Display(Name = "Gênero")]
        public string Genero { get; set; }

        [DataType(DataType.DateTime)]
        [Display(Name = "Data de Lancamento")]
        public DateTime DataLancamento { get; set; }

    }
}
