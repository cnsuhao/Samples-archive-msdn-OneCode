Public Class Person
    Public Property Name() As String
        Get
            Return m_Name
        End Get
        Set(value As String)
            m_Name = Value
        End Set
    End Property
    Private m_Name As String

    Public Property Comments() As String
        Get
            Return m_Comments
        End Get
        Set(value As String)
            m_Comments = Value
        End Set
    End Property
    Private m_Comments As String
End Class
