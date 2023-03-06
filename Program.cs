using DocumentService.Features.PdfService.Services.Interfaces;
using DocumentService.Features.PdfService.Services;
using DocumentService.Features.StorageService.Services.Interfaces;
using DocumentService.Features.StorageService.Services;

var builder = WebApplication.CreateBuilder(args);

var startup = new Startup(builder.Configuration);
// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddSingleton<IPdfService, PdfService>();
builder.Services.AddSingleton<IDocumentServiceStorage, DocumentServiceStorage>();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
