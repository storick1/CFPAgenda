<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Site.Master" CodeBehind="AgregarCuentas.aspx.vb" Inherits="Proyectojaz.AgregarCuentas" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <style>
        /* Estilos generales de la página */
        body {
            font-family: Arial, sans-serif;
            background-color: #f9f9f9;
            margin: 0;
            padding: 0;
        }

        /* Estilos para el contenedor principal */
        .container {
            max-width: 800px;
            margin: 0 auto;
            padding: 20px;
            background-color: #fff;
            border-radius: 8px;
            box-shadow: 0 4px 8px rgba(0, 0, 0, 0.1);
        }

        /* Estilos para el título */
        h1 {
            font-size: 2em;
            color: #333;
            text-align: center;
            margin-bottom: 20px;
        }

        /* Estilos para los formularios */
        .form-group {
            margin-bottom: 15px;
        }

        .form-group label {
            display: block;
            font-weight: bold;
            margin-bottom: 5px;
            color: #555;
        }

        .form-group input[type="text"],
        .form-group input[type="password"],
        .form-group select {
            width: 100%;
            padding: 10px;
            border: 1px solid #ddd;
            border-radius: 4px;
            box-sizing: border-box;
        }

        .form-group input[type="text"]:focus,
        .form-group input[type="password"]:focus,
        .form-group select:focus {
            border-color: #007bff;
            outline: none;
        }

        /* Estilos para el botón */
        .form-group button {
            background-color: #007bff;
            color: #fff;
            border: none;
            padding: 10px 20px;
            font-size: 16px;
            border-radius: 4px;
            cursor: pointer;
            transition: background-color 0.3s;
        }

        .form-group button:hover {
            background-color: #0056b3;
        }

        /* Estilo para el mensaje */
        .form-group .message {
            font-weight: bold;
            text-align: center;
            margin-top: 15px;
        }
    </style>

    <div class="container">
        <asp:Button ID="btnVolver" runat="server" Text="Volver" OnClick="btnVolver_Click" CssClass="btn-submit" CausesValidation="false"/>
        
        <h1>Agregar cuentas nuevas</h1>

        <asp:Label ID="lblMensaje" runat="server" CssClass="message"></asp:Label>

        <div class="form-group">
            <asp:Label ID="lbNombre" runat="server" Text="Nombre"></asp:Label>
            <asp:TextBox ID="txtNombre1" runat="server"></asp:TextBox>
        </div>

        <div class="form-group">
            <asp:Label ID="lbContraseña" runat="server" Text="Contraseña"></asp:Label>
            <asp:TextBox ID="txtContraseña" runat="server" TextMode="Password"></asp:TextBox>
        </div>

      <div class="form-group">
    <asp:Label ID="lbRol" runat="server" Text="Rol de Usuario"></asp:Label>
    <asp:DropDownList ID="ddlRol" runat="server">
        <asp:ListItem Text="Seleccione rol" Value="" />
        <asp:ListItem Text="Administrador" Value="1" />
        <asp:ListItem Text="Recepcionista" Value="2" />
        <asp:ListItem Text="Mecánico" Value="3" />
    </asp:DropDownList>
</div>

        <div class="form-group">
            <asp:Button ID="btnAgregar" runat="server" Text="Agregar" />
        </div>
    </div>
</asp:Content>
