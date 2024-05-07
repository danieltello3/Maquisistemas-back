using System;
using System.Collections.Generic;
using Application.Abstractions.Messaging;

namespace Application.Combos.Queries.GetTipoDocumento;

public sealed record GetTipoDocumentoComboQuery() : IQuery<IReadOnlyCollection<TipoDocumentoComboResponse>>;

