Imports Oracle.DataAccess

Public Class Form1
    Dim oradb As String = "Data Source=LyntronSAND;User Id=ODBCUSER;Password=coffee;"
    Dim conn As New Client.OracleConnection(oradb)

    Private Sub btnClickMe_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClickMe.Click
        Try
            conn.Open()
            Dim cmd As New Client.OracleCommand
            cmd.Connection = conn
            cmd.CommandText = "select * from GAUGES where 1 = 1"
            cmd.CommandType = CommandType.Text

            Dim dr As Client.OracleDataReader = cmd.ExecuteReader()

            If dr.Read() Then
                MessageBox.Show("Connection success. Read Success.")
            End If

            Dim ca As New clsCRUDAction

            ca.SQLAction = "UPDATE"
            ca.SQLCommand = "UPDATE TABEL SET Col = value"

        Catch ex As Exception
            MessageBox.Show(ex.Message.ToString())
        Finally
            conn.Close()
            conn.Dispose()
        End Try
    End Sub
End Class
