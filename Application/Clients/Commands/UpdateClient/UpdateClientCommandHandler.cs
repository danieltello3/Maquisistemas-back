using System;
using System.Threading;
using System.Threading.Tasks;
using Application.Abstractions.Messaging;
using Domain.Abstractions;

namespace Application.Clients.Commands.UpdateClient;

internal sealed class UpdateClientCommandHandler : ICommandHandler<UpdateClientCommand,Guid>
{
  private readonly IClientRepository _clientRepository;
  private readonly IUnitOfWork _unitOfWork;

  public UpdateClientCommandHandler(IClientRepository clientRepository, IUnitOfWork unitOfWork)
  {
    _clientRepository = clientRepository;
    _unitOfWork = unitOfWork;
  }

  public async Task<Guid> Handle(UpdateClientCommand request, CancellationToken cancellationToken)
  {
    var client = _clientRepository.Get(request.Id);

    client.Modificar(request.Nombres, request.Apellidos, request.FechaNacimiento);
    _clientRepository.Update(client);
    await _unitOfWork.SaveChangesAsync(cancellationToken);

    return request.Id;
  }
}

