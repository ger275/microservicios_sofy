using microservicios.Datos;
using microservicios.Models;
using Microsoft.AspNetCore.Mvc;
using MySql.Data.MySqlClient;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace microservicios.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class Producto : ControllerBase
    {
        ConexionBD con = new ConexionBD();
        MySqlConnection conecta = new MySqlConnection();

        // GET: api/<Producto>
        [HttpGet]
        public ActionResult<List<ProductoModel>> Get()
        {
            conecta = con.conectarBD();
            List<ProductoModel> listarProductos = new List<ProductoModel>();
            MySqlCommand sql = new MySqlCommand("select p.id_ptoducto, p.nombre, p.img_produc, p.precio_unitario, p.categoria, s.existencia from producto p, stock s where p.id_ptoducto = s.id_producto", conecta);
            MySqlDataReader leer = sql.ExecuteReader();

            while (leer.Read())
            {
                ProductoModel model = new ProductoModel();
                model.id_producto = Convert.ToInt32(leer["id_ptoducto"].ToString());
                model.nombre = leer["nombre"].ToString();
                model.img = leer["img_produc"].ToString();
                model.precio = Convert.ToDecimal(leer["precio_unitario"].ToString());
                model.categoria = leer["categoria"].ToString();
                model.existencia = Convert.ToInt32(leer["existencia"].ToString());
                listarProductos.Add(model);
            }
            return listarProductos;
        }

        // GET api/<Producto>/5
        [HttpGet("{categoria}")]
        public ActionResult<List<ProductoModel>> Get(string categoria)
        {
            conecta = con.conectarBD();
            List<ProductoModel> listarProductos = new List<ProductoModel>();
            MySqlCommand sql = new MySqlCommand("select p.id_ptoducto, p.nombre, p.img_produc, p.precio_unitario, p.categoria, s.existencia from producto p, stock s where p.id_ptoducto = s.id_producto and p.categoria = '" + categoria + "'", conecta);
            MySqlDataReader leer = sql.ExecuteReader();

            while (leer.Read())
            {
                ProductoModel model = new ProductoModel();
                model.id_producto = Convert.ToInt32(leer["id_ptoducto"].ToString());
                model.nombre = leer["nombre"].ToString();
                model.img = leer["img_produc"].ToString();
                model.precio = Convert.ToDecimal(leer["precio_unitario"].ToString());
                model.categoria = leer["categoria"].ToString();
                model.existencia = Convert.ToInt32(leer["existencia"].ToString());
                listarProductos.Add(model);
            }
            return listarProductos;
        }

        // POST api/<Producto>
        [HttpPost]
        public void Post([FromBody] PedidoModel pedido)
        {
            Console.WriteLine(pedido.fechaHora);
            conecta = con.conectarBD();
            MySqlCommand sql = new MySqlCommand("insert into pedido_tmp(email,nombre,fechaHora,id_producto,cantidad) values('"+pedido.email+"','"+pedido.nombre+"','"+pedido.fechaHora.ToString("yyyy-MM-dd HH:mm:ss") +"',"+pedido.id_producto+","+pedido.cantidad+")", conecta);
            int escribir = sql.ExecuteNonQuery();
            Console.WriteLine(escribir);
        }

    }
}
