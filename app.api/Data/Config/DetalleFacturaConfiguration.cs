using app.api.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace app.api.Data.Config
{
    public class DetalleFacturaConfiguration : IEntityTypeConfiguration<DetalleFactura>
    {
        public void Configure(EntityTypeBuilder<DetalleFactura> builder)
        {
            builder.HasOne(b => b.Cliente).WithMany().HasForeignKey(p => p.ClienteId);
            builder.HasOne(t => t.Factura).WithMany().HasForeignKey(p => p.FacturaId).OnDelete(DeleteBehavior.Restrict);
            builder.HasOne(t => t.Producto).WithMany().HasForeignKey(p => p.ProductoId);
        }
    }
}
