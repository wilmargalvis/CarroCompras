using System;
using System.Data;
using Microsoft.Data.SqlClient;

namespace DatosNegocioAPI
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
    }
}
