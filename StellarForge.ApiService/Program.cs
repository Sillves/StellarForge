using StellarForge.ApiService.Services;

var builder = WebApplication.CreateBuilder(args);

builder.AddServiceDefaults();
builder.Services.AddHealthChecks();

builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(); 
builder.Services.AddSingleton<SaveService>();


var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthorization();

app.MapControllers();

app.MapDefaultEndpoints();

app.UseExceptionHandler("/error");
app.Map("/error", (HttpContext httpContext) => Results.Problem());

app.Run();
