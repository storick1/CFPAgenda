Imports System.Data.SqlClient

Public Class ListadoCuentas
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As EventArgs) Handles Me.Load
        If Not IsPostBack Then
            CargarCuentas()
        End If
    End Sub

    Private Sub CargarCuentas()
        Dim connString As String = ConfigurationManager.ConnectionStrings("DefaultConnection").ConnectionString
        Using connection As New SqlConnection(connString)
            Dim query As String = "SELECT u.IdUsuario, u.Nombre, r.Rol FROM Usuarios u INNER JOIN Roles r ON u.IdRol = r.IdRol"
            Using command As New SqlCommand(query, connection)
                Dim adapter As New SqlDataAdapter(command)
                Dim dt As New DataTable()
                adapter.Fill(dt)
                gvCuentas.DataSource = dt
                gvCuentas.DataBind()
            End Using
        End Using
    End Sub

    Protected Sub gvCuentas_RowCommand(ByVal sender As Object, ByVal e As GridViewCommandEventArgs) Handles gvCuentas.RowCommand
        If e.CommandName = "Edit" Then
            Dim userId As String = e.CommandArgument
            Response.Redirect("EditarCUentas.aspx?IdUsuario=" & userId)
        End If
    End Sub

    Protected Sub gvCuentas_SelectedIndexChanged(sender As Object, e As EventArgs) Handles gvCuentas.SelectedIndexChanged

    End Sub
    Protected Sub btnVolver_Click(sender As Object, e As EventArgs) Handles btnVolver.Click
        Response.Redirect("HomeAdmin.aspx")
    End Sub
End Class
