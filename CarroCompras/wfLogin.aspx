<%@ Page Title="" Language="C#" AutoEventWireup="true" CodeBehind="wfLogin.aspx.cs" Inherits="CarroCompras.wfLogin" %>

<!DOCTYPE html>

<html>
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>

    <link rel="preconnect" href="https://fonts.gstatic.com">
    <link href="https://fonts.googleapis.com/css2?family=Poppins:ital,wght@0,100;1,300&display=swap" rel="stylesheet">
    <link href="https://fonts.googleapis.com/icon?family=Material+Icons" rel="stylesheet">
    <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.0.0-beta2/dist/css/bootstrap.min.css" rel="stylesheet" integrity="sha384-BmbxuPwQa2lc/FVzBcNJ7UAyJxM6wuqIj61tLrc4wSX0szH/Ev+nYRRuWlolflfl" crossorigin="anonymous">

    <link href="Theme/style.css" rel="stylesheet" />

</head>

<script runat="server">

    private void NuevoUsuario() {
        Response.Redirect("~/wfNuevoUsuario.aspx");
        //lblRegistrarme.Attributes.Add("onClick", "CallMe();");
    }


</script>

<body>
    <form id="form1" runat="server">
     <div class="container">
        <h3>Ingreso Carrito de Compras</h3>

        <div class="form-acceso">
            <asp:TextBox runat="server" class="texto" id="txtUsuario" placeholder="Usuario" required="true"/>
            <asp:TextBox runat="server" class="texto" id="txtContraseña" placeholder="Contraseña" required="true"/>
            <asp:Button Text="Ingresar" CssClass="btn btn-primary" id="btnIngresar" runat="server" OnClick="btnIngresar_Click" />
            
            <div class="label p-3" style="text-align: center">
                <asp:HyperLink NavigateUrl="~/wfNuevoUsuario.aspx" CssClass="text-warning" ID="hplRegistrarme" OnClick="hplRegistrarme_Click" runat="server" Text="Registrar cuenta nueva" />
                <%--<asp:Label Text="No tengo cuenta" CssClass="text-warning" id="lblRegistrarme" OnClick="lblRegistrarme_Click" runat="server" />--%>
            </div>
        </div>

         <div class="row">
             <div class="col-md-12">
                 <div class="alert alert-danger" runat="server" id="dvMensaje" visible="False">
                     <asp:Label runat="server" Text="" ID="lblMensaje"></asp:Label>
                 </div>
             </div>
         </div>

     </div>
    </form>
</body>
</html>




