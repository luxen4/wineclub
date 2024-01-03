using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.Windows.Forms;
using System.Drawing;
using System.IO;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TextBox;
using System.Net;
using System.Security.Policy;
using System.Runtime.InteropServices.ComTypes;

namespace proyectovinos
{
    internal class CumplimentarPictureBoxes
    {

        Consultas consultas = new Consultas();
        Utilidades ut = new Utilidades();

        // Para solo proveedores
        public void cumplimentarPictureBox(string referencia, PictureBox pictureBox1)
        {
            string nombreClaseVino = consultas.obtenerCualquierNombre("id_clasevino", "clasevino", "ref", referencia);

            ConexionBD con = new ConexionBD();
            string cadenaConexion = con.conexion();
            MySqlConnection conexionBD = new MySqlConnection(cadenaConexion);



            string selectQuery = "select p.id_proveedor as id_proveedor, p.nombre as nombreproveedor, a.nombreimagen from articulo as a " +
                " inner join proveedor as p on p.id_proveedor = a.id_proveedor" +
                " WHERE a.ref =" + "'" + referencia + "'";

            conexionBD.Open();
            MySqlCommand command = new MySqlCommand(selectQuery, conexionBD);
            MySqlDataReader reader = command.ExecuteReader();



            while (reader.Read())
            {
                int id_proveedor = Int32.Parse(reader.GetString("id_proveedor"));
                string nombreImagen = reader.GetString("nombreImagen");

                try
                {
                    string folderPath = ClaseCompartida.carpetaimg_absoluta + "proveedores/" + id_proveedor + "/articulos/" + nombreClaseVino + "/" + nombreImagen;

                    using (StreamReader stream = new StreamReader(folderPath))
                    {
                        pictureBox1.Image = Image.FromStream(stream.BaseStream);
                    }
                    // https://es.stackoverflow.com/questions/253118/error-al-liberar-imagen
                    

                    // loadImageFromUri("https://wineclub.000webhostapp.com/img/empleados/aoito.jpg", pictureBox1);

                    /*
                    // 000Webhostapp
                    string uri = "https://wineclub.000webhostapp.com/img/proveedores/" 
                        + id_proveedor + "/articulos/" + nombreClaseVino.ToLower() + "/" + nombreImagen;
                    loadImageFromUri(uri, pictureBox1);
                    */


                }
                catch (Exception ex)
                {
                    // pictureBox1.Image = Image.FromFile(@"../../img/proveedores/botellapredeterminada.jpg");

                    string folderPath = ClaseCompartida.carpetaimg_absoluta + "proveedores/botellapredeterminada.jpg";
                    using (StreamReader stream = new StreamReader(folderPath))
                    {
                        pictureBox1.Image = Image.FromStream(stream.BaseStream);
                    }
                } 
            }
        }



            private void loadImageFromUri(string uri, PictureBox pictureBox1)
            {  
                var request = WebRequest.Create(uri);
                using (var response = request.GetResponse())
                using (var stream1 = response.GetResponseStream())
                {
                    pictureBox1.Image = Bitmap.FromStream(stream1);
                }
            }




        // Método que agrega una imagen en un pictureBox 
        public void cumplimentarPictureBoxDinamico(string atributo, string tabla, string atributoWhere, string valorAtributo, PictureBox pictureBox1, string rutacarpeta)
        {
            ConexionBD con = new ConexionBD();
            string cadenaConexion = con.conexion();
            MySqlConnection conexionBD = new MySqlConnection(cadenaConexion);

            string selectQuery = "select " + atributo + " as resultado from " + tabla + " WHERE " + atributoWhere + " = " + "'" + valorAtributo + "'";

            conexionBD.Open();
            MySqlCommand command = new MySqlCommand(selectQuery, conexionBD);
            MySqlDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {

                string nombreImagen = reader.GetString("resultado");
                string[] cascos = nombreImagen.Split('.');
                string carpeta = cascos[0];
                carpeta = ut.limpiezaDeString(carpeta);

                agregarImagenPictureBox(rutacarpeta, carpeta, nombreImagen, pictureBox1);
            }
        }


        // Método que agrega una imagen en un pictureBox 
        public void cumplimentarPictureBoxDinamicoSocio(string atributo, string tabla, string atributoWhere, string valorAtributo, PictureBox pictureBox1, string rutacarpeta)
        {
            ConexionBD con = new ConexionBD();
            string cadenaConexion = con.conexion();
            MySqlConnection conexionBD = new MySqlConnection(cadenaConexion);

            string selectQuery = "select " + atributo + " as resultado from " + tabla + " WHERE " + atributoWhere + " = " + "'" + valorAtributo + "'";

            conexionBD.Open();
            MySqlCommand command = new MySqlCommand(selectQuery, conexionBD);
            MySqlDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {

                string nombreImagen = reader.GetString("resultado");
                string[] cascos = nombreImagen.Split('.');
                string carpeta = cascos[0];
                carpeta = ut.limpiezaDeString(carpeta);

                // agregarImagenPictureBox(rutacarpeta, carpeta, nombreImagen, pictureBox1);
            }
        }

        
        // Método que agrega una imagen de Empleado a un PictureBox
        private void agregarImagenPictureBox(string rutacarpeta, string carpeta, string nombreImagen, PictureBox pictureBox1)
        {
            
            try
            {
                string folderPath = ClaseCompartida.carpetaimg_absoluta + rutacarpeta + " / " + carpeta + "/perfil/" + nombreImagen;
              
                using (StreamReader stream = new StreamReader(folderPath))
                   
                {
                    pictureBox1.Image = Image.FromStream(stream.BaseStream);
                }
            }
            catch (Exception ex)
            {
                string folderPath = ClaseCompartida.carpetaimg_absoluta + rutacarpeta + " / predeterminada.jpg";
                using (StreamReader stream = new StreamReader(folderPath))
                {
                    pictureBox1.Image = Image.FromStream(stream.BaseStream);
                }
            }
        }


    // Método que agrega una imagen de Proveedor a un pictureBox
        public void cumplimentarPictureBoxProveedor(int id_proveedor, PictureBox pictureBox1)
        {
            try
            {
                string folderPath = ClaseCompartida.carpetaimg_absoluta + "proveedores/" + id_proveedor + "/logo/foto1.jpg";
                //MessageBox.Show(folderPath);

                using (StreamReader stream = new StreamReader(folderPath))
                {
                    pictureBox1.Image = Image.FromStream(stream.BaseStream);
                }
            }
            catch (Exception ex)
            {
                string folderPath = ClaseCompartida.carpetaimg_absoluta + "proveedores/logo2/logopredeterminada.jpg";
                using (StreamReader stream = new StreamReader(folderPath))
                {
                    pictureBox1.Image = Image.FromStream(stream.BaseStream);
                }
            }
            // https://es.stackoverflow.com/questions/253118/error-al-liberar-imagen

        }



        // Método que permite buscar una imagen en el PC
        public void buscarImagenPicturebox(object sender, EventArgs e, PictureBox pictureBox)
        {
            OpenFileDialog ofdSeleccionar = new OpenFileDialog();
            ofdSeleccionar.Filter = "Imagenes|*.jpg; *.png";
            ofdSeleccionar.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyPictures);
            ofdSeleccionar.Title = "Seleccionar imagen";

            if (ofdSeleccionar.ShowDialog() == DialogResult.OK)
            {
                pictureBox.Image = Image.FromFile(ofdSeleccionar.FileName);
                pictureBox.BackgroundImage = Image.FromFile(ofdSeleccionar.FileName);
            }
        }


        // Socios
        internal void agregarImagenPictureBox(int id_socio, PictureBox pictureBox1)
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
    }
}

//  Con CSharp y Asp.Net | Tutorial Cómo Cargar Archivos Vía FTP En C#