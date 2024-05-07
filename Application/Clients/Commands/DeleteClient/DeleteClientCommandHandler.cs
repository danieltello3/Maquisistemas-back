using System;
using System.Threading;
using System.Threading.Tasks;
using Application.Abstractions.Messaging;
using Domain.Abstractions;
using Domain.Exceptions;
using Domain.Primitives;
using MediatR;

namespace Application.Clients.Commands.DeleteClient;

	public class DeleteClientCommandHandler : ICommandHandler<DeleteClientCommand,Unit>
	{
  private readonly IClientRepository _clientRepository;
  private readonly IUnitOfWork _unitOfWork;

  public DeleteClientCommandHandler(IClientRepository clientRepository, IUnitOfWork unitOfWork)
  {
    _clientRepository = clientRepository;
    _unitOfWork = unitOfWork;
  }

  public async Task<Unit> Handle(DeleteClientCommand request, CancellationToken cancellationToken)
  {
    var client = _clientRepository.Get(request.ClientId);

    if(client is null || client.Estado == StatusEnum.DESACTIVADO.Id)
    {
      throw new ClientBadRequestException("El Cliente no existe");
    }

    client.Eliminar();

    await _unitOfWork.SaveChangesAsync(cancellationToken);

    return Unit.Value;
  }
}

