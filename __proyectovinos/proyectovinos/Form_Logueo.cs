using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySqlX.XDevAPI;



using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TextBox = System.Windows.Forms.TextBox;

using Microsoft;
using System.Runtime.Remoting.Contexts;
using System.Xml.Linq;
using System.Windows.Controls;
using MySql.Data.MySqlClient;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using proyectovinos.Empleados;

namespace proyectovinos


{
    public partial class Form_Logueo : Form
    {
        public Form_Logueo()
        {
            InitializeComponent();
        }

        private void Form_Logueo_Load(object sender, EventArgs e)
        {
            this.CenterToScreen();
            Form1 form1 = new Form1();
            form1.Enabled = false;

            textBox_usuario.Text = "adrian";
            textBox_contrasena.Text = "alberite";
        }



      Class_Empleado class_Empleado = new Class_Empleado();


        // Método que loguea a un usuario 
        // see https://es.stackoverflow.com/questions/10750/como-usar-una-variable-de-un-formulario-de-c-en-otro
       

        // Función que comprueva el usuario y la contraseña
        private void button_login_Click(object sender, EventArgs e)
        {
            string usuarioBox = textBox_usuario.Text;
            string contrasenaBox = textBox_contrasena.Text;
 
            string passwordEncriptadoForm = class_Empleado.encriptarSHA1(contrasenaBox);    //MessageBox.Show(passwordEncriptadoForm);
            string[] session = datosLogueo(usuarioBox, passwordEncriptadoForm);             // MessageBox.Show(session[1]);

            if (session!=null) { 
                if (passwordEncriptadoForm == session[2])
                {
                    //MessageBox.Show("Usuario válido.");
                    ClaseCompartida.nombre = session[0];
                    ClaseCompartida.usuario = session[1];
                    ClaseCompartida.contrasena = session[2];
                    ClaseCompartida.roll = session[3];
                    ClaseCompartida.refe = session[4];
                    // Form1.variableCompartida = "Adriana";
                }
                else
                {
                    MessageBox.Show("Acceso denegado.");
                }
                this.Close();
            }
        }


        // Método que devuelve los datos de un usuario logueado
        private string[] datosLogueo(string usuarioBox, string contrasenaBox)
        {
            ConexionBD con = new ConexionBD();
            string cadenaConexion = con.conexion();
            MySqlConnection conexionBD = new MySqlConnection(cadenaConexion);


            string nombre = "", usuario = "",contrasena = "", nombreroll = "", refe = "";
            string[] sesion = new string[5];
            try
            {
                string selectQuery = "select e.ref as ref, e.nombre as nombre, e.usuario as usuario, e.contrasena as contrasena, r.nombre as nombreroll from empleado e" +
                    " inner join rollempleado r on e.id_rollempleado = r.id_rollempleado where e.usuario = '" + usuarioBox + "' and contrasena = '" + contrasenaBox + "'";

               // MessageBox.Show(selectQuery);
                
                conexionBD.Open();
                MySqlCommand command = new MySqlCommand(selectQuery, conexionBD);
                MySqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {  
                    nombre = reader.GetString("nombre");            sesion[0] = nombre;
                    usuario = reader.GetString("usuario");          sesion[1] = usuario;
                    contrasena = reader.GetString("contrasena");    sesion[2]=  contrasena;
                    nombreroll = reader.GetString("nombreroll");    sesion[3]=  nombreroll;
                    refe = reader.GetString("ref");          sesion[4] = refe;   
                }
                conexionBD.Close();
                return sesion;

            }
            catch (Exception ex)
            {
                conexionBD.Close();
                MessageBox.Show(ex.Message);

            }
            /* finally
             {
                 conexionBD.Close();
             }*/

            return sesion;
        }
    }
}



// https://es.stackoverflow.com/questions/194778/almacenar-valor-de-variables-al-volver-a-cargar-un-windows-form