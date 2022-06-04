using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
//using Microsoft.Data.SqlClient;


namespace DatosNegocio
{
    public class clsBDCompras
    {
        private BD_Conexion conexion = new BD_Conexion();
        public IDataReader CargarCompras()
        {

            SqlCommand comando = new SqlCommand();
            comando.Connection = conexion.AbrirConexion();
            comando.CommandText = "spCompras_Buscar";
            comando.CommandType = CommandType.StoredProcedure;
            return comando.ExecuteReader();
        }

        public void GuadarPedido(string IDProducto, string IDUsuario, string ctdProductos)
        {
            DateTime hoy = DateTime.Now;
            SqlCommand comando = new SqlCommand();
            comando.Connection = conexion.AbrirConexion();
            comando.CommandText = "spCompras_Guardar";
            comando.CommandType = CommandType.StoredProcedure;
            comando.Parameters.AddWithValue("@ProductoID", IDProducto);
            comando.Parameters.AddWithValue("@UsuarioID", IDUsuario);
            comando.Parameters.AddWithValue("@Fecha", Convert.ToDateTime(hoy));
            comando.Parameters.AddWithValue("@CantidadComprada", ctdProductos);

            comando.ExecuteNonQuery();
            comando.Parameters.Clear();
            conexion.CerrarConexion();
        }

        public IDataReader CargarProductos()
        {
            SqlCommand comando = new SqlCommand();
            comando.Connection = conexion.AbrirConexion();
            comando.CommandText = "spProductos_Buscar";
            comando.CommandType = CommandType.StoredProcedure;
            return comando.ExecuteReader();
        }
    }
}
