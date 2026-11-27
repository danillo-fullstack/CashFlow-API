using AutoMapper;
using CashFlow.Domain.Repositories;
using CashFlow.Domain.Repositories.Expenses;
using CashFlow.Exception;
using CashFlow.Exception.ExceptionsBase;

namespace CashFlow.Application.UseCases.Expenses.Delete;

public class DeleteExpenseUseCase(IExpensesDeleteOnlyRepository repository, 
                                  IUnitOfWork unitOfWork) : IDeleteExpenseUseCase
{
    public async Task Execute(long id)
    {
        var result = await repository.Delete(id);
        
        if (!result)
        {
            throw new NotFoundException(ResourceErrorMessages.EXPENSE_NOT_FOUND);
        }
        
        await unitOfWork.Commit();
    }
}