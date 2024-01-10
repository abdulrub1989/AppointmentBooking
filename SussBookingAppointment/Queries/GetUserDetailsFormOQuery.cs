using MediatR;
using SUSS.DOM.Entities;

public record GetUserDetailsFormOQuery(string Email) : IRequest<FormO>;
