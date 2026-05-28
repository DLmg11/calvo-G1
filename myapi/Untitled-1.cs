///
var biulder = WebApplication.CreateBiulder(args);
biuder.WebHost.UserUrls("http:localhost: 8000");
var app = biulder.Biuld();

int idade = 15;
float altura = 1.75;
string cidade = "Camaçari";
bool aprovado = false;
app.MapGet("/", ()=> {
    new {mensagem= "API em execução..."};
});
 app.MapGet("/calculadora{opçao}", (int opçao) => {
    switch(opçao){
        case 1:
            return new { mensagem= "Execuçao caso 1 ..."};
            case 2:
            return new { mensagem= "Execuçao caso 2 ..."};
            case 3:
            return new { mensagem= "Execuçao caso 3 ..."};
            case 4:
            return new { mensagem= "Execuçao caso 4 ..."};
            default:
            return new { mensagem= "Opçao inválida ..."};
    }
 })