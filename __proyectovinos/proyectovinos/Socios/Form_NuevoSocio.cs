using System;
using System.Activities.Statements;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Web.WebPages;
using System.Windows.Controls;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using proyectovinos.Socios;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TextBox;
using Control = System.Windows.Forms.Control;
using TextBox = System.Windows.Forms.TextBox;

namespace proyectovinos
{
    public partial class Form_NuevoSocio : Form
    {
        public Form_NuevoSocio()
        {
            InitializeComponent();
        }


       // Utilidades ut = new Utilidades();

        Consultas consultas=new Consultas();

        private int id_socio=0;
        private string refSocio = "";
        private string nif = "",nombre="",apellidos="",sexo="", telefono = "", localidad = "", provincia = "", email = "", recibirInfo = "";
        private string nombreid = "id_socio";
        private string tabla = "socio";
        private string refPredeterminada = "CLS";

        private void Form_NuevoSocio_Load(object sender, EventArgs e)
        {
            this.CenterToScreen();
            this.Top = this.Top + 40;
            id_socio = consultas.referenciaPredeterminada(nombreid, tabla, refPredeterminada, text_referencia);
        }


        private void limpiarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            limpiezaCampos();
        }

        private void nuevoToolStripMenuItem_Click(object sender, EventArgs e)
        {

            refSocio = text_referencia.Text;
            nombre = text_nombre.Text;
            apellidos = text_apellidos.Text;

            if (radio_hombre.Checked)
            {
                sexo = radio_hombre.Text;
            }
            else if (radio_mujer.Checked)
            {
                sexo = radio_mujer.Text;
            }


            nif = text_nif.Text;
            telefono = text_telefono.Text.Trim();
            localidad = text_localidad.Text;
            provincia = text_provincia.Text;
            email = text_email.Text;


            if (check_recibirinfo.Checked) { recibirInfo = "Si"; }
            else { recibirInfo = "No"; }


            bool correctos = camposCumplimentados();

            if (correctos == true)
            {
                bool insertado = insertarSocio();
                if (insertado == true)
                {
                    salvarImagenEnCarpetaSocio2(id_socio);
                    id_socio = consultas.referenciaPredeterminada(nombreid, tabla, refPredeterminada, text_referencia);
                    limpiezaCampos();
                }
            }
            else
            {
                MessageBox.Show("Campos en blanco!");

            }
        }

        private void text_nombre_TextChanged(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// Función que carga predeterminadamente un socio de ejemplo.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked == true)
            {
                text_nombre.Text = "Paco";
                text_apellidos.Text = "Omaita Moranco";
                text_nif.Text = "16600000W";
                text_localidad.Text = "Écija";
                text_provincia.Text = "Sevilla";
                text_telefono.Text = "606999888";
                text_email.Text = "paco@gmail.com";
                radio_hombre.Checked = true;
                check_recibirinfo.Checked = true;
                pictureBox1.Image = System.Drawing.Image.FromFile(ClaseCompartida.carpetaimg_absoluta + "socios/paco.jpg");

            }
            else {
                limpiezaCampos();
            }
        }

        private bool camposCumplimentados()
        {
            if (text_nombre.Text == "" || text_apellidos.Text == "" || text_localidad.Text == "" || text_nif.Text == "" || text_provincia.Text == "" || text_email.Text == "" || text_referencia.Text == "" || text_telefono.Text == "")
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        /// <summary>
        /// Función que inserta un socio.
        /// </summary>
        /// <returns></returns>
        private bool insertarSocio()
        {
            ConexionBD con = new ConexionBD();
            string cadenaConexion = con.conexion();

            MySqlConnection conexionBD = new MySqlConnection(cadenaConexion);
            MySqlDataReader reader = null;

            try
            {
                string selectQuery = "insert into socio (id_socio, ref, nombre, apellidos, localidad, provincia, sexo, nif, telefono, email, recibir_info,activo) " +
                                    "values (" + id_socio + ", '" + refSocio + "','" + nombre + "' ,'" + apellidos + "'," +
                                    "'" + localidad + "','" + provincia + "','" + sexo + "','" + nif + "'," +
                                    "'" + telefono + "','" + email + "','" + recibirInfo + "' ,'1')";
                // MessageBox.Show(selectQuery);

                MySqlCommand comando = new MySqlCommand(selectQuery);
                comando.Connection = conexionBD;
                conexionBD.Open();
                reader = comando.ExecuteReader();

                MessageBox.Show(ClaseCompartida.msgInsertado);
                return true;
            }
            catch (MySqlException ex)
            { 
                MessageBox.Show(ex.Message);
                conexionBD.Close();
                return false;
            }
            finally { conexionBD.Close(); 
            }
        }

        /// <summary>
        /// Función que guarda la imagen de socio en su carpeta.
        /// </summary>
        /// <param name="id_socio">The identifier socio.</param>
        private void salvarImagenEnCarpetaSocio2(int id_socio)
        {   // (podría hacerse genérica con proveedor o empleado)
            try
            {
                // string folderPath = @"C:\MyFoldera";
                string folderPath = ClaseCompartida.carpetaimg_absoluta + "socios/" + id_socio + "/perfil/";

                if (!Directory.Exists(folderPath))
                {
                    Directory.CreateDirectory(folderPath);
                    Console.WriteLine(folderPath);

                    if (pictureBox1.Image != null)
                    {
                        pictureBox1.Image.Save(ClaseCompartida.carpetaimg_absoluta + "socios/" + id_socio + "/perfil/foto1.jpg", System.Drawing.Imaging.ImageFormat.Jpeg);
                    }
                    else
                    {
                        // Se mete la imagen predeterminada
                        pictureBox1.Image = System.Drawing.Image.FromFile(ClaseCompartida.carpetaimg_absoluta + "socios/predeterminada.jpg");
                        pictureBox1.Image.Save(ClaseCompartida.carpetaimg_absoluta + "socios/" + id_socio + "/perfil/predeterminada.jpg", System.Drawing.Imaging.ImageFormat.Jpeg);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ClaseCompartida.msgErrorGeneral + "->" + ex);
            }
        }



        /// <summary>
        /// Método que hace subir una fotografía de un Socio .
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void button1_Click(object sender, EventArgs e)
        {
            /*OpenFileDialog ofdSeleccionar = new OpenFileDialog();
            ofdSeleccionar.Filter = "Imagenes|*.jpg; *.png";
            ofdSeleccionar.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyPictures);
            ofdSeleccionar.Title = "Seleccionar imagen";

            if (ofdSeleccionar.ShowDialog() == DialogResult.OK)
            {
                pictureBox1.Image = System.Drawing.Image.FromFile(ofdSeleccionar.FileName);
            }*/
            Class_Socio socio = new Class_Socio();
            socio.cargarImagen(pictureBox1);
        }

        /// <summary>
        /// Función que implementa los campos en modo predeterminado.
        /// </summary>
        private void limpiezaCampos()
        {
            text_nombre.Text = "";
            text_apellidos.Text = "";
            text_localidad.Text = "";
            text_provincia.Text = "";
            text_nif.Text = "";
            text_telefono.Text = "";
            text_email.Text = "";
            pictureBox1.Image = null;
        }


        private void vENTASToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //AperturaFormulariosArticulo apertura=new AperturaFormulariosArticulo();
            //apertura.todaVentas();
        }

        private void txtLeave(object sender, EventArgs e)
        {
            /*MessageBox.Show("estoy");
            foreach (Control ctrl in groupBox2.Controls) {
                if (ctrl is TextBox && ctrl.Name == "text_nombre" && ctrl.Text.IsEmpty())
                {
                    // ctrl.BackColor = Color.FromArgb(79, 129, 189);
                    // ctrl.BackColor = Color.Red;
                }
            }*/
        }


        private void txtFocus(object sender, EventArgs e)
        {
            /*MessageBox.Show("estoy");
            foreach (Control ctrl in groupBox2.Controls)
            {
                if (ctrl is TextBox && ctrl.Name == "text_nombre")
                {
                    ctrl.BackColor = Color.FromArgb(251, 251, 247);
                }
                
            }*/
        }







        // Método que agrega un nuevo Socio
        private void btn_nuevosocio_Click(object sender, EventArgs e)
        {
            /*
                refSocio = text_referencia.Text;
                nombre = text_nombre.Text; 
                apellidos = text_apellidos.Text;

                if (radio_hombre.Checked) {
                    sexo = radio_hombre.Text;}
                else if (radio_mujer.Checked){
                    sexo = radio_mujer.Text; }
                

                 nif = text_nif.Text;
                 telefono = text_telefono.Text.Trim();
                 localidad = text_localidad.Text;
                 provincia = text_provincia.Text;
                 email = text_email.Text;

                
                if (check_recibirinfo.Checked){recibirInfo = "Si";}
                else{ recibirInfo = "No"; }


            bool correctos = camposCumplimentados();

            if (correctos == true)
            {
                bool insertado = insertarSocio();
                if (insertado == true)
                {
                    salvarImagenEnCarpetaSocio2(id_socio);
                    id_socio = consultas.referenciaPredeterminada(nombreid, tabla, refPredeterminada, text_referencia);
                    limpiezaCampos();
                }
            }
            else {
                MessageBox.Show("Campos en blanco!");
            
            }*/
        }
    }
}

/*
 * Bloque que limpia todo
 * https://www.elguille.info/colabora/NET2005/german_limpiar_acentos_puntonetwhidbey.htm */




/*
 
Refrescar si se implementa bien, lista de socios
MessageBox.Show("Clase de vino insertada");   // MessageBox.Show(consulta);
conexionBD.Close();


/// Refrescar el listview
listView1.Items.Clear();
string selectQuery = "select ref, nombre from clasevino ";
conexionBD.Open();
MySqlCommand command = new MySqlCommand(selectQuery, conexionBD);
reader = command.ExecuteReader();
while (reader.Read())
{
ListViewItem itemAgregar = new ListViewItem(reader.GetString("ref"));
// itemAgregar.Checked = true;
itemAgregar.SubItems.Add(reader.GetString("nombre"));
listView1.Items.Add(itemAgregar);
}
///

limpiarCampos();
*/
