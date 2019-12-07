Imports System.Data.OleDb

Public Class Connections
    <DebuggerStepThrough()>
    Public Function HeaderConnectionString(
        fileName As String,
        Optional IMEX As Integer = 1) As String

        Dim builder As New OleDbConnectionStringBuilder
        If IO.Path.GetExtension(fileName).ToUpper = ".XLS" Then
            builder.Provider = "Microsoft.Jet.OLEDB.4.0"
            builder.Add("Extended Properties", $"Excel 8.0;IMEX={IMEX};HDR=Yes;")
        Else
            builder.Provider = "Microsoft.ACE.OLEDB.12.0"
            builder.Add("Extended Properties", $"Excel 12.0;IMEX={IMEX};HDR=Yes;")
        End If

        builder.DataSource = fileName

        Return builder.ToString

    End Function
    ''' <summary>
    ''' Create a connection where first row contains data
    ''' </summary>
    ''' <param name="fileName"></param>
    ''' <param name="IMEX"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    <DebuggerStepThrough()>
    Public Function NoHeaderConnectionString(
        fileName As String,
        Optional IMEX As Integer = 1) As String

        Dim builder As New OleDbConnectionStringBuilder
        If IO.Path.GetExtension(fileName).ToUpper = ".XLS" Then
            builder.Provider = "Microsoft.Jet.OLEDB.4.0"
            builder.Add("Extended Properties", $"Excel 8.0;IMEX={IMEX};HDR=No;")
        Else
            builder.Provider = "Microsoft.ACE.OLEDB.12.0"
            builder.Add("Extended Properties", $"Excel 12.0;IMEX={IMEX};HDR=No;")
        End If

        builder.DataSource = fileName

        Return builder.ToString

    End Function
End Class