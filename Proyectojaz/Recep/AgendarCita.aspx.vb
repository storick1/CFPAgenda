Imports System.Data.SqlClient
Imports System.Configuration

Public Class AgendarCita
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            CargarClientes()
            CargarAutos()
            CargarServicios()
        End If
    End Sub

    Private Sub CargarClientes()
        Dim connString As String = ConfigurationManager.ConnectionStrings("DefaultConnection").ConnectionString
        Using conn As New SqlConnection(connString)
            Dim cmd As New SqlCommand("SELECT IdCliente, Nombre FROM Clientes", conn)
            conn.Open()
            Dim reader As SqlDataReader = cmd.ExecuteReader()
            ddlCliente.DataSource = reader
            ddlCliente.DataTextField = "Nombre"
            ddlCliente.DataValueField = "IdCliente"
            ddlCliente.DataBind()
            ddlCliente.Items.Insert(0, New ListItem("--Seleccione Cliente--", "0"))
        End Using
    End Sub

    Private Sub CargarAutos()
        Dim connString As String = ConfigurationManager.ConnectionStrings("DefaultConnection").ConnectionString
        Using conn As New SqlConnection(connString)
            Dim cmd As New SqlCommand("SELECT IdAuto, Modelo FROM Autos", conn)
            conn.Open()
            Dim reader As SqlDataReader = cmd.ExecuteReader()
            ddlAuto.DataSource = reader
            ddlAuto.DataTextField = "Modelo" ' O el nombre del campo que desees mostrar
            ddlAuto.DataValueField = "IdAuto"
            ddlAuto.DataBind()
            ddlAuto.Items.Insert(0, New ListItem("--Seleccione Auto--", "0"))
        End Using
    End Sub

    Private Sub CargarServicios()
        Dim connString As String = ConfigurationManager.ConnectionStrings("DefaultConnection").ConnectionString
        Using conn As New SqlConnection(connString)
            Dim cmd As New SqlCommand("SELECT IdServicio, Servicio FROM Servicios", conn)
            conn.Open()
            Dim reader As SqlDataReader = cmd.ExecuteReader()
            ddlServicio.DataSource = reader
            ddlServicio.DataTextField = "Servicio"
            ddlServicio.DataValueField = "IdServicio"
            ddlServicio.DataBind()
            ddlServicio.Items.Insert(0, New ListItem("--Seleccione Servicio--", "0"))
        End Using
    End Sub

    Protected Sub btnGuardar_Click(sender As Object, e As EventArgs)
        Dim connString As String = ConfigurationManager.ConnectionStrings("DefaultConnection").ConnectionString
        Using conn As New SqlConnection(connString)
            Dim idCliente As Integer = Integer.Parse(ddlCliente.SelectedValue)
            Dim idAuto As Integer = Integer.Parse(ddlAuto.SelectedValue)
            Dim idServicio As Integer = Integer.Parse(ddlServicio.SelectedValue)
            Dim kilometraje As String = txtKilometraje.Text
            Dim notas As String = txtNotas.Text

            Dim cmd As New SqlCommand("INSERT INTO Citas (IdCliente, IdAuto, IdServicio, Kilometraje, Notas) VALUES (@IdCliente, @IdAuto, @IdServicio, @Kilometraje, @Notas)", conn)
            cmd.Parameters.AddWithValue("@IdCliente", idCliente)
            cmd.Parameters.AddWithValue("@IdAuto", idAuto)
            cmd.Parameters.AddWithValue("@IdServicio", idServicio)
            cmd.Parameters.AddWithValue("@Kilometraje", kilometraje)
            cmd.Parameters.AddWithValue("@Notas", notas)

            conn.Open()
            cmd.ExecuteNonQuery()
        End Using

        lblSuccess.Text = "Cita agendada con éxito."
    End Sub
    Protected Sub btnVolver_Click(sender As Object, e As EventArgs) Handles btnVolver.Click
        Response.Redirect("HomeRep.aspx")
    End Sub
End Class