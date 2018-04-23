' Developer Express Code Central Example:
' How to handle a double-click on a grid row in a MVVM application
' 
' This example demonstrates one of many possible solutions for decoupling DXGrid
' mouse event handling from business logic, when using the MVVM architectural
' pattern.
' 
' You can find sample updates and versions for different programming languages here:
' http://www.devexpress.com/example=E2458

Imports Microsoft.VisualBasic
Imports System
Imports System.Collections.Generic
Imports System.Windows
Imports System.Windows.Input

Namespace SampleMVVM
	Partial Public Class DataRowView
		Inherits Window
		Public Sub New()
			InitializeComponent()
			Dim list As New List(Of DataRowViewModel)()
            For i As Integer = 0 To 100
                Dim obj As New DataRowModel
                obj.Id = i + 1
                obj.Name = "Row" & i.ToString()
                obj.Date = DateTime.Now
                list.Add(New DataRowViewModel(obj))
            Next i

			grid.ItemsSource = list
		End Sub
	End Class

	Public NotInheritable Class ClickBindingHelper
		Private Sub New()
		End Sub
		Public Shared Function GetDoubleClickCommand(ByVal obj As DependencyObject) As ICommand
			Return CType(obj.GetValue(DoubleClickCommandProperty), ICommand)
		End Function
		Public Shared Sub SetDoubleClickCommand(ByVal obj As DependencyObject, ByVal value As ICommand)
			obj.SetValue(DoubleClickCommandProperty, value)
        End Sub

        Public Shared ReadOnly DoubleClickCommandProperty As DependencyProperty = DependencyProperty.RegisterAttached("DoubleClickCommand", GetType(ICommand), GetType(ClickBindingHelper), New PropertyMetadata(Nothing, AddressOf OnDoubleClickCommandChanged))

		Private Shared Sub OnDoubleClickCommandChanged(ByVal d As DependencyObject, ByVal e As DependencyPropertyChangedEventArgs)
			Dim element As UIElement = TryCast(d, UIElement)
			If element IsNot Nothing Then
				element.InputBindings.Clear()
				Dim command As ICommand = TryCast(e.NewValue, ICommand)
				If command IsNot Nothing Then
					element.InputBindings.Add(New MouseBinding(command, New MouseGesture(MouseAction.LeftDoubleClick)))
				End If
			End If
		End Sub
	End Class
End Namespace
