Imports System.Data.SqlClient

Public Class EditarCuentas
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As EventArgs) Handles Me.Load
        If Not IsPostBack Then
            Dim userId As String = Request.QueryString("IdUsuario")
            If Not String.IsNullOrEmpty(userId) Then
                BindData(userId)
                BindRoles()
            End If
        End If
    End Sub

    Private Sub BindData(userId As String)
        Dim connString As String = ConfigurationManager.ConnectionStrings("DefaultConnection").ConnectionString
        Using connection As New SqlConnection(connString)
            Dim query As String = "SELECT IdUsuario, Nombre, IdRol, Contraseña FROM Usuarios WHERE IdUsuario = @IdUsuario"
            Using command As New SqlCommand(query, connection)
                command.Parameters.AddWithValue("@IdUsuario", userId)
                Dim adapter As New SqlDataAdapter(command)
                Dim dt As New DataTable()
                adapter.Fill(dt)
                If dt.Rows.Count > 0 Then
                    formViewUsuario.DataSource = dt
                    formViewUsuario.DataBind()
                End If
            End Using
        End Using
    End Sub

    Private Sub BindRoles()
        Dim connString As String = ConfigurationManager.ConnectionStrings("DefaultConnection").ConnectionString
        Using connection As New SqlConnection(connString)
            Dim query As String = "SELECT IdRol, Rol FROM Roles"
            Using command As New SqlCommand(query, connection)
                Dim adapter As New SqlDataAdapter(command)
                Dim dt As New DataTable()
                adapter.Fill(dt)
                ' Asegúrate de que el control ddlRol existe en el archivo .aspx
                Dim ddlRol As DropDownList = CType(formViewUsuario.FindControl("ddlRol"), DropDownList)
                If ddlRol IsNot Nothing Then
                    ddlRol.DataSource = dt
                    ddlRol.DataBind()
                End If
            End Using
        End Using
    End Sub

    Protected Sub formViewUsuario_ItemUpdating(ByVal sender As Object, ByVal e As FormViewUpdateEventArgs) Handles formViewUsuario.ItemUpdating
        Dim userId As String = e.Keys("IdUsuario").ToString()
        Dim nombre As String = CType(formViewUsuario.FindControl("txtNombre"), TextBox).Text
        Dim ddlRol As DropDownList = CType(formViewUsuario.FindControl("ddlRol"), DropDownList)
        Dim idRol As String = If(ddlRol IsNot Nothing, ddlRol.SelectedValue, String.Empty)
        Dim contraseña As String = CType(formViewUsuario.FindControl("txtContraseña"), TextBox).Text

        Dim connString As String = ConfigurationManager.ConnectionStrings("DefaultConnection").ConnectionString
        Using connection As New SqlConnection(connString)
            Dim query As String = "UPDATE Usuarios SET Nombre = @Nombre, IdRol = @IdRol, Contraseña = @Contraseña WHERE IdUsuario = @IdUsuario"
            Using command As New SqlCommand(query, connection)
                command.Parameters.AddWithValue("@Nombre", nombre)
                command.Parameters.AddWithValue("@IdRol", idRol)
                command.Parameters.AddWithValue("@Contraseña", contraseña)
                command.Parameters.AddWithValue("@IdUsuario", userId)
                connection.Open()
                command.ExecuteNonQuery()
            End Using
        End Using
    End Sub

    Protected Sub formViewUsuario_ItemUpdated(ByVal sender As Object, ByVal e As FormViewUpdatedEventArgs) Handles formViewUsuario.ItemUpdated
        Response.Redirect("ListadoCuentas.aspx") ' Redirigir a la lista de cuentas o a la página deseada
    End Sub
    Protected Sub btnVolver_Click(sender As Object, e As EventArgs) Handles btnVolver.Click
        Response.Redirect("ListadoCuentas.aspx")
    End Sub
End Class
