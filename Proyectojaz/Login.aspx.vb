Imports System.Data.SqlClient

Partial Class Login1
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        ' Opcional: Agregar lógica aquí si es necesario
    End Sub

    Protected Sub btnLogin_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnLogin.Click
        ' Obtener los valores de los controles de entrada
        Dim email As String = txtEmail.Text.Trim()
        Dim password As String = txtPassword.Text.Trim()

        ' Obtener el rol del usuario
        Dim userRole As String = GetUserRole(email, password)

        If Not String.IsNullOrEmpty(userRole) Then
            ' Redirigir a la página correspondiente según el rol del usuario
            Select Case userRole
                Case "Administrador"
                    Response.Redirect("~/Administrador/HomeAdmin.aspx")
                Case "Recepcionista"
                    Response.Redirect("~/Recep/HomeRep.aspx")
                Case "Mecánico"
                    Response.Redirect("~/Mecanico/HomeMec.aspx")
                Case Else
                    lblMessage.Text = "Rol de usuario no reconocido."
            End Select
        Else
            ' Mostrar un mensaje de error si las credenciales no son válidas
            lblMessage.Text = "Nombre de usuario o contraseña inválidos."
        End If
    End Sub

    Private Function GetUserRole(ByVal email As String, ByVal password As String) As String
        Dim connectionString As String = "Server=LAPTOP-L4BR3OML\SQLEXPRESS;Database=CFP;User Id=sa;Password=aaa;"
        Dim roleName As String = String.Empty

        Using connection As New SqlConnection(connectionString)
            ' Modifica la consulta según los nombres de columnas correctos
            Dim query As String = "SELECT r.Rol FROM [CFP].[dbo].[Usuarios] u INNER JOIN [CFP].[dbo].[Roles] r ON u.IdRol = r.IdRol WHERE u.Nombre = @Nombre AND u.Contraseña = @Contraseña"
            Dim command As New SqlCommand(query, connection)
            command.Parameters.AddWithValue("@Nombre", email)
            command.Parameters.AddWithValue("@Contraseña", password)

            connection.Open()
            roleName = Convert.ToString(command.ExecuteScalar())
        End Using

        ' Para depuración: imprime el rol del usuario
        Response.Write("RoleName: " & roleName)

        Return roleName
    End Function


End Class
