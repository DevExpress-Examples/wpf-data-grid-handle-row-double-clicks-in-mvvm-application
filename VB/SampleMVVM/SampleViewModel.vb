Imports DevExpress.Mvvm
Imports System.Collections.ObjectModel
Imports System.Windows
Imports System.Windows.Input

Namespace SampleMVVM
    Public Class SampleViewModel
        Inherits ViewModelBase

        Public Property Items() As ObservableCollection(Of SampleItem)
        Private privateRowDoubleClickCommand As ICommand
        Public Property RowDoubleClickCommand() As ICommand
            Get
                Return privateRowDoubleClickCommand
            End Get
            Private Set(ByVal value As ICommand)
                privateRowDoubleClickCommand = value
            End Set
        End Property
        Public Property CurrentItem() As SampleItem
            Get
                Return GetProperty(Function() CurrentItem)
            End Get
            Set(ByVal value As SampleItem)
                SetProperty(Function() CurrentItem, value)
            End Set
        End Property
        Public Sub New()
            Items = New ObservableCollection(Of SampleItem)()
            RowDoubleClickCommand = New DelegateCommand(AddressOf ExecuteRowDoubleClickCommand)
            InitItems()
        End Sub
        Private Sub InitItems()
            For i As Integer = 0 To 9
                Dim item As New SampleItem() With {.Id = i, .Name = "item " & i.ToString()}
                Items.Add(item)
            Next i
        End Sub
        Private Sub ExecuteRowDoubleClickCommand()
            MessageBox.Show("Row double click: " & CurrentItem.Name)
        End Sub
    End Class

    Public Class SampleItem
        Inherits BindableBase

        Public Property Id() As Integer
            Get
                Return GetProperty(Function() Id)
            End Get
            Set(ByVal value As Integer)
                SetProperty(Function() Id, value)
            End Set
        End Property
        Public Property Name() As String
            Get
                Return GetProperty(Function() Name)
            End Get
            Set(ByVal value As String)
                SetProperty(Function() Name, value)
            End Set
        End Property
    End Class
End Namespace
