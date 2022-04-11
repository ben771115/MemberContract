using Member.Repository.Implements;
using Member.Repository.Infrastructure;
using Member.Repository.Interfaces;
using Member.Services.Implements;
using Member.Services.Interfaces;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddHttpContextAccessor()
                .AddTransient<IDatabaseHelper, DatabaseHelper>()
                .AddTransient <IMemberRepository, MemberRepository>()
                .AddTransient<IMemberService, MemberService>();
builder.Services.AddControllers();
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
