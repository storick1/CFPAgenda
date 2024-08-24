<%@ Page Title="Agregar Servicios" Language="vb" AutoEventWireup="false" MasterPageFile="~/Site.Master" CodeBehind="AgregarServicios.aspx.vb" Inherits="Proyectojaz.AgregarServicios" %>
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
        .form-group {
            margin-bottom: 15px;
        }
        .form-group label {
            display: block;
            margin-bottom: 5px;
            font-weight: bold;
            color: #555;
        }
        .form-group input {
            width: 100%;
            padding: 10px;
            border: 1px solid #ddd;
            border-radius: 4px;
            box-sizing: border-box;
        }
        .form-group .error {
            color: red;
            font-size: 0.9em;
        }
        .form-group .success {
            color: green;
            font-size: 0.9em;
        }
        .btn-submit {
            display: block;
            width: 100%;
            padding: 10px;
            background-color: #007bff;
            color: white;
            border: none;
            border-radius: 4px;
            cursor: pointer;
            font-size: 16px;
        }
        .btn-submit:hover {
            background-color: #0056b3;
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
    </style>
    <div>
        <asp:Button ID="btnVolver" runat="server" Text="Volver" OnClick="btnVolver_Click" CssClass="btn-submit" CausesValidation="false"/>
    </div>
    <div class="container">
        <h2>Agregar Nuevo Servicio</h2>
        <asp:Panel ID="Panel1" runat="server" DefaultButton="btnAgregar">
            <div class="form-group">
                <asp:TextBox ID="txtIdServicio" runat="server" placeholder="ID Servicio"></asp:TextBox>
                <asp:RequiredFieldValidator ID="rfvIdServicio" runat="server" ControlToValidate="txtIdServicio" ErrorMessage="El ID del servicio es obligatorio." CssClass="error" />
            </div>
            <div class="form-group">
                <asp:TextBox ID="txtServicio" runat="server" placeholder="Nombre del Servicio"></asp:TextBox>
                <asp:RequiredFieldValidator ID="rfvServicio" runat="server" ControlToValidate="txtServicio" ErrorMessage="El nombre del servicio es obligatorio." CssClass="error" />
            </div>
            <asp:Button ID="btnAgregar" runat="server" Text="Agregar Servicio" OnClick="btnAgregar_Click" CssClass="btn-submit" />
            <asp:Label ID="lblMensaje" runat="server" CssClass="error success" />
        </asp:Panel>
        <div class="grid-container">
            <asp:GridView ID="gvServicios" runat="server" AutoGenerateColumns="False" DataKeyNames="IdServicio">
                <Columns>
                    <asp:BoundField DataField="IdServicio" HeaderText="ID Servicio" ReadOnly="True" />
                    <asp:BoundField DataField="Servicio" HeaderText="Nombre del Servicio" />
                </Columns>
            </asp:GridView>
        </div>
    </div>
</asp:Content>
