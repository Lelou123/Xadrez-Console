using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using tabuleiro;
using Xadrez_Console.tabuleiro;
using Xadrez_Console.xadrez;

namespace xadrez
{
    class PartidaDeXadrez
    {

        public Cor JogadorAtual { get; private set; }
        public Tabuleiro Tab { get; private set; }
        public int Turno { get; private set; }
        public bool Terminada { get; private set; }
        public HashSet<Peca> Pecas { get; private set; }
        public HashSet<Peca> Capturadas { get; private set; }

        public PartidaDeXadrez()
        {
            Tab = new Tabuleiro(8, 8);
            Turno = 1;
            JogadorAtual = Cor.Branca;
            Pecas = new HashSet<Peca>();
            Capturadas = new HashSet<Peca>();
            ColocarPecas();
        }


        public void ExecutaMovimento(Posicao origem, Posicao destino)
        {
            Peca p = Tab.RetirarPeca(origem);
            p.IncrementarQntMovimentos();
            Peca pecaCapturada = Tab.RetirarPeca(destino);
            Tab.ColocarPeca(p, destino);
            if (pecaCapturada != null)
            {
                Capturadas.Add(pecaCapturada);
            }
        }

        public void RealizaJogada(Posicao origem, Posicao destino)
        {
            ExecutaMovimento(origem, destino);
            Turno++;
            MudaJogador();
        }

        public void ValidarOrigem(Posicao origem)
        {
            if (Tab.peca(origem) == null)
            {
                throw new TabuleiroException("Não existe peça na origem escolhida");
            }
            if (JogadorAtual != Tab.peca(origem).Cor)
            {
                throw new TabuleiroException("A peça de origem escolhida não é sua!");
            }
            if (!Tab.peca(origem).ExisteMovimentosPossiveis())
            {
                throw new TabuleiroException("Não há movimentos possiveis para a peça na origem escolhida");
            }
        }
        private void MudaJogador()
        {
            if (JogadorAtual == Cor.Branca)
            {
                JogadorAtual = Cor.Preta;
            }
            else
            {
                JogadorAtual = Cor.Branca;
            }
        }

        public HashSet<Peca> pecasCapturadas(Cor cor)
        {
            HashSet<Peca> aux = new HashSet<Peca>();
            foreach (Peca x in Capturadas)
            {
                if (x.Cor == cor)
                {
                    aux.Add(x);
                }
            }
            return aux;
        }

        public HashSet<Peca> pecasEmJogo(Cor cor)
        {
            HashSet<Peca> aux = new HashSet<Peca>();
            foreach (Peca x in Pecas)
            {
                if (x.Cor == cor)
                {
                    aux.Add(x);
                }
            }
            aux.ExceptWith(pecasCapturadas(cor));
            return aux;
        }

        public void ColocarNovaPeca(char coluna, int linha, Peca peca)
            {
                Tab.ColocarPeca(peca, new PosicaoXadrez(coluna, linha).ToPosicao());
                Pecas.Add(peca);
            }
            private void ColocarPecas()
            {
                ColocarNovaPeca('c', 1, new Torre(Tab, Cor.Branca));
                ColocarNovaPeca('c', 2, new Torre(Tab, Cor.Branca));
                ColocarNovaPeca('d', 2, new Torre(Tab, Cor.Branca));
                ColocarNovaPeca('e', 2, new Torre(Tab, Cor.Branca));
                ColocarNovaPeca('e', 1, new Torre(Tab, Cor.Branca));
                ColocarNovaPeca('d', 1, new Rei(Tab, Cor.Branca));

                ColocarNovaPeca('c', 7, new Torre(Tab, Cor.Preta));
                ColocarNovaPeca('c', 8, new Torre(Tab, Cor.Preta));
                ColocarNovaPeca('d', 7, new Torre(Tab, Cor.Preta));
                ColocarNovaPeca('e', 7, new Torre(Tab, Cor.Preta));
                ColocarNovaPeca('e', 8, new Torre(Tab, Cor.Preta));
                ColocarNovaPeca('d', 8, new Rei(Tab, Cor.Preta));


            }
        }
    }
