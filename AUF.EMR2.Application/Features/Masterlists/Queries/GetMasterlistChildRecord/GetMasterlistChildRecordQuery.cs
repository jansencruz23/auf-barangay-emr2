using AUF.EMR2.Application.Features.Masterlists.Queries.Common;
using ErrorOr;
using MediatR;

namespace AUF.EMR2.Application.Features.Masterlists.Queries.GetMasterlistChildRecord;

public sealed record GetMasterlistChildRecordQuery(Guid Id) : IRequest<ErrorOr<MasterlistChildQueryResponse>>;