Imports System.Data.SqlClient

Public Class AgregarCuentas
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
    End Sub

    Protected Sub btnAgregar_Click(sender As Object, e As EventArgs) Handles btnAgregar.Click
        ' Obtener los valores de los controles
        Dim nombre As String = txtNombre1.Text.Trim()
        Dim contraseña As String = txtContraseña.Text.Trim()
        Dim idRol As String = ddlRol.SelectedValue

        ' Validar los datos
        If String.IsNullOrEmpty(nombre) OrElse String.IsNullOrEmpty(contraseña) OrElse String.IsNullOrEmpty(idRol) Then
            lblMensaje.Text = "Por favor, complete todos los campos."
            lblMensaje.ForeColor = System.Drawing.Color.Red
            Return
        End If

        ' Convertir el idRol a Integer
        Dim idRolInt As Integer
        If Not Integer.TryParse(idRol, idRolInt) Then
            lblMensaje.Text = "Error en el rol seleccionado."
            lblMensaje.ForeColor = System.Drawing.Color.Red
            Return
        End If

        ' Cadena de conexión (ajusta esto a tu configuración)
        Dim connectionString As String = "Server=VIRUXFIVE\SQLEXPRESS;Database=CFP;User Id=sa;Password=12345678;"

        ' Consulta SQL para insertar el nuevo usuario
        Dim query As String = "INSERT INTO Usuarios (Nombre, Contraseña, IdRol) VALUES (@Nombre, @Contraseña, @IdRol)"

        Using connection As New SqlConnection(connectionString)
            Using command As New SqlCommand(query, connection)
                ' Agregar parámetros para evitar inyecciones SQL
                command.Parameters.AddWithValue("@Nombre", nombre)
                command.Parameters.AddWithValue("@Contraseña", contraseña)
                command.Parameters.AddWithValue("@IdRol", idRolInt)

                Try
                    connection.Open()
                    command.ExecuteNonQuery()
                    lblMensaje.Text = "Usuario agregado exitosamente."
                    lblMensaje.ForeColor = System.Drawing.Color.Green
                    ' Limpiar los campos después de agregar
                    txtNombre1.Text = ""
                    txtContraseña.Text = ""
                    ddlRol.SelectedIndex = 0
                Catch ex As Exception
                    lblMensaje.Text = "Error al agregar el usuario: " & ex.Message
                    lblMensaje.ForeColor = System.Drawing.Color.Red
                End Try
            End Using
        End Using
    End Sub

    Private Function ObtenerIdRol(rolNombre As String) As Integer?
        Dim connectionString As String = "Server=VIRUXFIVE\SQLEXPRESS;Database=CFP;User Id=sa;Password=aaa;"
        Dim query As String = "SELECT IdRol FROM Roles WHERE Rol = @Rol"

        Using connection As New SqlConnection(connectionString)
            Using command As New SqlCommand(query, connection)
                command.Parameters.AddWithValue("@Rol", rolNombre)
                Try
                    connection.Open()
                    Dim result = command.ExecuteScalar()
                    If result IsNot Nothing AndAlso IsNumeric(result) Then
                        Return Convert.ToInt32(result)
                    End If
                Catch ex As Exception
                End Try
            End Using
        End Using

        Return Nothing
    End Function
    Protected Sub btnVolver_Click(sender As Object, e As EventArgs) Handles btnVolver.Click
        Response.Redirect("HomeAdmin.aspx")
    End Sub
End Class
