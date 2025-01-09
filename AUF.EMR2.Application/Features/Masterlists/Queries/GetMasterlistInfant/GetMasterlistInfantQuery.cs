using AUF.EMR2.Application.Features.Masterlists.Queries.Common;
using ErrorOr;
using MediatR;

namespace AUF.EMR2.Application.Features.Masterlists.Queries.GetMasterlistInfant;

public sealed record GetMasterlistInfantQuery(
    Guid HouseholdId    
): IRequest<ErrorOr<List<MasterlistChildQueryResponse>>>;