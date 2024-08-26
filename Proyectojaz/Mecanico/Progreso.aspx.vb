Public Class Progreso
    Inherits System.Web.UI.Page

    ' Al cargar la página, inicializa las actividades si no es una postback
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            ' Inicializar actividades con algunos ejemplos
            Session("actividades") = New List(Of String) From {
                "Cambio de bujias",
                "Cambio de aceite",
                "Alineacion y balanceo"
            }
            BindCheckBoxList()
        End If
    End Sub

    ' Método para enlazar la CheckBoxList con la lista de actividades
    Private Sub BindCheckBoxList()
        Dim actividades As List(Of String) = CType(Session("actividades"), List(Of String))
        chkLstActividades.Items.Clear()
        For Each actividad In actividades
            chkLstActividades.Items.Add(actividad)
        Next
        UpdateProgressBar()
    End Sub

    ' Evento para agregar una nueva actividad
    Protected Sub btnAgregarActividad_Click(sender As Object, e As EventArgs)
        Dim nuevaActividad As String = txtNuevaActividad.Text.Trim()
        If nuevaActividad <> "" Then
            Dim actividades As List(Of String) = CType(Session("actividades"), List(Of String))
            actividades.Add(nuevaActividad)
            Session("actividades") = actividades
            BindCheckBoxList()
            txtNuevaActividad.Text = ""
        End If
    End Sub

    ' Evento para eliminar la actividad seleccionada
    Protected Sub btnEliminarActividad_Click(sender As Object, e As EventArgs)
        Dim actividades As List(Of String) = CType(Session("actividades"), List(Of String))
        For Each item As ListItem In chkLstActividades.Items
            If item.Selected Then
                actividades.Remove(item.Text)
            End If
        Next
        Session("actividades") = actividades
        BindCheckBoxList()
    End Sub

    ' Evento que se activa al cambiar el estado de un checkbox
    Protected Sub chkLstActividades_SelectedIndexChanged(sender As Object, e As EventArgs)
        UpdateProgressBar()
    End Sub

    ' Método para actualizar la barra de progreso
    Private Sub UpdateProgressBar()
        Dim totalActividades As Integer = chkLstActividades.Items.Count
        Dim actividadesCompletadas As Integer = chkLstActividades.Items.Cast(Of ListItem).Count(Function(i) i.Selected)
        Dim progreso As Integer = If(totalActividades > 0, CInt((actividadesCompletadas / totalActividades) * 100), 0)
        lblProgreso.Text = "Progreso: " & progreso & "%"
    End Sub
End Class