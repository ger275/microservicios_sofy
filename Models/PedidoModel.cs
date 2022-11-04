namespace microservicios.Models
{
    public class PedidoModel
    {
        public string email { get; set; }
        public string nombre { get; set; }
        public DateTime fechaHora { get; set; }
        public int id_producto { get; set; }
        public int cantidad { get; set; }
    }
}
