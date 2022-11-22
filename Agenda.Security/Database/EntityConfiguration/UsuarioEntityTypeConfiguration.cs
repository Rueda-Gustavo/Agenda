using Agenda.Security.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Agenda.Security.Database.EntityConfiguration
{
    public class UsuarioEntityTypeConfiguration : IEntityTypeConfiguration<Usuario>
    {
        public void Configure(EntityTypeBuilder<Usuario> builder)
        {
            builder.ToTable($"{nameof(Usuario)}s");
            builder.HasKey(k => k.Id);

            builder.Property(p => p.NomeUsuario)
                   .HasMaxLength(20)
                   .IsUnicode(false)
                   .IsRequired(true);

            builder.Property(p => p.NomeCompleto)
                   .HasMaxLength(40)
                   .IsUnicode(false)
                   .IsRequired(true);

            builder.Property(p => p.Email)
                   .HasMaxLength(40)
                   .IsUnicode(false)
                   .IsRequired(true);

            builder.Property(p => p.Password)
                   .HasMaxLength(25)
                   .IsUnicode(false)
                   .IsRequired(true);

            builder.Property(p => p.RefreshToken)
                   .HasMaxLength(300)
                   .IsUnicode(false)
                   .IsRequired(false);

            builder.Property(p => p.Roles)
                   .HasMaxLength(1000)
                   .IsUnicode(false)
                   .IsRequired(false);

            builder.Property(p => p.RefreshTokenExpiryTime)
                   .IsRequired(false);

            builder.HasData(new Usuario
            {
                Id = 1,
                Email = "gustavo@gmail.com",
                NomeUsuario = "gustavo",
                NomeCompleto = "Gustavo Rueda dos Reis",
                Password = "1234",
                Roles = "Professor"
            },
            new Usuario
            {
                Id = 2,
                Email = "visit@gmail.com",
                NomeCompleto = "Visitante1",
                NomeUsuario = "visit",
                Password = "4321",
                Roles = "Visitante"
            });

        }
    }
}
