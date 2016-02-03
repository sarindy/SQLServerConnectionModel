Imports System.Data.SqlClient
Public Class DBMgr
    Private strConn As String


    Private cnn As New SqlConnection("Server=localhost;Database=OSD001;User Id=dy;Password=qwe;")
    Public Property GetConn() As SqlConnection
        Get
            Return cnn
        End Get
        Set(ByVal value As SqlConnection)
            cnn = value
        End Set
    End Property

End Class
