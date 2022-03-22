using Newtonsoft.Json.Serialization;
using TelegramPrivate;
using TelegramPrivateService;

var builder = WebApplication.CreateBuilder(args);
// Add services to the container.
builder.Services.AddControllers().AddNewtonsoftJson().AddJsonOptions(
    options =>
    {
        new Newtonsoft.Json.JsonSerializerSettings
        {
            ContractResolver = new DefaultContractResolver
            {
                NamingStrategy = new CamelCaseNamingStrategy
                {
                    OverrideSpecifiedNames = false
                }
            },
            NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore
        };
    });

builder.Services.AddSwaggerGenNewtonsoftSupport();
builder.Services.AddTransient<IConfigStorage, ConfigStorage>();
builder.Services.AddTransient<ISender, Sender>();

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
