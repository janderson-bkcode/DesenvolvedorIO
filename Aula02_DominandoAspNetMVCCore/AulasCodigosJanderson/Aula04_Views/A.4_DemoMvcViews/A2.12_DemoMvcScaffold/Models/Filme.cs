using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace A2._12_DemoMvcScaffold.Models
{    // Aula de prática com Annotations
    public class Filme
    {
        [Key] // Entende que o campo ID é a chave primária e vai colocá-la como incremental
        public int Id { get; set; }


        //Obrigando a validação e inserção do campo Titulo
        [Required(ErrorMessage = "O Campo Titulo é obrigatório")]
        //Definindo Validação de quantidade minima e máxima de caracteres do campo Titulo 
        [StringLength(60, MinimumLength = 3, ErrorMessage = "O título deve ter 3 a 60 caracteres")]
        public string Titulo { get; set; }


        //Validando o tipo de Data, ou seja, deve receber dateTime
        [DataType(DataType.DateTime, ErrorMessage = "Data em formaro incorreto")]
        [Required(ErrorMessage = "O Campo Data de Lançamento é obrigatório")]
        //Setando o nome da propriedade a ser exibido para o usuário
        [Display(Name ="Data de Lançamento")]
        public DateTime DataLancamento { get; set; }


        [RegularExpression(@"^[A-Z] + [a-zA-Z\u00C0-\u00FF]""'\w-]*$",ErrorMessage ="Genero em formato Inválido")]
        //Maximo de 30 caracteres e usando required dentro do mesmo colchete e usar mais de uma Annotation
        [StringLength(30,ErrorMessage ="Máximo de 30 Caracteres"), Required(ErrorMessage = "Campo Gênero é obrigatorio")]
        public string Genero { get; set; }



        //Validando minimo  e máximo valor 
        [Range(1,1000,ErrorMessage ="Valor de 1 a 1000")]
        [Required(ErrorMessage ="Preencha o campo valor")]
        //Definindo o comportamento da coluna valor no Banco de dados como decimal e tamanho no banco
        [Column(TypeName = "decimal(18,2)")]
        public decimal Valor { get; set; }





        [RegularExpression(@"^[0-5]*$",ErrorMessage ="Somente Números de 0 a 5")]
        [Required(ErrorMessage = "Preencha o campo Avaliação")]
        [Display(Name = "Avaliação")]
        public int Avaliacao { get; set; }




    }
}
