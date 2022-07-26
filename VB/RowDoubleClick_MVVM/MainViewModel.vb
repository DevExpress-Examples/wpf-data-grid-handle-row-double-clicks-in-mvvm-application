Imports DevExpress.Mvvm
Imports DevExpress.Mvvm.DataAnnotations
Imports DevExpress.Mvvm.Xpf
Imports DevExpress.Xpf.Core
Imports System.Collections.Generic
Imports System.Collections.ObjectModel
Imports System.Linq

Namespace RowDoubleClick_MVVM

    Public Class DataItem

        Public Property Id As Integer

        Public Property Name As String
    End Class

    Public Class MainViewModel
        Inherits ViewModelBase

        Public ReadOnly Property Items As ObservableCollection(Of DataItem)

        Public Sub New()
            Items = New ObservableCollection(Of DataItem)(GetItems())
        End Sub

        Private Function GetItems() As IEnumerable(Of DataItem)
            Return Enumerable.Range(0, 10).[Select](Function(i) New DataItem() With {.Id = i, .Name = "item " & i})
        End Function

        <Command>
        Public Sub RowDoubleClick(ByVal args As RowClickArgs)
            Call DXMessageBox.Show("Row double click: " & CType(args.Item, DataItem).Name)
        End Sub
    End Class
End Namespace
