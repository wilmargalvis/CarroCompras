using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data;
using Newtonsoft.Json;
using DatosNegocioAPI;
using EntidadesNegocioAPI;
//using CarroCompras;

namespace WebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ComprasController : Controller
    {

        public IActionResult Index()
        {
            return View();
        }

        //Consulta servicio compras de usuarios
        //URL local del servicio: https://localhost:puerto/api/Compras/usuariosCompras
        [HttpGet("usuariosCompras")]
        public string UsuarioCompras(string Usuario, string Clave)
        {
            string pwd = CarroCompras.Encrypt.GetSHA256(Clave);
            IDataReader Reader = new clsBDAcceso().ValidarAcceso(Usuario, pwd);

            if (Reader.Read())
            {
                //int UsuarioID = Reader.GetInt32(0);
                //string Nombres = Convert.ToString(Reader["Nombres"]);
                if (Convert.ToUInt16(Reader["Perfil"]) == 1) //perfil igual (1) es usuario administrador
                {
                    IDataReader UsuariosCompras = new clsBDCompras().CargarCompras();
                    List<clsBECompras> lista = new List<clsBECompras>();

                    while (UsuariosCompras.Read())
                    {
                        clsBECompras _objEBCompras = new clsBECompras();
                        _objEBCompras.Usuario = UsuariosCompras["Usuario"].ToString();
                        _objEBCompras.Identificacion = UsuariosCompras["Identificacion"].ToString();
                        _objEBCompras.Direccion = UsuariosCompras["Direccion"].ToString();
                        _objEBCompras.CantidadComprada = UsuariosCompras["CantidadComprada"].ToString();
                        _objEBCompras.FechaCompra = UsuariosCompras["Fecha"].ToString();
                        _objEBCompras.NombreProducto = UsuariosCompras["Nombre"].ToString();
                        _objEBCompras.DescripcionProducto = UsuariosCompras["Descripcion"].ToString();
                        _objEBCompras.Stock = UsuariosCompras["Cantidad"].ToString();
                        _objEBCompras.Precio = UsuariosCompras["Precio"].ToString();

                        lista.Add(_objEBCompras);
                    }

                    string json = JsonConvert.SerializeObject(lista);
                    return json;
                }
                else
                {
                    //Response.Redirect("~/wfComprasUsuario.aspx?UsuarioID=" + UsuarioID + "&" + "Nombre=" + Nombres + "&" + "Perfil=0");
                    return "Su perfil NO está autorizado";
                }

            }
            else
            { 
                return "Los datos de autenticación no son correctos";
            }

        }


        //Consulta servicio Productos Disponibles
        //URL local del servicio: https://localhost:puerto/api/Compras/productosdisponibles
        [HttpGet("productosdisponibles")]
        public string ProductosDisponibles(string Usuario, string Clave)
        {
            string pwd = CarroCompras.Encrypt.GetSHA256(Clave);
            IDataReader Reader = new clsBDAcceso().ValidarAcceso(Usuario, pwd);

            if (Reader.Read())
            {

                if (Convert.ToUInt16(Reader["Perfil"]) == 1) //perfil igual (1) es usuario administrador
                {
                    IDataReader ProductosDisponibles = new clsBDProductos().CargarProductos();
                    List<clsBEProductos> lista = new List<clsBEProductos>();

                    while (ProductosDisponibles.Read())
                    {
                        clsBEProductos _objEBProductos = new clsBEProductos();
                        _objEBProductos.Nombre = ProductosDisponibles["Nombre"].ToString();
                        _objEBProductos.Cantidad = ProductosDisponibles["Cantidad"].ToString();
                        _objEBProductos.Descripcion = ProductosDisponibles["Descripcion"].ToString();
                        _objEBProductos.Precio = ProductosDisponibles["Precio"].ToString();


                        lista.Add(_objEBProductos);
                    }

                    string json = JsonConvert.SerializeObject(lista);
                    return json;
                }
                else
                {
                    //Response.Redirect("~/wfComprasUsuario.aspx?UsuarioID=" + UsuarioID + "&" + "Nombre=" + Nombres + "&" + "Perfil=0");
                    return "Su perfil NO está autorizado";
                }

            }
            else
            {
                return "Los datos de autenticación no son correctos";
            }

        }


        //Actualizar los Productos Disponibles
        //URL local del servicio: https://localhost:puerto/api/Compras/actualizarproductos
        [HttpPut("actualizarproductos")]
        public string ActualizarProductos(string Usuario, string Clave, clsBEProductos Producto)
        {

            string pwd = CarroCompras.Encrypt.GetSHA256(Clave);
            IDataReader Reader = new clsBDAcceso().ValidarAcceso(Usuario, pwd);

            if (Reader.Read())
            {

                if (Convert.ToUInt16(Reader["Perfil"]) == 1) //perfil igual (1) es usuario administrador
                {
                    if (int.TryParse(Producto.ProductoID, out int valor))
                    {
                        clsBEProductos _objEBProductos = new clsBEProductos();
                        _objEBProductos.ProductoID = Producto.ProductoID;
                        _objEBProductos.Nombre = Producto.Nombre;
                        _objEBProductos.Cantidad = Producto.Cantidad;
                        _objEBProductos.Descripcion = Producto.Descripcion;
                        _objEBProductos.Precio = Producto.Precio;

                        int update = new clsBDProductos().ActualizarProductos(_objEBProductos);

                        if (update >0)
                        {
                            return "Producto actualizado con éxito";
                        }
                        else {
                            return "No fue posible realizar la actualización. Verifique si existe el producto";
                        }

                        
                    }
                    else { 
                            return "El ID del producto debe ser un número";
                         }
                }
                else
                {
                    //Response.Redirect("~/wfComprasUsuario.aspx?UsuarioID=" + UsuarioID + "&" + "Nombre=" + Nombres + "&" + "Perfil=0");
                    return "Su perfil NO está autorizado";
                }

            }
            else
            {
                return "Los datos de autenticación no son correctos";
            }

        }
    }
}
