using Microsoft.EntityFrameworkCore;
using Noleggi.Core.Services;
using Radzen;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();
builder.Services.AddRadzenComponents();
string connection = builder.Configuration.GetConnectionString("NoleggioConnection") ?? "";
builder.Services.AddDbContext<AppDbContext>(options => options.UseSqlite(connection));

builder.Services.AddScoped<IClienteRepository, ClienteDbDataRepository>();
builder.Services.AddScoped<IRisorsaRepository, RisorsaDbDataRepository>();
builder.Services.AddScoped<INoleggioRepository, NoleggioDbDataRepository>();
builder.Services.AddScoped<IPeriodicitaRepository, PeriodicitaDbDataRepository>();
builder.Services.AddScoped<IPeriodicitaRisorsaRepository, PeriodicitaRisorsaDbDataRepository>();
var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    app.UseHsts();
}
app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();
app.MapBlazorHub();
app.MapFallbackToPage("/_Host");
app.Run();
