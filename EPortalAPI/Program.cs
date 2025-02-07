using EPortal.Services;
using EPortalAPI.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddSingleton<IPersonalProfileService, PersonalProfileService>();
builder.Services.AddSingleton<IContactInfoService, ContactInfoService>();
builder.Services.AddSingleton<ITeachingSkillService, TeachingSkillService>();
builder.Services.AddSingleton<IDevelopmentSkillService, DevelopmentSkillService>();
builder.Services.AddSingleton<IExperienceService, ExperienceService>();
builder.Services.AddSingleton<IEducationService, EducationService>();
builder.Services.AddControllers().AddJsonOptions(options =>
{
    options.JsonSerializerOptions.Converters.Add(new DateOnlyJsonConverter());
});


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
