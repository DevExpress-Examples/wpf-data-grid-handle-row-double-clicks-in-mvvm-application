Imports DevExpress.Mvvm
Imports DevExpress.Mvvm.DataAnnotations
Imports DevExpress.Mvvm.Xpf
Imports DevExpress.Xpf.Core
Imports System
Imports System.Collections.Generic
Imports System.Collections.ObjectModel
Imports System.Linq
Imports System.Windows

Namespace RowDoubleClick_MVVM
	Public Class DataItem
		Public Property Id() As Integer
		Public Property Name() As String
	End Class
	Public Class MainViewModel
		Inherits ViewModelBase

		Public ReadOnly Property Items() As ObservableCollection(Of DataItem)
		Public Property CurrentItem() As DataItem
			Get
				Return GetProperty(Function() CurrentItem)
			End Get
			Set(ByVal value As DataItem)
				SetProperty(Function() CurrentItem, value)
			End Set
		End Property
		Public Sub New()
			Items = New ObservableCollection(Of DataItem)(GetItems())
		End Sub
		Private Function GetItems() As IEnumerable(Of DataItem)
			Return Enumerable.Range(0, 10).Select(Function(i) New DataItem() With {
				.Id = i,
				.Name = "item " & i
			})
		End Function

		<Command>
		Public Sub RowDoubleClick(ByVal args As RowClickArgs)
			DXMessageBox.Show("Row double click: " & CurrentItem.Name)
		End Sub
	End Class
End Namespace
