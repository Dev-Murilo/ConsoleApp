using System;
using System.Collections.Generic;

//TODO: Os comentários foram um guia para facilitar meu entendimento ;)

namespace ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {

            //*A lista é usada no lugar de um array, já que não ha necessidade de estabelecer um limite  

            List<Jogo> jogos = new List<Jogo>();
            Jogo J = new Jogo();
            J.Nome = "God of War";
            J.Descricao = "Kratos e Atreus";
            jogos.Add(J);

            string usuaOpcao = pegarUsuaEscolha();

            while (usuaOpcao.ToUpper() != "X")
            {
                switch (usuaOpcao)
                {
                    case "1":
                        foreach (var j in jogos)
                        {
                            Console.WriteLine($"Nome: {j.Nome}");
                        }
                        break;

                    case "2":
                        Console.Write("digite o nome do jogo: ");
                        string jogoEscolhido = Console.ReadLine();

                        //! O uso do If não funcionou, pois seria necessário fazer um tratamento do retorno
                        //*O método Find() foi mais fácil de tratado com try catch 

                        try
                        {
                            var x = jogos.Find(x => x.Nome.ToLower().Contains(jogoEscolhido.ToLower()));
                            System.Console.WriteLine(x.Descricao);

                        }
                        catch (System.Exception)
                        {
                            System.Console.WriteLine("Jogo indiponível");
                            usuaOpcao = pegarUsuaEscolha();

                        }
                        break;

                    case "3":

                        //? Analisar se uma nova instâcia do objeto é necessária 

                        Jogo J2 = new Jogo();
                        System.Console.Write("Digite o nome do jogo: ");
                        J2.Nome = Console.ReadLine();
                        System.Console.Write("digite a descrição do jogo: ");
                        J2.Descricao = Console.ReadLine();

                        if (!string.IsNullOrEmpty(J2.Nome) & !string.IsNullOrEmpty(J2.Descricao))
                        {

                            jogos.Add(J2);
                            Console.WriteLine($"{J2.Nome} inserido com sucesso");
                        }
                        else
                        {
                            throw new ArgumentOutOfRangeException("Os campos são obrigatorios");
                        }

                        break;
                    default:
                        throw new ArgumentOutOfRangeException();

                }
                usuaOpcao = pegarUsuaEscolha();

            }

        }

        private static string pegarUsuaEscolha()
        {

            Console.WriteLine();
            Console.WriteLine("#* Bem-vindo ao catálogo de jogos *#");
            Console.WriteLine(" 1 - jogos disponíveis");
            Console.WriteLine(" 2 - descrição do jogo");
            Console.WriteLine(" 3 - inserir um jogo");
            Console.WriteLine(" X - sair");
            Console.WriteLine();

            string usuaOpcao = Console.ReadLine();
            return usuaOpcao;


        }



    }
}
