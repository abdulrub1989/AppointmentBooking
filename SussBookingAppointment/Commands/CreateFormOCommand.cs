using MediatR;
using SUSS.DOM.Entities;

public record CreateFormNCommand(FormN formN_Model) : IRequest<int>;