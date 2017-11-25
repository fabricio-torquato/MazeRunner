using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace MazeRunner
{

    class Labirinto
    {

        private Bloco[,] matriz;//cria uma matriz de blocos
        public int tam { get; }//tamanho da matriz
        bool saida;//indica se a saida ja foi achada
        public Form1 p { get; }

        public Labirinto(int tam, Form1 p)
        {
            this.tam = tam;
            this.p = p;
            matriz = new Bloco[tam, tam];
            saida = false;

            for (int i = 0; i < tam; i++)//instancia todos quadrados da matriz
            {
                for (int j = 0; j < tam; j++)
                {
                    inicializarPb(i, j);
                }
            }
        }
        public Bloco acessar(int x, int y)//funcao que permite acessar atravez das posicoes qual o bloco da matriz esta relacionado
        {
            return matriz[y, x];
        }
        public void gerarLab()//funcao que cria os caminhos aleatorios do labirinto
        {
            andar(3, 5);//passa o ponto inicial
        }
        private void andar(int x, int y)
        {
            Stack<int> pilha = pilhaAleatoria();//cria uma pilha com numeros aleatorios de 1 a 4
            int aux;
            while (pilha.Count > 0)//percorre os 4 caminhos aleatorios
            {
                aux = pilha.Pop();
                if (analisa(x - 1, y) && analisa(x + 1, y) && analisa(x, y - 1) && analisa(x, y + 1))
                {
                    if (aux == 1 && x - 2 > 0)//se o caminho for 1 ele ira para esquerda
                    {
                        analisaCaminho(x - 1, y, x - 2, y);
                    }
                    else if (aux == 2 && x + 2 < tam)//se o caminho for 2 ira para direita
                    {
                        analisaCaminho(x + 1, y, x + 2, y);
                    }
                    else if (aux == 3 && y + 2 < tam)//se o caminho for 3 ele ira para cima
                    {
                        analisaCaminho(x, y + 1, x, y + 2);
                    }
                    else if (aux == 4 && y - 2 > 0)// se o caminho for 4 ira para baixo
                    {
                        analisaCaminho(x, y - 1, x, y - 2);
                    }
                }
            }
        }
        private void inicializarPb(int i, int j)
        {
            matriz[i, j] = new Bloco(j, i, p);
            matriz[i, j].pB.Name = "rect" + Convert.ToString(i) + Convert.ToString(j);//coloca um nome
            matriz[i, j].pB.Location = new Point(10 + 16 * i, 10 + 16 * j);//local que ele ficara na tela
            matriz[i, j].pB.Size = new Size(15, 15);//dimensões
            matriz[i, j].pB.Visible = true;
            if (i == 0 || j == 0 || i == tam - 1 || j == tam - 1)//as laterais troca a cor para vermelho
                matriz[i, j].trocaCor(Color.Red);
        }
        private bool analisa(int x, int y)
        {
            if (matriz[y, x].cor == Color.Red && saida == false)//se o caminho encotrar alguma lateral ele ira terminar o labirinto
            {
                matriz[y, x].trocaCor(Color.Yellow);
                saida = true;
                return false;
            }
            return true;
        }
        private void analisaCaminho(int x1, int y1, int x2, int y2)
        {
            if (matriz[y2, x2].cor == Color.Black)//se o caminho nao encotrar a cor azul faz o caminho
            {
                matriz[y2, x2].trocaCor(Color.Blue);
                matriz[y1, x1].trocaCor(Color.Blue);
                andar(x2, y2);
            }
        }
        private Stack<int> pilhaAleatoria()//metodo de caminhos aleatorios
        {
            Stack<int> aux = new Stack<int>();//pilha com caminhos aleatorios
            List<int> a = new List<int>();//lista com caminhos na sequencia
            Random r = new Random();
            int ran;

            a.AddRange(new[] { 1, 2, 3, 4 });//adiciona os possiveis caminhos

            for (int i = 4; i > 0; i--)
            {
                ran = r.Next(0, i);//cria numero aleatorio ate o tamanho da lista
                aux.Push(a[ran]);//adiciona o numero na pilha
                a.RemoveAt(ran);//remove o numero da lista
            }
            return aux;
        }
    }
}
