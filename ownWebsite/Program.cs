using Business.Abstract;
using Business.Concrete;
using Business.Validation;
using DataAccess.Abstract;
using DataAccess.Concrete;
using FluentValidation;
using FluentValidation.AspNetCore;

var builder = WebApplication.CreateBuilder(args);


// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddControllersWithViews();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Dependency Injection için servisleri ekleyelim
builder.Services.AddScoped<IProjectService, ProjectManager>();
builder.Services.AddScoped<IProjectDal, EfProjectDal>();

builder.Services.AddValidatorsFromAssemblyContaining<ProjectValidator>();

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

// CORS politikasını ekleyin
app.UseCors(builder => builder
    .AllowAnyOrigin()
    .AllowAnyMethod()
    .AllowAnyHeader());

app.UseStaticFiles();
app.UseRouting();

// Varsayılan sayfa yönlendirmesi
app.MapGet("/", context =>
{
    context.Response.Redirect("/test.html");
    return Task.CompletedTask;
});

app.Run();
