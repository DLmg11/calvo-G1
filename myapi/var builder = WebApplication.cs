var builder = WebApplication.CreateBuilder(args);

builder.WebHost.UserUrls("http://localhost:8000");

var app = builder.Buid();

Funcionario[]funcionarios = new Funcionario[100];

int contador = 0;

app.MapGet("/for",() =>{
    for(int i = 0; i<5; i++){
        Console.WriteLine(i);
    }
});

app.MapGet("/while",()=> new{
    mensagem = "Rota while em uso..."
});

app.MapGet("/objeto",()=>{
    Funcionario funcionario = new Funcionario();

    funcionario.Nome = "fulano";

    Console.WriteLine("Nome:" + funcionario.Nome);

    return Results.Ok(new{
        nome = funcionario.Nome
    });
});

app.MapGet("/vetor",()=>{
    int[ numeros = new int[100];

    numeros[0] = 15;
    numeros[1] = 53;
    numeros[2] = 34;

    Console.WriteLine("Valor;" + numeros[0]);
    Console.WriteLine("Valor;" + numeros[1]);
    Console.WriteLine("Valor;" + numeros[2]);

    return Results.Ok(new{
        numeros
    });
});

app.MapGet("/funcionario/cadastrar/{nome}",(string nome)=>[
    Funcionario funcionario = new funcionario();

    funcionario.Nome = nome;

    funcionarios[contador] = funcionario;

    contador++

    return Results.Ok(new{
        funcionario
    });
]);

app.MapGet("/funcionrio/listar/", () =>{
    Funcionario[] funcionariosCadastrados = new Funcionario[contador];
    for(int = 0; i<contador; i++){
        funcionariosCadastrados[i] = funcionarios[i];
    }
    return Results.Ok(new{
        funcionariosCadastrados
    });
});

app.Run();