using System;

namespace DIO.Series
{
    class Program
    {
        static SerieRepositorio repositorio = new SerieRepositorio();
        static void Main(string[] args)
        {
            string opcaoUsuario = "";

            do
            {
                opcaoUsuario = ObterOpcaoUsuario();

                switch(opcaoUsuario)
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
                        VisualizarSerie();
                        break;
                    case "c":
                    case "q":
                        Console.Clear();
                        break;

                    default:
                        throw new ArgumentOutOfRangeException();
                }
            }
            while(opcaoUsuario.ToLower() != "q");

            Console.WriteLine("Obrigado por utilizar nossos serviços.");
            Console.WriteLine();
        }

        private static void ExcluirSerie()
        {
            int indiceSerie = -1;

            Console.WriteLine("Excluir série");

            Console.Write("Digite o cod. da série: ");
            indiceSerie = int.Parse(Console.ReadLine());

            repositorio.Exclui(indiceSerie);
            
            Console.WriteLine();
        }

        private static void VisualizarSerie()
        {
            int indiceSerie = -1;

            Console.WriteLine("Visualizar série");

            Console.Write("Digite o cod. da série: ");
            indiceSerie = int.Parse(Console.ReadLine());

            var serie = repositorio.RetornaPorId(indiceSerie);

            Console.WriteLine(serie); // serie.ToString()

            Console.WriteLine();
        }

        private static void AtualizarSerie()
        {
            int indiceSerie = -1;
            int entradaGenero = -1;
            string entradaTitulo = "";
            int entradaAno = 0;
            string entradaDescricao = "";
            
            Console.WriteLine("Atualizar série");
            
            Console.Write("Digite o cod. da série: ");
            indiceSerie = int.Parse(Console.ReadLine());

            foreach(int i in Enum.GetValues(typeof(Genero)))
            {
                Console.WriteLine("{0} - {1}", i, Enum.GetName(typeof(Genero), i));
            }
            
            Console.Write("Digite o Gênero entre as opções acima: ");
            entradaGenero = int.Parse(Console.ReadLine());

            Console.Write("Digite o Título da série: ");
            entradaTitulo = Console.ReadLine();
            
            Console.Write("Digite o ano de lançamento da série: ");
            entradaAno = int.Parse(Console.ReadLine());

            Console.Write("Digite a descrição da série: ");
            entradaDescricao = Console.ReadLine();

            Console.WriteLine();

            Serie atualizarSerie = new Serie(id: indiceSerie, genero: (Genero) entradaGenero,
                titulo: entradaTitulo, ano: entradaAno, descricao: entradaDescricao);

            repositorio.Atualiza(indiceSerie, atualizarSerie);
        }

        private static void InserirSerie()
        {
            int entradaGenero = 0;
            string entradaTitulo = "";
            int entradaAno = 0;
            string entradaDescricao = "";
            
            Console.WriteLine("Inserir nova série");

            foreach(int i in Enum.GetValues(typeof(Genero)))
            {
                Console.WriteLine("{0} - {1}", i, Enum.GetName(typeof(Genero), i));
            }
            
            Console.Write("Digite o Gênero entre as opções acima: ");
            entradaGenero = int.Parse(Console.ReadLine());

            Console.Write("Digite o Título da série: ");
            entradaTitulo = Console.ReadLine();
            
            Console.Write("Digite o ano de lançamento da série: ");
            entradaAno = int.Parse(Console.ReadLine());

            Console.Write("Digite a descrição da série: ");
            entradaDescricao = Console.ReadLine();

            Console.WriteLine();

            Serie novaSerie = new Serie(id: repositorio.ProximoId(), genero: (Genero) entradaGenero,
                titulo: entradaTitulo, ano: entradaAno, descricao: entradaDescricao);

            repositorio.Insere(novaSerie);
        }

        private static void ListarSeries()
        {
            var lista = repositorio.Lista();

            Console.WriteLine("Listar séries");

            if(lista.Count == 0)
            {
                Console.WriteLine("Nenhuma série cadastrada.\n");
                return;
            }

            foreach(var serie in lista)
            {
                var excluido = serie.retornaExcluido();

                if(!excluido)
                    Console.WriteLine("Série c/ cod. {0}: {1}", serie.retornaId(), serie.retornaTitulo());
            }

            Console.WriteLine();
        }

        private static string ObterOpcaoUsuario()
        {
            Console.WriteLine("DIO Séries ao seu dispor!");
            Console.WriteLine("1- Listar séries");
            Console.WriteLine("2- Inserir nova série");
            Console.WriteLine("3- Atualizar série");
            Console.WriteLine("4- Excluir série");
            Console.WriteLine("5- Visualizar série");
            Console.WriteLine("C- Limpar tela");
            Console.WriteLine("Q- Sair");
            Console.Write("Informe a opção desejada: ");

            string opcaoUsuario = Console.ReadLine().ToLower();
            Console.WriteLine();
            
            return opcaoUsuario;
        }
    }
}
