' Developer Express Code Central Example:
' How to handle a double-click on a grid row in a MVVM application
' 
' This example demonstrates one of many possible solutions for decoupling DXGrid
' mouse event handling from business logic, when using the MVVM architectural
' pattern.
' 
' You can find sample updates and versions for different programming languages here:
' http://www.devexpress.com/example=E2458
Imports System.Windows
Imports System.Windows.Input
Imports DevExpress.Xpf.Core.Commands

Namespace SampleMVVM

    Public Class DataRowViewModel

        Private _Row As DataRowModel, _CellDoubleClickCommand As ICommand

        Public Property Row As DataRowModel
            Get
                Return _Row
            End Get

            Private Set(ByVal value As DataRowModel)
                _Row = value
            End Set
        End Property

        Public Property CellDoubleClickCommand As ICommand
            Get
                Return _CellDoubleClickCommand
            End Get

            Private Set(ByVal value As ICommand)
                _CellDoubleClickCommand = value
            End Set
        End Property

        Public Sub New(ByVal row As DataRowModel)
            Me.Row = row
            CellDoubleClickCommand = New DelegateCommand(Of Object)(Sub(o) MessageBox.Show("Cell double click. Row: " & Me.Row.Id))
        End Sub
    End Class
End Namespace
