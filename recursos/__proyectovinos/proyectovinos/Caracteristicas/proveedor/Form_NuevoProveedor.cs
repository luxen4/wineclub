using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using proyectovinos.ArticuloVino;
using proyectovinos.Caracteristicas.proveedor;

namespace proyectovinos
{
    public partial class Form_NuevoProveedor : Form
    {
        public Form_NuevoProveedor()
        {
            InitializeComponent();
        }

        private string referencia = "";
        private string nombre = "";
        private string direccion = "";
        private string localidad = "";
        private string provincia = "";
        private string telefono = "";
        private string email = "";
        

        private int max_id = 0, id_proveedor;


        CumplimentarListas cumplimentarListas = new CumplimentarListas();
        ConexionBD con = new ConexionBD();
        Consultas consultas = new Consultas();
        Utilidades ut = new Utilidades();

        // private string referencia = "";
        private int id_predeterminado = 0;
        private bool cargaLista = true;
        private string tabla = "proveedor";
        private string nombreId = "id_proveedor";
        private string refPredeterminada = "PRO";


        private void Form_NuevoProveedor_Load(object sender, EventArgs e)
        {
            this.CenterToScreen();
            id_predeterminado = consultas.referenciaPredeterminada(nombreId, tabla, refPredeterminada, text_referencia);
            cumplimentarListas.cumplimentarLista("ref", "nombre", tabla, listView1, '1');
            cargaLista = false;
        }


        // Método controlador que dirige la inserción de un Proveedor
        private void button2_Click(object sender, EventArgs e)
        {

            bool camposBlanco = camposEnBlanco();

            if (camposBlanco)
            {
                insertarProveedor();
                limpiarCampos();
                cumplimentarListas.cumplimentarLista("ref", "nombre", "proveedor", listView1, '1');

            }
            else {
                MessageBox.Show(ClaseCompartida.msgCamposEnBlanco);
            }
           
        }

        private void insertarProveedor()
        {
            string cadenaConexion = con.conexion();
            MySqlConnection conexionBD = new MySqlConnection(cadenaConexion);
            MySqlDataReader reader = null;

            try
            {
                string selectQuery = "insert into proveedor (id_proveedor, ref, nombre, direccion, localidad, provincia, telefono, email, activo) " +
                    "values (" + id_predeterminado + ", '" + referencia + "', '" + nombre + "', '" + direccion + "', '" + localidad + "', '" + provincia + "', '"
                    + telefono + "' , '" + email + "','1')";

                MySqlCommand comando = new MySqlCommand(selectQuery);
                comando.Connection = conexionBD;
                conexionBD.Open();
                reader = comando.ExecuteReader();
                MessageBox.Show("Nuevo Proveedor creado!");
                conexionBD.Close();

                cumplimentarListas.cumplimentarLista("ref", "nombre", "proveedor", listView1,'1');

                string carpetaproveedor = ut.limpiezaDeString(text_nuevoproveedor.Text);
              
                salvarImagenEnCarpetaProveedor(id_predeterminado);

                 limpiarCampos();

            }
            catch (MySqlException ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                conexionBD.Close();
            }
        }



        // Método que comprueba si los campos se encuentran en blanco antes de crear un nuevo registro
        private bool camposEnBlanco()
        {
            referencia = text_referencia.Text;
            nombre = text_nuevoproveedor.Text;
            direccion = text_direccion.Text;
            localidad = text_localidad.Text;
            provincia = text_provincia.Text;
            telefono = text_telefono.Text;
            email = text_email.Text;

            if (referencia == "" || nombre == "" || direccion == "" || localidad == "" || provincia == "" || telefono == "" || email == "")
            {
                return false;
            }
            else {
                return true;
            }
        }


        // Método que guarda la imagen-logo en la carpeta del proveedor (Se crea el directorio y se guarda la imagen propia o predeterminada)
        private void salvarImagenEnCarpetaProveedor(int id_proveedor)
        {
            try
            {
                // string folderPath = @"C:\MyFoldera";
                string folderPath = ClaseCompartida.carpetaimg_absoluta + "proveedores/" + id_proveedor + "/logo/";

                if (!Directory.Exists(folderPath))  
                {
                    Directory.CreateDirectory(folderPath); MessageBox.Show("Crea Directorio");
                    Console.WriteLine(folderPath);

                    if (pictureBox1.Image != null)
                    { 
                        pictureBox1.Image.Save(ClaseCompartida.carpetaimg_absoluta + "proveedores/" + id_proveedor + "/logo/foto1.jpg", System.Drawing.Imaging.ImageFormat.Jpeg);
                    }
                    else {
                        pictureBox1.Image = Image.FromFile(ClaseCompartida.carpetaimg_absoluta + "proveedores/logo2/logopredeterminada.jpg");
                        pictureBox1.Image.Save(ClaseCompartida.carpetaimg_absoluta + "proveedores/" + id_proveedor + "/logo/foto1.jpg", System.Drawing.Imaging.ImageFormat.Jpeg);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ocurrio un Error :\n " + ex);
            }

        }

        // Seleccionar una imagen para en pictureBox
        private void button4_Click_1(object sender, EventArgs e)
        {
            CumplimentarPictureBoxes cumplimentarPictureBoxes = new CumplimentarPictureBoxes();
            cumplimentarPictureBoxes.buscarImagenPicturebox(sender, e, pictureBox1);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            limpiarCampos();
        }   
 

        // Método que deja los campos con valores predeterminados
        private void limpiarCampos()
        {
            text_referencia.Text = "";
            text_nuevoproveedor.Text = "";
            text_direccion.Text = "";
            text_localidad.Text = "";
            text_provincia.Text = "";
            text_telefono.Text = "";
            text_email.Text = "";
            pictureBox1.Image = null;
        }

        private void todosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Class_ProveedorAperturaForms proveedor = new Class_ProveedorAperturaForms();
            proveedor.todosProveedores(); this.Close();
        }

        private void nuevoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Class_ArticuloAperturaForms articulo = new Class_ArticuloAperturaForms();
            articulo.nuevoArticuloVino(); this.Close();
        }


        // Método para inserción rápida de campos de proveedor para presentación rápida de la app 
        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (check_demo.Checked)
            {
                //text_referencia.Text = "PRO7";
                text_nuevoproveedor.Text = "CAMPO VIEJO";
                text_direccion.Text = "Cam. de Lapuebla de Labarca, 50, 26007";
                text_localidad.Text = "Logroño";
                text_provincia.Text = "La Rioja";
                text_telefono.Text = "941279900";
                text_email.Text = "campoviejo.com";
                pictureBox1.Image = Image.FromFile(ClaseCompartida.carpetaimg_absoluta + "proveedores/logocampoviejo.jpg");
            }
            else {
                limpiarCampos();
            }
        }

    }
}

