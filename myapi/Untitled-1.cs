
var builder = WebApplication.CreateBuilder(args);

builder.WebHost.UseUrls("http://localhost:8000");


var app = builder.Build();

app.MapGet("/", () =>
{
    return Results.Ok("API EduCalc funcionando com sucesso!");
});

app.MapGet("/operacoes", () =>
{
    return Results.Ok(new
    {
        mensagem = "Operações disponíveis",
        operacoes = new string[] { "soma", "subtracao", "multiplicacao", "divisao" }
    });
});

app.MapGet("/calcular/{operacao}/{a}/{b}", (string operacao, double a, double b) =>
{
    operacao = operacao.ToLower();

    double resultado;

    switch (operacao)
    {
        case "soma":
            resultado = a + b;
            return Results.Ok(new
            {
                operacao = "soma",
                valor1 = a,
                valor2 = b,
                resultado = resultado
            });

        case "subtracao":
            resultado = a - b;
            return Results.Ok(new
            {
                operacao = "subtracao",
                valor1 = a,
                valor2 = b,
                resultado = resultado
            });

        case "multiplicacao":
            resultado = a * b;
            return Results.Ok(new
            {
                operacao = "multiplicacao",
                valor1 = a,
                valor2 = b,
                resultado = resultado
            });

        case "divisao":            
            if (b == 0)
            {
                return Results.BadRequest(new
                {
                    erro = "Não é possível realizar divisão por zero."
                });
            }

            resultado = a / b;
            return Results.Ok(new
            {
                operacao = "divisao",
                valor1 = a,
                valor2 = b,
                resultado = resultado
            });
        
        default:
            return Results.BadRequest(new
            {
                erro = "Operação inválida. Utilize: soma, subtracao, multiplicacao ou divisao."
            });
    }
});

app.Run();
