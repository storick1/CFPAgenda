Imports System.Data.SqlClient
Imports System.Configuration

Public Class llenarform
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            CargarMarcas()
            CargarSubmarcas()
            CargarColores()
        End If
    End Sub

    Private Sub CargarMarcas()
        Dim connString As String = ConfigurationManager.ConnectionStrings("DefaultConnection").ConnectionString
        Using conn As New SqlConnection(connString)
            Dim cmd As New SqlCommand("SELECT IdMarca, Marca FROM Marcas", conn)
            conn.Open()
            Dim reader As SqlDataReader = cmd.ExecuteReader()
            ddlMarca.DataSource = reader
            ddlMarca.DataTextField = "Marca" ' Nombre de la columna en la base de datos
            ddlMarca.DataValueField = "IdMarca"
            ddlMarca.DataBind()
            ddlMarca.Items.Insert(0, New ListItem("--Seleccione Marca--", "0"))
        End Using
    End Sub

    Private Sub CargarSubmarcas()
        Dim connString As String = ConfigurationManager.ConnectionStrings("DefaultConnection").ConnectionString
        Using conn As New SqlConnection(connString)
            Dim cmd As New SqlCommand("SELECT IdSubmarca, Submarca, IdMarca FROM Submarcas", conn)
            conn.Open()
            Dim reader As SqlDataReader = cmd.ExecuteReader()
            ddlSubmarca.DataSource = reader
            ddlSubmarca.DataTextField = "Submarca" ' Nombre de la columna en la base de datos
            ddlSubmarca.DataValueField = "IdSubmarca"
            ddlSubmarca.DataBind()
            ddlSubmarca.Items.Insert(0, New ListItem("--Seleccione Submarca--", "0"))
        End Using
    End Sub

    Private Sub CargarColores()
        Dim connString As String = ConfigurationManager.ConnectionStrings("DefaultConnection").ConnectionString
        Using conn As New SqlConnection(connString)
            Dim cmd As New SqlCommand("SELECT Idcolor, Color FROM Colores", conn)
            conn.Open()
            Dim reader As SqlDataReader = cmd.ExecuteReader()
            ddlColor.DataSource = reader
            ddlColor.DataTextField = "Color" ' Nombre de la columna en la base de datos
            ddlColor.DataValueField = "Idcolor"
            ddlColor.DataBind()
            ddlColor.Items.Insert(0, New ListItem("--Seleccione Color--", "0"))
        End Using
    End Sub

    Protected Sub btnGuardar_Click(sender As Object, e As EventArgs)
        Dim connString As String = ConfigurationManager.ConnectionStrings("DefaultConnection").ConnectionString
        Using conn As New SqlConnection(connString)
            Dim idCliente As Integer
            Integer.TryParse(txtIdCliente.Text, idCliente)
            Dim idMarca As Integer = Integer.Parse(ddlMarca.SelectedValue)
            Dim idSubmarca As Integer = Integer.Parse(ddlSubmarca.SelectedValue)
            Dim idColor As Integer = Integer.Parse(ddlColor.SelectedValue)
            Dim modelo As String = txtModelo.Text

            Dim cmd As New SqlCommand("INSERT INTO Autos (IdCliente, IdMarca, IdSubmarca, IdColor, Modelo) VALUES (@IdCliente, @IdMarca, @IdSubmarca, @IdColor, @Modelo)", conn)
            cmd.Parameters.AddWithValue("@IdCliente", idCliente)
            cmd.Parameters.AddWithValue("@IdMarca", idMarca)
            cmd.Parameters.AddWithValue("@IdSubmarca", idSubmarca)
            cmd.Parameters.AddWithValue("@IdColor", idColor)
            cmd.Parameters.AddWithValue("@Modelo", modelo)

            conn.Open()
            cmd.ExecuteNonQuery()
        End Using

        ' Mensaje de éxito
        lblSuccess.Text = "Auto registrado con éxito."
    End Sub
    Protected Sub btnVolver_Click(sender As Object, e As EventArgs) Handles btnVolver.Click
        Response.Redirect("HomeAdmin.aspx")
    End Sub
End Class