Imports System.Data.SqlClient

Public Class consultarcitas
    Inherits System.Web.UI.Page

    Dim connString As String = ConfigurationManager.ConnectionStrings("DefaultConnection").ConnectionString

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As EventArgs) Handles Me.Load
        If Not IsPostBack Then
            LoadCitas()
        End If
    End Sub

    Private Sub LoadCitas()
        Try
            Using conn As New SqlConnection(connString)
                Dim cmd As New SqlCommand("SELECT C.Folio, C.Fecha, C.Hora, CL.Nombre AS Cliente FROM Citas C INNER JOIN Clientes CL ON C.IdCliente = CL.IdCliente", conn)
                conn.Open()

                Dim reader As SqlDataReader = cmd.ExecuteReader()
                If reader.HasRows Then
                    gvCitas.DataSource = reader
                    gvCitas.DataBind()
                Else
                    lblMensaje.Text = "No se encontraron citas."
                    lblMensaje.ForeColor = System.Drawing.Color.Red
                End If
            End Using
        Catch ex As FormatException
            lblMensaje.Text = "Error en el formato de los datos: " & ex.Message
            lblMensaje.ForeColor = System.Drawing.Color.Red
        Catch ex As SqlException
            lblMensaje.Text = "Error de SQL: " & ex.Message
            lblMensaje.ForeColor = System.Drawing.Color.Red
        Catch ex As Exception
            lblMensaje.Text = "Error al cargar las citas: " & ex.Message
            lblMensaje.ForeColor = System.Drawing.Color.Red
        End Try
    End Sub

End Class