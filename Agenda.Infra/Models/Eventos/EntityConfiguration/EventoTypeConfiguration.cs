using Agenda.Infra.Models.Eventos;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Agenda.Infra.Eventos.Models.EntityConfiguration
{
    public class EventoTypeConfiguration : IEntityTypeConfiguration<Evento>
    {
        public void Configure(EntityTypeBuilder<Evento> builder)
        {
            builder.ToTable($"{nameof(Evento)}s");
            builder.HasKey(k => k.Id);

            builder.Property(p => p.Nome)
                   .HasMaxLength(20)
                   .IsUnicode(false)
                   .IsRequired(true);

            builder.Property(p => p.Data)                                      
                   .IsRequired(true);

            builder.Property(p => p.Descricao)
                   .HasMaxLength(100)
                   .IsUnicode(false)
                   .IsRequired(true);

            builder.Property(p => p.CodigoCorEvento)
                   .HasMaxLength(10)
                   .IsUnicode(false)
                   .IsRequired(false);

            builder.HasOne(p => p.Usuario)
                   .WithMany()
                   .HasForeignKey("UsuarioId");
                

        }
    }
}
