// See https://aka.ms/new-console-template for more information

using Microsoft.Data.Sqlite;

var filePath = AppDomain.CurrentDomain.BaseDirectory;
var connectionStr =  $"Data Source=demo.db";
var sqliteBuilder = new SqliteConnectionStringBuilder(connectionStr)
{
    Mode = SqliteOpenMode.ReadWriteCreate,
    // Password = "sqlite"
}.ToString();

string sql = "CREATE TABLE FirstTable(ID varchar(36),UserName varchar(30),PassWord varchar(30))";


using var connection = new SqliteConnection(sqliteBuilder);
connection.Open();
using var command = connection.CreateCommand();
command.CommandText = sql;
command.ExecuteNonQuery();
command.Cancel();