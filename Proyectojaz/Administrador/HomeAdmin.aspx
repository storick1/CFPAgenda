<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Site.master" CodeBehind="HomeSite.aspx.vb" Inherits="Proyectojaz.HomeAdmin" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <h1>Dashboard de Administrador</h1>

    <div class="button-container">
        <asp:Button ID="btnAgregarcuenta" runat="server" Text="Agregar cuentas" OnClick="btnAgregarcuenta_Click" />
        <asp:Button ID="Button4" runat="server" Text="Agregar servicios" OnClick="Button4_Click" />
        <asp:Button ID="Button1" runat="server" Text="Editar cuentas" OnClick="Button1_Click" />
        <asp:Button ID="Button2" runat="server" Text="Modificar Registro" OnClick="Button2_Click" />
    </div>

    <style>
        /* Estilos para el título */
        h1 {
            font-size: 2em;
            color: #333;
            text-align: center;
            margin-bottom: 20px;
        }

        /* Contenedor para los botones */
        .button-container {
            display: flex;
            flex-wrap: wrap;
            justify-content: center;
            gap: 15px;
            margin: 20px;
        }

        /* Estilos para los botones */
        .button-container asp\:Button {
            background-color: #007bff;
            color: #fff;
            border: none;
            border-radius: 5px;
            padding: 12px 24px;
            font-size: 18px;
            cursor: pointer;
            transition: background-color 0.3s, transform 0.3s, box-shadow 0.3s;
        }

        .button-container asp\:Button:hover {
            background-color: #0056b3;
            transform: scale(1.1);
            box-shadow: 0 4px 8px rgba(0, 0, 0, 0.2);
        }

        .button-container asp\:Button:focus {
            outline: none;
        }
    </style>
</asp:Content>
