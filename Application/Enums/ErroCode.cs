namespace Application.Enums
{
    public enum ErroCode
    {
        NotFound = 404,
        ServerError = 500,

        //Os erros de validação devem estar no intervalo de 100 a 199
        ValidationError = 101,
        RequestValidationError = 102,

        //Os erros de infra devem estar no intervalo de 200 a 299
        CreationFailed = 202,
        DatabaseOperationException = 203,

        //Os erros do aplicativo devem estar no intervalo de 300 a 399
        UpdateNotPossible = 300,
        DeleteNotPossible = 301,
        RemovalNotAuthorized = 302,
        ResourceAlreadyExists = 303,
        ResourceDoesNotExist = 304,
        IncorrectPassword = 305,
        UnauthorizedAccountRemoval = 306,
        CommentRemovalNotAuthorized = 307,
        RequestAcceptNotPossible = 308,
        RequestRejectNotPossible = 309,


        UnknownError = 999
    }
}
