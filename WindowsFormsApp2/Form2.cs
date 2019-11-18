using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp2
{
    public partial class Form2 : Form
    {
        //Variables

        //Variables de valores entrada
        private string nombre= "nombre";
        private string apellido = "apellido";
        private string telefono = "telefono";
        private string cedula = "cedula";
        private string dirrecion = "dirrecion";

        //variable de entrada, asociar contacto
        private string cedulaAsociarContacto ="cedulaAsociarContacto";
        private string cedulaContacto = "cedulaContacto";

        //Busqueda cliente para agregar contacto
        private bool estadoBusquedaCliente;
        private int arrayBusquedaCliente;

        //Buscando Contacto
        private bool estadoBusquedaContacto;

        //Variables, Array, contadores
        private static int valorInicial = 0;//Valor inicial para contador
        private int contador = valorInicial;//Contador cliente
        private int contador2= valorInicial, contador3= valorInicial;//Contador contacto
        private bool estadoContador;
        private static VConstantes tTamanoArray=new VConstantes();
        //private static int tamanoArrayCliente = 10;
        //private static int tamanoArraycontacto = 20;
        private static CrearCliente[] cliente = new CrearCliente[tTamanoArray.gettamanoArrayCliente()];
        private static CrearContacto[]contacto = new CrearContacto[tTamanoArray.gettamanoArraycontacto()];

        public Form2()
        {
            InitializeComponent();
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void groupBox3_Enter(object sender, EventArgs e)
        {

        }

        //Btn para volver a menu principal
        private void button2_Click(object sender, EventArgs e)
        {
            radioButton1.Checked = true;//Marcando ingresar cliente
            this.Hide();//Ocultando ventana
            vCampos();//Eliminando valores ingresados
            Form1 menu = new Form1();//Regresando
            menu.Show();//Abriendo menu

        }

        //Btn para ingresar nuevo cliente/contacto
        private void Button3_Click(object sender, EventArgs e)
        {

            //Validaciones de campos
            if ( comprobarCampos()==false )
            {
                MessageBox.Show("No deben existir campos vacios");
            }
            //Comenzando proceso de guardar cliente
            else
            {

                //Variables de valores entrada
                nombre = textBox1.Text;
                apellido = textBox2.Text;
                telefono = textBox3.Text;
                cedula = textBox4.Text;
                dirrecion = textBox5.Text;
                cedulaAsociarContacto = textBox6.Text;
              
                //Contador

                //Utilizando  label7 para guardar numero de contador
                if (contador==0)/*Solo se ejecutara la primera vez que inicie el programa, ya
                                           que mas abajo lo igualamos a false para que no se muestre el valor del label en el formulario,
                                           recordemos que label 7 y 8 solo son utilizados para obtener el valor actual del contador que nos
                                           ayudara a saber cuantos conactos/clientes llevamos ingresados*/
                {
                    label7.Visible = false;
                    label8.Visible = false;
                    label7.Text = Convert.ToString(valorInicial); //Igualando label7 a 0 en su primera ejecucion.
                    label8.Text = Convert.ToString(valorInicial); //Igualando label8 a 0 en su primera ejecucion.
                }
                contador = (Convert.ToInt32(label7.Text)); //Igualando contador a label7 para obtener el valor actual de clientes ingresados
                contador2 = (Convert.ToInt32(label8.Text)); //Igualando contador a label8 para obtener el valor actual de contactos ingresados

                //Verificando si existe cliente
                if((radioButton2.Checked==true && groupBox3.Visible==true) || radioButton1.Checked == true)
                {
                    buscarCliente(2);
                }

                //Agregar Cliente
                if ((contador < tTamanoArray.gettamanoArrayCliente()) && (radioButton2.Checked == false) && (estadoBusquedaCliente == false)) 
                {
                    //Inicializando los arrays cliente/contacto
                    cliente[contador] = new CrearCliente();

                    //Verificando tipo de usuario a ingresar
                    if (radioButton1.Checked == true) //Ingresar clientes
                    {
                        //Agregando cliente
                        cliente[contador].setClientes(nombre, apellido, telefono, cedula, dirrecion);//cliente;

                        //Mensaje
                        MessageBox.Show("Cliente Agregado");

                        //Cambiando estado a cliente
                        estadoContador = true;
                    }

                    //Aumentando Contador
                    if (estadoContador)
                    {
                        contador++;
                        label7.Text = Convert.ToString(contador);//Guardando estado de contador en label7 para recuperarlo luego
                    }

                }
                else if(radioButton2.Checked == false)

                {
                    if (estadoBusquedaCliente == true)
                    {
                        //Mensaje
                        MessageBox.Show("Ups, no puede ingresar la misma cedula a dos clientes");

                    }
                    else
                    {
                        //Mensaje
                        MessageBox.Show("Ups, se ha quedado sin espacio para ingresar mas clientes");

                    }

                }


                //Veriricando si existe contacto
                if ( (radioButton2.Checked == true && groupBox3.Visible == false) )
                {
                    buscarContacto();
                }

                //Agregar Contacto
                if ((contador3 < tTamanoArray.gettamanoArraycontacto()) && (radioButton1.Checked == false) && (estadoBusquedaContacto == false))
                {
                    //Inicializando los arrays cliente/contacto
                    contacto[contador3] = new CrearContacto();

                    if (radioButton2.Checked == true)//Ingresar contactos
                    {
                        if (cliente[arrayBusquedaCliente].setposicionContacto(Convert.ToString(contador3)))
                        {

                            //Agregando Contacto
                            contacto[contador3].setContactos(nombre, apellido, telefono, cedula, dirrecion);//contacto;

                            //Mensaje
                            MessageBox.Show("Contacto Agregado");

                        }
                        else 
                        {
                            MessageBox.Show("Ups, se ha quedado sin espacio para ingresar mas contactos al cliente");
                        }

                        //Cambiando estado a contacto
                        estadoContador = false;

                        //Ocultando campos
                        button3.Visible = false;
                        groupBox2.Visible = false;

                        groupBox3.Visible = true;

                    }

                    if(!estadoContador)
                    {
                        contador3++;
                        /*contador2++;

                        if (contador2 == (tTamanoArray.gettamanoArrayCliente() / tTamanoArray.gettamanoArraycontacto()))//Repartiendo por igual a cada cliente
                        {
                            contador2 = 0;
                        }

                        label8.Text = Convert.ToString(contador2);//Guardando estado de contador en label8 para recuperarlo luego*/
                    }
                }
                else if(radioButton1.Checked == false)

                {
                    if (estadoBusquedaContacto == true)
                    {
                        //Mensaje
                        MessageBox.Show("Ups, no puede ingresar la misma cedula a dos contactos");

                    }
                    else
                    {
                        //Mensaje
                        MessageBox.Show("Ups, no queda espacio para ingresar contactos");

                    }

                }
                //Vaciar campos
                vCampos();

            }

        }

        //Enviar Datos de Cliente
        public CrearCliente[] getCliente()
        {
            return cliente;
        }

        //Enviar Datos de Contacto
        public CrearContacto[] getContacto()
        {
            return contacto;
        }

        //Validacion de los datos ingresados
        private bool comprobarCampos()
        {
            if ( (String.IsNullOrEmpty(textBox1.Text)) || String.IsNullOrEmpty(textBox2.Text)
                || String.IsNullOrEmpty(textBox3.Text) || String.IsNullOrEmpty(textBox4.Text)
                || String.IsNullOrEmpty(textBox5.Text) || String.IsNullOrEmpty(textBox5.Text)
                ){

                return false;

            }else
            {

                return true;
            }

        }

        //Vaciar Campos
        private void vCampos()
        {
            textBox1.Text = null;
            textBox2.Text = null;
            textBox3.Text = null;
            textBox4.Text = null;
            textBox5.Text = null;
            textBox6.Text = null;

        }

        private void Form2_Load(object sender, EventArgs e)
        {

        }

        //Verficando opciones (Cliente, Contacto)

        private void RadioButton1_CheckedChanged(object sender, EventArgs e)
        {

            //Verificando tipo de usuario
            if (radioButton1.Checked == true)
            {
                groupBox3.Visible = false;
                groupBox2.Visible = true;
                button3.Visible = true;
                groupBox2.Text = "Crear Cliente";

            }

        }

        private void RadioButton2_CheckedChanged(object sender, EventArgs e)
        {
            //Verificando tipo de usuario
            if (radioButton2.Checked == true)
            {
                groupBox3.Visible = true;
                groupBox2.Text = "Crear Contacto";
                groupBox2.Visible = false;
                button3.Visible = false;

            }
        }
        private void Label7_Click(object sender, EventArgs e)
        {
  
        }

        //Btn para buscar cliente
        private void button1_Click(object sender, EventArgs e)
        {

            buscarCliente(1);

        }

        private void buscarCliente(int valor) {

            //Variables

            //Variable de valores de entrada
            if (valor==1) 
            {
                cedulaAsociarContacto = textBox6.Text;

            }
            else
            {

                cedulaAsociarContacto = textBox4.Text;

            }
            

            //Validando valor ingresado
            if (String.IsNullOrEmpty(cedulaAsociarContacto))
            {

                MessageBox.Show("Debe ingresar cedula de cliente");

            }
            else
            {
                //Buscando cliente
                try
                {

                    for (int i = 0; i < tTamanoArray.gettamanoArrayCliente(); i++)
                    {
                        if (Equals(cliente[i].getCedula(), cedulaAsociarContacto))
                        {
                            arrayBusquedaCliente = i;
                            estadoBusquedaCliente = true;

                            //Mostrar campos para ingresar contactos
                            groupBox3.Visible = false;
                            groupBox2.Visible = true;
                            button3.Visible = true;

                            if (valor == 1)
                            {

                                MessageBox.Show(string.Format("Cliente {0} ", cliente[i].getNombre()), " Puede ingresar datos", MessageBoxButtons.OK);

                            }

                            break;
                        }
                        else
                        {
                            estadoBusquedaCliente = false;
                        }

                    }

                }
                catch
                {
                    if (valor == 1)
                    {

                        MessageBox.Show("Incorrecto: no se ha encontrado cliente, debe crear cliente, Si no logra completar el proceso comuniquese con el administrador de sistema");

                    }

                }

                if (estadoBusquedaCliente == false)
                {

                    if (valor == 1)
                    {

                        MessageBox.Show("No existe cliente, ingrese el cliente en el sistema");

                    }

                }

            }

            //Borrando valor de texto
            if (valor == 1)
            {

                textBox6.Text = null;

            }
            

        }

        private void buscarContacto()
        {

            //Variables

            //Variable de valores de entrada
            cedulaContacto = textBox4.Text;


            //Validando valor ingresado
            if (String.IsNullOrEmpty(cedulaContacto))
            {

                MessageBox.Show("Debe ingresar cedula de cliente");

            }
            else
            {
                //Buscando contacto
                try
                {

                    for (int i = 0; i < tTamanoArray.gettamanoArraycontacto(); i++)
                    {
                        if (Equals(contacto[i].getCedula(), cedulaContacto))
                        {
                            estadoBusquedaContacto = true;

                            break;
                        }
                        else
                        {
                            estadoBusquedaContacto = false;
                        }

                    }

                }
                catch
                {

                    //MessageBox.Show("Incorrecto: error de sistema");


                }

            }

        }
    }
}

