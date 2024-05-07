using System;
using Domain.Exceptions.Base;
namespace Domain.Exceptions;


public sealed class ClientNotFoundException : NotFoundException
{
	public ClientNotFoundException(Guid clientId)
		: base($"El cliente con el id {clientId} no se encontró")
	{
	}
}

