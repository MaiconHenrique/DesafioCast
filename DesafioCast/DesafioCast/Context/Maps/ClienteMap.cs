using DesafioCast.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DesafioCast.Context.Maps
{
    public class ClienteMap : IEntityTypeConfiguration<Cliente>
    {
        public void Configure(EntityTypeBuilder<Cliente> builder)
        {
            builder.ToTable("cliente", "biblioteca");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id)
               .HasColumnName("id_cliente").IsRequired();

            builder.Property(x => x.Nome)
               .HasColumnName("nm_cliente").IsRequired()
               .HasMaxLength(100);

            builder.Property(x => x.Cpf)
             .HasColumnName("cpf_cliente").IsRequired()
             .HasMaxLength(11);


        }
    }
}
