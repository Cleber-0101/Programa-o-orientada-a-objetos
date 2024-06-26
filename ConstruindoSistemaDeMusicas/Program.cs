﻿using System;
using System.Collections.Generic;
using System.Threading;

class Program
{
    string mensagem = "Seja bem-vindo ao seu app de músicas";
    Dictionary<string, List<int>> bandasRegistradas = new Dictionary<string, List<int>>();

    public Program() { }

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
        Console.WriteLine("Digite 3 para avaliar");
        Console.WriteLine("Digite 4 para exibir a média de uma Banda");
        Console.WriteLine("Digite -1 para sair");

        Console.Write("\nDigite uma opção: ");
        string escolhaUsuario = Console.ReadLine()!;
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
                    AvaliarBanda();
                    break;
                case 4:
                    ExibirMedia();
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
        string nomeDaBanda = Console.ReadLine()!;
        bandasRegistradas.Add(nomeDaBanda, new List<int>()!);
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

    void AvaliarBanda()
    {
        Console.Clear();
        Console.Write("Digite o nome da banda que deseja avaliar: ");
        string nomeDaBanda = Console.ReadLine()!;
        if (bandasRegistradas.ContainsKey(nomeDaBanda))
        {
            Console.Write($"Qual a nota que a banda {nomeDaBanda} merece: ");
            int nota = int.Parse(Console.ReadLine()!);
            bandasRegistradas[nomeDaBanda].Add(nota);
            Console.WriteLine($"A nota {nota} foi registrada com sucesso");
            Thread.Sleep(2000);
            Console.Clear();
            ExibirMenu();
        }
        else
        {
            Console.WriteLine($"A banda {nomeDaBanda} não foi encontrada");
            Console.WriteLine("Digite uma tecla para voltar às opções do menu");
            Console.ReadKey();
            Console.Clear();
            ExibirMenu();
        }
    }

    void ExibirMedia()
    {
        Console.Clear();
        Console.Write("Digite o nome da banda que deseja ver a média: ");
        string nomeDaBanda = Console.ReadLine()!;
        if (bandasRegistradas.ContainsKey(nomeDaBanda))
        {
            List<int> notas = bandasRegistradas[nomeDaBanda];
            if (notas.Count > 0)
            {
                double media = CalcularMedia(notas);
                Console.WriteLine($"A média das notas da banda {nomeDaBanda} é {media:F2}");
            }
            else
            {
                Console.WriteLine($"A banda {nomeDaBanda} ainda não tem notas registradas.");
            }
        }
        else
        {
            Console.WriteLine("Banda não encontrada");
        }
        Console.WriteLine("Digite uma tecla para voltar ao menu principal");
        Console.ReadKey();
        Console.Clear();
        ExibirMenu();
    }

    double CalcularMedia(List<int> notas)
    {
        int soma = 0;
        foreach (int nota in notas)
        {
            soma += nota;
        }
        return (double)soma / notas.Count;
    }
}
