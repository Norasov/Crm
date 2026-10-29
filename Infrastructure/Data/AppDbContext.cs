using System.Data;
using Npgsql;

namespace Infrastructure.Data;

public class AppDbContext
{
    public string connectionString = "Host=localhost;Port=5432;Database=Crm;Username=postgres;Password=p000";
    public IDbConnection Connection() => new NpgsqlConnection(connectionString);
}
