' Developer Express Code Central Example:
' How to handle a double-click on a grid row in a MVVM application
' 
' This example demonstrates one of many possible solutions for decoupling DXGrid
' mouse event handling from business logic, when using the MVVM architectural
' pattern.
' 
' You can find sample updates and versions for different programming languages here:
' http://www.devexpress.com/example=E2458
Imports System.Collections.Generic
Imports System.Windows
Imports System.Windows.Input

Namespace SampleMVVM

    Public Partial Class DataRowView
        Inherits Window

        Public Sub New()
            Me.InitializeComponent()
            Dim list As List(Of DataRowViewModel) = New List(Of DataRowViewModel)()
            For i As Integer = 0 To 100 - 1
                list.Add(New DataRowViewModel(New DataRowModel() With {.Id = i + 1, .Name = "Row" & i.ToString(), .[Date] = Date.Now}))
            Next

            Me.grid.ItemsSource = list
        End Sub
    End Class

    Public Module ClickBindingHelper

        Public Function GetDoubleClickCommand(ByVal obj As DependencyObject) As ICommand
            Return CType(obj.GetValue(DoubleClickCommandProperty), ICommand)
        End Function

        Public Sub SetDoubleClickCommand(ByVal obj As DependencyObject, ByVal value As ICommand)
            obj.SetValue(DoubleClickCommandProperty, value)
        End Sub

        Public ReadOnly DoubleClickCommandProperty As DependencyProperty = DependencyProperty.RegisterAttached("DoubleClickCommand", GetType(ICommand), GetType(ClickBindingHelper), New PropertyMetadata(Nothing, AddressOf OnDoubleClickCommandChanged))

        Private Sub OnDoubleClickCommandChanged(ByVal d As DependencyObject, ByVal e As DependencyPropertyChangedEventArgs)
            Dim element As UIElement = TryCast(d, UIElement)
            If element IsNot Nothing Then
                element.InputBindings.Clear()
                Dim command As ICommand = TryCast(e.NewValue, ICommand)
                If command IsNot Nothing Then element.InputBindings.Add(New MouseBinding(command, New MouseGesture(MouseAction.LeftDoubleClick)))
            End If
        End Sub
    End Module
End Namespace
