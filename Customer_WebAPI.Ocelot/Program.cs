using Ocelot.DependencyInjection;
using Ocelot.Middleware;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddCors(options =>
{
    options.AddPolicy("CORSPolicy", builder => builder.AllowAnyMethod().AllowAnyHeader()
        .AllowCredentials().SetIsOriginAllowed((hosts) => true));
}
);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddControllers();

builder.Configuration.AddJsonFile("ocelot.json", optional: false, reloadOnChange: true);
builder.Services.AddOcelot(builder.Configuration);

var app = builder.Build();

app.UseCors("CORSPolicy");
app.UseHttpsRedirection();
app.MapGet("/", () => "WellCome to Kiya Banking Online Platform");
await app.UseOcelot();

app.Run();
