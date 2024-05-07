using System;
using System.Threading;
using System.Threading.Tasks;
using Application.Abstractions.Messaging;
using Domain.Abstractions;
using Domain.Entities;

namespace Application.Clients.Commands.CreateClient;

internal sealed class CreateClientCommandHandler : ICommandHandler<CreateClientCommand,Guid>
{
	private readonly IClientRepository _clientRepository;
	private readonly IUnitOfWork _unitOfWork;

	public CreateClientCommandHandler(IClientRepository clientRepository, IUnitOfWork unitOfWork)
	{
		_clientRepository = clientRepository;
		_unitOfWork = unitOfWork;
	}

	public async Task<Guid> Handle(CreateClientCommand request, CancellationToken cancellationToken)
	{
		var client = new Client(Guid.NewGuid(), request.Nombres, request.Apellidos, request.FechaNacimiento, request.IdTipoDocumento, request.NroDocumento);

		_clientRepository.Insert(client);

		await _unitOfWork.SaveChangesAsync(cancellationToken);

		return client.Id;
	}
}

