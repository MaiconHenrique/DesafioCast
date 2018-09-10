using DesafioCast.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DesafioCast.Context.Maps
{
    public class LoginMap : IEntityTypeConfiguration<Login>
    {
        public void Configure(EntityTypeBuilder<Login> builder)
        {

            builder.ToTable("login", "biblioteca");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id)
               .HasColumnName("id_login");

            builder.Property(x => x.Usuario)
             .HasColumnName("usuario_login");

            builder.Property(x => x.Senha)
             .HasColumnName("senha_login");

        }
    }
}
