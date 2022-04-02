using KonusarakOgren.Business.Implementations;
using KonusarakOgren.Business.Interfaces;
using KonusarakOgren.DataAccess.EntityFramework;
using KonusarakOgren.DataAccess.EntityFramework.Repositories;
using KonusarakOgren.DataAccess.Interfaces;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddScoped<KonusarakOgrenContext>();

builder.Services.AddScoped<IUserRepository>(provider => new UserRepository(provider.GetService<KonusarakOgrenContext>()));
builder.Services.AddScoped<ITopicRepository>(provider => new TopicRepository(provider.GetService<KonusarakOgrenContext>()));
builder.Services.AddScoped<IExamRepository>(provider => new ExamRepository(provider.GetService<KonusarakOgrenContext>()));
builder.Services.AddScoped<IQuestionRepository>(provider => new QuestionRepository(provider.GetService<KonusarakOgrenContext>()));
builder.Services.AddScoped<IAnswerRepository>(provider => new AnswerRepository(provider.GetService<KonusarakOgrenContext>()));
builder.Services.AddScoped<IUserQuestionAnswerRepository>(provider => new UserQuestionAnswerRepository(provider.GetService<KonusarakOgrenContext>()));

builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

builder.Services.AddScoped<IUserEngine, UserEngine>();
builder.Services.AddScoped<ITopicEngine, TopicEngine>();
builder.Services.AddScoped<IExamEngine, ExamEngine>();
builder.Services.AddScoped<IQuestionEngine, QuestionEngine>();
builder.Services.AddScoped<IAnswerEngine, AnswerEngine>();
builder.Services.AddScoped<IUserQuestionAnswerEngine, UserQuestionAnswerEngine>();

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

app.UseCors(builder => builder.WithOrigins("http://localhost:4200").AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();