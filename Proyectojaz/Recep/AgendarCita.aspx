<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Site.Master" CodeBehind="AgendarCita.aspx.vb" Inherits="Proyectojaz.AgendarCita" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container">
        <asp:Button ID="btnVolver" runat="server" Text="Volver" OnClick="btnVolver_Click" CssClass="btn-submit" CausesValidation="false"/>
     <h2>Agendar Cita</h2>
     <asp:Panel ID="pnlModificarCita" runat="server">
     
         <div class="form-group">
             <label for="txtFolio">Folio</label>
             <asp:TextBox ID="txtFolio" runat="server" CssClass="form-control" />
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
             <label for="txtCliente">Cliente</label>
             <asp:TextBox ID="txtCliente" runat="server" CssClass="form-control" />
         </div>
         <asp:Button ID="btnGuardar" runat="server" Text="Guardar Cambios" CssClass="btn btn-primary" OnClick="btnGuardar_Click" />
         <asp:Label ID="lblSuccess" runat="server" CssClass="text-success" />
     </asp:Panel>
 </div>
</asp:Content>