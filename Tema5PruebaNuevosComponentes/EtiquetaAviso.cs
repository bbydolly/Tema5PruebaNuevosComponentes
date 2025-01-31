using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Tema5PruebaNuevosComponentes
{
    //Etiqueta Aviso

    //Define que vamos a dibujar (fuera de la clase)
    public enum EMarca
    {
        Nada,
        Cruz,
        Circulo,
        Imagen //ej2
    }

    public partial class EtiquetaAviso : Control
    {
        public EtiquetaAviso()
        {
            InitializeComponent();
        }

        protected override void OnTextChanged(EventArgs e)
        {
            base.OnTextChanged(e);
            this.Refresh();
        }


        //Defino una nueva propiedad para el componente CustomControl

        private EMarca marca = EMarca.Nada;
        //Va encima de la propiedad pública, que es la que se puede ver en propiedades
        [Category("Appearance")]
        [Description("Indica el tipo de marca que aparece junto al texto")]
        public EMarca Marca
        {

            set
            {
                marca = value;
                //Para actualizar la propiedad en la ventana
                this.Refresh();
            }
            get
            {
                return marca;
            }
        }



        //todo no puedo hacer el set 
        private Bitmap imagenMarca;

        [Category("Appearence")]
        [Description("Determina la imagen que se va a cargar")]
        public Bitmap ImagenMarca
        {
            set
            {
                imagenMarca = value;
            }
            get
            {
                return imagenMarca;
            }
        }



        //Ej 2 fondo opcional gradiente entre dos colores
        //Defino la propiedad 
        private bool gradiente;
        [Category("Appearence")]
        [Description("Establece un fondo de gradient entre dos colores")]
        public bool Gradiente
        {
            set
            {
                gradiente = value;
            }
            get
            {
                return gradiente;
            }
        }




        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            //Graphics es el lienzo sobre el que se pinta el componente
            Graphics g = e.Graphics;
            int grosor = 0; //Grosor de las líneas de dibujo
            int offsetX = 0; //Desplazamiento a la derecha del texto
            int offsetY = 0; //Desplazamiento hacia abajo del texto
                             // Altura de fuente, usada como referencia en varias partes
            int h = this.Font.Height;
            //Esta propiedad provoca mejoras en la apariencia o en la eficiencia
            // a la hora de dibujar
            g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;



            //El orden de pintado correcto es:
            //1.Fondo
            //2.Figura
            //3.Texto

            //Por ello compruebo primero el gradiente
            if (Gradiente)
            {   //PASOS PARA DIBUJAR
                //1.Primero pintar la forma (en este caso un rectángulo)
                //Coge todo el componente desde 0,0

                //Definición de la figura a dibujar, y desde donde empieza, coordenadas de origen 0,0
                //ancho y alto de la propia etiqueta
                Rectangle r = new Rectangle(0, 0, this.Width, this.Height);
                //2. Usar LinearGradientBrush para pintar el gradiente
                Brush brush = new LinearGradientBrush(r, Color.AliceBlue, Color.Red, 1);
                g.FillRectangle(brush, r);
            }




            //2.Pinto figura
            //Dependiendo del valor de la propiedad marca dibujamos una
            //Cruz o un Círculo
            switch (Marca)
            {
                case EMarca.Circulo:
                    grosor = 20;
                    g.DrawEllipse(new Pen(Color.Green, grosor), grosor, grosor,
                    h, h);
                    offsetX = h + grosor;
                    offsetY = grosor;
                    break;
                case EMarca.Cruz:
                    grosor = 3;
                    Pen lapiz = new Pen(Color.Red, grosor);
                    g.DrawLine(lapiz, grosor, grosor, h, h);
                    g.DrawLine(lapiz, h, grosor, grosor, h);
                    offsetX = h + grosor;
                    offsetY = grosor / 2;
                    //Es recomendable liberar recursos de dibujo pues se
                    //pueden realizar muchos y cogen memoria
                    lapiz.Dispose();
                    break;
                case EMarca.Imagen:

                    ImagenMarca(new Bitmap("C:\\Users\\Cris\\Desktop\\MuchasFotos\\f1.jpg"));
                    g.DrawImage(new Bitmap("C:\\Users\\Cris\\Desktop\\MuchasFotos\\f1.jpg"), 0, 0, h, h);
                    offsetX = h; //Cuanto se desplazan las letras en el eje x
                    break;

            }







            //3.Pinto texto
            //Finalmente pintamos el Texto; desplazado si fuera necesario
            SolidBrush b = new SolidBrush(this.ForeColor);

            g.DrawString(this.Text, this.Font, b, offsetX + grosor, offsetY);
            Size tam = g.MeasureString(this.Text, this.Font).ToSize();
            this.Size = new Size(tam.Width + offsetX + grosor, tam.Height + offsetY * 2);
            b.Dispose();
        }

    }
}
