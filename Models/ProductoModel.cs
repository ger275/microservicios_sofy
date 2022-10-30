namespace microservicios.Models
{
    public class ProductoModel
    {
        public int id_producto { get; set; }
        public string nombre { get; set; }
        public string img { get; set; }
        public decimal precio { get; set; }
        public string categoria { get; set; }
        public int existencia { get; set; }

    }
}
