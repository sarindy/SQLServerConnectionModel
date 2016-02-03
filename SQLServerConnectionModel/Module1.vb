Module Module1

    Sub Main()
        Console.WriteLine("Hello")

        Dim dbmgr As New DBMgr
        Try
            dbmgr.GetConn.Open()
            MsgBox("Connected", MsgBoxStyle.Information, "DB Connection")


        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
        Console.ReadKey()

    End Sub

End Module
