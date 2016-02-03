Module Module1

    Sub Main()
        Console.WriteLine("Hello")

        Dim dbmgr As New DBMgr
        If dbmgr.RetrieveData("select * from dbo.users;") = True Then
            For i As Integer = 1 To dbmgr.QueryResult(0, 0)
                For c As Integer = 1 To dbmgr.QueryResult(0, 1)
                    Console.WriteLine(dbmgr.QueryResult(i, c))
                Next c
            Next i
        End If
       
        Console.ReadKey()

    End Sub

End Module
