using AUF.EMR2.Application.Features.Barangays.Queries.Common.Responses;
using ErrorOr;
using MediatR;

namespace AUF.EMR2.Application.Features.Barangays.Queries.GetBarangay;

public record GetBarangayQuery : IRequest<ErrorOr<BarangayQueryResponse>>;