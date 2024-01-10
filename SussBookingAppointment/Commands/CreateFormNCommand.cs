using MediatR;
using SUSS.DOM.Entities;

public record CreateFormOCommand(FormO formO_Model) : IRequest<int>;