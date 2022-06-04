<%@ Page Title="" Language="C#" AutoEventWireup="true" CodeBehind="wfNuevoUsuario.aspx.cs" Inherits="CarroCompras.wfNuevoUsuario" %>

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
<body>
    <form id="form1" runat="server">
    <div class="container">
        <h3>Registro nuevo usuario</h3>
        <div class="form-acceso">
            <asp:TextBox runat="server" class="texto" id="txtUsuario" placeholder="Usuario" required="true" />
            <asp:TextBox runat="server" class="texto" id="txtContraseña" placeholder="Contraseña" required="true"/>
            <asp:TextBox runat="server" class="texto" id="txtNombres" placeholder="Nombres" required="true"/>
            <asp:TextBox runat="server" class="texto" id="txtIdentificacion" placeholder="Identificación" required="true"/>
            <asp:TextBox runat="server" class="texto" id="txtDireccion" placeholder="Dirección" required="true"/>
            <asp:TextBox runat="server" class="texto" id="txtTelefono" placeholder="Teléfono" required="true"/>

            <asp:Button Text="Registrarme" CssClass="btn btn-primary" id="btnRegistrarme" runat="server" OnClick="btnRegistrarme_Click" />
            
            <div class="label p-3" style="text-align: center">
                <%--<asp:Label Text="Ya tengo cuenta" CssClass="text-warning" runat="server" />--%>
                <asp:HyperLink NavigateUrl="~/wfLogin.aspx" CssClass="text-warning" Text="Ya tengo cuenta" runat="server" />
            </div>
        </div>

        <div class="form-group row p-2" style="text-align: center">
            <div class="col-sm-12">
                <div runat="server" id="mensaje" visible="false">
                    <asp:Label runat="server" ID="lblMensaje" />
                </div>
            </div>
        </div>

    </div>
    </form>
</body>
</html>
