using AutoMapper;
using CashFlow.Communication.Responses;
using CashFlow.Domain.Repositories.Expenses;

namespace CashFlow.Application.UseCases.Expenses.GetAll;

public class GetAllExpenseUseCase(IExpensesRepository repository, 
                                  IMapper mapper) : IGetAllExpenseUseCase
{
    public async Task<ResponseExpensesJson> Execute()
    {
        var result = await repository.GetAll();
        
        return new ResponseExpensesJson()
        {
            Expenses = mapper.Map<List<ResponseShortExpenseJson>>(result)
        };
    }
}