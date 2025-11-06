using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DesafioProjetoHospedagem.Models
{
public class MenuHospedaria
    {
        private List<Suite> SuitesDisponiveis { get; set; }
        private List<Reserva> ReservasAtivas { get; set; } = new List<Reserva>();

        public MenuHospedaria()
        {
            SuitesDisponiveis = new List<Suite>
            {
                new Suite(id: 1, tipoSuite: "Premium", capacidade: 4, valorDiaria: 100.00m),
                new Suite(id: 2, tipoSuite: "Luxo", capacidade: 3, valorDiaria: 80.00m),
                new Suite(id: 3, tipoSuite: "Padrão", capacidade: 2, valorDiaria: 50.00m)
            };
        }

        public void ExibirMenu()
        {
            bool exibir = true;
            while (exibir)
            {
                Console.Clear();
                Console.WriteLine("=================================");
                Console.WriteLine("===== SISTEMA DE HESPEDAGEM =====");
                Console.WriteLine("=================================");
                Console.WriteLine("1  -  CRIAR NOVA RESERVA");
                Console.WriteLine("2  -  LISTAR RESERVAS ATIVAS");
                Console.WriteLine("3  -  SAIR");
                Console.WriteLine("=================================");
                Console.Write("\nESCOLHA UMA OPÇÃO: ");

                switch (Console.ReadLine())
                {
                    case "1":
                        CriarNovaReserva();
                        break;
                    case "2":
                        ListarReservas();
                        break;
                    case "3":
                        exibir = false;
                        break;
                    default:
                        Console.WriteLine("Opção inválida. Tente novamente.");
                        break;
                }
                Console.WriteLine("\nPressione qualquer tecla para continuar...");
                Console.ReadKey();
            }
        }

        private void CriarNovaReserva()
        {
            Console.Clear();
            Console.WriteLine("=================================");
            Console.WriteLine("------ CADASTRO DE RESERVA ------");
            Console.WriteLine("=================================");

            Console.Write("Quantos dias de reserva? ");
            if (!int.TryParse(Console.ReadLine(), out int dias) || dias <= 0)
            {
                Console.WriteLine("Número de dias inválido.");
                return;
            }

            List<Pessoa> hospedes = ColetarHospedes();
            if (hospedes.Count == 0) return;

            Pessoa contato = hospedes.First();

            Suite suiteSelecionada = SelecionarSuite(hospedes.Count);
            if (suiteSelecionada == null) return;

            Reserva novaReserva = new Reserva(contato, dias);
            novaReserva.CadastrarSuite(suiteSelecionada);
            try
            {
                novaReserva.CadastrarHospedes(hospedes);
                
                ReservasAtivas.Add(novaReserva);
                decimal valorTotal = novaReserva.CalcularValorDiaria();

                Console.WriteLine("=================================");               
                Console.WriteLine("\n= RESERVA CRIADA COM SUCESSO! =");
                Console.WriteLine("=================================");
                Console.WriteLine($"Suíte: {suiteSelecionada.TipoSuite} (Capacidade: {suiteSelecionada.Capacidade})");
                Console.WriteLine($"Hóspedes: {novaReserva.ObterQuantidadeHospedes()}");
                Console.WriteLine($"Valor Total ({dias} dias, 10% desc. se >= 10): R$ {valorTotal:N2}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"ERRO ao cadastrar hóspedes: {ex.Message}");
            }
        }

        private List<Pessoa> ColetarHospedes()
        {
            List<Pessoa> lista = new List<Pessoa>();
            int i = 1;
            while (true)
            {
                Console.Write($"Digite o nome completo do Hóspede {i} (ou deixe vazio para encerrar): ");
                string nomeCompleto = Console.ReadLine().Trim();

                if (string.IsNullOrWhiteSpace(nomeCompleto)) break;

                string[] partesNome = nomeCompleto.Split(' ', 2);
                
                if (partesNome.Length == 0 || string.IsNullOrWhiteSpace(partesNome[0])) continue;

                string nome = partesNome[0];
                string sobrenome = partesNome.Length > 1 ? partesNome[1] : null;

                lista.Add(new Pessoa(nome, sobrenome));
                i++;
            }
            if (lista.Count == 0)
            {
                 Console.WriteLine("Nenhuma reserva criada. É preciso ter pelo menos um hóspede.");
            }
            return lista;
        }

        private Suite SelecionarSuite(int numHospedes)
        {
            Console.WriteLine("=================================");
            Console.WriteLine("\n----- SUÍTES DISPONÍVEIS ------");
            Console.WriteLine("=================================");
            var suitesAptas = SuitesDisponiveis.Where(s => s.Capacidade >= numHospedes).ToList();

            if (!suitesAptas.Any())
            {
                Console.WriteLine($"Nenhuma suíte comporta {numHospedes} hóspedes.");
                return null;
            }

            foreach (var suite in suitesAptas)
            {
                Console.WriteLine($"ID: {suite.Id} | {suite.TipoSuite} | Capacidade: {suite.Capacidade} | Diária: R$ {suite.ValorDiaria:N2}");
            }

            Console.Write("Digite o ID da suíte desejada: ");
            if (int.TryParse(Console.ReadLine(), out int idSuite))
            {
                return suitesAptas.FirstOrDefault(s => s.Id == idSuite);
            }
            
            Console.WriteLine("Seleção inválida.");
            return null;
        }
        
        private void ListarReservas()
        {
            Console.Clear();
            Console.WriteLine("=================================");
            Console.WriteLine("-------- Reservas Ativas --------");
            if (ReservasAtivas.Any())
            {
                foreach (var reserva in ReservasAtivas)
                {
                    Console.WriteLine("=================================");
                    Console.WriteLine($"Suíte: {reserva.Suite.TipoSuite}");
                    Console.WriteLine($"Hóspedes: {reserva.ObterQuantidadeHospedes()} ({reserva.Hospedes.First().NomeCompleto} + {reserva.ObterQuantidadeHospedes() - 1} pessoa(s))");
                    Console.WriteLine($"Dias: {reserva.DiasReservados}");
                    Console.WriteLine($"Total: R$ {reserva.CalcularValorDiaria():N2}");
                }
            }
            else
            {
                Console.WriteLine("Nenhuma reserva ativa no momento.");
            }
        }
    }
}