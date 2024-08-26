Imports System.Data.SqlClient

Public Class AgendarCita
    Inherits System.Web.UI.Page

    Dim connString As String = ConfigurationManager.ConnectionStrings("DefaultConnection").ConnectionString

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As EventArgs) Handles Me.Load
        ' No es necesario cargar datos si todos los campos son manuales
    End Sub

    Protected Sub btnGuardar_Click(ByVal sender As Object, ByVal e As EventArgs)
        Dim folio As String = txtFolio.Text
        Dim fecha As String = txtFecha.Text
        Dim hora As String = txtHora.Text
        Dim nombreCliente As String = txtCliente.Text

        If String.IsNullOrEmpty(folio) OrElse String.IsNullOrEmpty(nombreCliente) Then
            lblSuccess.Text = "Por favor, complete todos los campos obligatorios."
            lblSuccess.ForeColor = System.Drawing.Color.Red
            Return
        End If

        Dim idCliente As Integer = GetClienteIdByName(nombreCliente)

        If idCliente = 0 Then
            lblSuccess.Text = "El cliente no existe."
            lblSuccess.ForeColor = System.Drawing.Color.Red
            Return
        End If

        ' Validar y convertir la fecha y hora
        Dim fechaValida As DateTime
        Dim horaValida As DateTime

        If Not DateTime.TryParse(fecha, fechaValida) Then
            lblSuccess.Text = "La fecha ingresada no es válida."
            lblSuccess.ForeColor = System.Drawing.Color.Red
            Return
        End If

        If Not DateTime.TryParse(hora, horaValida) Then
            lblSuccess.Text = "La hora ingresada no es válida."
            lblSuccess.ForeColor = System.Drawing.Color.Red
            Return
        End If

        Using conn As New SqlConnection(connString)
            Dim cmd As New SqlCommand("INSERT INTO Citas (Folio, Fecha, Hora, IdCliente) VALUES (@Folio, @Fecha, @Hora, @IdCliente)", conn)
            cmd.Parameters.AddWithValue("@Folio", folio)
            cmd.Parameters.AddWithValue("@Fecha", fechaValida.ToString("yyyy-MM-dd"))
            cmd.Parameters.AddWithValue("@Hora", horaValida.ToString("HH:mm:ss"))
            cmd.Parameters.AddWithValue("@IdCliente", idCliente)

            conn.Open()
            Dim rowsAffected As Integer = cmd.ExecuteNonQuery()
            If rowsAffected > 0 Then
                lblSuccess.Text = "Cita agendada exitosamente."
                lblSuccess.ForeColor = System.Drawing.Color.Green
            Else
                lblSuccess.Text = "Error al agendar la cita."
                lblSuccess.ForeColor = System.Drawing.Color.Red
            End If
        End Using
    End Sub


    Private Function GetClienteIdByName(ByVal nombre As String) As Integer
        Using conn As New SqlConnection(connString)
            Dim cmd As New SqlCommand("SELECT IdCliente FROM Clientes WHERE Nombre = @Nombre", conn)
            cmd.Parameters.AddWithValue("@Nombre", nombre)

            conn.Open()
            Dim result = cmd.ExecuteScalar()
            If result IsNot Nothing Then
                Return Convert.ToInt32(result)
            End If
        End Using
        Return 0
    End Function
    Protected Sub btnVolver_Click(sender As Object, e As EventArgs) Handles btnVolver.Click
        Response.Redirect("HomeRep.aspx")
    End Sub

End Class