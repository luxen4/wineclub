using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using proyectovinos.Movimientos.AlmacenTienda;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using Image = System.Drawing.Image;
using ListView = System.Windows.Forms.ListView;
using ListViewItem = System.Windows.Forms.ListViewItem;

namespace proyectovinos.Socios
{
    public class Class_Socio
    {

        Utilidades ut = new Utilidades();
        Consultas consultas = new Consultas();

        /// <summary>
        /// Método que devuelve los datos de un Socio
        /// </summary>
        /// <param name="id_socio"></param>
        /// <returns></returns>
        public string[] datosSocioo(int id_socio){

            string[] datosSocio = new string[10];

            ConexionBD con = new ConexionBD();
            string cadenaConexion = con.conexion();
            MySqlConnection conexionBD = new MySqlConnection(cadenaConexion);

            try
            {
                string selectQuery = "select ref, nombre, apellidos, localidad, provincia, sexo, nif, telefono, email, recibir_info from socio where id_socio= " + id_socio;

                conexionBD.Open();
                MySqlCommand command = new MySqlCommand(selectQuery, conexionBD);
                MySqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    string nombre = reader.GetString("nombre");             datosSocio[0] = nombre;
                    string apellidos = reader.GetString("apellidos");       datosSocio[1] = apellidos;
                    string localidad = reader.GetString("localidad");       datosSocio[2] = localidad;
                    string provincia = reader.GetString("provincia");       datosSocio[3] = provincia;
                    string sexo = reader.GetString("sexo");                 datosSocio[4] = sexo;
                    string nif = reader.GetString("nif");                   datosSocio[5] = nif;
                    string telefono = reader.GetString("telefono");         datosSocio[6] = telefono;
                    string email = reader.GetString("email");               datosSocio[7] = email;
                    string recibirInfo = reader.GetString("recibir_info");  datosSocio[8] = recibirInfo;
                    string referencia = reader.GetString("ref");     datosSocio[9] = referencia;

                    // string nombreApellidos = nombre + " " + apellidos;              datosSocio[0] = nombreApellidos;
                }

            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
            finally { conexionBD.Close(); }


            return datosSocio;
        }



        /// <summary>
        /// Método que registra la Venta de un Socio
        /// </summary>
        /// <param name="id_ventasocio"></param>
        /// <param name="id_empleado"></param>
        /// <param name="id_socio"></param>
        /// <param name="fechaActual"></param>
        /// <returns></returns>
        public bool registrarVentaSocio(int id_ventasocio,int id_empleado,int id_socio, string fechaActual)
        {/* '2023-07-16 8:21:11 ' timeStamp*/

            string refVentaSocio = "VSO" + id_ventasocio;
            

            ConexionBD con = new ConexionBD();
            string cadenaConexion = con.conexion();
            MySqlConnection conexionBD = new MySqlConnection(cadenaConexion);
            MySqlDataReader reader = null;

            try
            {
                string selectQuery = "insert into ventasocio (id_ventasocio, ref, id_empleado, id_socio, fecha) " +
                    " values(" + id_ventasocio + 
                    ", '" + refVentaSocio + "'" +
                    ", " + id_empleado + "" +
                    ", " + id_socio + " " +
                    ", '" + fechaActual + "'  )";  

                MySqlCommand comando = new MySqlCommand(selectQuery);
                comando.Connection = conexionBD;
                conexionBD.Open();
                reader = comando.ExecuteReader();

                MessageBox.Show("Venta a Socio Registrada");
                conexionBD.Close();

                ClaseCompartida.refVentaSocio = refVentaSocio;

                return true;
            }
            catch (MySqlException ex) { MessageBox.Show(ex.Message);
                conexionBD.Close();
                return false;
            }
            finally { conexionBD.Close(); }
        }



        /// <summary>
        /// Método que cumplimenta la lista de Socios
        /// </summary>
        /// <param name="listView1"></param>
        /// <param name="activo"></param>
        public void infoLista(ListView listView1, char activo)
        {
            ConexionBD con = new ConexionBD();
            string cadenaConexion = con.conexion();
            MySqlConnection conexionBD = new MySqlConnection(cadenaConexion);
            MySqlDataReader reader = null;

            try
            {
                conexionBD.Close();
                string selectQuery = "select ref, nombre, apellidos from socio where activo='" + activo + "' ";
                conexionBD.Open();
                MySqlCommand command = new MySqlCommand(selectQuery, conexionBD);
                reader = command.ExecuteReader();


                while (reader.Read())
                {
                    ListViewItem itemAgregar = new ListViewItem(reader.GetString("ref"));
                    // itemAgregar.Checked = true;
                    itemAgregar.SubItems.Add(reader.GetString("nombre") + " " + reader.GetString("apellidos"));
                    listView1.Items.Add(itemAgregar);
                }

            }
            catch (MySqlException ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally { conexionBD.Close(); }
        }


        /// <summary>
        /// Método que obtiene el id_socio de una venta
        /// </summary>
        /// <param name="refVentaSocio"></param>
        /// <returns></returns>
        public int obtener_id_socioDesdeRefVentaSocio(string refVentaSocio)
        {
            int id_socio = 0;
            ConexionBD con = new ConexionBD();
            string cadenaConexion = con.conexion();
            MySqlConnection conexionBD = new MySqlConnection(cadenaConexion);

            try
            {
                string selectQuery = "select soc.id_socio as id_socio from socio soc " +
                    " inner join ventasocio v on soc.id_socio=v.id_socio " +
                    " where v.ref = '" + refVentaSocio + "' ";

                conexionBD.Open();
                MySqlCommand command = new MySqlCommand(selectQuery, conexionBD);
                MySqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    id_socio = Int32.Parse(reader.GetString("id_socio"));
                }
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
            finally { conexionBD.Close(); }

            return id_socio;
        }
        






   //Class_Socio socio = new Class_Socio();
        
        internal void socioHover(ListViewItemMouseHoverEventArgs e, PictureBox pictureBox1)
        {     
            string referencia = e.Item.Text;

            int id_socio = consultas.obtenerCualquierId("id_socio", "socio", "ref", referencia);
            string[] datosSocio = datosSocioo(id_socio);
            string nombre = datosSocio[0];
            string apellido1 = datosSocio[1];
            string carpeta = nombre + apellido1;
            carpeta = ut.limpiezaDeString(carpeta);

            //agregarImagenPictureBoxSocio(carpeta, pictureBox1);
        }

        /// <summary>
        /// Método que agrega una imagen de Empleado a un PictureBox
        /// </summary>
        /// <param name="id_socio"></param>
        /// <param name="pictureBox1"></param>
        public void agregarImagenPictureBoxSocio(int id_socio, PictureBox pictureBox1)
        {
            try
            {
                string folderPath = ClaseCompartida.carpetaimg_absoluta + "socios/" + id_socio + "/perfil/foto1.jpg";

                using (StreamReader stream = new StreamReader(folderPath))

                {
                    pictureBox1.Image = Image.FromStream(stream.BaseStream);
                }
            }
            catch (Exception ex)
            {
                string folderPath = ClaseCompartida.carpetaimg_absoluta + "socios/predeterminada.jpg";
                using (StreamReader stream = new StreamReader(folderPath))
                {
                    pictureBox1.Image = Image.FromStream(stream.BaseStream);
                }
            }
        }




        /// <summary>
        /// Método que cumplimenta una lista de datos de Socios
        /// </summary>
        /// <param name="listView1"></param>
        /// <param name="activo"></param>
        internal void cumplimentarListaSocios(ListView listView1, char activo)
        {
                ConexionBD con = new ConexionBD();
                string cadenaConexion = con.conexion();
                MySqlConnection conexionBD = new MySqlConnection(cadenaConexion);

                try
                {
                    string selectQuery = "select ref, nombre, apellidos, sexo, nif, telefono, localidad, provincia, email, recibir_info from socio where activo='" + activo+"'";
                    conexionBD.Open();
                    MySqlCommand command = new MySqlCommand(selectQuery, conexionBD);
                    MySqlDataReader reader = command.ExecuteReader();

                    while (reader.Read())
                    {
                        ListViewItem itemAgregar = new ListViewItem(reader.GetString("ref"));
                        itemAgregar.Checked = false;
                        itemAgregar.SubItems.Add(reader.GetString("nombre"));
                        itemAgregar.SubItems.Add(reader.GetString("apellidos"));
                        itemAgregar.SubItems.Add(reader.GetString("sexo"));
                        itemAgregar.SubItems.Add(reader.GetString("nif"));
                        itemAgregar.SubItems.Add(reader.GetString("telefono"));
                        itemAgregar.SubItems.Add(reader.GetString("localidad"));
                        itemAgregar.SubItems.Add(reader.GetString("provincia"));
                        itemAgregar.SubItems.Add(reader.GetString("email"));
                        itemAgregar.SubItems.Add(reader.GetString("recibir_info"));

                        listView1.Items.Add(itemAgregar);
                    }

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

        /// <summary>
        /// Salvars the imagen en carpeta socio.
        /// </summary>
        /// <param name="pictureBox1">The picture box1.</param>
        /// <param name="id_socio">The identifier socio.</param>
        internal void salvarImagenEnCarpetaSocio(PictureBox pictureBox1, int id_socio)
        {
            try
            {
                // string folderPath = @"C:\MyFoldera";
                string folderPath = ClaseCompartida.carpetaimg_absoluta + "socios/" + id_socio + "/perfil/";

                if (!Directory.Exists(folderPath))
                {
                    Directory.CreateDirectory(folderPath);
                    Console.WriteLine(folderPath);

                    salvarImagenSocio(pictureBox1, id_socio);
                }
                else {
                    salvarImagenSocio(pictureBox1, id_socio);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ClaseCompartida.msgErrorGeneral + "->" + ex);
            }
        }

        /// <summary>
        /// Salvars the imagen socio.
        /// </summary>
        /// <param name="pictureBox1">The picture box1.</param>
        /// <param name="id_socio">The identifier socio.</param>
        private void salvarImagenSocio(PictureBox pictureBox1, int id_socio)
        {
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
}


