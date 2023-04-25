using Microsoft.EntityFrameworkCore;
using NerdStore.Enterprise.Core.DomainObjects;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Model = NerdStore.Enterprise.Cliente.API.Models;

namespace NerdStore.Enterprise.Cliente.API.Data.Mappings
{
    public class ClienteMapping : IEntityTypeConfiguration<Model.Cliente>
    {
        public void Configure(EntityTypeBuilder<Model.Cliente> builder)
        {
            builder.HasKey(c => c.Id);

            builder.Property(c => c.Nome)
                .IsRequired()
                .HasColumnType("varchar(200)");

            builder.OwnsOne(c => c.Cpf, tf =>
            {
                tf.Property(c => c.Numero)
                .IsRequired()
                .HasMaxLength(Cpf.CpfMaxLength)
                .HasColumnName("Cpf")
                .HasColumnType($"varchar({Cpf.CpfMaxLength})");
            });

            builder.OwnsOne(c => c.Email, tf =>
            {
                tf.Property(c => c.Endereco)
                .IsRequired()
                .HasColumnName("Email")
                .HasColumnType($"varchar({Email.EnderecoMaxLength})");
            });

            // 1 : 1 => Cliente : Endereço                   
            builder
                .HasOne(cliente => cliente.Endereco)    //"Cliente" tem um relacionamento com a entidade "Endereco"
                .WithOne(endereco => endereco.Cliente); //Endereco" também tem um relacionamento com a entidade "Cliente"

            builder.ToTable("Clientes");
        }
    }
}