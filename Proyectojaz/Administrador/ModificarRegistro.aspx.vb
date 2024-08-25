Imports System.Data
Imports System.Data.SqlClient

Public Class ModificarServicios
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As EventArgs) Handles Me.Load
        If Not IsPostBack Then
            CargarServicios()
        End If
    End Sub

    Private Sub CargarServicios()
        Dim connString As String = ConfigurationManager.ConnectionStrings("DefaultConnection").ConnectionString
        Using connection As New SqlConnection(connString)
            Dim query As String = "SELECT IdServicio, Servicio FROM Servicios"
            Using command As New SqlCommand(query, connection)
                Dim adapter As New SqlDataAdapter(command)
                Dim dt As New DataTable()
                adapter.Fill(dt)
                gvServicios.DataSource = dt
                gvServicios.DataBind()
            End Using
        End Using
    End Sub

    Protected Sub gvServicios_RowEditing(ByVal sender As Object, ByVal e As GridViewEditEventArgs) Handles gvServicios.RowEditing
        Dim idServicio As String = gvServicios.DataKeys(e.NewEditIndex).Value.ToString()

        formViewServicio.ChangeMode(FormViewMode.Edit)
        formViewServicio.DataSource = ObtenerServicioPorId(idServicio)
        formViewServicio.DataBind()
    End Sub

    Protected Sub gvServicios_RowUpdating(ByVal sender As Object, ByVal e As GridViewUpdateEventArgs) Handles gvServicios.RowUpdating
        Try
            Dim idServicio As String = gvServicios.DataKeys(e.RowIndex).Value.ToString()
            Dim txtServicio As TextBox = CType(gvServicios.Rows(e.RowIndex).FindControl("txtServicio"), TextBox)

            If txtServicio IsNot Nothing Then
                Dim nombreServicio As String = txtServicio.Text

                Dim connString As String = ConfigurationManager.ConnectionStrings("DefaultConnection").ConnectionString
                Using connection As New SqlConnection(connString)
                    Dim query As String = "UPDATE Servicios SET Servicio = @Servicio WHERE IdServicio = @IdServicio"
                    Using command As New SqlCommand(query, connection)
                        command.Parameters.AddWithValue("@Servicio", nombreServicio)
                        command.Parameters.AddWithValue("@IdServicio", idServicio)
                        connection.Open()
                        command.ExecuteNonQuery()
                    End Using
                End Using

                gvServicios.EditIndex = -1
                CargarServicios()
            End If
        Catch ex As Exception
            ' Manejo de excepciones aquí
        End Try
    End Sub

    Protected Sub gvServicios_RowCancelingEdit(ByVal sender As Object, ByVal e As GridViewCancelEditEventArgs) Handles gvServicios.RowCancelingEdit
        gvServicios.EditIndex = -1
        CargarServicios()
    End Sub

    Protected Sub gvServicios_RowDeleting(ByVal sender As Object, ByVal e As GridViewDeleteEventArgs) Handles gvServicios.RowDeleting
        Try
            Dim idServicio As String = gvServicios.DataKeys(e.RowIndex).Value.ToString()

            Dim connString As String = ConfigurationManager.ConnectionStrings("DefaultConnection").ConnectionString
            Using connection As New SqlConnection(connString)
                Dim query As String = "DELETE FROM Servicios WHERE IdServicio = @IdServicio"
                Using command As New SqlCommand(query, connection)
                    command.Parameters.AddWithValue("@IdServicio", idServicio)
                    connection.Open()
                    command.ExecuteNonQuery()
                End Using
            End Using

            CargarServicios()
        Catch ex As Exception
            ' Manejo de excepciones aquí
        End Try
    End Sub

    Private Function ObtenerServicioPorId(ByVal idServicio As String) As DataTable
        Dim dt As New DataTable()
        Dim connString As String = ConfigurationManager.ConnectionStrings("DefaultConnection").ConnectionString
        Using connection As New SqlConnection(connString)
            Dim query As String = "SELECT IdServicio, Servicio FROM Servicios WHERE IdServicio = @IdServicio"
            Using command As New SqlCommand(query, connection)
                command.Parameters.AddWithValue("@IdServicio", idServicio)
                Dim adapter As New SqlDataAdapter(command)
                adapter.Fill(dt)
            End Using
        End Using
        Return dt
    End Function

    Protected Sub formViewServicio_ItemUpdating(ByVal sender As Object, ByVal e As FormViewUpdateEventArgs) Handles formViewServicio.ItemUpdating
        Try
            Dim idServicio As String = formViewServicio.DataKey.Value.ToString()
            Dim txtServicio As TextBox = CType(formViewServicio.FindControl("txtServicio"), TextBox)

            If txtServicio IsNot Nothing Then
                Dim nombreServicio As String = txtServicio.Text

                Dim connString As String = ConfigurationManager.ConnectionStrings("DefaultConnection").ConnectionString
                Using connection As New SqlConnection(connString)
                    Dim query As String = "UPDATE Servicios SET Servicio = @Servicio WHERE IdServicio = @IdServicio"
                    Using command As New SqlCommand(query, connection)
                        command.Parameters.AddWithValue("@Servicio", nombreServicio)
                        command.Parameters.AddWithValue("@IdServicio", idServicio)
                        connection.Open()
                        command.ExecuteNonQuery()
                    End Using
                End Using

                formViewServicio.ChangeMode(FormViewMode.ReadOnly)
                CargarServicios()
            End If
        Catch ex As Exception
            ' Manejo de excepciones aquí
        End Try
    End Sub

    Protected Sub formViewServicio_ModeChanging(ByVal sender As Object, ByVal e As FormViewModeEventArgs) Handles formViewServicio.ModeChanging
        If e.NewMode = FormViewMode.ReadOnly Then
            formViewServicio.ChangeMode(FormViewMode.ReadOnly)
            CargarServicios()
        End If
    End Sub
    Protected Sub btnVolver_Click(sender As Object, e As EventArgs) Handles btnVolver.Click
        Response.Redirect("HomeAdmin.aspx")
    End Sub
End Class
