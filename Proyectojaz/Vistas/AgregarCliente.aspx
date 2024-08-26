<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Site.Master" CodeBehind="AgregarCliente.aspx.vb" Inherits="Proyectojaz.AgregarCliente" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
           <div class="container">
       <asp:Button ID="btnVolver" runat="server" Text="Volver" OnClick="btnVolver_Click" CssClass="btn-submit" CausesValidation="false"/>
    <h2>Agregar Clientes</h2>
    <asp:Panel ID="pmlAgregarClientes" runat="server">
            <asp:Label ID="lblMensaje" runat="server" CssClass="message"></asp:Label>

        <div class="form-group">
            <label for="txtNombre">Nombre</label>
            <asp:TextBox ID="txtNombre" runat="server" CssClass="form-control" />
        </div>
        <div class="form-group">
            <label for="txtPaterno">Paterno</label>
            <asp:TextBox ID="txtPaterno" runat="server" CssClass="form-control" />
        </div>
           <div class="form-group">
       <label for="txtMaterno">Materno</label>
       <asp:TextBox ID="txtMaterno" runat="server" CssClass="form-control" />
   </div>
        <div class="form-group">
            <label for="txtNumero">Numero</label>
            <asp:TextBox ID="txtNumero" runat="server" CssClass="form-control" />
        </div>
  <div class="form-group">
    <label for="txtCorreo">Correo</label>
    <asp:TextBox ID="Correo" runat="server" CssClass="form-control" />
</div>
                <div class="form-group">
    <label for="txtDirreccion">Direccion</label>
    <asp:TextBox ID="txtDirreccion" runat="server" CssClass="form-control" />
</div>
        <asp:Button ID="btnGuardar" runat="server" Text="Guardar Cambios" CssClass="btn btn-primary" OnClick="btnGuardar_Click" />
        <asp:Label ID="lblSuccess" runat="server" CssClass="text-success" />
    </asp:Panel>
</div>
</asp:Content>
