extern alias MySqlEFOracle;
extern alias OracleMySql;

extern alias PomeloEFMySql;
extern alias MySqlConnect;

global using Generated;
global using Microsoft.EntityFrameworkCore;
global using System.Data.SqlClient;
global using Testcontainers.MsSql;
global using Azure.Core;
global using Microsoft.Azure.Cosmos;
global using System.Drawing;
global using Testcontainers.CosmosDb;
global using Testcontainers.MySql;
global using DotNet.Testcontainers.Containers;
global using LightBDD.Core.Extensibility.Execution;
global using System.Runtime.CompilerServices;

global using MySqlCNBOracle = MySqlEFOracle.Microsoft.EntityFrameworkCore.MySQLDbContextOptionsExtensions;
global using MySqlOracle = OracleMySql.MySql.Data.MySqlClient;
global using MySqlEF = MySqlEFOracle::Microsoft.EntityFrameworkCore;
 
global using PomeloCN= MySqlConnect::MySqlConnector;
global using PomeloEF = PomeloEFMySql::Microsoft.EntityFrameworkCore;
global using PomeloMySqlCNB =PomeloEFMySql::Microsoft.EntityFrameworkCore.MySqlDbContextOptionsBuilderExtensions;