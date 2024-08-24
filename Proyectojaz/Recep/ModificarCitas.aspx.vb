Imports System.Data.SqlClient
Imports System.Configuration

Public Class ModificarCita
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(sender As Object, e As EventArgs) Handles Me.Load
        If Not IsPostBack Then
            CargarClientes()
            CargarCitas()
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

    Private Sub CargarCitas()
        Dim connString As String = ConfigurationManager.ConnectionStrings("DefaultConnection").ConnectionString
        Using conn As New SqlConnection(connString)
            Dim cmd As New SqlCommand("SELECT Folio, Fecha FROM Citas", conn)
            conn.Open()
            Dim reader As SqlDataReader = cmd.ExecuteReader()
            ddlCita.DataSource = reader
            ddlCita.DataTextField = "Fecha"
            ddlCita.DataValueField = "Folio"
            ddlCita.DataBind()
            ddlCita.Items.Insert(0, New ListItem("--Seleccione Cita--", "0"))
        End Using
    End Sub

    Protected Sub ddlCita_SelectedIndexChanged(sender As Object, e As EventArgs)
        Dim folio As String = ddlCita.SelectedValue

        Dim connString As String = ConfigurationManager.ConnectionStrings("DefaultConnection").ConnectionString
        Using conn As New SqlConnection(connString)
            Dim cmd As New SqlCommand("SELECT Folio, Fecha, Hora, idCliente FROM Citas WHERE Folio = @Folio", conn)
            cmd.Parameters.AddWithValue("@Folio", folio)
            conn.Open()
            Dim reader As SqlDataReader = cmd.ExecuteReader()

            If reader.Read() Then
                txtFolio.Text = reader("Folio").ToString()

                ' Asegúrate de que la fecha y hora están en un formato compatible
                If Not IsDBNull(reader("Fecha")) Then
                    txtFecha.Text = Convert.ToDateTime(reader("Fecha")).ToString("yyyy-MM-dd")
                End If
                If Not IsDBNull(reader("Hora")) Then
                    ' Asegúrate de que la hora se maneje como un TimeSpan
                    Dim hora As TimeSpan = CType(reader("Hora"), TimeSpan)
                    txtHora.Text = hora.ToString("hh\:mm")
                End If
                ddlCliente.SelectedValue = reader("idCliente").ToString()
            End If
        End Using
    End Sub

    Protected Sub btnGuardar_Click(sender As Object, e As EventArgs)
        Dim folio As String = txtFolio.Text
        Dim fecha As String = txtFecha.Text
        Dim hora As String = txtHora.Text
        Dim idCliente As Integer = Integer.Parse(ddlCliente.SelectedValue)

        ' Asegúrate de que la fecha y hora están en el formato correcto
        Dim fechaHora As DateTime
        If Not DateTime.TryParseExact(fecha, "yyyy-MM-dd", Nothing, Globalization.DateTimeStyles.None, fechaHora) Then
            lblSuccess.Text = "Formato de fecha inválido."
            Return
        End If
        Dim horaFormat As TimeSpan
        If Not TimeSpan.TryParseExact(hora, "hh\:mm", Nothing, horaFormat) Then
            lblSuccess.Text = "Formato de hora inválido."
            Return
        End If

        Dim connString As String = ConfigurationManager.ConnectionStrings("DefaultConnection").ConnectionString
        Using conn As New SqlConnection(connString)
            Dim cmd As New SqlCommand("UPDATE Citas SET Fecha = @Fecha, Hora = @Hora, idCliente = @idCliente WHERE Folio = @Folio", conn)
            cmd.Parameters.AddWithValue("@Folio", folio)
            cmd.Parameters.AddWithValue("@Fecha", fechaHora.ToString("yyyy-MM-dd"))
            cmd.Parameters.AddWithValue("@Hora", horaFormat.ToString("hh\:mm"))
            cmd.Parameters.AddWithValue("@idCliente", idCliente)
            conn.Open()
            cmd.ExecuteNonQuery()
        End Using

        lblSuccess.Text = "Cita actualizada exitosamente."
    End Sub
End Class