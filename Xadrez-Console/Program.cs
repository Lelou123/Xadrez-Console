using System;
using tabuleiro;
using xadrez;
using Xadrez_Console.tabuleiro;
using Xadrez_Console.xadrez;

namespace Xadrez_Console
{
    internal class Program
    {
        static void Main(string[] args)
        {
            try
            {
                PartidaDeXadrez partida = new PartidaDeXadrez();
                Tela.ImprimirTabuleiro(partida.Tab);
                while(!partida.Terminada)
                {
                    Console.Clear();
                    Tela.ImprimirTabuleiro(partida.Tab);

                    Console.WriteLine();
                    Console.Write("Digite a posição de origem: ");
                    Posicao origem = Tela.LerPosicaoXaderz().ToPosicao();

                    bool[,] posicoesPossiveis = partida.Tab.peca(origem).MovimentosPossiveis();

                    Console.Clear();
                    Tela.ImprimirTabuleiro(partida.Tab, posicoesPossiveis);

                    Console.WriteLine();

                    Console.Write("Digite a posição de destino: ");
                    Posicao destino = Tela.LerPosicaoXaderz().ToPosicao();
                    partida.ExecutaMovimento(origem, destino);
                }

            }
            catch (TabuleiroException ex)
            {
                Console.WriteLine(ex.Message);
            }                                             
            Console.ReadLine();
        }
    }
}
