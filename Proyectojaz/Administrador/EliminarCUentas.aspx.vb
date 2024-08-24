Imports System.Data.SqlClient

Public Class EliminarCuentas
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As EventArgs) Handles Me.Load
        If Not IsPostBack Then
            CargarCuentas()
        End If
    End Sub

    Private Sub CargarCuentas()
        Dim connectionString As String = "Server=VIRUXFIVE\SQLEXPRESS;Database=CFP;User Id=sa;Password=12345678;"
        Using connection As New SqlConnection(connectionString)
            ' Ajustar la consulta para coincidir con la estructura correcta de la tabla
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

    Protected Sub btnEliminar_Click(ByVal sender As Object, ByVal e As EventArgs)
        Dim btnEliminar As Button = CType(sender, Button)
        Dim idUsuario As String = btnEliminar.CommandArgument

        Dim connectionString As String = "Server=VIRUXFIVE\SQLEXPRESS;Database=CFP;User Id=sa;Password=12345678;"
        Using connection As New SqlConnection(connectionString)
            Dim query As String = "DELETE FROM Usuarios WHERE IdUsuario = @IdUsuario"
            Using command As New SqlCommand(query, connection)
                command.Parameters.AddWithValue("@IdUsuario", idUsuario)
                connection.Open()
                command.ExecuteNonQuery()
            End Using
        End Using

        CargarCuentas() ' Recargar la lista de cuentas después de eliminar
    End Sub
    Protected Sub btnVolver_Click(sender As Object, e As EventArgs) Handles btnVolver.Click
        Response.Redirect("HomeAdmin.aspx")
    End Sub
End Class
