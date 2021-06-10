namespace app.api.Entities
{
    public class DetalleFactura : BaseEntity
    {
        public Producto Producto { get; set; }
        public int ProductoId { get; set; }
        public Cliente Cliente { get; set; }
        public int ClienteId { get; set; }
        public Factura Factura { get; set; }
        public int FacturaId { get; set; }
        public float Cantidad { get; set; }
        public float Subtotal { get; set; }
    }
}