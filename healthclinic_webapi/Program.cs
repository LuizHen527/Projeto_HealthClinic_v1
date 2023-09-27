using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

// Add services to the container.
builder.Services.AddRazorPages();

//Adiciona servi�o de Jwt Bearer (forma de autentica��o)
builder.Services.AddAuthentication(options =>
{
    options.DefaultChallengeScheme = "JwtBearer";
    options.DefaultAuthenticateScheme = "JwtBearer";
})

.AddJwtBearer("JwtBearer", options =>
{
    options.TokenValidationParameters = new TokenValidationParameters
    {
        //valida quem est� solicitando
        ValidateIssuer = true,

        //valida quem est� recebendo
        ValidateAudience = true,

        //define se o tempo de expira��o ser� validado
        ValidateLifetime = true,

        //forma de criptografia e valida a chave de autentica��o
        IssuerSigningKey = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes("HealthClinic-chave-autenticacao-webapi-dev")),

        //valida o tempo de expira��o do token
        ClockSkew = TimeSpan.FromMinutes(5),

        //nome do issuer (de onde est� vindo)
        ValidIssuer = "healthclinic_webapi",

        //nome do audience (para onde est� indo)
        ValidAudience = "healthclinic_webapi"
    };
});

//Configuracoes Swagger

builder.Services.AddSwaggerGen(options =>
{
    options.SwaggerDoc("v1", new OpenApiInfo
    {
        Version = "v1",
        Title = "healthclinic_webapi",
        Description = "API para gerenciamento de Clinicas. Sprint 2 - BackEnd API",
        TermsOfService = new Uri("https://example.com/terms"),
        Contact = new OpenApiContact
        {
            Name = "Senai Informatica - Turma Manha - Luiz Henrique",
            Url = new Uri("https://github.com/senai-desenvolvimento")
        },
    });

    // Configure o Swagger para usar o arquivo XML gerado
    var xmlFilename = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
    options.IncludeXmlComments(Path.Combine(AppContext.BaseDirectory, xmlFilename));

    options.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme()
    {
        Name = "Authorization",
        Type = SecuritySchemeType.ApiKey,
        Scheme = "Bearer",
        BearerFormat = "JWT",
        In = ParameterLocation.Header,
        Description = "Value: Bearer TokenJWT ",
    });

    options.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference
                {
                    Type = ReferenceType.SecurityScheme,
                    Id = "Bearer"
                }
            },
            new string[] {}
        }
    });
});

var app = builder.Build();

//Mais configuracoes do swagger

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseSwaggerUI(options =>
{
    options.SwaggerEndpoint("/swagger/v1/swagger.json", "v1");
    options.RoutePrefix = string.Empty;
});

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.MapControllers();

//Adiciona autentica��o
app.UseAuthentication();

//Adiciona autoriza��o
app.UseAuthorization();

app.MapRazorPages();

app.Run();
