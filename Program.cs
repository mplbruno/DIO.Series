using System;

namespace DIO.Series
{
    class Program
    {
        static SerieRepositorio repositorio = new SerieRepositorio();
        static void Main(string[] args)
        {
            
            string opcaoUsusario = ObterOpcaoUsuario();
            while (opcaoUsusario.ToUpper() != "X")
            {
                switch (opcaoUsusario)
                {
                    case "1":
                    ListarSeries();
                    break;

                    case "2":
                    InserirSerie();
                    break;

                    case "3":
                    AtualizarSerie();
                    break;

                    case "4":
                    ExcluirSerie();
                    break;

                    case "5":
                    VizualizarSerie();
                    break;

                    case "C":
                    Console.Clear();
                    break;

                    default:
                        throw new ArgumentException();
                }

                opcaoUsusario = ObterOpcaoUsuario();
            }
            Console.WriteLine("Obrigado por utilizar nossos serviços.");
            Console.ReadLine();
        }

            private static void ExcluirSerie()
            {
                Console.Write("Digite o id da série:");
                int indiceSerie = int.Parse(Console.ReadLine());

                repositorio.Exclui(indiceSerie);
            }

            private static void VizualizarSerie()
            {
                Console.Write("Digite o id da série:");
                int indiceSerie = int.Parse(Console.ReadLine());

                var serie = repositorio.RetornaPorId(indiceSerie);

                Console.WriteLine(serie);
            }

            private static void ListarSeries()
            {
                Console.WriteLine("Listar séries");
                var lista = repositorio.Lista();
                if  (lista.Count == 0)
                {
                   Console.WriteLine("Nenhuma série cadastrada");
                   return; 
                } 
               foreach (var serie in lista) 
               {
                   var excluido = serie.retornaExcluido();
                   
                   Console.WriteLine("#ID {0}: - {1} - {2}", serie.retornaId(),serie.retornaTitulo(), (excluido ? "Excluido" : ""));
               }            
            }

            private static void AtualizarSerie()
            {
                Console.WriteLine("Digite o id da série");
                int indiceSerie = int.Parse(Console.ReadLine());
                foreach (int i in Enum.GetValues(typeof(Genero))) 
                {
                     Console.WriteLine("{0} - {1}", i,  Enum.GetName(typeof(Genero), i));
                }

                Console.WriteLine("Digite o gênero entre as opcoes acima:");
                int entradaGenero = int.Parse(Console.ReadLine());

                Console.WriteLine("Digite o Título da Série:");
                string entraTitulo = Console.ReadLine();

                Console.WriteLine("Digite o ano do início da Série:");
                int entradaAno = int.Parse(Console.ReadLine());

                Console.WriteLine("Digite a Descrição da Série:");
                string entradaDescricão = Console.ReadLine();

                Serie  atualizaSerie  = new Serie (id: indiceSerie,
                genero: (Genero)entradaGenero, titulo: entraTitulo, ano: entradaAno, descricao: entradaDescricão);

                repositorio.Atualiza(indiceSerie, atualizaSerie);
                
            }


            private static void InserirSerie()
            {
                Console.WriteLine("Inserir a nova série");
                foreach (int i in Enum.GetValues(typeof(Genero))) 
                {
                     Console.WriteLine("{0} - {1}", i,  Enum.GetName(typeof(Genero), i));
                }

                Console.WriteLine("Digite o gênero entre as opcoes acima:");
                int entradaGenero = int.Parse(Console.ReadLine());

                Console.WriteLine("Digite o Título da Série:");
                string entraTitulo = Console.ReadLine();

                Console.WriteLine("Digite o ano do início da Série:");
                int entradaAno = int.Parse(Console.ReadLine());

                Console.WriteLine("Digite a Descrição da Série:");
                string entradaDescricão = Console.ReadLine();

                Serie novaSerie  = new Serie (id: repositorio.ProximoId(),
                genero: (Genero)entradaGenero, titulo: entraTitulo, ano: entradaAno, descricao: entradaDescricão);

                repositorio.Insere(novaSerie);
                
            }

        private static string ObterOpcaoUsuario()
        {
            Console.WriteLine();
            Console.WriteLine("DIO Série a seu dispor!!!");
            Console.WriteLine("Informe a opcao desejada");

            Console.WriteLine("1 - Listar série");
            Console.WriteLine("2 - Inserir nova série");
            Console.WriteLine("3 - Atualizar série");
            Console.WriteLine("4 - Excluir série");
            Console.WriteLine("5 - Visualizar série");
            Console.WriteLine("C - Limpar Tela");
            Console.WriteLine("X - Sair");
            Console.WriteLine();

            string opcaoUsuario = Console.ReadLine().ToUpper();
            Console.WriteLine();
            return opcaoUsuario;
        }
            

       
    }
}
