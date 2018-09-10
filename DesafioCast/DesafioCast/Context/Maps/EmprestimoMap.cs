using DesafioCast.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DesafioCast.Contexto.Maps
{
    public class EmprestimoMap : IEntityTypeConfiguration<Emprestimo>
    {
        public void Configure(EntityTypeBuilder<Emprestimo> builder)
        {
            builder.ToTable("emprestimo", "biblioteca");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id)
               .HasColumnName("id_emprestimo").IsRequired();

            builder.Property(x => x.IdCliente)
               .HasColumnName("id_cliente_emprestimo");

            builder.HasOne(x => x.Cliente)
               .WithMany()
               .HasForeignKey(x => x.IdCliente)
               .IsRequired();

            builder.Property(x => x.IdLivro)
             .HasColumnName("id_livro_emprestimo");

            builder.HasOne(x => x.Livro)
              .WithMany()
              .HasForeignKey(x => x.IdLivro)
              .IsRequired();

            builder.Property(x => x.DataAluguel)
              .HasColumnName("dt_aluguel_emprestimo").IsRequired();

            builder.Property(x => x.DataEntrega)
          .HasColumnName("dt_entrega_emprestimo").IsRequired();
        }
    }
}
