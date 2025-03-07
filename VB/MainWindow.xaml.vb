Imports DevExpress.Xpf.Charts
Imports System
Imports System.Collections.Generic
Imports System.Windows
Imports System.Windows.Controls

Namespace ArgumentBasedMarkerTypeSelector

    Public Partial Class MainWindow
        Inherits Window

        Public Property DataItems As List(Of ChartDataItem) = New List(Of ChartDataItem)()

        Public Sub New()
            Me.InitializeComponent()
            DataItems.AddRange(GenerateRandomData())
        End Sub

        Private Iterator Function GenerateRandomData() As IEnumerable(Of ChartDataItem)
            Dim random = New Random()
            For i = 0 To 90 - 1
                Yield New ChartDataItem() With {.DateTimeStamp = Date.Today.AddDays(i), .Value = random.Next(0, 100)}
            Next
        End Function
    End Class

    Public Class ChartDataItem

        Public Property DateTimeStamp As Date

        Public Property Value As Double
    End Class

    Public Class MarkerDataTemplateSelector
        Inherits DataTemplateSelector

        Public Overrides Function SelectTemplate(ByVal item As Object, ByVal container As DependencyObject) As DataTemplate
            Dim element As FrameworkElement = Nothing, seriesPoint As SeriesPoint = Nothing
            If CSharpImpl.__Assign(element, TryCast(container, FrameworkElement)) IsNot Nothing AndAlso CSharpImpl.__Assign(seriesPoint, TryCast(item, SeriesPoint)) IsNot Nothing Then
                Dim dayOfWeek = seriesPoint.DateTimeArgument.DayOfWeek
                If dayOfWeek = DayOfWeek.Saturday OrElse dayOfWeek = DayOfWeek.Sunday Then
                    Return TryCast(element.FindResource("squareModel"), DataTemplate)
                Else
                    Return TryCast(element.FindResource("circleModel"), DataTemplate)
                End If
            End If

            Return Nothing
        End Function

        Private Class CSharpImpl

            <Obsolete("Please refactor calling code to use normal Visual Basic assignment")>
            Shared Function __Assign(Of T)(ByRef target As T, value As T) As T
                target = value
                Return value
            End Function
        End Class
    End Class
End Namespace
