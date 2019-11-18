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
    public partial class Form4 : Form
    {

        //Variables

        //Tamaño arrays
        private static VConstantes tTamanoArray = new VConstantes();
        private Form2 infoCliente = new Form2();//Capturar informacion de usuario desde el formulario 2

        //Manipular informacion de cliente
        private CrearCliente[] datosCliente = new CrearCliente[tTamanoArray.gettamanoArrayCliente()];
        private string[] infoFinalCliente = new string[tTamanoArray.gettamanoArrayinfoFinalCliente()];

        //Manipular informacion de contacto
        private Form2 infoContacto = new Form2();
        private CrearContacto[] datosContacto = new CrearContacto[tTamanoArray.gettamanoArraycontacto()];
        private string[] infoFinalContacto = new string[tTamanoArray.gettamanoArrayinfoFinalContacto()];

        //variable de entrada, asociar contacto
        private string cedulaAsociarContacto = "cedulaAsociarContacto";

        //Busqueda cliente
        bool estadoBusquedaCliente;
        int arrayBusquedaCliente;

        public Form4()
        {
            InitializeComponent();
        }

        private void groupBox3_Enter(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        //Btn para buscar/mostrar Cliente y sus Contactos
        private void button1_Click(object sender, EventArgs e)
        {

            //Eliminando valores de los campos
            dataGridView1.Rows.Clear();

            //Variables

            //Variable de valores de entrada
            cedulaAsociarContacto = textBox6.Text;

            //Inicializar Array de la clase Cliente y clase form
            for (int i = 0; i < tTamanoArray.gettamanoArrayCliente(); i++)
            {
                datosCliente[i] = new CrearCliente();
            }
            for (int i = 0; i < tTamanoArray.gettamanoArrayCliente(); i++)
            {
                datosCliente[i] = (infoCliente.getCliente())[i];
            }
            for (int i = 0; i < tTamanoArray.gettamanoArraycontacto(); i++)
            {
                datosContacto[i] = new CrearContacto();
            }
            for (int i = 0; i < tTamanoArray.gettamanoArraycontacto(); i++)
            {
                datosContacto[i] = (infoContacto.getContacto())[i];
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

                            MessageBox.Show("Cliente no existe, Ingrese cliente al sistema");
                            vCampos();
                        }
                        else
                        {
                            //Busqueda de cliente
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

                    MessageBox.Show("No existe cliente, intente con otro o ingrese el cliente en el sistema");
                    vCampos();

                }
                else
                {
                    //Datos de cliente
                    infoFinalCliente = datosCliente[arrayBusquedaCliente].getClientes();

                    label7.Text = infoFinalCliente[0];
                    label8.Text = infoFinalCliente[1];

                    //Buscar contacto de cliente
                    for (int i=5; i< tTamanoArray.gettamanoArrayinfoFinalCliente(); i++) {

                        if (Equals(infoFinalCliente[i], "Espacio disponible para contacto"))
                        {
                            dataGridView1.Rows.Add("Espacio disponible para contacto", "Espacio disponible para contacto", "Espacio disponible para contacto", "Espacio disponible para contacto", "Espacio disponible para contacto");
                        }
                        else
                        {
                            try
                            {

                                infoFinalContacto = datosContacto[Convert.ToInt32(infoFinalCliente[i])].getContactos();

                                dataGridView1.Rows.Add(infoFinalContacto[0], infoFinalContacto[1], infoFinalContacto[2], infoFinalContacto[3], infoFinalContacto[4]);

                            }
                            catch
                            {
                                MessageBox.Show("No se han recibido datos, comuniquese con el administrador de sistemas");
                            }
                        }

                    }

                }

            }

        }

        //Volver al menu
        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();//Ocultando ventana
            vCampos();//Eliminando datos ingresados
            Form1 menu = new Form1();//Regresando
            menu.Show();//Abriendo menu
        }

        //Eliminar valores de campos
        private void vCampos()
        {
            label7.Text = null;
            label8.Text = null;
            textBox6.Text = null;

            dataGridView1.Rows.Clear();
        }
    }
}
