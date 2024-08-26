Imports System.Data.SqlClient

Public Class AgregarCliente
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        lblMensaje.Text = ""
        lblSuccess.Text = ""
    End Sub

    Protected Sub btnVolver_Click(sender As Object, e As EventArgs) Handles btnVolver.Click
        Response.Redirect("HomeRep.aspx")
    End Sub

    Protected Sub btnGuardar_Click(ByVal sender As Object, ByVal e As EventArgs)
        ' Recoge los valores de los TextBox en variables
        Dim nombre As String = txtNombre.Text.Trim()
        Dim paterno As String = txtPaterno.Text.Trim()
        Dim materno As String = txtMaterno.Text.Trim()
        Dim numero As String = txtNumero.Text.Trim()
        Dim correoTexto As String = Correo.Text.Trim()
        Dim direccion As String = txtDirreccion.Text.Trim()

        ' Verifica si los campos están vacíos
        If String.IsNullOrEmpty(nombre) OrElse String.IsNullOrEmpty(paterno) OrElse String.IsNullOrEmpty(materno) OrElse String.IsNullOrEmpty(numero) OrElse String.IsNullOrEmpty(correoTexto) OrElse String.IsNullOrEmpty(direccion) Then
            lblMensaje.Text = "Por favor, complete todos los campos."
            Return
        End If

        ' Cadena de conexión y consulta SQL para insertar el cliente
        Dim connString As String = ConfigurationManager.ConnectionStrings("DefaultConnection").ConnectionString
        Dim query As String = "INSERT INTO Clientes (Nombre, Paterno, Materno, Numero, Correo, Direccion) VALUES (@Nombre, @Paterno, @Materno, @Numero, @Correo, @Direccion)"

        Using conn As New SqlConnection(connString)
            Using cmd As New SqlCommand(query, conn)
                ' Asigna los valores de los parámetros SQL
                cmd.Parameters.AddWithValue("@Nombre", nombre)
                cmd.Parameters.AddWithValue("@Paterno", paterno)
                cmd.Parameters.AddWithValue("@Materno", materno)
                cmd.Parameters.AddWithValue("@Numero", numero)
                cmd.Parameters.AddWithValue("@Correo", correoTexto)
                cmd.Parameters.AddWithValue("@Direccion", direccion)

                Try
                    conn.Open()
                    cmd.ExecuteNonQuery()
                    lblSuccess.Text = "Cliente agregado exitosamente."
                    lblMensaje.Text = ""
                    LimpiarFormulario()
                Catch ex As SqlException
                    lblMensaje.Text = "Error al guardar el cliente. Por favor, intente de nuevo. Detalles: " & ex.Message
                End Try
            End Using
        End Using
    End Sub

    ' Método para limpiar los TextBox después de guardar el cliente
    Private Sub LimpiarFormulario()
        txtNombre.Text = ""
        txtPaterno.Text = ""
        txtMaterno.Text = ""
        txtNumero.Text = ""
        Correo.Text = ""
        txtDirreccion.Text = ""
    End Sub
End Class
