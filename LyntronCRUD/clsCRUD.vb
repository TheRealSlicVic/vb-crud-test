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

    Public Sub CreateRecord(ByVal tableName As String, ByVal listofSqlParams As List(Of sqlParams))
        Dim colName As String = "("
        Dim paramHolder As String = " VALUES ("

        Dim insertSQL As String = "INSERT INTO " & tableName

        For Each sqlObj As sqlParams In listofSqlParams
            colName = colName & sqlObj.column & ", "
            paramHolder = paramHolder & "?, "
            cmdOracle.Parameters.AddWithValue(sqlObj.column, sqlObj.value)
        Next

        colName = colName.Remove(colName.LastIndexOf(", ")) & ")"
        paramHolder = paramHolder.Remove(paramHolder.LastIndexOf(", ")) & ")"
        insertSQL = insertSQL & colName & paramHolder

        cmdOracle.CommandText = insertSQL
        cmdOracle.Connection = dbConnOracle

        dbConnOracle.Open()
        Try
            cmdOracle.ExecuteNonQuery()
        Catch ex As Exception
            MsgBox(ex.Message, vbCritical)
            dbConnOracle.Close()
        End Try
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
            MsgBox(ex.Message, vbCritical)
            dbConnOracle.Close()
        End Try
        Return strPartNum
    End Function

    Public Sub UpdateRecord(ByVal tableName As String, ByVal listofSqlParams As List(Of sqlParams), ByVal listOfwhereCriteria As List(Of notesWhereCriteria))
        Dim updateValue As String = ""
        Dim updateSql As String = "UPDATE " & tableName & " SET "
        Dim updateWhere As String = " WHERE "

        For Each sqlObj As sqlParams In listofSqlParams
            updateValue = updateValue & sqlObj.column & "=?, "
            cmdOracle.Parameters.AddWithValue(sqlObj.column, sqlObj.value)
        Next
        updateValue = updateValue.Remove(updateValue.LastIndexOf(", "))

        For Each searchObj As notesWhereCriteria In listOfwhereCriteria
            updateWhere = updateWhere & searchObj.searchKey & searchObj.searchOperator & searchObj.searchValue
        Next

        updateSql = updateSql & updateValue & updateWhere

        cmdOracle.CommandText = updateSql
        cmdOracle.Connection = dbConnOracle

        dbConnOracle.Open()
        Try
            cmdOracle.ExecuteNonQuery()
        Catch ex As Exception
            MsgBox(ex.Message, vbCritical)
            dbConnOracle.Close()
        End Try
    End Sub

    Public Sub DeleteRecord(ByVal id As Integer)

        Dim cmdtxt As String

        'update this with either passing it the update statement or can pass it table
        'ideally this would be replaced with stored procedure
        cmdtxt = "Delete From Parts Where ID = " & id & ""

        Try
            'The connection
            dbConnOracle.ConnectionString = gOracleDsnConnection
            dbConnOracle.Open()

            'The OLEDB Command
            With cmdOracle
                .Connection = dbConnOracle
                .CommandType = CommandType.Text
                .CommandText = cmdtxt
            End With

            cmdOracle.ExecuteNonQuery()

        Catch ex As Exception
            MsgBox(ex.Message, vbCritical)
        Finally
            dbConnOracle.Dispose()
            dbConnOracle.Close()
        End Try
    End Sub
End Class
