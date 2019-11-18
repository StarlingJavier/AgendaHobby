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
    public partial class Form3 : Form
    {
        //Variables

        //Tamaño arrays
        private static VConstantes tTamanoArray = new VConstantes();
        private Form2 infoUsuario = new Form2();//Capturar informacion de usuario desde el formulario 2

        //Manipular informacion de cliente
        private CrearCliente[] datosCliente = new CrearCliente[tTamanoArray.gettamanoArrayCliente()];
        private string[] infoFinalCliente = new string[tTamanoArray.gettamanoArrayinfoFinalCliente()];

        //Manipular informacion de contacto
        private CrearContacto[] datosContacto = new CrearContacto[tTamanoArray.gettamanoArraycontacto()];
        private string[] infoFinalContacto = new string[tTamanoArray.gettamanoArraycontacto()];

        //variable de entrada, asociar contacto
        private string cedulaAsociarContacto = "cedulaAsociarContacto";

        //Busqueda cliente
        private bool estadoBusquedaCliente;
        private int arrayBusquedaCliente;

        //Busqueda contacto
        private bool estadoBusquedaContacto;
        private int arrayBusquedaContacto;

        public Form3()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        //Btn mostrar/buscar cliente/contacto
        private void Button1_Click(object sender, EventArgs e)
        {

            //Variables
            
            //Variable de valores de entrada
            cedulaAsociarContacto = textBox6.Text;

            if (radioButton1.Checked == true)//Buscar Cliente
            {

                //Inicializar Array de la clase Cliente
                for (int i = 0; i < tTamanoArray.gettamanoArrayCliente(); i++)
                {
                    datosCliente[i] = new CrearCliente();
                }
                for (int i = 0; i < tTamanoArray.gettamanoArrayCliente(); i++)
                {
                    datosCliente[i] = ((infoUsuario.getCliente())[i]);
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

                            if (String.IsNullOrEmpty((datosCliente[i].getCedula())))
                            {//Validando que existe cliente

                                MessageBox.Show("Cliente no existe, Ingrese cliente");
                            }
                            else
                            {

                                if (Equals(datosCliente[i].getCedula(), cedulaAsociarContacto))
                                {
                                    estadoBusquedaCliente = true;
                                    arrayBusquedaCliente = i;

                                    break;
                                }
                                else
                                {
                                    estadoBusquedaCliente = false;
                                }


                            }

                        }
                    }
                    catch
                    {
                        MessageBox.Show("Incorrecto: no se ha podido recibir datos, si no logra completar el proceso comuniquese con el administrador de sistema");
                    }

                    if (estadoBusquedaCliente == false)
                    {

                        MessageBox.Show("No existe cliente, ingrese el cliente en el sistema");

                    }
                    else
                    {

                        //Mostrando datos de cliente
                        infoFinalCliente = datosCliente[arrayBusquedaCliente].getClientes();

                        label7.Text = infoFinalCliente[0];
                        label8.Text = infoFinalCliente[1];
                        label9.Text = infoFinalCliente[2];
                        label10.Text = infoFinalCliente[3];
                        label11.Text = infoFinalCliente[4];

                    }

                }

            }
            else if(radioButton2.Checked == true)//Buscar contacto
            {
                //Inicializar Array de la clase Cliente
                for (int i = 0; i < tTamanoArray.gettamanoArraycontacto(); i++)
                {
                    datosContacto[i] = new CrearContacto();
                }
                for (int i = 0; i < tTamanoArray.gettamanoArraycontacto(); i++)
                {
                    datosContacto[i] = ((infoUsuario.getContacto())[i]);
                }

                //Validando valor ingresado
                if (String.IsNullOrEmpty(cedulaAsociarContacto))
                {
                    MessageBox.Show("Debe ingresar cedula de contacto");
                }
                else
                {
                    //Buscando cliente
                    try
                    {
                        for (int i = 0; i < tTamanoArray.gettamanoArraycontacto(); i++)
                        {

                            if (String.IsNullOrEmpty((datosContacto[i].getCedula())))
                            {//Validando que existe cliente

                                MessageBox.Show("Contacto no existe, Ingrese contacto");
                            }
                            else
                            {

                                if (Equals(datosContacto[i].getCedula(), cedulaAsociarContacto))
                                {
                                    estadoBusquedaContacto = true;
                                    arrayBusquedaContacto = i;

                                    break;
                                }
                                else
                                {
                                    estadoBusquedaContacto = false;
                                }


                            }

                        }
                    }
                    catch
                    {
                        MessageBox.Show("Incorrecto: no se ha podido recibir datos, si no logra completar el proceso comuniquese con el administrador de sistema");
                    }

                    if (estadoBusquedaContacto == false)
                    {

                        MessageBox.Show("No existe contacto, ingrese el contacto en el sistema");

                    }
                    else
                    {

                        //Mostrando datos de cliente
                        infoFinalContacto = datosContacto[arrayBusquedaContacto].getContactos();

                        label7.Text = infoFinalContacto[0];
                        label8.Text = infoFinalContacto[1];
                        label9.Text = infoFinalContacto[2];
                        label10.Text = infoFinalContacto[3];
                        label11.Text = infoFinalContacto[4];

                    }

                }
            }
            else
            {
                MessageBox.Show("Por favor seleccione Cliente o Contacto para realizar la busqueda");
            }
        }

        //Volver al menu
        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();//Ocultando ventana
            vCampos();//Eliminando datos agregados
            Form1 menu = new Form1();//Regresando
            menu.Show();//Abriendo menu
        }

        //Vaciar Campos
        private void vCampos()
        {
            label7.Text = null;
            label8.Text = null;
            label9.Text = null;
            label10.Text = null;
            label11.Text = null;
            textBox6.Text = null;

        }
    }
}
