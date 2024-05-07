using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Application.Clients.Commands.CreateClient;
using Application.Clients.Commands.DeleteClient;
using Application.Clients.Commands.UpdateClient;
using Application.Clients.Queries.GetClientById;
using Application.Clients.Queries.GetClients;
using Mapster;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Presentation.Controllers;

public sealed class ClientsController : ApiController
{
	[HttpGet("{clientId:guid}")]
  [ProducesResponseType(typeof(ClientResponse), StatusCodes.Status200OK)]
  [ProducesResponseType(StatusCodes.Status404NotFound)]
  public async Task<IActionResult> GetClient(Guid clientId, CancellationToken cancellationToken)
  {
    var query = new GetClientByIdQuery(clientId);

    var client = await Sender.Send(query, cancellationToken);

    return Ok(client);
  }

  [HttpGet]
  [ProducesResponseType(typeof(List<ClientsResponse>), StatusCodes.Status200OK)]
  [ProducesResponseType(StatusCodes.Status400BadRequest)]
  public async Task<IActionResult> GetClients(CancellationToken cancellationToken)
  {
    var query = new GetClientsQuery();

    var clients = await Sender.Send(query, cancellationToken);

    return Ok(clients);
  }

  [HttpPost]
  [ProducesResponseType(typeof(Guid), StatusCodes.Status201Created)]
  [ProducesResponseType(StatusCodes.Status400BadRequest)]
  public async Task<IActionResult> CreateClient([FromBody] CreateClientRequest request, CancellationToken cancellationToken)
  {
    var command = request.Adapt<CreateClientCommand>();

    var clientId = await Sender.Send(command, cancellationToken);

    return CreatedAtAction(nameof(GetClient), new { clientId }, clientId);
  }

  [HttpDelete("{clientId:guid}")]
  [ProducesResponseType(StatusCodes.Status200OK)]
  [ProducesResponseType(StatusCodes.Status400BadRequest)]
  public async Task<IActionResult> DeleteClient(Guid clientId,CancellationToken cancellationToken)
  {
    var command = new DeleteClientCommand(clientId);

    await Sender.Send(command, cancellationToken);

    return Ok();
  }

  [HttpPut]
  [ProducesResponseType(typeof(Guid), StatusCodes.Status200OK)]
  [ProducesResponseType(StatusCodes.Status400BadRequest)]
  public async Task<IActionResult> UpdateClient([FromBody] UpdateClientRequest request, CancellationToken cancellationToken)
  {
    var command = request.Adapt<UpdateClientCommand>();

    var clientId = await Sender.Send(command, cancellationToken);

    return Ok(clientId);
  }

}

