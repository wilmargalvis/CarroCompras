using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using ReglasNegocio;

namespace CarroCompras
{
    public partial class wfComprasAdmin : System.Web.UI.Page
    {
        clsBRCompras _objBRProductos = new clsBRCompras();
        protected void Page_Load(object sender, EventArgs e)
        {

            if (!IsPostBack)
            {

                if (Request.QueryString["UsuarioID"] == "" || Request.QueryString["Perfil"] != "1")
                {
                    Response.Redirect("~/wfLogin.aspx");
                    return;
                }

                lblUsuarioActual.Text = "Usuario actual: " + Request.QueryString["Nombre"];
                Session["Usuario"] = Request.QueryString["UsuarioID"];

                CargarCompras();
            }

        }

        private void CargarCompras()
        {
            IDataReader Compras = _objBRProductos.CargarCompras();
            gvCompras.DataSource = Compras;
            gvCompras.DataBind();
            Compras.Close();
            Compras.Dispose();
        }
    }
}