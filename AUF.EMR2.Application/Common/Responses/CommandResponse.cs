﻿namespace AUF.EMR2.Application.Common.Responses;

public class CommandResponse<T>
{
    public T Id { get; set; }
    public bool Success { get; set; }
    public string Message { get; set; }
}
