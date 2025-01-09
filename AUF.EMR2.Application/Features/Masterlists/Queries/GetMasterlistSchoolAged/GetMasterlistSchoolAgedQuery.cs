using AUF.EMR2.Application.Features.Masterlists.Queries.Common;
using ErrorOr;
using MediatR;

namespace AUF.EMR2.Application.Features.Masterlists.Queries.GetMasterlistSchoolAged;

public sealed record GetMasterlistSchoolAgedQuery(
    Guid HouseholdId
) : IRequest<ErrorOr<List<MasterlistChildQueryResponse>>>, IMasterlistQuery;