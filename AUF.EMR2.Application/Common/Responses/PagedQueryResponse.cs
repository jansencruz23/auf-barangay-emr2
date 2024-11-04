namespace AUF.EMR2.Application.Common.Responses;

public class PagedQueryResponse<T>
    where T : class
{
    public List<T> Data { get; set; } = null!;
    public int TotalCount { get; set; }
}
