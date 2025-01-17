using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Tema5PruebaNuevosComponentes;

namespace FormPruebaComponentes
{

    //Si el set está mal puede saltar stackOverFlow (Llamada recursiva)
    //, editar la clase con 
    //Para pruebas 
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void labelTextBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            /* Prueba para ver que se ha enlazado en componente txt al LabelTextBox
             */
            Debug.WriteLine("Key pressed");

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (labelTextBox1.Posicion == LabelTextBox.EPosicion.IZQUIERDA)
            {//Izquierda
                labelTextBox1.Posicion = LabelTextBox.EPosicion.DERECHA;

            }
            else
            {
                labelTextBox1.Posicion = LabelTextBox.EPosicion.IZQUIERDA;

            }

        }

        private void labelTextBox1_PosicionChanged(object sender, EventArgs e)
        {
            this.Text = labelTextBox1.Posicion.ToString();
        }



        private void button2_Click(object sender, EventArgs e)
        {
            labelTextBox1.Separacion += 5;

        }

        //Hay que enlazarlo con el evento desde la definicion de LabelTextBox en el momento en el que se modifica la separacion
        //en el set y se recolocan los elementos lanzo el evento
        private void labelTextBox1_SeparacionChanged_1(object sender, EventArgs e)
        {
            Debug.Write(labelTextBox1.Separacion);

        }

        private void labelTextBox1_KeyUp(object sender, KeyEventArgs e)
        {
            Debug.WriteLine("Levanto la tecla");
        }


        //En UserControl he tenido que invocar el evento, hacer la llamada
        private void labelTextBox1_TxtChange_1(object sender, EventArgs e)
        {
            Debug.WriteLine("Textchange");
        }

        //Método que dibuja en el canvas, región del cliente
        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            //Debug.Write("pinto");
            ////Lienzo donde puedo empezar a pintar
            ////La representación gráfica de un string, No es un objeto 
            //e.Graphics.DrawString("Prueba de escritura de texto",
            //this.Font, Brushes.BlueViolet, 10, 10); //la opacidad?
            //Mirar brocha 
            //Paint está en control
            //No se recomìla

        }
    }
}
