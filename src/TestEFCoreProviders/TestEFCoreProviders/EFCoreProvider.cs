namespace TestEFCoreProviders;

public enum EFCoreProvider
{
    None=0,
    Microsoft_EntityFrameworkCore_SqlServer = 1,
    Microsoft_EntityFrameworkCore_In_Memory,
    Microsoft_EntityFrameworkCore_Sqlite_In_Memory ,
    Microsoft_EntityFrameworkCore_Sqlite_File,
    Npgsql_EntityFrameworkCore_PostgreSQL,
    Pomelo_EntityFrameworkCore_MySql,
    MySql_EntityFrameworkCore,
    Microsoft_EntityFrameworkCore_Cosmos
}
