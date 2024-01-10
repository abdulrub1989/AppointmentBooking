using MediatR;
using SUSS.DOM.Entities;

public record ApproveCommand(Approver approver) : IRequest<int>;