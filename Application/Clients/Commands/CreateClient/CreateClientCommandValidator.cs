using FluentValidation;

namespace Application.Clients.Commands.CreateClient;

public sealed class CreateClientCommandValidator : AbstractValidator<CreateClientCommand>
{
	public CreateClientCommandValidator()
	{
		RuleFor(x => x.Nombres).NotEmpty();
		RuleFor(x => x.Apellidos).NotEmpty();
		RuleFor(x => x.FechaNacimiento).NotEmpty();
		RuleFor(x => x.IdTipoDocumento).NotEmpty();
		RuleFor(x => x.NroDocumento).NotEmpty();
	}
}

