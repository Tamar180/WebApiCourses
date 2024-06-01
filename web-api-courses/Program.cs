using Courses.Core.Mapping;
using Courses.Core.Repositories;
using Courses.Core.Servises;
using Courses.Data;
using Courses.Data.Repositories;
using Courses.Service;
using System.Text.Json.Serialization;
using web_api_courses.Mapping;
using web_api_courses.Middlewares;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers().AddJsonOptions(options =>
{
    options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles;
    options.JsonSerializerOptions.WriteIndented = true;
});
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<ICourseService,CourseService>();
builder.Services.AddScoped<ILectureService, LectureService>();
builder.Services.AddScoped<IPupilService, PupilService>();

builder.Services.AddScoped<ICourseRepository, CourseRepository>();
builder.Services.AddScoped<ILectureRepository, LectureRepository>();
builder.Services.AddScoped<IPupilRepository, PupilRepository>();

builder.Services.AddDbContext<DataContext>();
//builder.Services.AddSingleton<DataContext>();

builder.Services.AddAutoMapper(typeof(ApiMappingProfile), typeof(MappingProfile));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.UseShabbat();

app.MapControllers();

app.Run();
