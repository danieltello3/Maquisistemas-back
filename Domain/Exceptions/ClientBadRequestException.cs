using System;
using Domain.Exceptions.Base;

namespace Domain.Exceptions
{
	public sealed class ClientBadRequestException : BadRequestException
	{
		public ClientBadRequestException(string message) : base(message)
		{
		}
	}
}

