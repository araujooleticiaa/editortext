using System;
using System.IO;

namespace EditorText
{
    class Program
    {
        static void Main(string[] args)
        {
            Menu();
        }


        static void Menu()
        {
            Console.Clear();
            Console.WriteLine("O que você deseja fazer?");
            Console.WriteLine("1 - Criar arquivo");
            Console.WriteLine("2 - Abrir arquivo");
            Console.WriteLine("3 - Sair ");

            short options = short.Parse(Console.ReadLine());

            switch (options)
            {
                case 0: System.Environment.Exit(0); break;
                case 1: CriarArquivo(); break;
                case 2: AbrirArquivo(); break;
            }
        }

        static void CriarArquivo()
        {
            Console.Clear();
            Console.WriteLine("Digite o texto abaixo: (para sair pressione a tecla ESC)");
            Console.WriteLine("-------------------------");

            string text = "";

            do
            {
                text += Console.ReadLine();
                text += System.Environment.NewLine;
            }
            while (Console.ReadKey().Key != ConsoleKey.Escape);

            SalvarAquivo(text);
        }
        static void AbrirArquivo()
        {
            Console.Clear();
            Console.WriteLine("Qual arquivo voce deseja ler?");

            string path = Console.ReadLine();

            using (var file = new StreamReader(path))
            {
                string text = file.ReadToEnd();
                Console.WriteLine(text);
            }

            Console.WriteLine("");
            Console.ReadKey();
            Menu();

        }


        static void SalvarAquivo(string text)
        {
            Console.Clear();
            Console.WriteLine("Qual caminho você deseja salvar o arquivo?");

            var path = Console.ReadLine();


            using (var file = new StreamWriter(path))
            {
                file.Write(text);
            }

            Console.WriteLine($"Arquivo salvo com sucesso no diretorio: {path}!");
            Console.ReadLine();
            Menu();
        }

    }
}