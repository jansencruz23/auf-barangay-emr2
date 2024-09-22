using AUF.EMR2.API;
using AUF.EMR2.Application;
using AUF.EMR2.Persistence;

var builder = WebApplication.CreateBuilder(args);
{
    builder.Services
        .AddPresentationServices()
        .AddApplicationServices()
        .AddPersistenceServices(builder.Configuration);
}
    
var app = builder.Build();
{
    app.UseSwagger();
    app.UseSwaggerUI();

    app.UseHttpsRedirection();
    app.UseRouting();

    app.UseAuthentication();
    app.UseAuthorization();

    app.MapControllers();
    app.Run();
}