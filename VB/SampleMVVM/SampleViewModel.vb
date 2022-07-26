Imports DevExpress.Mvvm
Imports System.Collections.ObjectModel
Imports System.Windows
Imports System.Windows.Input

Namespace SampleMVVM

    Public Class SampleViewModel
        Inherits ViewModelBase

        Private _RowDoubleClickCommand As ICommand

        Public Property Items As ObservableCollection(Of SampleItem)

        Public Property RowDoubleClickCommand As ICommand
            Get
                Return _RowDoubleClickCommand
            End Get

            Private Set(ByVal value As ICommand)
                _RowDoubleClickCommand = value
            End Set
        End Property

        Public Property CurrentItem As SampleItem
            Get
                Return GetProperty(Function() Me.CurrentItem)
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
            For i As Integer = 0 To 10 - 1
                Dim item As SampleItem = New SampleItem() With {.Id = i, .Name = "item " & i.ToString()}
                Items.Add(item)
            Next
        End Sub

        Private Sub ExecuteRowDoubleClickCommand()
            MessageBox.Show("Row double click: " & CurrentItem.Name)
        End Sub
    End Class

    Public Class SampleItem
        Inherits BindableBase

        Public Property Id As Integer
            Get
                Return GetProperty(Function() Me.Id)
            End Get

            Set(ByVal value As Integer)
                SetProperty(Function() Id, value)
            End Set
        End Property

        Public Property Name As String
            Get
                Return GetProperty(Function() Me.Name)
            End Get

            Set(ByVal value As String)
                SetProperty(Function() Name, value)
            End Set
        End Property
    End Class
End Namespace
