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
using proyectovinos.ArticuloVino;
using proyectovinos.Roles;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TextBox;

namespace proyectovinos.Empleados

{
    public partial class Form_TodosEmpleados : Form
    {
        public Form_TodosEmpleados()
        {
            InitializeComponent();
        }

        Consultas consultas = new Consultas();
        Utilidades ut = new Utilidades();
        ConexionBD con = new ConexionBD();        
        Class_EmpleadoAperturaForms empleadoAperturaForms=new Class_EmpleadoAperturaForms();
        Class_Empleado empleado = new Class_Empleado();
        CumplimentarComboboxes cumplimentar = new CumplimentarComboboxes();
        CumplimentarListas cumplimentarListas = new CumplimentarListas();
        CumplimentarPictureBoxes cumplimentarPictureBoxes = new CumplimentarPictureBoxes();

        private string nombre = "", apellido1, apellido2 = "", telefono = "", fechanacimiento = "",
                        referencia = "", email = "", sexo = "", usuario = "", contrasena = "", nombreimagen = "";

        private int id_empleado = 0, id_rollempleado = 0, max_id = 0;
        private bool cargaLista = true;

        private string nombreApellidos = "";
        private string tabla = "empleado";
        private string carpeta = "";

        private string nombreId = "id_empleado";
        private string refPredeterminada = "EMP";
        private int id_predeterminado = 0;


        private void Form_TodosEmpleados_Load(object sender, EventArgs e)
        {
            this.CenterToScreen();
            empleado.cumplimentarlistasListaEmpleados(listView1, '1');
            cumplimentar.refrescarCombo("nombre", "rollempleado", combo_roll);

            id_predeterminado = consultas.referenciaPredeterminada(nombreId, tabla, refPredeterminada, text_referencia);
            cargaLista = false;

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button_nuevoempleado_Click(object sender, EventArgs e)
        {
            nombre = text_nombre.Text; apellido1 = text_apellido1.Text; apellido2 = text_apellido2.Text;
            telefono = text_telefono.Text; email = text_email.Text; fechanacimiento = dateTime_fechanacimiento.Text;

            if (radio_hombre.Checked) { sexo = radio_hombre.Text; }
            else if (radio_mujer.Checked) { sexo = radio_mujer.Text; }


            fechanacimiento = ut.preparacionFecha(fechanacimiento);

            usuario = ut.limpiezaDeString(text_nombre.Text);
            contrasena = "6QRNJHgiEptBfbMM4eaHEFkCctQ=";

            
            nombreimagen = nombre + apellido1 + apellido2;
            nombreimagen = ut.limpiezaDeString(nombreimagen);
            string carpetaempleado = ut.limpiezaDeString(nombreimagen);

            nombreimagen = nombreimagen + ".jpg";


            string roll_nombre = combo_roll.Text;
            id_rollempleado = consultas.obtenerCualquierId("id_rollempleado", "rollempleado", "nombre", roll_nombre);

            if (text_nombre.Text == "" || text_apellido1.Text == "" || text_apellido2.Text == "" || text_telefono.Text == ""
                || text_email.Text == "" || combo_roll.Text == "Seleccione")
            {

                MessageBox.Show("Campos no válidos");
            }
            else
            {
                Class_Empleado empleado = new Class_Empleado();
                // empleado.salvarImagenEnCarpetaEmpleado(carpetaempleado, pictureBox1);
               

                bool insertado = insertarEmpleado();

                if (insertado==true) { 
                    empleado.salvarImagenEnCarpetaEmpleado2(id_predeterminado, pictureBox1);

                    cargaLista=true;
                    empleado.cumplimentarlistasListaEmpleados(listView1, '1');
                    cargaLista = false;
                    id_predeterminado = consultas.referenciaPredeterminada(nombreId, tabla, refPredeterminada, text_referencia);

                    limpiarCampos();
                }
            }
        }


        private void button5_Click(object sender, EventArgs e)
        {
            text_nombre.Text = "";
            text_apellido1.Text = "";
            text_apellido2.Text = "";
            text_telefono.Text = "";
            text_email.Text = "";
            dateTime_fechanacimiento.Text = DateTime.Now.ToString();
            // dateTime_fechanacimiento.Text = "26/07/2023 16:59";
            pictureBox1.Image = null;
            combo_roll.Text = "Seleccione";
        }


        // Metodo para Presentación
        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked==true) {
                text_nombre.Text = "Aoito";
                text_apellido1.Text = "Pérez";
                text_apellido2.Text = "Martínez";
                text_telefono.Text = "606999999";
                text_email.Text = "aoito@aoito.com";
                // dateTime_fechanacimiento.Text = "26/07/2023 16:59";
                radio_hombre.Checked = true;
                dateTime_fechanacimiento.Text = "1970/04/26";
                combo_roll.Text = "Dependiente";
                pictureBox1.Image = Image.FromFile(ClaseCompartida.carpetaimg_absoluta + "empleados/aoito.jpg");
            }
            else {
                limpiarCampos();
            }


        }

        private void button2_Click(object sender, EventArgs e)
        {
            controladorDeshabilitarEmpleado(check_segurodeshabilitar, text_referenciadeshabilitar, text_nombredeshabilitar, tabla, listView1, '0');
            empleado.cumplimentarlistasListaEmpleados(listView1, '1');
        }


        internal void controladorDeshabilitarEmpleado(CheckBox check_segurodeshabilitar, TextBox text_referenciadeshabilitar, TextBox text_nombredeshabilitar, string tabla, ListView listView1, char activo)
        {
            if (check_segurodeshabilitar.Checked)
            {
                if (text_nombredeshabilitar.Text == "" || text_referenciadeshabilitar.Text == "")
                {
                    MessageBox.Show(ClaseCompartida.msgCamposEnBlanco);
                }
                else
                {
                    ut.habilitarOnOff_Caracteristica(tabla, "ref", text_referenciadeshabilitar.Text, activo);
                    ut.limpiarCamposNuevoDeshabilitar(check_segurodeshabilitar, text_referenciadeshabilitar, text_nombredeshabilitar);
                }
            }
            else
            {
                MessageBox.Show(ClaseCompartida.msgCasillaSeguro);
            }
        }


        // Enlaces del Menu-Strip para abrir otros formularios
        private void eliminarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            empleadoAperturaForms.eliminarEmpleado(); 
        }

        private void modificarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            empleadoAperturaForms.modificarEmpleado(); 
        }
        private void empleadosInhabilitadosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            empleadoAperturaForms.empleadosInhabilitados(); 
        }



        private void todosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Class_RollAperturaForms rol = new Class_RollAperturaForms();
            rol.todosRoles();
        }


        private void listView1_ItemChecked(object sender, ItemCheckedEventArgs e)
        {

            if (cargaLista==false) { 
                ut.checkMarcadoTodos(cargaLista, e, text_referenciadeshabilitar, tabla, text_nombredeshabilitar);

                referencia = e.Item.Text;
                id_empleado = consultas.obtenerCualquierId("id_empleado","empleado","ref",referencia);


                try
                {
                    // Local_absoluta
                    string folderPath = ClaseCompartida.carpetaimg_absoluta + "empleados/" + id_empleado + "/perfil/foto1.jpg";

                    using (StreamReader stream = new StreamReader(folderPath))

                    {
                        pictureBox1.Image = Image.FromStream(stream.BaseStream);
                    }
                }
                catch (Exception ex)
                {
                    string folderPath = ClaseCompartida.carpetaimg_absoluta + "empleados/empleadopredeterminada.jpg";

                    using (StreamReader stream = new StreamReader(folderPath))
                    {
                        pictureBox1.Image = Image.FromStream(stream.BaseStream);
                    }
                }
            }
        }


        // Método que inserta un Empleado
        private bool insertarEmpleado()
        {

            string cadenaConexion = con.conexion();
            MySqlConnection conexionBD = new MySqlConnection(cadenaConexion);
            MySqlDataReader reader = null;

            try
            {
                string selectQuery = "insert into empleado (id_empleado, ref, nombre, apellido1, apellido2, telefono, email, sexo, " +
                    "fechanacimiento, usuario, contrasena, id_rollempleado, activo)" +
                                    "values (" +
                                    "   " + id_predeterminado + "" +
                                    ", '" + text_referencia.Text + "'" +
                                    ", '" + nombre + "'" +
                                    ", '" + apellido1 + "'" +
                                    ", '" + apellido2 + "'" +
                                    ", '" + telefono + "'" +
                                    ", '" + email + "'" +
                                    ", '" + sexo + "'" +
                                    ", '" + fechanacimiento + "'" +
                                    ", '" + usuario + "'" +
                                    ", '" + contrasena + "'" +
                                    ",  " + id_rollempleado + "" +
                                    ", '1'" + ")";

                // MessageBox.Show(selectQuery);

                MySqlCommand comando = new MySqlCommand(selectQuery);
                comando.Connection = conexionBD;
                conexionBD.Open();
                reader = comando.ExecuteReader();

                MessageBox.Show("Nuevo Empleado incorporado!");
              
            }
            catch (MySqlException ex)
            { 
                MessageBox.Show("No insertado"); 
                conexionBD.Close();  
                return false;
            }
            finally { 
               
            }
            conexionBD.Close();
            return true;
        }


 
        private void button3_Click(object sender, EventArgs e)
        {
            limpiarCampos();
        }

        private void limpiarCampos()
        {
            pictureBox1.Image = null;
            text_nombre.Text = "";
            text_apellido1.Text = "";
            text_apellido2.Text = "";
            text_telefono.Text = "";
            text_email.Text = "";
            // dateTime_fechanacimiento.Text = "26/07/2023 16:59";
            radio_hombre.Checked = true;
            dateTime_fechanacimiento.Text = DateTime.Now.ToString();
            combo_roll.Text = "Seleccione";
        }

       

        private void button11_Click(object sender, EventArgs e)
        {
            cumplimentarPictureBoxes.buscarImagenPicturebox(sender, e, pictureBox1);
        }

    }
}
