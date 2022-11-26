using Agenda.Security.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Agenda.Security.Database.EntityConfiguration
{
    public class UsuarioTesteEntityConfiguration : IEntityTypeConfiguration<UsuarioTeste>
    {
        public void Configure(EntityTypeBuilder<UsuarioTeste> builder)
        {
            builder.ToTable($"{nameof(UsuarioTeste)}");
            builder.HasKey(k => k.Id);

            builder.Property(p => p.NomeUsuario)
                   .HasMaxLength(20)
                   .IsUnicode(false)
                   .IsRequired(true);

            builder.Property(p => p.NomeCompleto)
                   .HasMaxLength(40)
                   .IsUnicode(false)
                   .IsRequired(true);

            builder.Property(p => p.Password)
                   .HasMaxLength(25)
                   .IsUnicode(false)
                   .IsRequired(true);

            builder.HasData(new UsuarioTeste
            {
                Id = 1,               
                NomeUsuario = "gustavo",
                NomeCompleto = "Gustavo Rueda dos Reis",
                Password = "1234",               
            },
           new UsuarioTeste
           {
               Id = 2,               
               NomeCompleto = "Visitante1",
               NomeUsuario = "visit",
               Password = "4321",               
           });

        }
    }
}
