<%@ Page Title="" Language="C#" MasterPageFile="~/MasterAdmin.Master" AutoEventWireup="true" CodeBehind="wfComprasAdmin.aspx.cs" Inherits="CarroCompras.wfComprasAdmin" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

  <div class="container border border-info p-4" style="margin-top: 40px;">

      <div class="col-sm-12" style="text-align: right">
          <asp:Label Text="" ID="lblUsuarioActual" runat="server" Style="text-align: right" ForeColor="OrangeRed" />
      </div>

    <h2 style="text-align:center">Transacciones de compras por usuario</h2><br>
    <div>
        <asp:GridView runat="server" ID="gvCompras" AutoGenerateColumns="false" HorizontalAlign="Center" BackColor="#adb5bd" BorderColor="#ffffff">
            <Columns>
                <asp:BoundField Datafield="Usuario" HeaderText="Usuario Comprador"/>
                <asp:BoundField Datafield="Identificacion" HeaderText="Identificación"/>
                <asp:BoundField Datafield="Direccion" HeaderText="Dirección"/>
                <asp:BoundField Datafield="Fecha" HeaderText="Fecha"/>
                <asp:BoundField Datafield="Nombre" HeaderText="Nombre Producto"/>
                <asp:BoundField Datafield="Descripcion" HeaderText="Descripción"/>
                <asp:BoundField Datafield="CantidadComprada" HeaderText="Cantidad"/>
                <asp:BoundField Datafield="Precio" HeaderText="Precio"/>
                <asp:BoundField Datafield="Cantidad" HeaderText="Stock"/>

<%--                <asp:TemplateField HeaderText="Editar">
                    <ItemTemplate>
                        <asp:LinkButton runat="server" ID="btnEditar" CommandArgument='<%# Eval("ProductoID") %>' CommandName='<%# Eval("Producto") %>' OnCommand="btnEditar_Command" Text="Editar" CausesValidation="false" CssClass="btn btn-primary" />

                    </ItemTemplate>
                </asp:TemplateField>--%>

            </Columns>

        </asp:GridView>
    </div>
    <div class="p-3" style="text-align:center">
        <asp:HyperLink NavigateUrl="~/wfLogin.aspx" Text="Iniciar sesión con otro usuario" runat="server" />
    </div>

  </div>
</asp:Content>
