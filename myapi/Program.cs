var builder = WebApplication.CreateBuilder(args);

builder.WebHost.UseUrls("http://localhost:8000");

var app = builder.Build();


app.MapGet("/", () => "API funcionando com ASP.NET!");
app.MapGet("/saudacao", () => new {mensagem="Olá, mundo!" });


app.Run();
