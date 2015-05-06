Imports Oracle.DataAccess

Public Class clsCRUD
    Dim oradb As String = "Data Source=LyntronSAND;User Id=ODBCUSER;Password=coffee;"
    Dim dbConnOracle As New Client.OracleConnection(oradb)
    Dim cmdOracle As New Client.OracleCommand
    Dim daDataAdapterOracle As New Odbc.OdbcDataAdapter

    Public Enum CRUD_Action
        CREATE
        READ
        UPDATE
        DELETE
    End Enum

    Public Sub CreateRecord()

    End Sub

    Public Function ReadRecord(ByVal sql As String) As String
        Dim strPartNum As String = Nothing

        Try
            dbConnOracle.Open()

            With cmdOracle
                .CommandText = Sql
                .CommandType = CommandType.Text
                .Connection = dbConnOracle
            End With

            daDataAdapterOracle.SelectCommand = cmdOracle
            strPartNum = daDataAdapterOracle.SelectCommand.ExecuteScalar
            dbConnOracle.Close()
        Catch ex As Exception
            'showException(ex)
            dbConnOracle.Close()
        End Try
        Return strPartNum
    End Function

    Public Sub UpdateRecord()

    End Sub

    Public Sub DeleteRecord()

    End Sub
End Class
