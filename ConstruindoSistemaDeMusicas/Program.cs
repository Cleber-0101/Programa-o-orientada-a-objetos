using System;
using System.Collections.Generic;
using System.Threading;

class Program
{
    string mensagem = "Seja bem-vindo ao seu app de músicas";
  //  List<string> listaDeBandas = new List<string> { "cpm" , "calypsu" , "djonga"};

    Dictionary<string , List<int>> bandasRegistradas = new Dictionary<string , List<int>>();


    public Program() { } // Construtor padrão

    void BoasVindas()
    {
        Console.WriteLine(mensagem);
    }

    public static void Main(string[] args)
    {
        Program programa = new Program(); 
        programa.BoasVindas();
        programa.ExibirMenu();
    }

    public void ExibirMenu()
    {
        Console.WriteLine("Digite 1 para registrar uma Banda");
        Console.WriteLine("Digite 2 para mostrar todas as Bandas");
        Console.WriteLine("Digite 3 para registrar uma Banda");
        Console.WriteLine("Digite 4 para exibir a média de uma Banda");
        Console.WriteLine("Digite -1 para sair");

        Console.Write("\nDigite uma opção: ");
        string escolhaUsuario = Console.ReadLine();
        int escolhaUsuarioNumero;

        if (int.TryParse(escolhaUsuario, out escolhaUsuarioNumero))
        {
            switch (escolhaUsuarioNumero)
            {
                case 1:
                    Console.WriteLine("Você escolheu a opção " + escolhaUsuario);
                    RegistrarBandas();
                    break;
                case 2:
                    MostrarBandasRegistradas();
                    break;
                case 3:
                    Console.WriteLine("Você escolheu a opção " + escolhaUsuario);
                    break;
                case 4:
                    Console.WriteLine("Você escolheu a opção " + escolhaUsuario);
                    break;
                case -1:
                    Console.WriteLine("Você escolheu a opção " + escolhaUsuario);
                    break;
                default:
                    Console.WriteLine("Opção inválida.");
                    break;
            }
        }
        else
        {
            Console.WriteLine("Opção inválida. Por favor, digite um número.");
        }
    }

    void RegistrarBandas()
    {
        Console.Clear();
        Console.WriteLine("Registro de Bandas");
        Console.Write("Digite o nome da Banda que deseja Registrar: ");
        string nomeDaBanda = Console.ReadLine();
        bandasRegistradas.Add(nomeDaBanda, new List<int>());
        Console.WriteLine($"A banda {nomeDaBanda} foi registrada com sucesso");
        Thread.Sleep(2000);
        Console.Clear();
        ExibirMenu();
    }

    void MostrarBandasRegistradas()
    {
        Console.Clear();
        Console.WriteLine("Exibindo todas as Bandas registradas");
        foreach (string banda in bandasRegistradas.Keys)
        {
            Console.WriteLine($"Banda: {banda}");
        }
        Console.WriteLine("Digite alguma coisa para voltar ao menu principal");
        Console.ReadKey();
        Console.Clear();
        ExibirMenu();
    }
}
