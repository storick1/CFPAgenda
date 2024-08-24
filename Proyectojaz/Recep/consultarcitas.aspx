<%@ Page Title="Consultar Citas" Language="vb" AutoEventWireup="false" MasterPageFile="~/Site.Master" CodeBehind="consultarcitas.aspx.vb" Inherits="Proyectojaz.consultarcitas" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
      <div class="container">
        <h2>Consultar Citas</h2>
        <asp:GridView ID="gvCitas" runat="server" CssClass="table table-striped" AutoGenerateColumns="False">
            <Columns>
                <asp:BoundField DataField="Folio" HeaderText="Folio" />
                <asp:BoundField DataField="Fecha" HeaderText="Fecha" />
                <asp:BoundField DataField="Hora" HeaderText="Hora" />
                <asp:BoundField DataField="Cliente" HeaderText="Cliente" />
            </Columns>
        </asp:GridView>
        <asp:Label ID="lblMensaje" runat="server" CssClass="text-success" />
    </div>
</asp:Content>