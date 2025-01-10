using AUF.EMR2.Application.Features.Masterlists.Queries.Common;

namespace AUF.EMR2.Application.Features.Masterlists.Queries.GetAllMasterlistRecords;

public sealed record AllMasterlistRecordQueryResponse(
    string Barangay,
    string Midwife,
    string Address,
    List<MasterlistChildQueryResponse> Newborns,
    List<MasterlistChildQueryResponse> Infants,
    List<MasterlistChildQueryResponse> UnderFiveChildren,
    List<MasterlistChildQueryResponse> SchoolAgedChildren,
    List<MasterlistChildQueryResponse> Adolescents,
    List<MasterlistAdultQueryResponse> Adults,
    List<MasterlistAdultQueryResponse> Seniors
);