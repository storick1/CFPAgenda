<%@ Page Title="Consultar Servicios" Language="vb" AutoEventWireup="false" MasterPageFile="~/Site.Master" CodeBehind="consultarservicios.aspx.vb" Inherits="Proyectojaz.consultarservicios" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container">
        <h2>Consultar Servicios</h2>
        <asp:GridView ID="gvServicios" runat="server" CssClass="table table-striped" AutoGenerateColumns="False">
            <Columns>
                <asp:BoundField DataField="IdServicio" HeaderText="ID Servicio" />
                <asp:BoundField DataField="Servicio" HeaderText="Servicio" />
            </Columns>
        </asp:GridView>
        <asp:Label ID="lblMensaje" runat="server" CssClass="text-success" />
    </div>
</asp:Content>