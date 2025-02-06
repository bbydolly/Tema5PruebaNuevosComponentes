﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;


//Para hacer pruebas, se crea un nuevo proyecto en la misma solución 
//Permitir acceso con set y get para acceder a los campos necesarios
//Quiero acceder al campo text del textBox, creo un set/get para el campo
//No se declara


/*
 * Para crear una libreria de funciones
 * creo una clase la empaqueto como dll
 * le añado la ruta 
 * le doy a cuadro de elementos en general >elegir elementos
 * añado la ruta de la dll, donde está
 * añado la referencia
*/



//VALIDADO ejercicio 1

namespace Tema5PruebaNuevosComponentes
{
    //.Net Framework para que al ejecutar añada las nuevas categorías y su descripción

    public partial class LabelTextBox : UserControl
    {
        //Defino el enumerado dependiendo de que uso le vaya a dar,
        //Es una clase 
        //Depende del diseño de clases
        //Como clase interna, en el mismo archivo, en otra clase

        public enum EPosicion
        {
            IZQUIERDA, DERECHA
        }
        public LabelTextBox()
        {
            InitializeComponent();
        }


        //El evento no me va a salir en las propiedades/eventos, sólo aparece cuando se instancia
        //Definición de un evento
        //Posteriormente se crea la función del evento con el prefijo On 
        [Category("La propiedad cambió")]
        [Description("Se lanza cuando la propiedad Posicion cambia")]

        public event System.EventHandler PosicionChanged;

        private EPosicion posicion = EPosicion.IZQUIERDA;


        //Añado una nueva Propiedad con su descripción y tras compilarla me aparece 
        //Aparecen por orden alfabético
        //Si la categoría ya existe hay que ponerla en Inglés, como la hayan definido
        //Si la creo yo cualquier nombre
        //Se pueden añadir ambos idiomas (TODO BUSCAR)
        [Category("Appearance")]
        [Description("Indica si la Label se sitúa a la IZQUIERDA o DERECHA del Textbox")]
        public EPosicion Posicion
        {
            set
            {
                //Comprueba si el enumerado existe en la definición 
                if (Enum.IsDefined(typeof(EPosicion), value))
                {
                    //Si la posición nueva es diferente a la posición
                    posicion = value;
                    recolocar();
                    OnPosicionChanged(EventArgs.Empty); //Información del sistema/evento ->Me da un objecto vacío
                    //o new EventArgs
                }
                else
                {
                    //Si no está definido lanzo excepción
                    throw new InvalidEnumArgumentException();
                }
            }
            get
            {
                return posicion;
            }
        }
        /* Función que se encarga de reconfigurar 
         * los elementos dentro del nuevo componente
         */
        private void recolocar()
        {
            switch (posicion)
            {
                case EPosicion.IZQUIERDA:
                    //Establecemos posición del componente lbl
                    lbl.Location = new Point(0, 0);
                    // Establecemos posición componente txt
                    txt.Location = new Point(lbl.Width + Separacion, 0);
                    //Establecemos ancho del Textbox
                    //(la label tiene ancho por autosize)
                    //  txt.Width = this.Width - lbl.Width - Separacion;
                    //Establecemos altura del componente
                    this.Width = txt.Width + lbl.Width + Separacion;
                    this.Height = Math.Max(txt.Height, lbl.Height);
                    break;
                case EPosicion.DERECHA:
                    //Establecemos posición del componente txt
                    txt.Location = new Point(0, 0);
                    //Establecemos ancho del Textbox
                    // txt.Width = this.Width - lbl.Width - Separacion;
                    //Establecemos posición del componente lbl
                    lbl.Location = new Point(txt.Width + Separacion, 0);
                    this.Width = txt.Width + lbl.Width + Separacion;

                    //Establecemos altura del componente (Puede sacarse del switch)
                    this.Height = Math.Max(txt.Height, lbl.Height);
                    break;
            }
        }

        // Esta función has de enlazarla con el evento SizeChanged.
        // Sería necesario también tener en cuenta otros eventos como FontChanged
        // que aquí nos saltamos.
        private void LabelTextBox_SizeChanged(object sender, EventArgs e)
        {
            recolocar();
        }


        /*
         * Propiedad que establece la separación entre las partes de mi nuevo componente
         * 
         */
        private int separacion = 0;
        [Category("Mis Propiedades")] // O se puede meter en categoría Design.
        [Description("Píxels de separación entre Label y Textbox")]
        public int Separacion
        {
            set
            {
                if (value >= 0)
                {
                    separacion = value;
                    recolocar();
                    OnSeparacionChange(EventArgs.Empty);
                }
                else
                {
                    throw new ArgumentOutOfRangeException();
                }
            }
            get
            {
                return separacion;
            }
        }

        /*
         * Son propiedades que ya están definidas internamente,
         * no hay que definir la propiedad privada
         * Cada vez que añada una propiedad hay que compilar la clase 
         * para que el nuevo componente tenga las propiedades
         */

        [Category("Mis Propiedades")] // O se puede meter en categoría Appearance.
        [Description("Texto asociado a la Label del control")]

        public string TextLbl
        {
            set
            {
                lbl.Text = value;
                recolocar();
            }
            get
            {
                return lbl.Text;
            }
        }
        [Category("Mis Propiedades")]
        [Description("Texto asociado al TextBox del control")]
        public string TextTxt
        {
            set
            {
                txt.Text = value;
            }
            get
            {
                return txt.Text;
            }
        }


        //Propiedad PswChr
        [Category("La propiedad cambió")]
        [Description("Contraseña asociada al PasswordChar del textbox")]

        public char PswChr
        {
            set
            {
                txt.PasswordChar = value;
            }
            get
            {
                return txt.PasswordChar;
            }
        }



        [Category("La propiedad cambió")]
        [Description("Se lanza cuando el campo text del txt interno cambia")]

        public event System.EventHandler TxtChange;

        private void txt_TextChanged(object sender, EventArgs e)
        {
            //Forma de invocar el evento
            TxtChange?.Invoke(this, EventArgs.Empty);
        }






        /* EVENTOS
         * Definir nuevos eventos y
         * enlazarlo con otros eventos ya definidos
         * 
         * Los eventos por ejemplo de teclado lo recoge uno de los componentes
         * del nuevo componente
        */

        protected override void OnSizeChanged(EventArgs e)
        {
            base.OnSizeChanged(e);
            recolocar();
        }

        private void txt_KeyPress(object sender, KeyPressEventArgs e)
        {
            //Nomenclatura para enlazar el nuevo componente con el evento interno
            //Se enlaza de dentro hacia fuera
            this.OnKeyPress(e);
        }

        //Dll, dinamyc link library

        /*
         * Eventos:
         *  No se puede asignar varias funciones, puedo AÑADIR funciones o ELIMINAR funciones
         *  NO se puede asignar
         *  
         *  Definición de un evento:
         *  
         *  event TipoDatoDevuelto NombreEvento;
         *  
         *  Solo se puede ejecutar el evento en la clase en la que está definida el EVENTO,
         *  PARA EJECUTARLA DESDE OTRA CLASE BUTTON.OnClick();
         *  
         *  Usaremos EventHandler 
         *  public delegate void EventHandler(Object? o, EventArgs a);
         *  para añadir += al delegado o -= para eliminar--->Al crear un evento se coloca en la lista de eventos del componente
         *
         *  El evento no puede ser null, hacer comprobacion dentro de la definicion del evento
         *  protected virtual void OnPositionChanged();
         *  apunta a una o más funciones
         *  
         *TODO Delegados buscar en los apendices(Curro said)
         
         */



        //Definición de un evento
        //[Category("La propiedad cambió")]
        //[Description("Se lanza cuando la propiedad Posicion cambia")]
        //public event System.EventHandler PosicionChanged;
        protected virtual void OnPosicionChanged(EventArgs e)
        {
            if (PosicionChanged != null)
            {
                PosicionChanged(this, e);

            }

        }

        /*
         * 
         * Ejercicio 1: prueba, y/o 3
         * 
         * Crear componentes a partir de agregación 
         * Enlazar componentes
         */

        //TODO
        [Category("La propiedad cambió")]
        [Description("Se lanza cuando la separación entre el TextBox y el Label del componente cambia")]//Solo hay un TextBox y una Label que forman parte del componente

        public event System.EventHandler SeparacionChanged;

        protected virtual void OnSeparacionChange(EventArgs e)
        {
            if (SeparacionChanged != null)
            {
                SeparacionChanged(this, e);

            }

        }

        private void txt_KeyUp(object sender, KeyEventArgs e)
        {
            //Le paso el evento a LabelTextBox

            //Nomenclatura para enlazar el nuevo componente con el evento interno
            //Se enlaza de dentro hacia fuera
            this.OnKeyUp(e);
        }



        //Ejercicio 2
        [Category("La propiedad cambió")]
        [Description("Se lanza cuando ")]

        private bool subrayada;

        public bool Subrayada
        {
            set
            {
                subrayada = value;
                //TODO no funciona bien???
                this.Refresh();
            }
            get
            {
                return subrayada;
            }
           
        }

        //TODO CURRO REVISAR

        //La clase userControl no pone por defecto el OnPaint pero se lo añado 
        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            Graphics g = e.Graphics;
            recolocar();
            if (Subrayada)
            {
                Pen lapiz;
                //Esta propiedad provoca mejoras en la apariencia o en la eficiencia
                // a la hora de dibujar
                g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
                if (Posicion == EPosicion.IZQUIERDA)
                {

                 lapiz = new Pen(Color.Red, 1);
                } else
                {
                    lapiz = new Pen(Color.Blue, 1);

                }
                //Cordenadas punto de origen y punto final 
                //  g.DrawLine(lapiz, lbl.Location.X, lbl.Location.Y    +    lbl.Height+5, lbl.Location.X + lbl.Height + 5, lbl.Width);
                g.DrawLine(lapiz, lbl.Location.X, lbl.Location.Y + lbl.Height + 5,
                    lbl.Location.X+lbl.Width, lbl.Location.Y + lbl.Height + 5); //Y es constante y x varía
                lapiz.Dispose();
                

            }
        }

       
    }
}
