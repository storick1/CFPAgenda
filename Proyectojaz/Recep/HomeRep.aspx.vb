Public Class HomeRep
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub

    Protected Sub btnAgendarCita_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnAgendarCita.Click
        ' Redirigir o manejar la acción de agendar cita
        Response.Redirect("AgendarCita.aspx")
    End Sub
End Class