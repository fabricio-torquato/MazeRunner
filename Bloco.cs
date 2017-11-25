using System.Drawing;
using System.Windows.Forms;

namespace MazeRunner
{
    class Bloco
    {
        public Bitmap btm { get; set; }//cria a imagem de um bloco
        public PictureBox pB { get; set; }
        public Color cor { get; set; } //cor do bloco
        public int x { get; }//posicao x em relação a matriz
        public int y { get; }//posicao y em relação a matriz
        public Form1 p { get; }

        public Bloco(int x, int y, Form1 p)
        {
            this.x = x;
            this.y = y;
            this.p = p;
            pB = new PictureBox();//cria um PictureBox
            btm = new Bitmap(50, 50);//cria um quadrado de 50x50
            cor = new Color();
            trocaCor(Color.Black);//troca a cor do bloco para preto
        }
        public void trocaCor(Color c)//troca todas as cores dos pixel do quadrado para a cor escolhida
        {
            cor = c;
            for (int Xcount = 0; Xcount < btm.Width; Xcount++)
            {
                for (int Ycount = 0; Ycount < btm.Height; Ycount++)
                {
                    btm.SetPixel(Xcount, Ycount, c);
                }
            }
            pB.Image = btm;
        }
    }
}
