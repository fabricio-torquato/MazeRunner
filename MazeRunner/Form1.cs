using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MazeRunner
{
    public partial class Form1 : Form
    {
        private Labirinto maze;//variavel que guarda o labirinto
        private int tam;//tamanho do labirinto
        public Form1()
        {
            InitializeComponent();
        }
        private void ControlsMouseDown(object sender, MouseEventArgs e)
        {
            if (sender.GetType() == typeof(PictureBox))
            {
                PictureBox aux = (PictureBox)sender;
                for (int i = 0; i < tam; i++)
                {
                    for (int j = 0; j < tam; j++)
                    {
                        if (aux.Image.Equals(maze.acessar(i, j).btm) && maze.acessar(i, j).cor == Color.Blue)
                        {
                            Correr c = new Correr(maze);
                            if (MessageBox.Show(c.resolver(i, j), "Sair", MessageBoxButtons.OK, MessageBoxIcon.Information) == DialogResult.OK)
                                this.Close();
                        }
                    }
                }

            }
        }
        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }
        private void pB0_Click(object sender, EventArgs e)
        {

        }
        private void button1_Click(object sender, EventArgs e)
        {
            tamanho();
            maze = new Labirinto(tam, this);//instancia o labirinto       
            controlarLab(maze);
            maze.gerarLab();//cria os caminhos 
            button1.Enabled = false;//desabilita o botao para gerar novo labirinto
        }
        //garante que o valor escrito nao ultrapasse o valor permitido
        private void tamanho()
        {
            if (txb.Text == "")
                txb.Text = "8";
            tam = Convert.ToInt32(txb.Text);
            if (tam < 8)
                tam = 8;
            else if (tam > 29)
                tam = 29;
        }
        private void controlarLab(Labirinto maze)
        {
            for (int i = 0; i < tam; i++)
            {
                for (int j = 0; j < tam; j++)
                {
                    maze.acessar(i, j).pB.MouseClick += ControlsMouseDown;
                    Controls.Add(maze.acessar(i, j).pB);
                }
            }
        }
        private void pB4_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {

        }
        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
