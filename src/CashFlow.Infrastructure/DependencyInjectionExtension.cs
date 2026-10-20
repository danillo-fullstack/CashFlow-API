using CashFlow.Domain.Repositories.Expenses;
using CashFlow.Infrastructure.DataAccess;
using CashFlow.Infrastructure.DataAccess.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace CashFlow.Infrastructure;

public static class DependencyInjectionExtension
{
    public static void AddInfrastructure(this IServiceCollection services)
    {
        services.AddDbContext<CashFlowDbContext>(options =>
            options.UseSqlite("Data Source=cashflow.db"));

        services.AddScoped<IExpensesRepository, ExpensesRepository>();
    }
}