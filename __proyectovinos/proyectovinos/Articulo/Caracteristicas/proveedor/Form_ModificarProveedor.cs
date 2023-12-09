using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Shapes;
using CrystalDecisions.CrystalReports.ViewerObjectModel;
using MySql.Data.MySqlClient;
using proyectovinos;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TextBox;

namespace proyectovinos
{
    public partial class Form_ModificarProveedor : Form
    {
        public Form_ModificarProveedor()
        {
            InitializeComponent();
        }
        private int primeravez;


        CumplimentarComboboxes cump = new CumplimentarComboboxes();
        CumplimentarListas cumplimentarListas = new CumplimentarListas();
        CumplimentarPictureBoxes cumplimentarPictureBoxes = new CumplimentarPictureBoxes();
        Consultas consulta = new Consultas();
        Utilidades ut = new Utilidades();   
        ConexionBD con = new ConexionBD();

        public string referenciaActual = "";
        public string nombrecarpetaActual = "";
        public string nombreimagenActual = "";

        private string referencia = "";
        private string nombre = "";
        private string direccion = "";
        private string localidad = "";
        private string provincia = "";
        private string telefono = "";
        private string email = "";


        private bool cambioImagen = false;


        private void Form_ModificarProveedor_Load(object sender, EventArgs e)
        {
            this.CenterToScreen();
            cumplimentarListas.cumplimentarListaProveedor(listView1);
            primeravez = 1;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            referencia = text_referencia.Text;
            nombre = text_nombre.Text;
            direccion = text_direccion.Text;
            localidad = text_localidad.Text;
            provincia =  text_provincia.Text ;
            telefono = text_telefono.Text ;
            email = text_email.Text;            

            if (referencia == "" || nombre == "" || direccion == "" || localidad == "" || provincia == "" || telefono == "" || email == "")
            {
                MessageBox.Show(ClaseCompartida.msgCamposEnBlanco);
            }
            else { 

                bool modificado = modificarProveedor();

                if (modificado==true) { 
                    int id_proveedor = consulta.obtenerCualquierId("id_proveedor", "proveedor", "nombre", nombre);
                    
                    if (referencia != ""){

                        if (cambioImagen == true){ 
                            pictureBox1.Image.Save(ClaseCompartida.carpetaimg_absoluta + "proveedores/" + id_proveedor + "/logo/foto1.jpg", System.Drawing.Imaging.ImageFormat.Jpeg);
                            cambioImagen = false;
                        }
                    }
                    else { MessageBox.Show("Proveedor Vacio"); }
                   
                    cumplimentarListas.cumplimentarListaProveedor(listView1);
                    limpiarCampos();
                }   
            }
        }

        private bool modificarProveedor()
        {
            string cadenaConexion = con.conexion();
            MySqlConnection conexionBD = new MySqlConnection(cadenaConexion);
            MySqlDataReader reader = null;

            try
            {
                string consulta = "update proveedor SET " +
                    " ref= " + "'" + referencia + "', " +
                    " nombre= " + "'" + nombre + "', " +
                    " direccion= " + "'" + direccion + "', " +
                    " localidad= " + "'" + localidad + "', " +
                    " provincia= " + "'" + provincia + "', " +
                    " telefono= " + "'" + telefono + "', " +
                    " email= " + "'" + email + "'  " +
                    " WHERE ref= " + "'" + referenciaActual + "' ";

                MySqlCommand comando = new MySqlCommand(consulta);
                comando.Connection = conexionBD;
                conexionBD.Open();
                reader = comando.ExecuteReader();

                MessageBox.Show("Proveedor Modificado con Éxito!");

                conexionBD.Close();
                return true;

            }
            catch (MySqlException ex)
            {
                MessageBox.Show(ex.Message);
                conexionBD.Close();
                return false;

            }
            finally { conexionBD.Close(); }

        }


        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }


        // Método que cumplimenta los campos de Proveedor
        private void listView1_ItemChecked(object sender, ItemCheckedEventArgs e)
        {

            if (primeravez == 1)
            {
                referenciaActual = e.Item.Text;

                // Cumplimentar los campos desde la referencia del proveedor
            
                string cadenaConexion = con.conexion();
                MySqlConnection conexionBD = new MySqlConnection(cadenaConexion);

                Utilidades ut = new Utilidades();
                nombreimagenActual = ut.limpiezaDeString(text_nombre.Text);
                try
                {
                    string selectQuery = "select * from proveedor where ref = '" + referenciaActual + "'";

                    conexionBD.Open();
                    MySqlCommand command = new MySqlCommand(selectQuery, conexionBD);
                    MySqlDataReader reader = command.ExecuteReader();


                    while (reader.Read())
                    {
                        text_referencia.Text = reader.GetString("ref");
                        text_nombre.Text = reader.GetString("nombre");
                        text_direccion.Text = reader.GetString("direccion");
                        text_localidad.Text = reader.GetString("localidad");
                        text_provincia.Text = reader.GetString("provincia");
                        text_telefono.Text = reader.GetString("telefono");
                        text_email.Text = reader.GetString("email");


                        nombrecarpetaActual =ut.limpiezaDeString(text_nombre.Text);
                        Consultas consultas = new Consultas();
                        int id_proveedor = consultas.obtenerCualquierId("id_proveedor", "proveedor", "ref", referenciaActual);
                        cumplimentarPictureBoxes.cumplimentarPictureBoxProveedor(id_proveedor, pictureBox2);
                        //cumplimentarPictureBoxes.cumplimentarPictureBoxProveedor(id_proveedor, pictureBox1);
                        cambioImagen = false;
                    }
                }
                catch (Exception ex) { MessageBox.Show(ex.Message); }
                finally { conexionBD.Close(); }
            }
        }


        private void button6_Click(object sender, EventArgs e)
        {
            cumplimentarPictureBoxes.buscarImagenPicturebox(sender, e, pictureBox1);
        }


        //Método que salva la imagen de logo en la carpeta de proveedor
        public void salvarImagenEnCarpetaProveedor(string carpetaproveedorModificada, string nombreimagen, PictureBox pictureBox)
        {
            pictureBox1.Image.Save(ClaseCompartida.carpetaimg_absoluta + "proveedores/" + carpetaproveedorModificada + "/logo/logo.jpg", System.Drawing.Imaging.ImageFormat.Jpeg);
        }


        private void button1_Click(object sender, EventArgs e)
        {
            limpiarCampos();
        }

        private void limpiarCampos()
        {
            text_referencia.Text = "";
            text_nombre.Text = "";
            text_direccion.Text = "";
            text_localidad.Text = "";
            text_provincia.Text = "";
            text_telefono.Text = "";
            text_email.Text = "";

            pictureBox1.Image = null;
            pictureBox2.Image = null;
        }



        private void checkBox_cambioimagen_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox_cambioimagen.Checked)
            {
                pictureBox1.Visible = true;
                button_anadirimagen.Enabled = true;
                pictureBox1.Image = Image.FromFile(ClaseCompartida.carpetaimg_absoluta + "proveedores/logo2/logopredeterminada.jpg");
                cambioImagen = true;
            }
            else {
                pictureBox1.Visible = false;
                button_anadirimagen.Enabled = false;
            }
        }
    }
}

/* Probar esto https://www.youtube.com/watch?v=1IlzHEbjLBU  cada cierto rato cambie de foto  */


/*
// Borrar carpeta sin tocar y tocando
// string folderPath = @"../../img/proveedores/" + id_proveedor + "/logo ";
// Directory.Delete(folderPath, true); MessageBox.Show("Carpeta borrada");

// Crear Carpeta donde se eliminó
// string n_folderPath = @"../../img/proveedores/" + id_proveedor + "/logo";
// Directory.CreateDirectory(n_folderPath); MessageBox.Show("Carpeta creada");

// MessageBox.Show(@"../../img/proveedores/" + id_proveedor + "/logo/foto1.jpg");
 */