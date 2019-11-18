using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp2
{
    static public class Program
    {
        static public Form1 menu = new Form1();
        static public Form2 crear = new Form2();
        static public Form3 mostrar1 = new Form3();
        static public Form4 mostrar2 = new Form4();

        static void Main()
        {
            Application.EnableVisualStyles();
            //Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
        }
    }
}


//Clase cliente
public class CrearCliente
{

    //Variables
    private string nombre;//1
    private string apellido;//2
    private string telefono;//3
    private string cedula;//4
    private string dirrecion;//5
    private string[] contactos = new string[2];//7 //Array que contiene la posicion en el array de los contactos del cliente, como son 20 contactos a 10 clientes, cada cliente tendra 2 contactos
    private string[] datosClientes = new string[7]; //Array que se utiliza para devolver los datos de cliente                         
    bool estado;//Valor que se envia para verificar si la consulta fue exitosa

    //Inicializando Variables
    public CrearCliente()
    {
        this.nombre = "nombre";
        this.apellido = "apellido";
        this.telefono = "telefono";
        this.cedula = "cedula";
        this.dirrecion = "dirrecion";

        //Inicizando array contactos
        for(int i=0; i<2; i++)
        {
            this.contactos[i] = "Espacio disponible para contacto";
        }

        this.estado = false;

    }

    //Ingresando datos de cliente
    public void setClientes(string nombreC, string apellidoC, string telefonoC, string cedulaC, string dirrecionC)
    {
        this.nombre = nombreC;
        this.apellido = apellidoC;
        this.telefono = telefonoC;
        this.cedula = cedulaC;
        this.dirrecion = dirrecionC;
    }

    //Ingresando posicion de contacto en el array
    public bool setposicionContacto(string posicion)
    {
        //Ingresando posicion de contacto
        for (int i = 0; i < 2; i++)
        {
            if (Equals(this.contactos[i], "Espacio disponible para contacto")==true) { //Comprobando que el array esta vacio para ingresar posicion

                this.contactos[i] = posicion;

                estado=true;

                break;

            }
            else
            {
                estado=false;
            }
            
        }

        return estado;

    }

    //Obteniendo Datos de clientes ya ingresados
    public string[] getClientes()
    {
        this.datosClientes[0] = this.nombre;
        this.datosClientes[1] = this.apellido;
        this.datosClientes[2] = this.telefono;
        this.datosClientes[3] = this.cedula;
        this.datosClientes[4] = this.dirrecion;
        this.datosClientes[5] = this.contactos[0];
        this.datosClientes[6] = this.contactos[1];

        return datosClientes;
    }

    public string getCedula()
    {
        return this.cedula;
    }

    public string getNombre()
    {
        return this.nombre;
    }

}

//Clase contacto
public class CrearContacto
{

    //Variables
    private string nombre;//1
    private string apellido;//2
    private string telefono;//3
    private string cedula;//4
    private string dirrecion;//5
    private string[] datosContacto = new string[5]; //Array que se utiliza para devolver los datos de contacto

    //Inicializando Variables
    public CrearContacto()
    {
        this.nombre = "nombre";
        this.apellido = "apellido";
        this.telefono = "telefono";
        this.cedula = "cedula";
        this.dirrecion = "dirrecion";
    }

    //Ingresando datos de contacto
    public void setContactos(string nombreC, string apellidoC, string telefonoC, string cedulaC, string dirrecionC)
    {
        this.nombre = nombreC;
        this.apellido = apellidoC;
        this.telefono = telefonoC;
        this.cedula = cedulaC;
        this.dirrecion = dirrecionC;
    }

    //Obteniendo Datos de contacto ya ingresados
    public string[] getContactos()
    {

        this.datosContacto[0] = this.nombre;
        this.datosContacto[1] = this.apellido;
        this.datosContacto[2] = this.telefono;
        this.datosContacto[3] = this.cedula;
        this.datosContacto[4] = this.dirrecion;

        return datosContacto;

    }

    public string getCedula()
    {
        return this.cedula;
    }

    public string getNombre()
    {
        return this.nombre;
    }

}

//Valores constantes usados en todos los formularios
public class VConstantes {

    private const int tamanoArrayCliente = 10;//Debe ser ser menor que el numero de contactos. Tambien la division entre contactos y clientes debe dar un numero par.
    private const int tamanoArraycontacto = 20;//Debe ser mayor que el numero de clientes. Tambien la division entre contactos y clientes debe dar un numero par.
    private const int tamanoArrayinfoFinalCliente = 7;
    private const int tamanoArrayinfoFinalContacto = 2;

    //Obteniendo Valores
    public int gettamanoArrayCliente() {

        return tamanoArrayCliente;
    
    }
    public int gettamanoArraycontacto()
    {

        return tamanoArraycontacto;

    }
    public int gettamanoArrayinfoFinalCliente()
    {

        return tamanoArrayinfoFinalCliente;

    }
    public int gettamanoArrayinfoFinalContacto()
    {

        return tamanoArrayinfoFinalContacto;

    }


}