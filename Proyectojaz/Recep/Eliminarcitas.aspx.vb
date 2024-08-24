Imports System.Data.SqlClient
Imports System.Configuration

Public Class EliminarCitas
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(sender As Object, e As EventArgs) Handles Me.Load
        If Not IsPostBack Then
            CargarCitas()
        End If
    End Sub

    Private Sub CargarCitas()
        Dim connString As String = ConfigurationManager.ConnectionStrings("DefaultConnection").ConnectionString
        Using conn As New SqlConnection(connString)
            Dim cmd As New SqlCommand("SELECT Folio, Fecha FROM Citas", conn)
            conn.Open()
            Dim reader As SqlDataReader = cmd.ExecuteReader()
            ddlCita.DataSource = reader
            ddlCita.DataTextField = "Fecha" ' Cambia esto si deseas mostrar otro campo
            ddlCita.DataValueField = "Folio"
            ddlCita.DataBind()
            ddlCita.Items.Insert(0, New ListItem("--Seleccione Cita--", "0"))
        End Using
    End Sub

    Protected Sub ddlCita_SelectedIndexChanged(sender As Object, e As EventArgs)
        ' Puedes realizar alguna acción cuando se selecciona una cita, si es necesario
    End Sub

    Protected Sub btnEliminar_Click(sender As Object, e As EventArgs)
        Dim folio As String = ddlCita.SelectedValue

        If folio = "0" Then
            lblError.Text = "Por favor, seleccione una cita para eliminar."
            Return
        End If

        Dim connString As String = ConfigurationManager.ConnectionStrings("DefaultConnection").ConnectionString
        Using conn As New SqlConnection(connString)
            Dim cmd As New SqlCommand("DELETE FROM Citas WHERE Folio = @Folio", conn)
            cmd.Parameters.AddWithValue("@Folio", folio)
            conn.Open()
            Dim rowsAffected As Integer = cmd.ExecuteNonQuery()

            If rowsAffected > 0 Then
                lblSuccess.Text = "Cita eliminada exitosamente."
                CargarCitas() ' Actualiza el DropDownList después de eliminar
            Else
                lblError.Text = "No se encontró la cita para eliminar."
            End If
        End Using
    End Sub
End Class