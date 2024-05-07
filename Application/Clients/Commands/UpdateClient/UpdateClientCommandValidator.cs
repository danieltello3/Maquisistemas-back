using System;
using FluentValidation;

namespace Application.Clients.Commands.UpdateClient;

public sealed class UpdateClientCommandValidator : AbstractValidator<UpdateClientCommand>
{
	public UpdateClientCommandValidator()
	{
		RuleFor(x => x.Id).NotEmpty();
	}
}

