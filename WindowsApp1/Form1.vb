Imports System.Data.OleDb

Public Class Form1
    ''' <summary>
    ''' Load a WorkSheet where first row is data,
    ''' cell data is strongly typed, not all
    ''' strings, some are type double, if we had
    ''' boolean and date cells they would be strongly typed
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim table As New DataTable

        Dim connection As New Connections
        Dim selectStatement = "SELECT * FROM [Sheet5$]"
        Dim fileName = "Shoppers.xlsx"

        Using cn As New OleDbConnection With
            {
                .ConnectionString = connection.NoHeaderConnectionString(fileName)
            }
            Using cmd As New OleDbCommand With
                {
                    .Connection = cn,
                    .CommandText = selectStatement
                }

                cn.Open()
                table.Load(cmd.ExecuteReader())
                table.Columns("F1").ColumnName = "Id"
                table.Columns("F2").ColumnName = "Product"
                table.Columns("F3").ColumnName = "Category id"
                table.Columns("F4").ColumnName = "Per stock"
                table.Columns("F5").ColumnName = "UnitPrice"

                DataGridView1.DataSource = table

            End Using
        End Using

    End Sub
End Class
