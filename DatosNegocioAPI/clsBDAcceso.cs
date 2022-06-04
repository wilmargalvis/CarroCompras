using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using Microsoft.Data.SqlClient;

namespace DatosNegocioAPI
{
    public class clsBDAcceso
    {

        private BD_Conexion conexion = new BD_Conexion();
        public IDataReader ValidarAcceso(string usuario, string contraseña)
        {
            SqlCommand comando = new SqlCommand();
            comando.Connection = conexion.AbrirConexion();
            comando.CommandText = "spUsuarios_ValidarUsuario";
            comando.CommandType = CommandType.StoredProcedure;
            comando.Parameters.AddWithValue("@Usuario", usuario);
            comando.Parameters.AddWithValue("@Contraseña", contraseña);
            return comando.ExecuteReader();
        }
    }
}
