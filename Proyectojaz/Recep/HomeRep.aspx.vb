Public Class HomeRep
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub

    Protected Sub btnAgendarCita_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnAgendarCita.Click
        ' Redirigir a    agendar cita
        Response.Redirect("AgendarCita.aspx")
    End Sub

    Protected Sub btnConsultarCita_Click(sender As Object, e As EventArgs) Handles btnConsultarCita.Click
        Response.Redirect("consultarcitas.aspx")
    End Sub
End Class