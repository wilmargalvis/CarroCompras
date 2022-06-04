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
    internal class BD_Conexion
    {
        private SqlConnection Conexion = new SqlConnection("Server=.\\SQLEXPRESS;DataBase=Carro de compras;Integrated Security=true;Encrypt=False");
        public SqlConnection AbrirConexion()
        {
            if (Conexion.State == ConnectionState.Closed)
                Conexion.Open();
            return Conexion;
        }
        public SqlConnection CerrarConexion()
        {
            if (Conexion.State == ConnectionState.Open)
                Conexion.Close();
            return Conexion;
        }

    }
}
