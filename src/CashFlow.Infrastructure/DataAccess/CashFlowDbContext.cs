using CashFlow.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace CashFlow.Infrastructure.DataAccess;

internal class CashFlowDbContext : DbContext
{
    public DbSet<Expense> Expenses { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        const string connectionString = "Server=localhost;Database=cashflowdb;Uid=root;Pwd=@Root123;";
        
        var version = new Version(8,0,46);
        var serverVersion = new MySqlServerVersion(version);
        
        optionsBuilder.UseMySql(connectionString, serverVersion);
    }
}