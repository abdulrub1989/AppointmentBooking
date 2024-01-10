using MediatR;
using SUSS.DOM.Entities;

public record CheckCunsultancyExistQyery(string emailID,int CounselindID):IRequest<BaseEntity>;