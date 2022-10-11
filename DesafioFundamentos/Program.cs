using DesafioFundamentos.Models;

// Coloca o encoding para UTF8 para exibir acentuação
Console.OutputEncoding = System.Text.Encoding.UTF8;

decimal precoInicial = 0;
decimal precoPorHora = 0;

Console.WriteLine("Seja bem vindo ao sistema de estacionamento!\n" +
                  "Digite o preço inicial:\n" +
                  "(Caso não digite nada o valor será R$5,00)");
// PRECO INICIAL
string precoInicialInput = Console.ReadLine();
if(String.IsNullOrEmpty(precoInicialInput)) precoInicialInput = "5";
precoInicial = Convert.ToDecimal(precoInicialInput);

Console.WriteLine("Agora digite o preço por hora:\n" +
                  "(Caso não digite nada o valor será R$1,00)");
// PRECO POR HORA
string precoPorHoraInput = Console.ReadLine();
if(String.IsNullOrEmpty(precoPorHoraInput)) precoInicialInput = "1";
precoPorHora = Convert.ToDecimal(precoInicialInput);

// Instancia a classe Estacionamento, já com os valores obtidos anteriormente
Estacionamento es = new Estacionamento(precoInicial, precoPorHora);

bool exibirMenu = true;

// Realiza o loop do menu
while (exibirMenu)
{
    Console.Clear();
    Console.WriteLine("Digite a sua opção:");
    Console.WriteLine("1 - Cadastrar veículo");
    Console.WriteLine("2 - Remover veículo");
    Console.WriteLine("3 - Listar veículos");
    Console.WriteLine("4 - Encerrar");

    string opcao = Console.ReadLine();
    if(!String.IsNullOrEmpty(opcao)){
        switch (opcao){
            case "1":
                es.AdicionarVeiculo();
                break;

            case "2":
                es.RemoverVeiculo();
                break;

            case "3":
                es.ListarVeiculos();
                break;

            case "4":
                exibirMenu = false;
                break;

            default:
                Console.WriteLine("Opção inválida");
                break;
        }
    }else{
        Console.WriteLine("Opção inválida");
    }
    

    Console.WriteLine("Pressione uma tecla para continuar");
    Console.ReadLine();
}

Console.WriteLine("O programa se encerrou");
