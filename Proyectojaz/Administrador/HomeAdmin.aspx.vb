Public Class HomeAdmin
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As EventArgs) Handles Me.Load
        ' Código de inicialización, si es necesario
    End Sub

    ' Métodos para manejar eventos de los botones
    Protected Sub btnAgregarcuenta_Click(ByVal sender As Object, ByVal e As EventArgs)
        Response.Redirect("AgregarCuentas.aspx")
    End Sub

    Protected Sub btnContraseña_Click(ByVal sender As Object, ByVal e As EventArgs)
        Response.Redirect("RestaurarContraseña.aspx")
    End Sub



    Protected Sub Button4_Click(ByVal sender As Object, ByVal e As EventArgs)
        Response.Redirect("AgregarServicios.aspx")
    End Sub

    Protected Sub Button1_Click(ByVal sender As Object, ByVal e As EventArgs) Handles Button1.Click
        Response.Redirect("ListadoCuentas.aspx")
    End Sub

    Protected Sub Button2_Click(ByVal sender As Object, ByVal e As EventArgs)
        Response.Redirect("ModificarRegistro.aspx")
    End Sub

End Class
