using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using Microsoft.Data.SqlClient;
using EntidadesNegocioAPI;

namespace DatosNegocioAPI
{
    public class clsBDProductos
    {
        private BD_Conexion conexion = new BD_Conexion();
        public IDataReader CargarProductos()
        {

            SqlCommand comando = new SqlCommand();
            comando.Connection = conexion.AbrirConexion();
            comando.CommandText = "spProductos_Buscar";
            comando.CommandType = CommandType.StoredProcedure;
            return comando.ExecuteReader();
        }

        public int ActualizarProductos(clsBEProductos clsBEProductos)
        {
            try
            {
                SqlCommand comando = new SqlCommand();
                comando.Connection = conexion.AbrirConexion();
                comando.CommandText = "spProductos_Actualizar";
                comando.CommandType = CommandType.StoredProcedure;
                comando.Parameters.AddWithValue("@ProductoID", clsBEProductos.ProductoID);
                comando.Parameters.AddWithValue("@Nombre", clsBEProductos.Nombre);
                comando.Parameters.AddWithValue("@Cantidad", clsBEProductos.Cantidad);
                comando.Parameters.AddWithValue("@Descripcion", clsBEProductos.Descripcion);
                comando.Parameters.AddWithValue("@Precio", clsBEProductos.Precio);

                return (int)comando.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                return 0;
            }
        }
    }
}
