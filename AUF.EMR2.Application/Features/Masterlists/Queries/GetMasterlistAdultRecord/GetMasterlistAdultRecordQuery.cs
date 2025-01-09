using AUF.EMR2.Application.Features.Masterlists.Queries.Common;
using ErrorOr;
using MediatR;

namespace AUF.EMR2.Application.Features.Masterlists.Queries.GetMasterlistAdultRecord;

public sealed record GetMasterlistAdultRecordQuery(
    Guid Id
) : IRequest<ErrorOr<MasterlistAdultQueryResponse>>;