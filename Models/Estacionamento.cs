namespace DesafioFundamentos.Models
{
    public class Estacionamento
    {
        private decimal precoInicial = 0;
        private decimal precoPorHora = 0;
        private List<string> veiculos = new List<string>();

        public Estacionamento(decimal precoInicial, decimal precoPorHora)
        {
            this.precoInicial = precoInicial;
            this.precoPorHora = precoPorHora;
        }

        public void AdicionarVeiculo()
        {
            Console.WriteLine("Digite a placa do veículo para estacionar:");
            string placa = Console.ReadLine().ToUpper();

            // Validar a placa
            if (!ValidarPlaca(placa))
            {
                Console.WriteLine("Formato de placa inválido. A placa deve estar no formato XXX-0000. Tente novamente.");
                return;
            }

            if (!string.IsNullOrEmpty(placa))
            {
                veiculos.Add(placa);
                Console.WriteLine($"Veículo com placa {placa} adicionado ao estacionamento.");
            }
            else
            {
                Console.WriteLine("Placa inválida. Tente novamente.");
            }
        }

        public void RemoverVeiculo()
        {
           Console.WriteLine("Digite a placa do veículo para remover:");
            string placa = Console.ReadLine().ToUpper();

            if (veiculos.Contains(placa))
            {
                Console.WriteLine("Digite a quantidade de horas que o veículo permaneceu estacionado:");
                if (int.TryParse(Console.ReadLine(), out int horas))
                {                 
                    decimal valorTotal = precoInicial + (precoPorHora * horas);
                    veiculos.Remove(placa);
                    Console.WriteLine($"O veículo com placa {placa} foi removido e o preço total é de R$ {valorTotal:F2}");
                }
                else
                {
                    Console.WriteLine("Quantidade de horas inválida. Tente novamente.");
                }
            }
            else
            {
                Console.WriteLine("Veículo não encontrado no estacionamento.");
            }
        }

        public void ListarVeiculos()
        {
            // Verifica se há veículos no estacionamento
            if (veiculos.Any())
            {
                Console.WriteLine("Os veículos estacionados são:");
                foreach (var veiculo in veiculos)
                {
                    Console.WriteLine(veiculo);
                }
            }
            else
            {
                Console.WriteLine("Não há veículos estacionados.");
            }
        }


        // Função para validar a placa
        private bool ValidarPlaca(string placa)
        {
            // Verifica o comprimento da placa e se o caractere do meio é um traço
            if (placa.Length != 8 || placa[3] != '-')
            {
                return false;
            }

            // Verifica se todos os caracteres antes do traço são letras
            for (int i = 0; i < 3; i++)
            {
                if (!char.IsLetter(placa[i]))
                {
                    return false;
                }
            }

            // Verifica se todos os caracteres após o traço são números
            for (int i = 4; i < 8; i++)
            {
                if (!char.IsDigit(placa[i]))
                {
                    return false;
                }
            }

            return true;
        }
    }
}
