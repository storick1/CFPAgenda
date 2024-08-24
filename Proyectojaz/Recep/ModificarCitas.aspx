<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Site.Master" CodeBehind="ModificarCitas.aspx.vb" Inherits="Proyectojaz.ModificarCita" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container">
        <h2>Modificar Cita</h2>
        <asp:Panel ID="pnlModificarCita" runat="server">
            <div class="form-group">
                <label for="ddlCita">Seleccionar Cita</label>
                <asp:DropDownList ID="ddlCita" runat="server" CssClass="form-control" AutoPostBack="True" OnSelectedIndexChanged="ddlCita_SelectedIndexChanged">
                </asp:DropDownList>
            </div>
            <div class="form-group">
                <label for="txtFolio">Folio</label>
                <asp:TextBox ID="txtFolio" runat="server" CssClass="form-control" ReadOnly="True" />
            </div>
            <div class="form-group">
                <label for="txtFecha">Fecha</label>
                <asp:TextBox ID="txtFecha" runat="server" CssClass="form-control" />
            </div>
            <div class="form-group">
                <label for="txtHora">Hora</label>
                <asp:TextBox ID="txtHora" runat="server" CssClass="form-control" />
            </div>
            <div class="form-group">
                <label for="ddlCliente">Cliente</label>
                <asp:DropDownList ID="ddlCliente" runat="server" CssClass="form-control" />
            </div>
            <asp:Button ID="btnGuardar" runat="server" Text="Guardar Cambios" CssClass="btn btn-primary" OnClick="btnGuardar_Click" />
            <asp:Label ID="lblSuccess" runat="server" CssClass="text-success" />
        </asp:Panel>
    </div>
</asp:Content>