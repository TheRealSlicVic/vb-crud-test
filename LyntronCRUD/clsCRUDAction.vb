Public Class clsCRUDAction
    Public SQLAction As String
    Public SQLCommand As String

    Public Property Action() As String
        Get
            Return SQLAction
        End Get
        Set(ByVal value As String)
            SQLAction = value
        End Set
    End Property

    Public Property Command() As String
        Get
            Return SQLCommand
        End Get
        Set(ByVal value As String)
            SQLCommand = value
        End Set
    End Property


End Class
