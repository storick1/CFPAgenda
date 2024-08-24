<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Site.Master" CodeBehind="Eliminarcitas.aspx.vb" Inherits="Proyectojaz.Eliminarcitas" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
         <div class="container">
        <h2>Eliminar Cita</h2>
        <asp:Panel ID="pnlEliminarCita" runat="server">
            <div class="form-group">
                <label for="ddlCita">Seleccionar Cita</label>
                <asp:DropDownList ID="ddlCita" runat="server" CssClass="form-control" AutoPostBack="True" OnSelectedIndexChanged="ddlCita_SelectedIndexChanged">
                    
                </asp:DropDownList>
            </div>
            <asp:Button ID="btnEliminar" runat="server" Text="Eliminar Cita" CssClass="btn btn-danger" OnClick="btnEliminar_Click" />
            <asp:Label ID="lblSuccess" runat="server" CssClass="text-success"></asp:Label>
            <asp:Label ID="lblError" runat="server" CssClass="text-danger"></asp:Label>
        </asp:Panel>
    </div>
</asp:Content>