namespace AUF.EMR2.Contracts.Common.Responses;

public class ApiPagedResponse<T>
    where T : class
{
    public List<T> Data { get; set; } = null!;
    public int TotalCount { get; set; }
}
