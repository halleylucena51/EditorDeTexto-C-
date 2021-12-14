using System;
using System.IO;

namespace EditordeTexto
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
            Console.WriteLine("O que vc deseja fazer ?");
            Console.WriteLine("1 - Abrir arquivo");
            Console.WriteLine("2 - Criar novo arquivo");
            Console.WriteLine("0 - Sair");
            short option = short.Parse(Console.ReadLine());

            switch (option)
            {
                case 0: System.Environment.Exit(0); break;
                case 1: Abrir(); break;
                case 2: Editar(); break;

            }
        }
        static void Abrir()
        {
            Console.Clear();
            Console.WriteLine("Qual o caminho do arquvo ?");
            string path = Console.ReadLine();

            using (var file = new StreamReader(path))
            {
                string text = file.ReadToEnd();
                Console.WriteLine(text);

            }
            Console.WriteLine("");
            Console.ReadLine();
            Menu();



        }

        static void Editar()
        {
            Console.Clear();
            Console.WriteLine("Digite seu texto abaixo (ESC para Sair)");
            Console.WriteLine("---------------");
            string text = "";

            do
            {
                text += Console.ReadLine();
                text += Environment.NewLine;


            }
            while (Console.ReadKey().Key != ConsoleKey.Escape);

            Console.Write(text);

            Salvar(text);
            // Menu();


        }

        static void Salvar(string text)
        {
            Console.Clear();
            Console.WriteLine("Qual o caminho para salvar o arquivo ?");
            var path = Console.ReadLine();

            using (var file = new StreamWriter(path))
            // abre e fecha arquivos e objetos
            {
                file.Write(text);

                Salvar(text);

            }

            Console.WriteLine($"Arquivo {path} salvo com sucesso !");
            Console.ReadLine();

            Menu();

        }

    }
}
