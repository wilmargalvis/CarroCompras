using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ReglasNegocio;
using EntidadesNegocio;
using System.Data;

namespace CarroCompras
{
    public partial class wfComprasUsuario : System.Web.UI.Page
    {
        clsBRCompras _objProductos = new clsBRCompras();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack ) {

                if (Request.QueryString["UsuarioID"] ==""|| Request.QueryString["Perfil"] !="0") {
                    Response.Redirect("~/wfLogin.aspx");
                    return;
                }

                lblUsuarioActual.Text= "Usuario actual: " + Request.QueryString["Nombre"];
                Session["UsuarioID"] = Request.QueryString["UsuarioID"];

                CargarProductos();
            }
        }

        private void CargarProductos()
        {
            IDataReader Productos = _objProductos.CargarProductos();
            gvCompras.DataSource = Productos;
            gvCompras.DataBind();
            Productos.Close();
            Productos.Dispose();
        }

        protected void btnGuardarPedido_Click(object sender, EventArgs e)
        {
            string ProductoID = hfProductoId.Value;
            string UsuarioID = Session["UsuarioID"].ToString();
            int CtdPedio = Convert.ToInt32(txtCantidadProductos.Text);

            if (CtdPedio > Convert.ToInt32(Session["Stock"])) {
                mensaje.Attributes["class"] = "alert alert-warning";
                lblMensaje.Text = "La cantidad no puede ser superior al stock del producto";
                mensaje.Visible = true;
                return;
            }

            if (UsuarioID != "" && ProductoID != "")
            {

                new clsBRCompras().GuadarPedido(ProductoID, UsuarioID, txtCantidadProductos.Text);
                mensaje.Visible = true;
                mensaje.Attributes["class"] = "alert alert-info";
                lblMensaje.Text = "Se ha guardado el pedido del producto llamado " + lblNombreProducto.Text + ". Recargue la página para ver el stock actualizado";
            }
            else {
                mensaje.Attributes["class"] = "alert alert-warning";
                lblMensaje.Text = "Registro inválido, no se identifica el usuario, asegúrese de que está logueado correctamente";
                mensaje.Visible = true;
            }
        }

        protected void btnEditar_Command(object sender, CommandEventArgs e)
        {
            mensaje.Visible = false;
            string[] cadena = e.CommandName.Split(';');
            
            hfProductoId.Value = cadena[0];
            lblNombreProducto.Text = cadena[1];
            Session["Stock"] = Convert.ToInt32(cadena[2]);
            txtCantidadProductos.Text = "";
            lblPedido.Visible = true;
            lblNombreProducto.Visible = true;
            txtCantidadProductos.Visible = true;
            btnGuardarPedido.Visible = true;
        }
    }
}