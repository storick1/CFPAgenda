<%@ Page Title="Editar Cuentas" Language="vb" AutoEventWireup="false" MasterPageFile="~/Site.Master" CodeBehind="EditarCuentas.aspx.vb" Inherits="Proyectojaz.EditarCuentas" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container">
        <asp:Button ID="btnVolver" runat="server" Text="Volver" OnClick="btnVolver_Click" CssClass="btn-submit" CausesValidation="false"/>
        <h2>Editar Usuario</h2>
        <asp:FormView ID="formViewUsuario" runat="server" DataKeyNames="IdUsuario" DefaultMode="Edit">
            <EditItemTemplate>
                <div class="form-group">
                    <label for="txtNombre">Nombre</label>
                    <asp:TextBox ID="txtNombre" runat="server" Text='<%# Bind("Nombre") %>' />
                </div>
                <div class="form-group">
                    <label for="ddlRol">Rol</label>
                    <asp:DropDownList ID="ddlRol" runat="server" DataTextField="Rol" DataValueField="IdRol" AppendDataBoundItems="True">
                        <asp:ListItem Text="Seleccione un rol" Value="" />
                    </asp:DropDownList>
                </div>
                <div class="form-group">
                    <label for="txtContraseña">Contraseña</label>
                    <asp:TextBox ID="txtContraseña" runat="server" Text='<%# Bind("Contraseña") %>' TextMode="Password" />
                </div>
                <asp:Button ID="btnGuardar" runat="server" Text="Guardar Cambios" CssClass="btn-submit" CommandName="Update" />
                <asp:Button ID="btnCancelar" runat="server" Text="Cancelar" CssClass="btn-cancel" CommandName="Cancel" />
            </EditItemTemplate>
        </asp:FormView>
    </div>
</asp:Content>
