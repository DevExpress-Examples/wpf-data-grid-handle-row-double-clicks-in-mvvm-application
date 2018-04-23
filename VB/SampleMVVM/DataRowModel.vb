Imports Microsoft.VisualBasic
Imports System

Namespace SampleMVVM
	Public Class DataRowModel
		Private privateId As Integer
		Public Property Id() As Integer
			Get
				Return privateId
			End Get
			Set(ByVal value As Integer)
				privateId = value
			End Set
		End Property
		Private privateName As String
		Public Property Name() As String
			Get
				Return privateName
			End Get
			Set(ByVal value As String)
				privateName = value
			End Set
        End Property

		Private privateDate As DateTime
        Public Property [Date]() As DateTime
            Get
                Return privateDate
            End Get
            Set(ByVal value As DateTime)
                privateDate = value
            End Set
        End Property
	End Class
End Namespace
