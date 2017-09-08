using System;
using System.Collections.Generic;
using System.Drawing;
using System.Threading;
using System.Windows.Forms;

namespace MazeRunner
{
    class Correr
    {
        private Labirinto maze;
        private Stack<Stack<Bloco>> pilha;

        public Correr(Labirinto maze)
        {
            this.maze = maze;
        }
        public String resolver(int x, int y)
        {
            pilha = new Stack<Stack<Bloco>>();
            pilha.Push(new Stack<Bloco>());
            pilha.Peek().Push(maze.acessar(x, y));
            percorrer(x, y);
            return "Labirinto Resolvido com Sucesso";
        }
        private void atrasar()
        {
            int temporizador = 0;
            while (temporizador++ <= 1000000)
            {
                Application.DoEvents();
            }
        }
        private bool analisarSaida(int x, int y)
        {
            if (maze.acessar(x, y).cor == Color.Yellow)
            {
                maze.acessar(x, y).trocaCor(Color.Aqua);
                return false;
            }
            return true;
        }
        private void analisarLateral(int x, int y, List<Bloco> lista)
        {
            if (x > 0 && maze.acessar(x, y).cor == Color.Blue)
                lista.Add(maze.acessar(x, y));
        }
        private void esvasiarPilha(Stack<Bloco> pilha)
        {
            while (pilha.Count != 0)
            {
                Bloco aux2 = pilha.Pop();
                aux2.trocaCor(Color.Green);
                atrasar();
            }
        }
        private void distribuirCaminho(List<Bloco> lista)
        {
            for (int i = 0; i < lista.Count; i++)
            {
                Stack<Bloco> aux3 = new Stack<Bloco>();
                aux3.Push(lista[i]);
                pilha.Push(aux3);
            }
        }
        private void percorrer(int x, int y)
        {
            maze.acessar(x, y).trocaCor(Color.Gray);
            atrasar();
            if (analisarSaida(x - 1, y) && analisarSaida(x + 1, y) && analisarSaida(x, y - 1) && analisarSaida(x, y + 1))
            {
                List<Bloco> lista = new List<Bloco>();

                analisarLateral(x + 1, y, lista);
                analisarLateral(x - 1, y, lista);
                analisarLateral(x, y + 1, lista);
                analisarLateral(x, y - 1, lista);

                if (lista.Count == 1)
                {
                    pilha.Peek().Push(lista[0]);
                    percorrer(lista[0].x, lista[0].y);
                }
                else if (lista.Count == 0)
                {
                    esvasiarPilha(pilha.Pop());
                    percorrer(pilha.Peek().Peek().x, pilha.Peek().Peek().y);
                }
                else
                {
                    distribuirCaminho(lista);
                    percorrer(pilha.Peek().Peek().x, pilha.Peek().Peek().y);
                }
            }
        }
    }
}
