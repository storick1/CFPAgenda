<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Site.Master" CodeBehind="ModificarServicios.aspx.vb" Inherits="Proyectojaz.ModificarServicios" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container">
        <asp:Button ID="btnVolver" runat="server" Text="Volver" OnClick="btnVolver_Click" CssClass="btn-submit" CausesValidation="false"/>
        <h2>Modificar Servicio</h2>
        
        <asp:FormView ID="formViewServicio" runat="server" DataKeyNames="IdServicio" DefaultMode="Edit"
            OnItemUpdating="formViewServicio_ItemUpdating" OnModeChanging="formViewServicio_ModeChanging">
            <EditItemTemplate>
                <div class="form-group">
                    <label for="txtServicio">Nombre del Servicio</label>
                    <asp:TextBox ID="txtServicio" runat="server" Text='<%# Bind("Servicio") %>' CssClass="form-control" />
                </div>
                <asp:Button ID="btnGuardar" runat="server" Text="Guardar Cambios" CssClass="btn btn-primary" CommandName="Update" />
                <asp:Button ID="btnCancelar" runat="server" Text="Cancelar" CssClass="btn btn-secondary" CommandName="Cancel" />
            </EditItemTemplate>
            <ItemTemplate>
                <div class="form-group">
                    <label for="txtServicio">Nombre del Servicio</label>
                    <asp:TextBox ID="txtServicio" runat="server" Text='<%# Bind("Servicio") %>' CssClass="form-control" ReadOnly="True" />
                </div>
            </ItemTemplate>
        </asp:FormView>
        
        <h2>Lista de Servicios</h2>
        <asp:GridView ID="gvServicios" runat="server" AutoGenerateColumns="False" CssClass="table table-striped" 
            DataKeyNames="IdServicio" OnRowEditing="gvServicios_RowEditing" OnRowUpdating="gvServicios_RowUpdating" 
            OnRowCancelingEdit="gvServicios_RowCancelingEdit" OnRowDeleting="gvServicios_RowDeleting">
            <Columns>
                <asp:BoundField DataField="IdServicio" HeaderText="ID Servicio" ReadOnly="True" />
                <asp:BoundField DataField="Servicio" HeaderText="Nombre del Servicio" />
                <asp:CommandField ShowEditButton="True" ShowDeleteButton="True" />
            </Columns>
        </asp:GridView>
    </div>
</asp:Content>

