namespace CashFlow.Communication.Responses;

public class ResponseErrorJson
{
    public string ErrorMessage { get; }

    public ResponseErrorJson(string errorMessage)
    { 
        ErrorMessage = errorMessage;
    }
}