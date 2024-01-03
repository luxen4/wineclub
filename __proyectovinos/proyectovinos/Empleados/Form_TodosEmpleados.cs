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
using PdfSharp.Internal;
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
            this.Top = this.Top + 20;
            habilitarToolStripMenuItem.Enabled = false;
            eliminarToolStripMenuItem.Enabled = false;
            referencia = "";
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


        // Función que deja todos los campos en modo predeterminado
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

        // Función que carga la lista de todos empleados activos
        private void actualizarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            cargaLista = true;
            empleado.cumplimentarlistasListaEmpleados(listView1, '1');
            cargaLista = false;
            cumplimentar.refrescarCombo("nombre", "rollempleado", combo_roll);
            id_predeterminado = consultas.referenciaPredeterminada(nombreId, tabla, refPredeterminada, text_referencia);
           
            referencia = "";
            pictureBox1.Image=null;
        }

        private void check_demo_CheckedChanged(object sender, EventArgs e)
        {
            if (check_demo.Checked==true) {
                generaEmpleadoDemo(); }
            else {
                limpiarCampos();
            }
        }

        private void generaEmpleadoDemo()
        {
            id_predeterminado = consultas.referenciaPredeterminada(nombreId, tabla, refPredeterminada, text_referencia);
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

        private void deshabilitarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (referencia != "")
            {
                // Pregunta
                DialogResult opcionSeleccionada = MessageBox.Show("Realmente desea deshabilitar el empleado?", "Aviso", MessageBoxButtons.YesNo);

                if (opcionSeleccionada == DialogResult.Yes)
                {
                    ut.habilitarOnOff_Caracteristica(tabla, "ref", text_referenciadeshabilitar.Text, '0');
                    empleado.cumplimentarlistasListaEmpleados(listView1, '1');
                }
                else {
                    MessageBox.Show("Tenga cuidado!");
                }
            }
            else {
                MessageBox.Show("No ha seleccionado una referencia");
            }
}

        private void refrescaLista(char activo)
        {
            listView1.Items.Clear();
            cargaLista = true;
            empleado.cumplimentarlistasListaEmpleados(listView1, activo);
            cumplimentar.refrescarCombo("nombre", "rollempleado", combo_roll);
            id_predeterminado = consultas.referenciaPredeterminada(nombreId, tabla, refPredeterminada, text_referencia);
            cargaLista = false;
            limpiarCampos();
        }

        private void cARGOSROLESToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Class_CargosAperturaForms rol = new Class_CargosAperturaForms();
            rol.todosRoles();
        }

        private void button_subirImagen_Click(object sender, EventArgs e)
        {

        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            refrescaLista('1');
            actualizarToolStripMenuItem.Enabled = true;
            deshabilitarToolStripMenuItem.Enabled = true;
            habilitarToolStripMenuItem.Enabled = false;
            eliminarToolStripMenuItem.Enabled = false;
            referencia = "";
        }

        /// <summary>
        /// Handles the 1 event of the eliminarToolStripMenuItem_Click control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void eliminarToolStripMenuItem_Click_1(object sender, EventArgs e)
        { 
            if (referencia != "")
            {
                // Pregunte si está seguro de eliminar y si es sí que lo elimine
                DialogResult opcionSeleccionada = MessageBox.Show("Realmente desea eliminar el empleado?", "Aviso", MessageBoxButtons.YesNo);

                if (opcionSeleccionada == DialogResult.Yes)
                {
                    bool eliminado = consultas.eliminarCaracteristica(tabla, "ref", referencia);
                    if (eliminado == true)
                    {
                        //que refresque 
                        refrescaLista('0');
                        // Eliminar su carpeta (repetido de Proveedor que se podría sacar a función y ahorrar código)
                        if (eliminado == true)
                        {
                            string folderPath = ClaseCompartida.carpetaimg_absoluta + "empleados/" + id_empleado;
                            try
                            {
                                Directory.Delete(folderPath, true);
                                // MessageBox.Show("Directorio eliminado: " + folderPath);

                            }
                            catch (Exception ex)
                            {
                                MessageBox.Show("The process failed: {0}", ex.Message);
                            }
                        }
                        else
                        {
                            MessageBox.Show("No se ha eliminado, consulte con el administrador!");
                        }

                        pictureBox1.Image = null;
                    }
                }
                else
                {
                    MessageBox.Show("Tenga cuidado");
                }
            }
            else
            {
                MessageBox.Show("No ha seleccionado una referencia");
            }
        }

        private void habilitarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (referencia != "")
            {
                // Pregunte si está seguro de eliminar y si es sí que lo elimine
                DialogResult opcionSeleccionada = MessageBox.Show("Realmente desea habilitar el empleado?", "Aviso", MessageBoxButtons.YesNo);
                if (opcionSeleccionada == DialogResult.Yes)
                {
                    consultas.habilitarDesabilitarCualquierReferencia(tabla, "ref", referencia, '1');
                    listView1.Items.Clear();
                    empleado.cumplimentarlistasListaEmpleados(listView1, '0');
                    limpiarCampos();
                }
                else
                {
                    MessageBox.Show("No se hace nada");
                }
            }
            else {
                MessageBox.Show("No ha seleccionado una referencia");
            }
            
            referencia = "";
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            refrescaLista('0');
            actualizarToolStripMenuItem.Enabled = false;
            habilitarToolStripMenuItem.Enabled = true;
            deshabilitarToolStripMenuItem.Enabled=false;
            eliminarToolStripMenuItem.Enabled = true;
            referencia = "";
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


        /// <summary>
        /// Función-controlador que abre el formulario de modificar empleado.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void modificarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            empleadoAperturaForms.modificarEmpleado(); 
        }


        private void listView1_ItemChecked(object sender, ItemCheckedEventArgs e)
        {
            while (cargaLista == false)
            {  
                cargaLista = true;
                ut.limpiarChecks(listView1, e);

                referencia = e.Item.Text;
                id_empleado = consultas.obtenerCualquierId("id_empleado","empleado","ref",referencia);

                string folderPathPropia = ClaseCompartida.carpetaimg_absoluta + "empleados/" + id_empleado + "/perfil/foto1.jpg";
                string folderPathPredeterminada = ClaseCompartida.carpetaimg_absoluta + "empleados/empleadopredeterminada.jpg";
                ut.cargarImagen(pictureBox1, folderPathPropia, folderPathPredeterminada);
            }
            cargaLista = false;
        }




        /// <summary>
        /// Método que inserta un Empleado
        /// </summary>
        /// <returns></returns>
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

        /// <summary>
        /// Método que pone los campos de empleado en modo predeterminado.
        /// </summary>
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
            pictureBox1.Image = null; 
        }

       
        private void button11_Click(object sender, EventArgs e)
        {
            cumplimentarPictureBoxes.buscarImagenPicturebox(sender, e, pictureBox1);
        }
    }
}
