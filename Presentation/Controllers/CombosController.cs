using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Application.Combos.Queries.GetTipoDocumento;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Presentation.Controllers;

public sealed class CombosController : ApiController
{
  [HttpGet("[action]")]
  [ProducesResponseType(typeof(List<TipoDocumentoComboResponse>), StatusCodes.Status200OK)]
  [ProducesResponseType(StatusCodes.Status400BadRequest)]
  public async Task<IActionResult> GetTipoDocumentos(CancellationToken cancellationToken)
  {
    var query = new GetTipoDocumentoComboQuery();

    var tipoDocs = await Sender.Send(query, cancellationToken);

    return Ok(tipoDocs);
  }
}

