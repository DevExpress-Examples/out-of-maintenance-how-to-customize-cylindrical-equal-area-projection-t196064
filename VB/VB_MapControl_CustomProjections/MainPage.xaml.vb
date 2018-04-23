Imports DevExpress.UI.Xaml.Map

Public NotInheritable Class MainPage
    Inherits Page

    Private projectionRatios() As ProjectionRatio = { _
        New ProjectionRatio("Lambert", 3.14), _
        New ProjectionRatio("Behrmann", 2.36), _
        New ProjectionRatio("Trystan Edwards", 2), _
        New ProjectionRatio("Gall-Peters", 1.57), _
        New ProjectionRatio("Balthasart", 1.3), _
        New ProjectionRatio("Default", 1) _
    }

    Private sizeValue As Integer = 512

    Public ReadOnly Property Ratios() As ProjectionRatio()
        Get
            Return projectionRatios
        End Get
    End Property

    Public Sub New()
        Me.InitializeComponent()
    End Sub

    Private Sub ListView_SelectionChanged(sender As Object, e As SelectionChangedEventArgs)
        Dim lView = TryCast(sender, ListView)
        If lView Is Nothing Then Return

        Dim vectorLayer = TryCast(map.Layers(0), VectorFileLayer)
        vectorLayer.InitialMapSize = New Size(Ratios(lView.SelectedIndex).Value * sizeValue, sizeValue)
    End Sub

    Private Sub Page_Loaded(sender As Object, e As RoutedEventArgs)
        Me.DataContext = Me
        listView.SelectedIndex = Ratios.Length - 1
    End Sub
End Class