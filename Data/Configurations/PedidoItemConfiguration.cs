﻿using System;
using System.Collections.Generic;
using System.Text;
using CursoEFCore.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
namespace CursoEFCore.Data.Configurations
{
    public class PedidoItemConfiguration : IEntityTypeConfiguration<PedidoItem>
    {
        public void Configure(EntityTypeBuilder<PedidoItem> builder)
        {
            builder.ToTable("PedidoItens");
            builder.HasKey(p => p.Id);
            builder.Property(p => p.Quantidade).HasDefaultValue(0).IsRequired();
            builder.Property(p => p.Valor).HasDefaultValue(0).IsRequired();
            builder.Property(p => p.Desconto).HasDefaultValue(0).IsRequired();
        }
    }
}
