Imports MySql.Data.MySqlClient
Imports System.IO

Public Module ConnectionModule
    Private ReadOnly StartupPathCert As String = Path.Combine(Application.StartupPath, "certificate.pem")

    Public ReadOnly Property ConnectionString As String
        Get
            Return $"server=pos-aws-cloud.cnk01mqwsyxf.ap-southeast-1.rds.amazonaws.com;user=localuser2;password=password.2023;database=posrev;sslmode=Required;sslca={StartupPathCert};CharSet=utf8mb4;Convert Zero Datetime=True"
        End Get
    End Property

    Public ReadOnly Property LocalConnectionString As String
        Get
            Return "server=localhost;user=root;password=00000000;database=dgposv2;charset=utf8mb4;"
        End Get
    End Property

    ' Helper functions to create connections
    Public Function GetConnection() As MySqlConnection
        Return New MySqlConnection(ConnectionString)
    End Function

    Public Function GetLocalConnection() As MySqlConnection
        Return New MySqlConnection(LocalConnectionString)
    End Function
End Module

