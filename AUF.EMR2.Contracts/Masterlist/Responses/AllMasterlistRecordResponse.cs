namespace AUF.EMR2.Contracts.Masterlist.Responses;

public sealed record AllMasterlistRecordResponse(
    string Barangay,
    string Midwife,
    string Address,
    List<MasterlistChildResponse> Newborns,
    List<MasterlistChildResponse> Infants,
    List<MasterlistChildResponse> UnderFiveChildren,
    List<MasterlistChildResponse> SchoolAgedChildren,
    List<MasterlistChildResponse> Adolescents,
    List<MasterlistAdultResponse> Adults,
    List<MasterlistAdultResponse> Seniors
);