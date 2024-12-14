using Microsoft.EntityFrameworkCore;
using VotingSystemBackend.Data; // Adjust based on your project structure
using VotingSystemBackend.Interfaces; // For IVoter, IVoting, IElection, ICandidate
using VotingSystemBackend.Services;   // For VoterService, VotingService, ElectionService, CandidateService

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

// Add DbContext with connection string
builder.Services.AddDbContext<VotingDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddScoped<IVoter, VoterService>();
builder.Services.AddScoped<IVoting, VotingService>();
builder.Services.AddScoped<IElection, ElectionService>();
builder.Services.AddScoped<ICandidate, CandidateService>();
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
