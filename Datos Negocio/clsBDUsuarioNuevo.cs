using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
//using Microsoft.Data.SqlClient;
using EntidadesNegocio;

namespace DatosNegocio
{
    public class clsBDUsuarioNuevo
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

        public int Guardar(clsBEUsuarioNuevo obj_BEUsuarioNuevo)
        {
            SqlCommand comando = new SqlCommand();
            comando.Connection = conexion.AbrirConexion();
            comando.CommandText = "spUsuarios_GuardarUsuario";
            comando.CommandType = CommandType.StoredProcedure;
            comando.Parameters.AddWithValue("@Nombres", obj_BEUsuarioNuevo.Nombres);
            comando.Parameters.AddWithValue("@Usuario", obj_BEUsuarioNuevo.Usuario);
            comando.Parameters.AddWithValue("@Contraseña", obj_BEUsuarioNuevo.Contraseña);
            comando.Parameters.AddWithValue("@Identificacion", obj_BEUsuarioNuevo.Identificacion);
            comando.Parameters.AddWithValue("@Direccion", obj_BEUsuarioNuevo.Direccion);
            comando.Parameters.AddWithValue("@Telefono", obj_BEUsuarioNuevo.Telefono);
            comando.Parameters.AddWithValue("@Perfil", obj_BEUsuarioNuevo.Perfil);
            return (int)comando.ExecuteScalar();

        }
    }
}
