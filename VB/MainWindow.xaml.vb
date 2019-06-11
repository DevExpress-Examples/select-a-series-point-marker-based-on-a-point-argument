Imports DevExpress.Xpf.Charts
Imports System
Imports System.Collections.Generic
Imports System.Windows
Imports System.Windows.Controls

Namespace ArgumentBasedMarkerTypeSelector
	Partial Public Class MainWindow
		Inherits Window

		Public Property DataItems() As New List(Of ChartDataItem)()
		Public Sub New()
			InitializeComponent()
			DataItems.AddRange(GenerateRandomData())
		End Sub
		Private Iterator Function GenerateRandomData() As IEnumerable(Of ChartDataItem)
			Dim random = New Random()
			For i = 0 To 89
				Yield New ChartDataItem() With {
					.DateTimeStamp = DateTime.Today.AddDays(i),
					.Value = random.Next(0, 100)
				}
			Next i
		End Function
	End Class
	Public Class ChartDataItem
		Public Property DateTimeStamp() As DateTime
		Public Property Value() As Double
	End Class
	Public Class MarkerDataTemplateSelector
		Inherits DataTemplateSelector

		Public Overrides Function SelectTemplate(ByVal item As Object, ByVal container As DependencyObject) As DataTemplate
			Dim tempVar As Boolean = TypeOf item Is SeriesPoint
			Dim seriesPoint As SeriesPoint = If(tempVar, CType(item, SeriesPoint), Nothing)
			Dim tempVar2 As Boolean = TypeOf container Is FrameworkElement
			Dim element As FrameworkElement = If(tempVar2, CType(container, FrameworkElement), Nothing)
			If tempVar2 AndAlso tempVar Then
				Dim dayOfWeek = seriesPoint.DateTimeArgument.DayOfWeek
				If dayOfWeek = System.DayOfWeek.Saturday OrElse dayOfWeek = System.DayOfWeek.Sunday Then
					Return TryCast(element.FindResource("squareModel"), DataTemplate)
				Else
					Return TryCast(element.FindResource("circleModel"), DataTemplate)
				End If
			End If
			Return Nothing
		End Function
	End Class
End Namespace
