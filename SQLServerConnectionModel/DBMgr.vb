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


    Public Sub CloseConnection()
        Try
            cnn.Close()
            MsgBox("DB Closed")
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try



    End Sub
    Public Sub New()
        Try
            cnn.Open()
            MsgBox("Connected")
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try


    End Sub

    Public Function ExecuteSQL(ByVal sql As String) As Boolean
        Try
            Dim cmd As New SqlCommand

            cmd.CommandText = sql

            cmd.Connection = cnn

            cmd.ExecuteNonQuery()

            ExecuteSQL = True

            cnn.Close()

        Catch ex As Exception
            MsgBox(ex.Message)
            Return False
        End Try

        
    End Function

    Private sqlResult As Object
    Public Property QueryResult() As Object
        Get
            Return sqlResult
        End Get
        Set(ByVal value As Object)
            sqlResult = value
        End Set
    End Property

    Public Function RetrieveData(ByVal sql As String) As Boolean

        Try
            Dim result As Object
            Dim adapter As New SqlDataAdapter(sql, cnn)
            Dim dtTable As New DataTable
            adapter.Fill(dtTable)
            Dim cCount As Integer = dtTable.Columns.Count
            Dim rCount As Long = dtTable.Rows.Count
            ReDim result(rCount, cCount)

            result(0, 0) = rCount
            result(0, 1) = cCount


            For i As Long = 1 To rCount

                For c As Integer = 1 To cCount
                    result(i, c) = fnCheckValue(dtTable.Rows(i - 1).Item(c - 1))
                Next
            Next
            adapter.Dispose()
            dtTable.Dispose()
            cnn.Close()
            sqlResult = result
            Return True
        Catch ex As Exception
            MsgBox(ex.Message)
            Return False

        End Try

    End Function

End Class
