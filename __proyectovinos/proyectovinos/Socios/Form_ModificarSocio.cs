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
using MySql.Data.MySqlClient;
using proyectovinos.Socios;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TextBox;

namespace proyectovinos
{
    public partial class Form_ModificarSocio : Form
    {
        public Form_ModificarSocio()
        {
            InitializeComponent();
        }

        Consultas consultas = new Consultas();
        Class_Socio socio = new Class_Socio();
        Class_Socio consulta = new Class_Socio();
        CumplimentarComboboxes combos = new CumplimentarComboboxes();

        private string referencia = "";
        private int id_socio = 0;

        private string tabla = "socio";
        private string nombreId = "id_socio";


        private void Form_ModificarSocio_Load(object sender, EventArgs e)
        {
            this.CenterToScreen();
            this.Top = this.Top + 40;
            combos.cumplimenterComboboxSocio(combo_socio);
        }


        private void listView1_ItemChecked(object sender, ItemCheckedEventArgs e)
        {
            referencia = e.Item.Text;
            id_socio = consultas.obtenerCualquierId(nombreId, tabla, "ref", referencia);
            int index = e.Item.Index;

            socio.agregarImagenPictureBoxSocio(id_socio, pictureBox1);
        }

               
        /// <summary>
        /// Función que modifica los registros de un socio  
        /// </summary>
        /// <returns></returns>
        private bool modificarSocio()
        {
            string newRef = text_referencianueva.Text;
            string newNombre = text_nombrenuevo.Text;
            string newApellidos = text_apellidosnuevo.Text;
            string newLocalidad = text_localidad.Text;
            string newProvincia = text_provincia.Text;

            string newSexo = "";
            if (radio_hombre.Checked == true) {
                newSexo = "Hombre";
            }
            else if (radio_mujer.Checked == true) {
                newSexo = "Mujer";
            }

            string newNif = text_nif.Text;
            string newTelefono = text_telefono.Text;
            string newEmail = text_email.Text;

            string newRecibirInfo = "";
            if (check_recibirinfo.Checked == true)
            {
                newRecibirInfo = "Si";
            }
            else if (check_recibirinfo.Checked == false)
            {
                newRecibirInfo = "No";
            }

            ConexionBD con = new ConexionBD();
            string cadenaConexion = con.conexion();
            MySqlConnection conexionBD = new MySqlConnection(cadenaConexion);
            MySqlDataReader reader = null;

            try
            {
                string selectQuery = "update socio SET " +
                    " ref='" + newRef + "'" + ", " +
                    " nombre='" + newNombre + "'" + ", " +
                    " apellidos='" + newApellidos + "', " +
                    " localidad='" + newLocalidad + "'" + ", " +
                    " provincia='" + newProvincia + "'" + ", " +
                    " sexo='" + newSexo + "'," +
                    " nif='" + newNif + "'" + ", " +
                    " telefono='" + newTelefono + "', " +
                    " email='" + newEmail + "'," +
                    " recibir_info='" + newRecibirInfo + "'" +

                    " WHERE ref = " + "'" + refSocio + "' "; 
                // MessageBox.Show(selectQuery);

                MySqlCommand comando = new MySqlCommand(selectQuery);
                comando.Connection = conexionBD;
                conexionBD.Open();
                reader = comando.ExecuteReader();

                MessageBox.Show("Registro Modificado");
                conexionBD.Close();
                return true;
            }

            catch (MySqlException ex)
            {
                MessageBox.Show(ex.Message);
                MessageBox.Show("La referencia ya se encuentra asignada a otro usuario \n ...pruebe con otra!");
                conexionBD.Close();
                return false;
            }
            finally { conexionBD.Close(); }
        
        }

        private void limpiarCampos()
        {
            combo_socio.Text = "Seleccione";
            text_nombrenuevo.Text = ""; text_nif.Text = ""; text_telefono.Text = "";
            text_apellidosnuevo.Text = ""; text_localidad.Text = ""; text_provincia.Text = "";
            text_referencianueva.Text = ""; text_email.Text = ""; check_recibirinfo.Checked = false;
            radio_hombre.Checked = true;
            pictureBox1.Image = null;

        }

        private string refSocio = "";



        private void combo_socio_SelectedIndexChanged(object sender, EventArgs e)
        {
            refSocio = combo_socio.Text;
            id_socio = consultas.obtenerCualquierId("id_socio", "socio", "ref", refSocio);

            //socio.agregarImagenPictureBoxSocio(id_socio, pictureBox1);

            string folderPathPropia = ClaseCompartida.carpetaimg_absoluta + "socios/" + id_socio + "/perfil/foto1.jpg";
            string folderPathPredeterminada = ClaseCompartida.carpetaimg_absoluta + "socios/predeterminada.jpg";
            ut.cargarImagen(pictureBox1, folderPathPropia, folderPathPredeterminada);



            string[] datos = socio.datosSocioo(id_socio);
            text_nombrenuevo.Text = datos[0];
            text_apellidosnuevo.Text = datos[1];
            text_localidad.Text = datos[2];
            text_nif.Text = datos[5];
            text_telefono.Text = datos[3];

            text_provincia.Text = datos[3];
            text_email.Text = datos[7];
            text_telefono.Text = datos[6];
            text_referencianueva.Text = datos[9];

            if (datos[8] == "Si")
            {
                check_recibirinfo.Checked = true;
            }
            else if (datos[8] == "No")
            {
                check_recibirinfo.Checked = true;
            }


            if (datos[4] == "Hombre")
            {
                radio_hombre.Checked = true;
            }
            else if (datos[4] == "Mujer")
            {
                radio_mujer.Checked = true;
            }

        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (combo_socio.Text != "Seleccione")
            {
                if (text_referencianueva.Text != "")
                {
                    bool modificado = modificarSocio();

                    if (modificado == true)
                    {
                        socio.salvarImagenEnCarpetaSocio(pictureBox1, id_socio);
                        limpiarCampos();
                    }
                    else {
                        MessageBox.Show("No insertado");
                    }
                }
                else
                {
                    MessageBox.Show(ClaseCompartida.msgCamposEnBlanco);
                }
            }
            else
            {
                MessageBox.Show("Seleccione un socio!");
            }
        }

        private void actualizarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            combo_socio.Items.Clear();
            combos.cumplimenterComboboxSocio(combo_socio);
        }

        Utilidades ut = new Utilidades();

        private void butn_subirfoto_Click(object sender, EventArgs e)
        {
            ut.cargarNuevaImagen(pictureBox1);
        }
    }
}


