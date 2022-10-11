namespace DesafioFundamentos.Models
{
    public class Estacionamento{
        private decimal precoInicial = 0;
        private decimal precoPorHora = 0;
        private List<string> veiculos = new List<string>();

        public Estacionamento(decimal precoInicial, decimal precoPorHora)
        {
            this.precoInicial = precoInicial;
            this.precoPorHora = precoPorHora;
        }
        (bool sucesso, string mensagem) ValidaPlacaVeiculo(string placa){
            // tira espacos da placa e deixa mauiscula
            string placaFormatada = placa.Trim().ToUpper();

            // verifica se esta vazia
            if(String.IsNullOrEmpty(placaFormatada)){
                return (false, "Parece que você não digitou uma placa. Tente novamente.");
            }

            // verifica se placa está sendo usada
            if(veiculos.Any(x => x == placaFormatada)){
                return (false, "Este carro já esta no estacionamento");
            }
            // verifica se placa esta no formato correto
            try{
                string[] placaSeparada = placaFormatada.Split("-");
                if(placaSeparada[0].Length != 3 || placaSeparada[1].Length != 4){
                    return (false, "A placa que você digitou é invalida.\nA placa deve ter o formato 'XXX-XXXX'");
                }
            }
            catch(Exception){
                return (false, "A placa que você digitou é invalida. \nA placa deve ter o formato 'XXX-XXXX'");
            }
            return (true, "Placa adicionada com sucesso");
        }
        public void AdicionarVeiculo()
        {
            Console.WriteLine("Digite a placa do veículo para estacionar:");
            string placa = Console.ReadLine();
            (bool sucesso, string mensagem) = ValidaPlacaVeiculo(placa);
            if(sucesso){
                veiculos.Add(placa.ToUpper());
            }
            Console.WriteLine(mensagem);
        }

        public void RemoverVeiculo(){
            Console.WriteLine("Digite a placa do veículo para remover:");

            string placa = Console.ReadLine();

            // Verifica se o veículo existe
            if (veiculos.Any(x => x == placa.ToUpper()))
            {
                Console.WriteLine("Digite a quantidade de horas que o veículo permaneceu estacionado:");
               
                int horas = Convert.ToInt32(Console.ReadLine());
                decimal valorTotal = precoInicial + precoPorHora * horas;

                veiculos.Remove(placa.ToUpper());
                Console.WriteLine($"O veículo {placa.ToUpper()} foi removido e o preço total foi de: {valorTotal:c}");
            }
            else
            {
                Console.WriteLine("Desculpe, esse veículo não está estacionado aqui. Confira se digitou a placa corretamente");
            }
        }

        public void ListarVeiculos(){
            // Verifica se há veículos no estacionamento
            if (veiculos.Any()){
                Console.WriteLine("Os veículos estacionados são:");
                for (int i = 0; i < veiculos.Count; i++){
                    Console.WriteLine($"{i + 1} - {veiculos[i]}");
                }
            }else{
                Console.WriteLine("Não há veículos estacionados.");
            }
        }
    }
}
