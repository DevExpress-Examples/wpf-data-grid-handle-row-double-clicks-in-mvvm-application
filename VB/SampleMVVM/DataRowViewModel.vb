Imports Microsoft.VisualBasic
Imports System
Imports System.Windows
Imports System.Windows.Input
Imports DevExpress.Xpf.Core.Commands

Namespace SampleMVVM
	Public Class DataRowViewModel
		Private privateRow As DataRowModel
		Public Property Row() As DataRowModel
			Get
				Return privateRow
			End Get
			Private Set(ByVal value As DataRowModel)
				privateRow = value
			End Set
        End Property

		Private privateCellDoubleClickCommand As ICommand
		Public Property CellDoubleClickCommand() As ICommand
			Get
				Return privateCellDoubleClickCommand
			End Get
			Private Set(ByVal value As ICommand)
				privateCellDoubleClickCommand = value
			End Set
        End Property

		Public Sub New(ByVal row As DataRowModel)
            Me.Row = row
			CellDoubleClickCommand = New DelegateCommand(Of Object)(Function(o) MessageBox.Show("Cell double click. Row: " & Row.Id))
		End Sub
	End Class
End Namespace
