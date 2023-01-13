using System;

namespace Domain.Exceptions;

public class UsuarioPerfilNotifException: DomainModelException
{
    internal UsuarioPerfilNotifException() { }
    internal UsuarioPerfilNotifException(string message) 
        : base(message) { }
    internal UsuarioPerfilNotifException(string message, Exception inner) 
        : base(message, inner) { }
}
