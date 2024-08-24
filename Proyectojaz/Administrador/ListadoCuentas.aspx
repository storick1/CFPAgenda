<%@ Page Title="Listado de Cuentas" Language="vb" AutoEventWireup="false" MasterPageFile="~/Site.Master" CodeBehind="ListadoCuentas.aspx.vb" Inherits="Proyectojaz.ListadoCuentas" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <style>
        .container {
            width: 80%;
            margin: auto;
            padding: 20px;
            background-color: #f9f9f9;
            border-radius: 8px;
            box-shadow: 0 0 10px rgba(0, 0, 0, 0.1);
        }
        h2 {
            color: #333;
            text-align: center;
        }
        .grid-container {
            margin-top: 20px;
        }
        .grid-container table {
            width: 100%;
            border-collapse: collapse;
        }
        .grid-container th, .grid-container td {
            padding: 10px;
            border: 1px solid #ddd;
            text-align: left;
        }
        .grid-container th {
            background-color: #f4f4f4;
        }
        .btn-edit {
            background-color: #007bff;
            color: white;
            border: none;
            padding: 5px 10px;
            border-radius: 4px;
            cursor: pointer;
        }
        .btn-edit:hover {
            background-color: #0056b3;
        }
    </style>

    <div class="container">
        <asp:Button ID="btnVolver" runat="server" Text="Volver" OnClick="btnVolver_Click" CssClass="btn-submit" CausesValidation="false"/>
        <h2>Listado de Cuentas</h2>
        <div class="grid-container">
            <asp:GridView ID="gvCuentas" runat="server" AutoGenerateColumns="False" DataKeyNames="IdUsuario">
                <Columns>
                    <asp:BoundField DataField="IdUsuario" HeaderText="ID Usuario" ReadOnly="True" />
                    <asp:BoundField DataField="Nombre" HeaderText="Nombre" />
                    <asp:BoundField DataField="Rol" HeaderText="Rol" />
                    <asp:TemplateField>
                        <ItemTemplate>
                            <asp:Button ID="btnEditar" runat="server" Text="Editar" CssClass="btn-edit" CommandName="Edit" CommandArgument='<%# Eval("IdUsuario") %>' />
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>
        </div>
    </div>
</asp:Content>
