using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EntidadesNegocio;
using ReglasNegocio;

namespace CarroCompras
{
    public partial class wfNuevoUsuario : System.Web.UI.Page
    {
        private readonly clsBEUsuarioNuevo obj_BEUsuarioNuevo = new clsBEUsuarioNuevo();
        private readonly clsBRUsuarioNuevo obj_BRUsuarioNuevo = new clsBRUsuarioNuevo();
        protected void Page_Load(object sender, EventArgs e)
        {
            

        }

        protected void btnRegistrarme_Click(object sender, EventArgs e)
        {
            llenarUsuarioNuevo();
            int UsuarioID = obj_BRUsuarioNuevo.Guardar(obj_BEUsuarioNuevo);
            if (UsuarioID != 0)
            {
                mensaje.Visible = true;
                mensaje.Attributes["class"] = "alert alert-info";
                lblMensaje.Text = "Se ha guardado el usuario satisfactoriamente. inicie sesión con las nuevas credenciales";
                
                Response.Redirect("~/wfComprasUsuario.aspx?UsuarioID=" + UsuarioID + "&" + "Nombre=" + txtUsuario.Text);
                limpiarRegistro();
            }
        }

        private void limpiarRegistro()
        {
            txtNombres.Text = "";
            txtUsuario.Text = "";
            txtContraseña.Text = "";
            txtIdentificacion.Text = "";
            txtDireccion.Text= "";
            txtTelefono.Text = "";
        }

        private void llenarUsuarioNuevo()
        {
            obj_BEUsuarioNuevo.Nombres = txtNombres.Text;
            obj_BEUsuarioNuevo.Usuario = txtUsuario.Text;
            string pwd = txtContraseña.Text;
            obj_BEUsuarioNuevo.Contraseña = Encrypt.GetSHA256(pwd);
            obj_BEUsuarioNuevo.Identificacion = txtIdentificacion.Text;
            obj_BEUsuarioNuevo.Direccion = txtDireccion.Text;
            obj_BEUsuarioNuevo.Telefono = txtTelefono.Text;
            obj_BEUsuarioNuevo.Perfil = 0;
        }
    }
}