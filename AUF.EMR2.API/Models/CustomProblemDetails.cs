using Microsoft.AspNetCore.Mvc;

namespace AUF.EMR2.API.Models
{
    public class CustomProblemDetails : ProblemDetails
    {
        public List<string> Errors { get; set; } = new();
    }
}
