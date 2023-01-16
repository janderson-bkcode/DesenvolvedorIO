using System.Collections.Generic;
using NerdStore.Core.DomainObjects;

namespace NerdStore.Catalogo.Domain
{
    public class Categoria : Entity
    {
        public string Nome { get; private set; }
        public int Codigo { get; private set; }

        // EF Relation
        public ICollection<Produto> Produtos { get; set; } // Necessário para o Mapping da Categoria no Entity Framework não é para fins de Modelagem

        protected Categoria() { } // Necessário para o Entity que pode ter problemas com objetos que não tem construtor aberto(sem parametros)

        public Categoria(string nome, int codigo)
        {
            Nome = nome;
            Codigo = codigo;
            
            Validar();
        }

        public override string ToString()
        {
            return $"{Nome} - {Codigo}";
        }

        public void Validar()
        {
            Validacoes.ValidarSeVazio(Nome, "O campo Nome da categoria não pode estar vazio");
            Validacoes.ValidarSeIgual(Codigo, 0, "O campo Código não pode ser 0");
        }
    }
}