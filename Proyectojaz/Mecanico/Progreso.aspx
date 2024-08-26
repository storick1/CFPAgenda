<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="Progreso.aspx.vb" Inherits="Proyectojaz.Progreso" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
            <asp:CheckBoxList ID="chkLstActividades" runat="server" AutoPostBack="true" OnSelectedIndexChanged="chkLstActividades_SelectedIndexChanged">
            </asp:CheckBoxList>
            <asp:TextBox ID="txtNuevaActividad" runat="server"></asp:TextBox>
            <asp:Button ID="btnAgregarActividad" runat="server" Text="Agregar Actividad" OnClick="btnAgregarActividad_Click" />
            <asp:UpdateProgress ID="UpdateProgress1" runat="server">
                <ProgressTemplate>
                    <div>
                        <img src="spinner.gif" alt="Cargando..." />
                            Actualizando progreso...
                     </div>
                </ProgressTemplate>
                </asp:UpdateProgress>
            <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                <ContentTemplate>
                    <asp:Label ID="lblProgreso" runat="server" Text="Progreso: 0%"></asp:Label>
                        <br />
                    <asp:Button ID="btnEliminarActividad" runat="server" Text="Eliminar Actividad Seleccionada" OnClick="btnEliminarActividad_Click" />
                </ContentTemplate>
            </asp:UpdatePanel>




        </div>
    </form>
</body>
</html>
