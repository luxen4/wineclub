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
using proyectovinos;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TextBox;

namespace proyectovinos.Empleados
{
    public partial class Form_ModificarEmpleado : Form
    {
        public Form_ModificarEmpleado()
        {
            InitializeComponent();
            this.CenterToScreen();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        string carpetaempleadoAnterior = "";
        CumplimentarComboboxes cumplimentarComboboxes=new CumplimentarComboboxes();
        CumplimentarPictureBoxes cumplimentarPictureBoxes= new CumplimentarPictureBoxes();
        Consultas consultas = new Consultas();
        Class_Empleado empleado = new Class_Empleado();
        Utilidades ut = new Utilidades();

        private string nombreApellidosAntiguos = "";


        private void Form_ModificarEmpleado_Load(object sender, EventArgs e)
        {
            this.CenterToScreen();
            this.Top = this.Top + 20;
            cumplimentarComboboxes.cumplimentarComboNombreEmpleado(comboBox_empleado);
            cumplimentarComboboxes.refrescarCombo("nombre","rollempleado",combo_roll);
        }

        private int id_empleado = 0;

        private void comboBox_empleado_SelectedIndexChanged(object sender, EventArgs e)
        {

           // Rellenar campos
            id_empleado=empleado.obtener_id_EmpleadoDesdeNombreApellidos(comboBox_empleado);
           cumplimentarCamposEmpleado(id_empleado);

           string referencia = text_referencia.Text;
        

            string [] datos = empleado.datosEmpleado(referencia);
            string carpeta = datos[0] + datos[1] + datos[2];
            carpeta =  ut.limpiezaDeString(carpeta);


            try
            {
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


            carpetaempleadoAnterior = text_nombre.Text + text_apellido1.Text + text_apellido2.Text;
            carpetaempleadoAnterior = ut.limpiezaDeString(carpetaempleadoAnterior);
        }



        private string n_referencia = "", n_nombre = "", n_apellido1 = "", n_apellido2 = "",
            n_telefono = "", n_email = "", n_sexo = "", fechanacimiento = "", cargo = "";

        private void label11_Click(object sender, EventArgs e)
        {

        }

        private bool haCambiado=false;


        private void pictureBox1_BackgroundImageChanged(object sender, EventArgs e)
        {
            haCambiado = true;
            //MessageBox.Show("Ha cambiado");
        }

        private int n_id_rollempleado = 0;


        private void button10_Click(object sender, EventArgs e)
        { 
            n_referencia = text_referencia.Text;
            n_nombre = text_nombre.Text;
            n_apellido1 = text_apellido1.Text;
            n_apellido2 = text_apellido2.Text;
            n_telefono = text_telefono.Text;
            n_email = text_email.Text;

            if (radio_hombre.Checked)
            {
                n_sexo = "Hombre";
            }
            else {
                n_sexo = "Mujer";
            }

            fechanacimiento = dateTime_fechanacimiento.Text;
            fechanacimiento = ut.preparacionFecha(fechanacimiento);
            cargo = combo_roll.Text;

            n_id_rollempleado = consultas.obtenerCualquierId("id_rollempleado","rollempleado","nombre", cargo);


            bool insertado = modificarEmpleado();


            if (haCambiado == true)
            {
                 pictureBox1.Image.Save(ClaseCompartida.carpetaimg_absoluta + "empleados/" + id_empleado + "/perfil/foto1.jpg", System.Drawing.Imaging.ImageFormat.Jpeg);
            }
            else
            {
                //pictureBox1.Image.Save(ClaseCompartida.carpetaimg_absoluta + "empleados/" + carpetaempleadoAnterior + "/perfil/foto1.jpg", System.Drawing.Imaging.ImageFormat.Jpeg);
            }

            comboBox_empleado.Items.Clear();
            cumplimentarComboboxes.cumplimentarComboNombreEmpleado(comboBox_empleado);

            this.Close();
        }




        private void button11_Click(object sender, EventArgs e)
        {
            cumplimentarPictureBoxes.buscarImagenPicturebox(sender, e, pictureBox1);
        }

        private void button5_Click(object sender, EventArgs e)
        {
            text_referencia.Text = "";
            text_nombre.Text = "";
            text_apellido1.Text = "";
            text_apellido2.Text = "";
            text_telefono.Text = "";
            text_email.Text = "" ;
            radio_hombre.Checked = true;
            dateTime_fechanacimiento.Text = DateTime.Now.ToString();
            combo_roll.Text = "Seleccione";
            pictureBox1.Image = null;
        }



        // Solo es aquí
        private void cumplimentarCamposEmpleado(int id_empleado)
        {
            ConexionBD con = new ConexionBD();
            string cadenaConexion = con.conexion();
            MySqlConnection conexionBD = new MySqlConnection(cadenaConexion);

            try
            {
                string selectQuery = "select e.ref as referencia, e.nombre as nombre, " +
                    "e.apellido1 as apellido1, " +
                    "e.apellido2 as apellido2, " +
                    "e.telefono as telefono, " +
                    "e.email as email, " +
                    "e.sexo as sexo, " +
                    "r.nombre as nombreroll, " +
                    "e.fechanacimiento as fechanacimiento from empleado e " +
                    "inner join rollempleado r on r.id_rollempleado = e.id_rollempleado where e.id_empleado = " + id_empleado + "   ";


                //MessageBox.Show(selectQuery);

                conexionBD.Open();
                MySqlCommand command = new MySqlCommand(selectQuery, conexionBD);
                MySqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    text_referencia.Text = reader.GetString("referencia");
                    text_nombre.Text = reader.GetString("nombre");
                    text_apellido1.Text = reader.GetString("apellido1");
                    text_apellido2.Text = reader.GetString("apellido2");
                    text_telefono.Text = reader.GetString("telefono");
                    text_email.Text = reader.GetString("email");

                    nombreApellidosAntiguos = reader.GetString("nombre") + reader.GetString("apellido1") + reader.GetString("apellido2");
                    carpetaempleadoAnterior = ut.limpiezaDeString(nombreApellidosAntiguos);

                    string sexo = reader.GetString("sexo");

                    if (sexo == "Hombre")
                    {
                        radio_hombre.Checked = true;
                    }
                    else
                    {
                        radio_mujer.Checked = true;
                    }
                    dateTime_fechanacimiento.Text = reader.GetString("fechanacimiento");
                    combo_roll.Text = reader.GetString("nombreroll");

                }
                comboBox_empleado.Text = "Seleccione";

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                conexionBD.Close();
            }
        }




        // Método que modifica un empleado
        private bool modificarEmpleado()
        {
            ConexionBD con = new ConexionBD();
            string cadenaConexion = con.conexion();
            MySqlConnection conexionBD = new MySqlConnection(cadenaConexion);
            MySqlDataReader reader = null;

            try
            {
                string consulta = "update empleado SET nombre='" + n_nombre + "'" +
                                            ", apellido1='" + n_apellido1 + "'" +
                                            ", apellido2='" + n_apellido2 + "'" +
                                            ", telefono='" + n_telefono + "'" +
                                            ", email='" + n_email + "'" +
                                            ", sexo='" + n_sexo + "'" +
                                            ", fechanacimiento='" + fechanacimiento + "'" +
                                            ", id_rollempleado=" + n_id_rollempleado + "" +
                                            " WHERE ref =" + "'" + n_referencia + "' ";

                MySqlCommand comando = new MySqlCommand(consulta);
                comando.Connection = conexionBD;
                conexionBD.Open();
                reader = comando.ExecuteReader();

                // MessageBox.Show(consulta);
                MessageBox.Show(ClaseCompartida.msgInsertado);


            }

            catch (MySqlException ex)
            {
                MessageBox.Show(ex.Message);
                return false;
            }
            finally
            {
                conexionBD.Close();
            }
            return true;
        }
    }
}


// Luego nos cargamos la imagen, debemos salvarla antes
/*
 pictureBox_empleado.Image = Image.FromFile(@"../../img/empleados/" + carpetaempleadoAnterior + "/perfil/" + nombreimagen);

 pictureBox_empleado.Image.Save(@"../../img/empleados/logo.jpg", System.Drawing.Imaging.ImageFormat.Jpeg); // Salvada

 string folderPath = @"../../img/empleados/" + carpetaempleadoAnterior + "/perfil/" + nombreimagen;
 using (StreamReader stream = new StreamReader(folderPath))
 {
     MessageBox.Show(folderPath);
     pictureBox_empleado.Image = Image.FromStream(stream.BaseStream);
 }

 //pictureBox_empleado.Image = null;
 pictureBox_empleado.Image = Image.FromFile(@"../../img/empleados/logo.jpg");
*/


/*  System.IO.Directory.Move(@"../../img/empleados/" + carpetaempleadoAnterior + "/perfil" ,
      @"../../img/empleados/perfil");*/



//System.IO.Directory.Move(@".. /../img/proveedores/" + nombrecarpetaActual, @"../../img/proveedores/" + nombrecarpetaModificado + " ");

// Borrar la carpeta
//  string folderPath1 = @"../../img/empleados/" + carpetaempleadoAnterior;
//   Directory.Delete(folderPath1, true);

/*
                    // Crear la carpeta
                    string n_folderPath = @"../../img/empleados/" + carpetaempleado;
                    Directory.CreateDirectory(n_folderPath); 
                    MessageBox.Show("Directorio creado");
                    Console.WriteLine(n_folderPath);*/

// pictureBox_empleado.Image.Save(@"../../img/empleados/" + carpetaempleado + "/perfil/" + nombreimagen, System.Drawing.Imaging.ImageFormat.Jpeg);

//System.IO.Directory.Move(@"../../img/empleados/perfil", @"../../img/empleados/" + carpetaempleado + "/perfil");


//System.IO.Directory.Move(@"../../img/empleados/" + carpetaempleadoAnterior, @"../../img/empleados/" + n_carpeta + " ");


/*
    if (pictureBox1 == null)
    {
        MessageBox.Show("No hemos tocado la imagen");
        MessageBox.Show(@"../../img/empleados/" + carpetaempleado + "/perfil/" + nombreimagen);
        pictureBox1.Image = Image.FromFile(@"../../img/empleados/" + carpetaempleado + "/perfil/" + nombreimagen);
        pictureBox1.Image.Save(@"../../img/empleados/" + carpetaempleado + "/perfil/" + nombreimagen);
    }
    else
    {
        MessageBox.Show("Hemos tocado la imagen");
        pictureBox1.Image.Save(@"../../img/empleados/" + carpetaempleado + "/perfil/" + nombreimagen);
    }*/