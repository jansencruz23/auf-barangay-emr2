using ErrorOr;
using MediatR;

namespace AUF.EMR2.Application.Features.Masterlists.Queries.GetAllMasterlistRecords;

public sealed record GetAllMasterlistRecordsQuery(
    Guid HouseholdId
) : IRequest<ErrorOr<AllMasterlistRecordQueryResponse>>;