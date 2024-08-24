Imports System.Data.SqlClient

Public Class AgregarServicios
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As EventArgs) Handles Me.Load
        If Not IsPostBack Then
            CargarServicios()
        End If
    End Sub
    Protected Sub btnVolver_Click(sender As Object, e As EventArgs) Handles btnVolver.Click
        Response.Redirect("HomeAdmin.aspx")
    End Sub

    Protected Sub btnAgregar_Click(ByVal sender As Object, ByVal e As EventArgs)
        Dim idServicio As String = txtIdServicio.Text.Trim()
        Dim servicio As String = txtServicio.Text.Trim()
        If String.IsNullOrEmpty(idServicio) OrElse String.IsNullOrEmpty(servicio) Then
            ' Mensaje de error si es necesario
            lblMensaje.Text = "Ambos campos son obligatorios."
            lblMensaje.ForeColor = System.Drawing.Color.Red
            Return
        End If


        Dim connectionString As String = "Server=LAPTOP-L4BR3OML\SQLEXPRESS;Database=CFP;User Id=sa;Password=aaa;"
        Using connection As New SqlConnection(connectionString)
            Dim query As String = "INSERT INTO Servicios (IdServicio, Servicio) VALUES (@IdServicio, @Servicio)"
            Using command As New SqlCommand(query, connection)
                command.Parameters.AddWithValue("@IdServicio", idServicio)
                command.Parameters.AddWithValue("@Servicio", servicio)
                connection.Open()
                command.ExecuteNonQuery()
            End Using
        End Using

        txtIdServicio.Text = String.Empty
        txtServicio.Text = String.Empty
        lblMensaje.Text = "Servicio agregado exitosamente."
        lblMensaje.ForeColor = System.Drawing.Color.Green
        CargarServicios()
    End Sub

    Private Sub CargarServicios()
        Dim connectionString As String = "Server=LAPTOP-L4BR3OML\SQLEXPRESS;Database=CFP;User Id=sa;Password=aaa;"
        Using connection As New SqlConnection(connectionString)
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


End Class
