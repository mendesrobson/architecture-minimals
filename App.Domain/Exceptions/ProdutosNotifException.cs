using Domain.Exceptions;

namespace App.Domain.Exceptions;

internal class ProdutosNotifException: DomainModelException
{
    internal ProdutosNotifException() { }
    internal ProdutosNotifException(string message)
        : base(message) { }
    internal ProdutosNotifException(string message, Exception inner)
        : base(message, inner) { }
}
