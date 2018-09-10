using DesafioCast.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DesafioCast.Context.Maps
{
    public class LivroMap : IEntityTypeConfiguration<Livro>
    {
        public void Configure(EntityTypeBuilder<Livro> builder)
        {

            builder.ToTable("livro", "biblioteca");

            builder.HasKey(x => x.Id);


            builder.Property(x => x.Id)
               .HasColumnName("id_livro").IsRequired();

            builder.Property(f => f.Nome)
               .HasColumnName("nm_livro").IsRequired()
               .HasMaxLength(100);

            builder.Property(f => f.Descricao)
             .HasColumnName("ds_livro").IsRequired()
             .HasMaxLength(500);

            builder.Property(x => x.Status)
              .HasColumnName("st_livro").IsRequired()
              .HasMaxLength(10);

        }
    }
}
