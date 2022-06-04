using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using EntidadesNegocio;
using ReglasNegocio;

namespace CarroCompras
{
    public partial class wfLogin : System.Web.UI.Page
    {
        readonly clsBRUsuarioNuevo obj_BRUsuarioNuevo=new clsBRUsuarioNuevo();


        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack) {


            }

        }

        protected void btnIngresar_Click(object sender, EventArgs e)
        {
            dvMensaje.Visible = false;
            string pwd = Encrypt.GetSHA256(txtContraseña.Text);
            IDataReader Reader = obj_BRUsuarioNuevo.ValidarAcceso(txtUsuario.Text, pwd);

            if (Reader.Read())
            {
                int UsuarioID = Reader.GetInt32(0);
                string Nombres = Convert.ToString(Reader["Nombres"]);
                string Usuario = Convert.ToString(Reader["Usuario"]);
                string Contraseña = Convert.ToString(Reader["Contraseña"]);

                if (Usuario.Equals(txtUsuario.Text) && Contraseña != pwd)
                {
                    dvMensaje.Visible = true;
                    lblMensaje.Text = "El usuario existe, pero ingresó una contraseña incorrecta";
                    return;
                }

                if (Convert.ToUInt16(Reader["Perfil"]) == 1) //perfil igual a (1) es usuario administrador
                {
                    Response.Redirect("~/wfComprasAdmin.aspx?UsuarioID=" + UsuarioID + "&" + "Nombre=" + Nombres + "&" + "Perfil=1");
                }
                 else
                    {
                        Response.Redirect("~/wfComprasUsuario.aspx?UsuarioID=" + UsuarioID + "&" + "Nombre=" + Nombres + "&" + "Perfil=0");
                    }

            }
            else {
                dvMensaje.Visible = true;
                lblMensaje.Text = "El usuario no existe en el sistema. Presione click en 'Registrar cuenta nueva'";
                LimpiarCampos();

            }
            Reader.Close();
            Reader.Dispose();
        }

        private void LimpiarCampos()
        {
            txtUsuario.Text = "";
            txtContraseña.Text = "";

        }

        private void LlenarObjetoUsuarioNuevo()
        {
            throw new NotImplementedException();
        }
    }
}