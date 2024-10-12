namespace AUF.EMR2.Contracts.Common.Response;

public sealed class ApiResponse<T>
{
    public T Id { get; set; } = default!;
    public bool Success { get; set; }
    public string Message { get; set; } = null!;
}
