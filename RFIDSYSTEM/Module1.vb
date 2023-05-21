Imports System.Data.OleDb
Module Module1
    Public connStr As String = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" & Application.StartupPath & "\RFIDdatabase.mdb"
    Public Conn As New OleDbConnection(connStr)

    Function Connect()
        If Conn.State = ConnectionState.Closed Then
            Conn.Open()
        End If
        Return True
    End Function
End Module
