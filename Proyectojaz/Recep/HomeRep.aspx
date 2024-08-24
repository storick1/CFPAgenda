<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Site.Master" CodeBehind="HomeRep.aspx.vb" Inherits="Proyectojaz.HomeRep" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <h1>Recepcionista</h1>
    <div class="container">
        <div class="row">
            <div class="col-md-4 mb-3">
                <asp:Button ID="btnAgendarCita" runat="server" Text="Agendar Cita" CssClass="btn btn-primary btn-block" />
            </div>
            <div class="col-md-4 mb-3">
                <asp:Button ID="btnModificarCita" runat="server" Text="Modificar Cita" CssClass="btn btn-secondary btn-block" />
            </div>
            <div class="col-md-4 mb-3">
                <asp:Button ID="btnConsultarCita" runat="server" Text="Consultar Cita" CssClass="btn btn-info btn-block" />
            </div>
        </div>
        <div class="row">
            <div class="col-md-4 mb-3">
                <asp:Button ID="btnRevisarHistorial" runat="server" Text="Revisar Historial" CssClass="btn btn-warning btn-block" />
            </div>
            <div class="col-md-4 mb-3">
                <asp:Button ID="btnLlenarFormulario" runat="server" Text="Llenar Formulario" CssClass="btn btn-success btn-block" />
            </div>
            <div class="col-md-4 mb-3">
                <asp:Button ID="btnVerProgreso" runat="server" Text="Ver Progreso" CssClass="btn btn-danger btn-block" />
            </div>
        </div>
        <div class="row">
            <div class="col-md-12">
                <asp:Button ID="btnConsultarServicios" runat="server" Text="Consultar Servicios" CssClass="btn btn-dark btn-block" />
            </div>
        </div>
    </div>
</asp:Content>
