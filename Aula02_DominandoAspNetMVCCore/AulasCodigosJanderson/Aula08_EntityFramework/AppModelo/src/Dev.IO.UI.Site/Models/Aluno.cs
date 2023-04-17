namespace Dev.IO.UI.Site.Models
{//Aula 08.04 CRUD  passo 1 
    public class Aluno
    {
        public Aluno()
        {
            Id = Guid.NewGuid();
        }
        public Guid Id { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }

        public DateTime DataNascimento { get; set; }

        public int Nota { get; set; }



    }
}
