using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.Windows.Forms;
using System.IO;
using System.Drawing;

namespace proyectovinos.Empleados
{
    internal class Class_Empleado
    {


    
        /// <summary>
        /// Función para salvar la imagen de nuevo Empleado (solo se utiliza en el crear)   
        /// </summary>
        /// <param name="id_empleado">The identifier empleado.</param>
        /// <param name="pictureBox1">The picture box1.</param>
        public void salvarImagenEnCarpetaEmpleado2(int id_empleado, PictureBox pictureBox1)
        {
            try
            {
                // string folderPath = @"C:\MyFoldera";
                string folderPath = ClaseCompartida.carpetaimg_absoluta + "empleados/" + id_empleado + "/perfil/";

                if (!Directory.Exists(folderPath))
                {
                    Directory.CreateDirectory(folderPath); 
                    // MessageBox.Show("Crea Directorio");
                    Console.WriteLine(folderPath);
                    
                    if (pictureBox1.Image != null)
                    {
                        //MessageBox.Show("Estoy");
                        pictureBox1.Image.Save(ClaseCompartida.carpetaimg_absoluta + "empleados/" + id_empleado + "/perfil/foto1.jpg", System.Drawing.Imaging.ImageFormat.Jpeg);
                    }
                    else
                    {
                        //MessageBox.Show("Estoyyy");
                        pictureBox1.Image = Image.FromFile(ClaseCompartida.carpetaimg_absoluta + "empleados/empleadopredeterminada.jpg");
                        pictureBox1.Image.Save(ClaseCompartida.carpetaimg_absoluta + "empleados/" + id_empleado + "/perfil/foto1.jpg", System.Drawing.Imaging.ImageFormat.Jpeg);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ocurrio un Error :\n " + ex);
            }
        }


        /// <summary>
        /// Método que guarda la imagen de un articulo y la presenta en un PictureBox
        /// </summary>
        /// <param name="carpetaempleado"></param>
        /// <param name="pictureBox_empleado"></param>
        private void agregarImagenPredeterminada(string carpetaempleado, PictureBox pictureBox_empleado)
        {
            //Local_absoluta
            pictureBox_empleado.Image = Image.FromFile(ClaseCompartida.carpetaimg_absoluta + "empleados/empleadopredeterminada.jpg");
            pictureBox_empleado.Image.Save(ClaseCompartida.carpetaimg_absoluta + "empleados/" + carpetaempleado + "/perfil/foto1.jpg", System.Drawing.Imaging.ImageFormat.Jpeg);

        }

        // Método que guarda la imagen de un articulo predeterminada y la presenta en un PictureBox
        private void agregarImagen(string carpetaempleado, PictureBox pictureBox_empleado)
        {
            // Local_absoluta
            pictureBox_empleado.Image.Save(ClaseCompartida.carpetaimg_absoluta + "empleados/" + carpetaempleado + "/perfil/foto1.jpg", System.Drawing.Imaging.ImageFormat.Jpeg);
            pictureBox_empleado.Image = Image.FromFile(ClaseCompartida.carpetaimg_absoluta + "empleados/" + carpetaempleado + "/perfil/foto1.jpg");
        }



        /// <summary>
        /// Método que encripta una contraseña
        /// </summary>
        /// <param name="vsValue"></param>
        /// <returns></returns>
        public string encriptarSHA1(string vsValue)
        {
            System.Security.Cryptography.HashAlgorithm hashValue = new System.Security.Cryptography.SHA1CryptoServiceProvider();

            // Convert the original string to array of Bytes
            byte[] byteValue = System.Text.Encoding.UTF8.GetBytes(vsValue);

            // Compute the Hash, returns an array of Bytes
            byte[] byteHash = hashValue.ComputeHash(byteValue);

            hashValue.Clear();

            // Return a base 64 encoded string of the Hash value
            return (Convert.ToBase64String(byteHash));
        }
        
        /// <summary>
        /// Método que devuelve el id_empleado desde su nombre y apellidos
        /// </summary>
        /// <param name="referencia"></param>
        /// <returns></returns>
        public int obtener_id_Empleado(string referencia)
        {
            int id_empleado = 0;

            ConexionBD con = new ConexionBD();
            string cadenaConexion = con.conexion();
            MySqlConnection conexionBD = new MySqlConnection(cadenaConexion);

            try
            {
                string selectQuery = "select id_empleado as id_empleado from empleado where ref = '" + referencia+ "' " ;

                conexionBD.Open();
                MySqlCommand command = new MySqlCommand(selectQuery, conexionBD);
                MySqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    id_empleado = Int32.Parse(reader.GetString("id_empleado"));
                }
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
            finally { conexionBD.Close(); }

            return id_empleado;
        }
        


        public string obtener_ref_Empleado(string nombreYapellidos)
        {
            string referencia = "";

            string[] cascos = nombreYapellidos.Split(' ');

            ConexionBD con = new ConexionBD();
            string cadenaConexion = con.conexion();
            MySqlConnection conexionBD = new MySqlConnection(cadenaConexion);

            try
            {
                string selectQuery = "select ref as referencia from empleado where " +
                    " nombre = '" + cascos[0] + "' " +
                    " and apellido1='" + cascos[1] + "'" +
                    " and apellido2='" + cascos[2] + "'";

                // MessageBox.Show(selectQuery);

                conexionBD.Open();
                MySqlCommand command = new MySqlCommand(selectQuery, conexionBD);
                MySqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    referencia = reader.GetString("referencia");
                }
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
            finally { conexionBD.Close(); }

            return referencia;
        }

        internal void insertarEmpleado()
        {
            throw new NotImplementedException();
        }

        internal string empleadoSeleccionado(int primeravez, ItemCheckedEventArgs e)
        {
            string nombreApellidos = "";

            if (primeravez == 1)
            {
                string refe = e.Item.Text; // MessageBox.Show("Referencia empleado " + refe);

                ConexionBD con = new ConexionBD();
                string cadenaConexion = con.conexion();
                MySqlConnection conexionBD = new MySqlConnection(cadenaConexion);

                try
                {
                    string selectQuery = "select nombre as nombre, apellido1 as apellido1, apellido2 as apellido2 from empleado where ref = '" + refe + "' order by ref asc";

                    conexionBD.Open();
                    MySqlCommand command = new MySqlCommand(selectQuery, conexionBD);
                    MySqlDataReader reader = command.ExecuteReader();

                    while (reader.Read())
                    {
                        nombreApellidos = reader.GetString("nombre") + " " + reader.GetString("apellido1") + " " + reader.GetString("apellido2");
                    }

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                    return null;

                }
                finally
                {
                    conexionBD.Close();
                }

                return nombreApellidos;

            }
            else {
                return null;
            }
        }


        public string[] datosEmpleado(string referencia)
        {
            string[] datos = new string[3];

            ConexionBD con = new ConexionBD();
            string cadenaConexion = con.conexion();
            MySqlConnection conexionBD = new MySqlConnection(cadenaConexion);


            try
            {
                string selectQuery = "select nombre as nombre, apellido1 as apellido1, apellido2 as apellido2 from empleado where ref = '" + referencia + "' order by ref asc";

                conexionBD.Open();
                MySqlCommand command = new MySqlCommand(selectQuery, conexionBD);
                MySqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    
                    datos[0] = reader.GetString("nombre");
                    datos[1] = reader.GetString("apellido1");
                    datos[2] = reader.GetString("apellido2");
                }
            }
            catch (Exception ex)
            { MessageBox.Show(ex.Message); }
            finally
            {
                conexionBD.Close();
            }

            return datos;
        }


        internal int obtener_id_EmpleadoDesdeNombreApellidos(ComboBox comboBox)
        {
            string[] cascos = comboBox.Text.Split(' ');
            string nombre = cascos[0];
            string apellido1 = cascos[1];
            string apellido2 = cascos[2];

            int id_empleado = 0;

            ConexionBD con = new ConexionBD();
            string cadenaConexion = con.conexion();
            MySqlConnection conexionBD = new MySqlConnection(cadenaConexion);


            try
            {
                string selectQuery = "select id_empleado as id from empleado " +
                    "where nombre = '" + nombre + "' " +
                    " and apellido1 = '" + apellido1 + "' " +
                    " and apellido2 = '" + apellido2 + "' " +
                    " order by ref asc";

                conexionBD.Open();
                MySqlCommand command = new MySqlCommand(selectQuery, conexionBD);
                MySqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    id_empleado = Int32.Parse(reader.GetString("id"));
                }
            }
            catch (Exception ex)
            { MessageBox.Show(ex.Message); }
            finally
            {
                conexionBD.Close();
            }

            return id_empleado;
        }

        internal bool modificarEmpleado()
        {
            throw new NotImplementedException();
        }


        // Función que cumplimenta una lista de empleados
        internal void cumplimentarlistasListaEmpleados(ListView listView1, char activo)
        {
                listView1.Items.Clear();

                ConexionBD con = new ConexionBD();
                string cadenaConexion = con.conexion();
                MySqlConnection conexionBD = new MySqlConnection(cadenaConexion);

                try
                {
                    string selectQuery = "select e.ref as referencia, e.nombre as nombrearticulo, e.apellido1 as apellido1, e.apellido2 as apellido2," +
                        " e.telefono as telefono, e.email as email, e.sexo as sexo, e.fechanacimiento as fechanacimiento, r.nombre as nombreroll " +
                        " from empleado as e " +
                        " inner join rollempleado as r on r.id_rollempleado= e.id_rollempleado where e.activo = '" + activo + "' ";

                    conexionBD.Open();
                    MySqlCommand command = new MySqlCommand(selectQuery, conexionBD);
                    MySqlDataReader reader = command.ExecuteReader();

                    while (reader.Read())
                    {
                        ListViewItem itemAgregar = new ListViewItem(reader.GetString("referencia"));
                        // itemAgregar.Checked = true;
                        itemAgregar.SubItems.Add(reader.GetString("nombrearticulo"));
                        itemAgregar.SubItems.Add(reader.GetString("apellido1"));
                        itemAgregar.SubItems.Add(reader.GetString("apellido2"));
                        itemAgregar.SubItems.Add(reader.GetString("telefono"));
                        itemAgregar.SubItems.Add(reader.GetString("email"));
                        itemAgregar.SubItems.Add(reader.GetString("sexo"));

                        string [] cascos = reader.GetString("fechanacimiento").Split(' ');
                        // itemAgregar.SubItems.Add(reader.GetString("fechanacimiento"));
                        itemAgregar.SubItems.Add(cascos[0]);
                        itemAgregar.SubItems.Add(reader.GetString("nombreroll"));
                        listView1.Items.Add(itemAgregar);
                    }
                }
                catch (Exception ex) { MessageBox.Show(ex.Message); }
                finally { conexionBD.Close(); }
        }


    }
}



/* ESTO VA A DESAPARECER
         /*
        public int countRoles()
        {
            int countRegistros = 0;

            ConexionBD con = new ConexionBD();
            string cadenaConexion = con.conexion();
            MySqlConnection conexionBD = new MySqlConnection(cadenaConexion);

            try
            {
                string selectQuery = "select count(id_rollempleado) as countregistros from rollempleado";

                conexionBD.Open(); // MessageBox.Show("Aquiii:" + selectQuery);
                MySqlCommand command = new MySqlCommand(selectQuery, conexionBD);
                MySqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    countRegistros = Int32.Parse(reader.GetString("countregistros"));
                }
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
            finally { conexionBD.Close(); }

            return countRegistros;
        }
*/

/* ESTO VA ADESAPARECER
         /*
        public void implementarPictureBoxEmpleado(int id_empleado, PictureBox pictureBox1)
        {
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
*/