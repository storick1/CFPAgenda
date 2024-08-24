<<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Site.Master" CodeBehind="llenarform.aspx.vb" Inherits="Proyectojaz.llenarform" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container mt-5">
        <asp:Button ID="btnVolver" runat="server" Text="Volver" OnClick="btnVolver_Click" CssClass="btn-submit" CausesValidation="false"/>
        <h2>Formulario de Registro de Auto</h2>
        <asp:Panel ID="pnlFormulario" runat="server">
            <div class="form-group">
    <label for="txtIdCliente">Id Cliente:</label>
    <asp:TextBox ID="txtIdCliente" runat="server" CssClass="form-control" />
</div>
            <div class="form-group">
                <label for="txtNombre">Nombre:</label>
                <asp:TextBox ID="txtNombre" runat="server" CssClass="form-control" />
            </div>
            <div class="form-group">
                <label for="txtPaterno">Paterno:</label>
                <asp:TextBox ID="txtPaterno" runat="server" CssClass="form-control" />
            </div>
            <div class="form-group">
                <label for="txtMaterno">Materno:</label>
                <asp:TextBox ID="txtMaterno" runat="server" CssClass="form-control" />
            </div>
            <div class="form-group">
                <label for="txtNumero">Número:</label>
                <asp:TextBox ID="txtNumero" runat="server" CssClass="form-control" />
            </div>
            <div class="form-group">
                <label for="txtCorreo">Correo:</label>
                <asp:TextBox ID="txtCorreo" runat="server" CssClass="form-control" />
            </div>
            <div class="form-group">
                <label for="txtDireccion">Dirección:</label>
                <asp:TextBox ID="txtDireccion" runat="server" CssClass="form-control" />
            </div>

            <div class="form-group">
                <label for="ddlMarca">Marca:</label>
                <asp:DropDownList ID="ddlMarca" runat="server" CssClass="form-control" />
            </div>
            <div class="form-group">
                <label for="ddlSubmarca">Submarca:</label>
                <asp:DropDownList ID="ddlSubmarca" runat="server" CssClass="form-control" />
            </div>
            <div class="form-group">
                <label for="ddlColor">Color:</label>
                <asp:DropDownList ID="ddlColor" runat="server" CssClass="form-control" />
            </div>
            <div class="form-group">
                <label for="txtModelo">Modelo:</label>
                <asp:TextBox ID="txtModelo" runat="server" CssClass="form-control" />
            </div>

            <asp:Button ID="btnGuardar" runat="server" Text="Guardar" CssClass="btn btn-primary" OnClick="btnGuardar_Click" />
            <asp:Label ID="lblError" runat="server" ForeColor="Red" CssClass="mt-2" />
            <asp:Label ID="lblSuccess" runat="server" ForeColor="Green" CssClass="mt-2" />
        </asp:Panel>
    </div>
</asp:Content>