Imports System.Data.SqlClient

Public Class consultarservicios
    Inherits System.Web.UI.Page

    Private connectionString As String = "Server=VIRUXFIVE\SQLEXPRESS;Database=CFP;User Id=sa;Password=12345678;"

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As EventArgs) Handles Me.Load
        If Not IsPostBack Then
            LoadServicios()
        End If
    End Sub

    Private Sub LoadServicios()
        Try
            Using conn As New SqlConnection(connectionString)
                Dim cmd As New SqlCommand("SELECT IdServicio, Servicio FROM Servicios", conn)
                conn.Open()

                Dim reader As SqlDataReader = cmd.ExecuteReader()
                If reader.HasRows Then
                    gvServicios.DataSource = reader
                    gvServicios.DataBind()
                Else
                    lblMensaje.Text = "No se encontraron servicios."
                    lblMensaje.ForeColor = System.Drawing.Color.Red
                End If
            End Using
        Catch ex As Exception
            lblMensaje.Text = "Error al cargar los servicios: " & ex.Message
            lblMensaje.ForeColor = System.Drawing.Color.Red
        End Try
    End Sub

End Class