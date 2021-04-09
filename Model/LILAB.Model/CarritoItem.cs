namespace LILAB.Model
{
    public class CarritoItem
    {
        public int CarritoItemId { get; set; }
        public int ProductoId { get; set; }
        public decimal PrecioUnitario { get; set; }
        public int Cantidad { get; set; }
        public decimal PrecioTotal { get; set; }
        public bool Estado { get; set; } = true;
    }
}