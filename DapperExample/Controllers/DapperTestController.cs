using Dapper;
using DapperExample.Models;
using Microsoft.AspNetCore.Mvc;
using Npgsql;

namespace DapperExample.Controllers;

[ApiController]
[Route("[controller]/[action]")]
public class DapperTestController : ControllerBase
{
    [HttpGet]
    public List<IDictionary<string, object>> GetDapperNoDto()
    {
        using var connection = getConnection();
        var sql = "SELECT * FROM \"DapperTestTable1\"";
        var result = connection.Query(sql).Cast<IDictionary<string,object>>().ToList();
        
        return result;
    }

    [HttpGet]
    public List<DapperTestTable2> GetDapperTestWithDto()
    {
        using var connection = getConnection();
        var sql = "SELECT * FROM \"DapperTestTable2\"";
        var result = connection.Query<DapperTestTable2>(sql).ToList();
        return result;
    }
    
    [HttpGet]
    public List<IDictionary<string, object>> GetDapperTestWithComplexQuery()
    {
        using var connection = getConnection();
        var sql = Scripts.ComplexQuery;
        var parameters = new { ID = 1 };
        var result = connection.Query(sql, parameters).Cast<IDictionary<string,object>>().ToList();
        return result;
    }
    
    private NpgsqlConnection getConnection()
    {
        var connectionStringBuilder = new NpgsqlConnectionStringBuilder();
        connectionStringBuilder.Host = "127.0.0.1";
        connectionStringBuilder.Username = "postgres";
        connectionStringBuilder.Password = "SuperWeakPassword123!";
        
        var connectionString = connectionStringBuilder.ConnectionString;
        
        var connection = new NpgsqlConnection(connectionString);
        connection.Open();
        return connection;
    }
}