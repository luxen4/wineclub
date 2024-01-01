using System;
/*using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;*/
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace proyectovinos.Empleados.usuariocontrasena
{
    public partial class Form_ModificarEmpleadoUsuarioContrasena : Form
    {
        public Form_ModificarEmpleadoUsuarioContrasena()
        {
            InitializeComponent();
        }

        private void Form_ModificarEmpleadoUsuarioContrasena_Load(object sender, EventArgs e)
        {
            this.CenterToScreen();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {

            if (checkBox_seguro.Checked)
            {
ConexionBD con = new ConexionBD();
            string cadenaConexion = con.conexion();
            MySqlConnection conexionBD = new MySqlConnection(cadenaConexion);
            MySqlDataReader reader = null;

            string usuarioActual = textBox_usuarioactual.Text;
            string usuarioNuevo = textBox_nuevousuario.Text;
            string contrasenaActual = textBox_contrasenaactual.Text;
            string contrasenaNueva = textBox_nuevacontrasena.Text;


            Class_Empleado class_Empleado = new Class_Empleado();
                string contrasenaActualEncript = class_Empleado.encriptarSHA1(contrasenaActual);
                string contrasenaNuevaEncript = class_Empleado.encriptarSHA1(contrasenaNueva);

            /*
            string sexo = "";
            if (checkBox_seguro.Checked) {}
            else{ MessageBox.Show(ClaseCompartida.msgCasillaSeguro); }*/

            try
            { 
                string consulta = "update empleado SET usuario='" + usuarioNuevo + "'" +
                                        ", contrasena='" + contrasenaNuevaEncript + "'" +
                                        "  WHERE usuario = '" + usuarioActual + "' and contrasena= '" + contrasenaActualEncript + "' ";    


                MySqlCommand comando = new MySqlCommand(consulta);
                comando.Connection = conexionBD;
                conexionBD.Open();
               // reader = comando.ExecuteReader();

                // https://es.stackoverflow.com/questions/283891/como-recuperar-el-registro-acabado-de-insertar-en-mysql-con-c
                int rowafectadas = comando.ExecuteNonQuery();

                if (rowafectadas > 0)
                {
                    // MessageBox.Show(rowafectadas + " Datos Insertados");
                    MessageBox.Show("Usuario modificado");
                    }
                else
                {
                    MessageBox.Show("Error");
                }

                // MessageBox.Show(consulta);
                // MessageBox.Show(ClaseCompartida.msgModificado);

                ClaseCompartida.usuario = usuarioNuevo;
                ClaseCompartida.contrasena = contrasenaNueva;

                this.Close();
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
            else {
                MessageBox.Show(ClaseCompartida.msgCasillaSeguro);
            }

            
        }
    }
}
