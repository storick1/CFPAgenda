<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Site.Master" CodeBehind="AgendarCita.aspx.vb" Inherits="Proyectojaz.AgendarCita" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container">
        <asp:Button ID="btnVolver" runat="server" Text="Volver" OnClick="btnVolver_Click" CssClass="btn-submit" CausesValidation="false"/>
        <h2>Agendar Cita</h2>
        <asp:Panel ID="pnlAgendarCita" runat="server">
            <div class="form-group">
                <label for="ddlCliente">Cliente</label>
                <asp:DropDownList ID="ddlCliente" runat="server" CssClass="form-control" />
            </div>
            <div class="form-group">
                <label for="ddlAuto">Auto</label>
                <asp:DropDownList ID="ddlAuto" runat="server" CssClass="form-control" />
            </div>
            <div class="form-group">
                <label for="ddlServicio">Servicio</label>
                <asp:DropDownList ID="ddlServicio" runat="server" CssClass="form-control" />
            </div>
            <div class="form-group">
                <label for="txtKilometraje">Kilometraje</label>
                <asp:TextBox ID="txtKilometraje" runat="server" CssClass="form-control" />
            </div>
            <div class="form-group">
                <label for="txtNotas">Notas</label>
                <asp:TextBox ID="txtNotas" runat="server" CssClass="form-control" TextMode="MultiLine" Rows="3" />
            </div>
            <asp:Button ID="btnGuardar" runat="server" Text="Guardar Cita" CssClass="btn btn-primary" OnClick="btnGuardar_Click" />
            
            <!-- Label para mostrar mensajes de éxito -->
            <asp:Label ID="lblSuccess" runat="server" CssClass="text-success" />
        </asp:Panel>
    </div>
</asp:Content>