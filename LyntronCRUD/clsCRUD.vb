Imports Oracle.DataAccess

Public Class clsCRUD
    Private gOracleDsnConnection As String = "DSN=VMFG_ORACLE;Uid=ODBCUser;Pwd=coffee;"
    Private dtDataTable As DataTable
    Private dsDataSet As DataSet

    Private dbConnOracle As Odbc.OdbcConnection
    Private daDataAdapterOracle As Odbc.OdbcDataAdapter
    Private cmdOracle As Odbc.OdbcCommand

    Private strSql As String

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
