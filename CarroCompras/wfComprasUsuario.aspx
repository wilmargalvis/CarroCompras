<%@ Page Title="" Language="C#" MasterPageFile="~/Layout.Master" AutoEventWireup="true" CodeBehind="wfComprasUsuario.aspx.cs" Inherits="CarroCompras.wfComprasUsuario" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

  <div class="container border border-info p-4" style="margin-top: 40px;">
      <div class="p-3">
          <div class="col-sm-12" style="text-align: right">
              <asp:Label Text="" ID="lblUsuarioActual" runat="server" Style="text-align: right" ForeColor="OrangeRed" />
          </div>
          <h3 style="text-align: center">Realiza compras de manera más segura</h3>
          <h1 style="text-align: center">Inventario de productos</h1><br>
      </div>


    <div>
        <asp:GridView runat="server" ID="gvCompras" AutoGenerateColumns="false" HorizontalAlign="Center" BackColor="#adb5bd" BorderColor="#ffffff">
            <Columns>
                <asp:BoundField Datafield="ProductoID" HeaderText="ProductoID"/>
                <asp:BoundField Datafield="Nombre" HeaderText="Nombre del Producto"/>
                <asp:BoundField Datafield="Cantidad" HeaderText="Cantidad en Stock"/>
                <asp:BoundField Datafield="Descripcion" HeaderText="Descripción"/>
                <asp:BoundField Datafield="Precio" HeaderText="Precio"/>

                <asp:TemplateField HeaderText="Solicitar Producto">
                    <ItemTemplate>
                        <asp:LinkButton runat="server" ID="btnEditar" CommandName='<%# Eval("Cadena") %>' OnCommand="btnEditar_Command" Text="Seleccionar" CausesValidation="false" CssClass="btn btn-primary" />

                    </ItemTemplate>
                </asp:TemplateField>

            </Columns>

        </asp:GridView><br>
    </div>


    <div class="form-group row">
        <div class="col-sm-5" style="text-align: right">
            <asp:Label runat="server" ID="lblPedido" Text="Producto seleccionado:  " Visible="false" />
            <asp:Label runat="server" ID="lblNombreProducto" Font-Bold="true"></asp:Label>
            <asp:HiddenField runat="server" ID="hfProductoId" Value="" />
        </div>
        <div class="col-sm-2" style="text-align: right">
            <asp:TextBox runat="server" ID="txtCantidadProductos" PlaceHolder="Cantidad a comprar" ValidationGroup="validarCantidad" Visible="false" type="number" required="true" />
        </div>
        <div class="col-sm-3" style="text-align: center">
            <asp:Button Text="Realizar pedido" ID="btnGuardarPedido" CssClass=" btn btn-primary" OnClick="btnGuardarPedido_Click" runat="server" ValidationGroup="validarCantidad" CausesValidation="true" Visible="false" />
        </div>

        <div class="col-sm-2">
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
</asp:Content>
