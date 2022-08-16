using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using System;
using System.Collections.Generic;
using System.Text;
using SolicitacaoAgg = SistemaCompra.Domain.SolicitacaoCompraAggregate;

namespace SistemaCompra.Infra.Data.SolicitacaoCompra
{
    public class SolicitacaoCompraConfiguration : IEntityTypeConfiguration<SolicitacaoAgg.SolicitacaoCompra>
    {
        public void Configure(EntityTypeBuilder<SolicitacaoAgg.SolicitacaoCompra> builder)
        {
            builder.ToTable("SolicitacaoCompra");

            builder.Property(c => c.CondicaoPagamento)
                .HasColumnType("datetime");

            builder.Property(c => c.Data)
                .HasColumnType("datetime");

            builder.Property(c => c.NomeFornecedor)
                .HasColumnType("varchar(50)");

            builder.Property(c => c.Situacao)
                .HasConversion(new EnumToStringConverter<SolicitacaoAgg.Situacao>());

            //builder.OwnsOne(c=>c.UsuarioSolicitante)
            //    .Property
        }
    }
}
