using System;
using FluentValidation;

namespace Application.Clients.Commands.DeleteClient;

public sealed class DeleteClientCommandValidator : AbstractValidator<DeleteClientCommand>
{
	public DeleteClientCommandValidator()
	{
		RuleFor(x => x.ClientId).NotEmpty();
	}
}

