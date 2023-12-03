using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.Windows.Forms;
using System.Reflection;
using System.Text.RegularExpressions;
using System.Drawing;
using System.IO;
using proyectovinos.ArticuloVino;
using proyectovinos.Caracteristicas.proveedor;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TextBox;

namespace proyectovinos
{
    internal class Utilidades
    {





        // Método que devuelve la fecha preparada para introducir en mysql (se recibe desde un dataPicker)           
        /// <summary>
        /// Preparación de fecha.
        /// </summary>
        /// <param name="fecha">The fecha.</param>
        /// <returns>fechacompra(*2023/12/31)</returns>
        public string preparacionFecha(string fecha)
        {

            string[] subs = fecha.Split();
            string dia = subs[1];
            string mesNombre = subs[3];
            string mes = "";

            if (mesNombre == "enero") { mes = "01"; }
            else if (mesNombre == "febrero") { mes = "02"; }
            else if (mesNombre == "marzo") { mes = "03"; }
            else if (mesNombre == "abril") { mes = "04"; }
            else if (mesNombre == "mayo") { mes = "05"; }
            else if (mesNombre == "junio") { mes = "06"; }
            else if (mesNombre == "julio") { mes = "07"; }
            else if (mesNombre == "agosto") { mes = "08"; }
            else if (mesNombre == "septiembre") { mes = "09"; }
            else if (mesNombre == "octubre") { mes = "10"; }
            else if (mesNombre == "noviembre") { mes = "11"; }
            else if (mesNombre == "diciembre") { mes = "12"; }


            string ano = subs[5];
            string fechacompra = ano + "/" + mes + "/" + dia;

            return fechacompra;

        }


        // Bloque que quita de todo
        /* https://www.elguille.info/colabora/NET2005/german_limpiar_acentos_puntonetwhidbey.htm */
        // Debug.WriteLine(textoSinAcentos); //muestra 'Manana sera otro dia'
        public string limpiezaDeString(string nombreEnBruto)
        {
            
            string rutaimagenBruto = nombreEnBruto;
            string textoNormalizado = rutaimagenBruto.Normalize(NormalizationForm.FormD);
            Regex reg = new Regex("[^a-zA-Z0-9 ]");
            string textoSinAcentos = reg.Replace(textoNormalizado, "");
            string textoSinespacios = textoSinAcentos.Trim();
            string textosinmayusculas = textoSinAcentos.ToLower();
            string nombreLimpio = Regex.Replace(textosinmayusculas, @"\s", "");

            return nombreLimpio;
        }




        // Método que formatea la fecha para introdución en Mysql "TimeStam"
        public string fechaTimeStam(DateTime fechaActual)
        {
            string fecha = fechaActual.ToString().Replace("/", "-");
            string[] cascosDia = fecha.Split(' ');
            string[] cascosPartesDia = cascosDia[0].Split('-');
            string fechaFinal = cascosPartesDia[2] + "-" + cascosPartesDia[1] + "-" + cascosPartesDia[0] + " " + cascosDia[1];

            return fechaFinal;
        }

        public void selecionarImagen(PictureBox pictureBox)
        {
            OpenFileDialog ofdSeleccionar = new OpenFileDialog();
            ofdSeleccionar.Filter = "Imagenes|*.jpg; *.png";
            ofdSeleccionar.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyPictures);
            ofdSeleccionar.Title = "Seleccionar imagen";

            if (ofdSeleccionar.ShowDialog() == DialogResult.OK)
            {
                pictureBox.Image = Image.FromFile(ofdSeleccionar.FileName);
            }
        }


       





        internal void habilitarOnOff_Caracteristica( string tabla, string whereAtributo, string valorAtributo, char activo)
        {
                ConexionBD con = new ConexionBD();
                string cadenaConexion = con.conexion();
                MySqlConnection conexionBD = new MySqlConnection(cadenaConexion);
                MySqlDataReader reader = null;

                try
                {
                    //string selectQuery = "delete from " + tabla + " WHERE " + whereAtributo + " = " + "'" + valorAtributo + "'";
                    string selectQuery = "update " + tabla + " SET " + "activo= '" + activo + "' WHERE " + whereAtributo + " = " + "'" + valorAtributo + "' ";
              

                    MySqlCommand comando = new MySqlCommand(selectQuery);
                    comando.Connection = conexionBD;
                    conexionBD.Open();
                    reader = comando.ExecuteReader();
                    MessageBox.Show(ClaseCompartida.msgModificado);

                }
                catch (MySqlException ex)
                {
                    MessageBox.Show(ex.Message);
                }
                finally { conexionBD.Close(); }
        }





        internal void checkMarcadoTodos(bool cargaLista, ItemCheckedEventArgs e, TextBox text_referencia, string tabla, TextBox text_nombre)
        {
            if (cargaLista == false)
            {
                string referencia = e.Item.Text;
                text_referencia.Text = referencia;

                Consultas consultas = new Consultas();
                string nombre = consultas.obtenerCualquierRefDesdeNombre("nombre", tabla, "ref", referencia);
                text_nombre.Text = nombre;
            }
        }

        internal void checkMarcadoModificar(bool cargaLista, ItemCheckedEventArgs e, TextBox text_nombreactual, TextBox text_referenciaactual)
        {
            if (cargaLista == false)
            {
                string referenciaActual = e.Item.Text;
                text_referenciaactual.Text = referenciaActual;
            }
        }


   


        internal void limpiarCampos(TextBox text_nuevonombre, TextBox text_nuevareferencia, TextBox text_referencia, TextBox text_nombre, CheckBox check_seguro1, CheckBox check_seguro2)
        {
            text_nuevonombre.Text = "";
            text_nuevareferencia.Text = "";
            text_referencia.Text = "";
            text_nombre.Text = "";
            check_seguro1.Checked = false;
            check_seguro2.Checked = false;
        }

        internal void limpiarCamposModificar(TextBox text_referenciaactual, TextBox text_nuevonombre, TextBox text_nuevareferencia)
        {
            text_referenciaactual.Text = "";
            text_nuevonombre.Text = "";
            text_nuevareferencia.Text = "";
        }
        

        internal void checkMarcadoEliminar(bool cargaLista, ItemCheckedEventArgs e, string tabla, TextBox text_referenciaeliminar, TextBox text_nombreeliminar)
        {
            if (cargaLista == false)
            {
                string referencia = e.Item.Text;
                text_referenciaeliminar.Text = referencia;
                Consultas consultas = new Consultas();
                string nombre = consultas.obtenerCualquierRefDesdeNombre("nombre", tabla, "ref", referencia);
                text_nombreeliminar.Text = nombre;

                text_referenciaeliminar.Text = referencia;
                text_nombreeliminar.Text = nombre;
            }
        }

        // Función que elimina una característica de un artículo
        // General para todas
        internal bool controladorEliminarCaracteristica(CheckBox check_seguroeliminar, TextBox text_referenciaeliminar, TextBox text_nombreeliminar, string id_tabla, string tabla, ListView listView1)
        {
            if (check_seguroeliminar.Checked)
            {
                if (text_referenciaeliminar.Text != "")
                {
                    Consultas consultas = new Consultas();
                    int id = consultas.obtenerCualquierId(id_tabla, tabla, "ref", text_referenciaeliminar.Text);

                    Class_Articulo articulo = new Class_Articulo();
                    int existencias = articulo.existeArticuloConCaracteristica("id_articulo", "articulo", id_tabla, id);

                    if (existencias > 0)
                    {
                        MessageBox.Show(existencias + ClaseCompartida.msgArticulosTipo);
                        return false;
                    }
                    else
                    {
                        consultas.eliminarCaracteristica(tabla, "ref", text_referenciaeliminar.Text);
                        return true;
                    }
                }
                else
                {
                    MessageBox.Show(ClaseCompartida.msgCamposEnBlanco);
                    return false;
                }
            }
            else
            {
                MessageBox.Show(ClaseCompartida.msgCasillaSeguro);
                return false;
            }
        }


        // Método que deja los campos para el formulario de eliminar en modo predeterminado
        internal void limpiarCamposEliminar(TextBox text_referenciaeliminar, TextBox text_nombreeliminar, CheckBox check_seguroeliminar)
        {
            text_referenciaeliminar.Text = "";
            text_nombreeliminar.Text = "";
            check_seguroeliminar.Checked = false;
        }

        // Método que deja los campos para el formulario de desabilitar en modo predeterminado
        internal void limpiarCamposNuevoDeshabilitar(CheckBox check_segurodesabilitar, TextBox text_referenciadeshabilitar, TextBox text_nombredeshabilitar)
        {
            check_segurodesabilitar.Checked = false;
            text_referenciadeshabilitar.Text = "";
            text_nombredeshabilitar.Text = "";
        }
        
        internal void controladorHabilitarCaracteristica(CheckBox check_segurodesabilitar, TextBox text_referenciadeshabilitar,
            TextBox text_nombredeshabilitar, string tabla, ListView listView1, char activo)
        {
            if (check_segurodesabilitar.Checked)
            {
                if (text_nombredeshabilitar.Text == "" || text_referenciadeshabilitar.Text == "")
                {
                    MessageBox.Show(ClaseCompartida.msgCamposEnBlanco);
                }
                else
                {
                    habilitarOnOff_Caracteristica(tabla, "ref", text_referenciadeshabilitar.Text, activo);

                    //char refrescar = '0';
                    if (activo == '1')
                    {
                        activo = '0';
                    }
                    else {
                        activo = '1';
                    }
                    CumplimentarListas cumplimentarListas = new CumplimentarListas();
                    cumplimentarListas.cumplimentarLista("ref", "nombre", tabla, listView1, activo);
                    limpiarCamposNuevoDeshabilitar(check_segurodesabilitar, text_referenciadeshabilitar, text_nombredeshabilitar);
                }
            }
            else
            {
                MessageBox.Show(ClaseCompartida.msgCasillaSeguro);
            }
        }


        internal void controladorEliminarRegistroTablaMadre(CheckBox check_seguroeliminar, TextBox text_referenciaeliminar, TextBox text_nombreeliminar, string idTablaDependiente, string tabladependiente, string id_tabla, string tabla, ListView listView1)
        {   
            // Caso de variedad de uva 
            // private string tabladependiente = "tipouva";
            // private string idTablaDependiente = "id_tipouva";

            // Caso de roll
            // private string tabladependiente = "empleado";
            // private string idTablaDependiente = "id_empleado";

            if (check_seguroeliminar.Checked)
            {
                if (text_referenciaeliminar.Text != "")
                {
                    Consultas consultas = new Consultas();
                    int id = consultas.obtenerCualquierId(id_tabla, tabla, "ref", text_referenciaeliminar.Text);

                    Class_Articulo articulo = new Class_Articulo();
                    int existencias = articulo.existeArticuloConCaracteristica(idTablaDependiente, tabladependiente, id_tabla, id);

                    if (existencias > 0)
                    {
                        MessageBox.Show(existencias + ClaseCompartida.msgArticulosTipo);
                    }
                    else
                    {
                        
                        consultas.eliminarCaracteristica(tabla, "ref", text_referenciaeliminar.Text);
                        CumplimentarListas cumplimentarListas = new CumplimentarListas();
                        cumplimentarListas.cumplimentarLista("ref", "nombre", tabla, listView1, '1');
                        limpiarCamposEliminar(text_referenciaeliminar, text_nombreeliminar, check_seguroeliminar);
                    }
                }
                else{ MessageBox.Show(ClaseCompartida.msgCamposEnBlanco); }
            }else {
                MessageBox.Show(ClaseCompartida.msgCasillaSeguro);
            }
        }


        // Método que elimina la carpeta de un Empleado (prueba con proveedores tb)
        internal void eliminarCarpeta(string carpeta, int id_)
        {

            string folderPath = ClaseCompartida.carpetaimg_absoluta + carpeta + "/" + id_;
            try
            {
                Directory.Delete(folderPath, true);
                //MessageBox.Show("Directorio eliminado: " + folderPath);

            }
            catch (Exception ex)
            {
                MessageBox.Show("The process failed: {0}", ex.Message);
            }
        }

        internal void limpiarCampos(RadioButton radioButton_habilitado, RadioButton radioButton_deshabilitado, CheckBox check_segurohabilitardeshabilitareliminar1, TextBox textBox_referencia, TextBox textBox_nombre, Button button_habilitar, Button button_deshabilitar, Button button_eliminar, TextBox text_referencianuevo, TextBox text_nombrenuevo, TextBox textBox_referenciamodificar, TextBox textBox_nombremodificar, CheckBox check_nueva, CheckBox check_modificar, CheckBox check_segurohabilitardeshabilitareliminar2, CheckBox check_seguronuevo, CheckBox checkBox_seguromodificar, bool listaCargada1, object v, bool listaCargada2)
        {
            throw new NotImplementedException();
        }
    }
}



/*
internal void modificacionNombreCarpetaProveedor(string directorio, string carpetaempleadoAnterior, string n_carpeta)
{

    // Mueve la imagen
    string sourceFilePath = ClaseCompartida.carpetaimg_absoluta + directorio + " / " + carpetaempleadoAnterior + "/logo/foto1.jpg";
    string destinationFilePath = ClaseCompartida.carpetaimg_absoluta + directorio + " / logo/foto1.jpg";
    File.Move(sourceFilePath, destinationFilePath);

    // Borra la carpeta
    string folderPath = ClaseCompartida.carpetaimg_absoluta + directorio + " / " + carpetaempleadoAnterior + "/logo ";
    Directory.Delete(folderPath, true);

    // Crea nueva carpeta
    string n_folderPath = ClaseCompartida.carpetaimg_absoluta + directorio + " / " + n_carpeta + "/logo";
    Directory.CreateDirectory(n_folderPath);

    // Mueve la imagen a la nueva carpeta
    sourceFilePath = ClaseCompartida.carpetaimg_absoluta + directorio + " / logo/foto1.jpg";
    destinationFilePath = ClaseCompartida.carpetaimg_absoluta + directorio + " / " + n_carpeta + "/logo/foto1.jpg";
    File.Move(sourceFilePath, destinationFilePath);

    // Mover carpetas interiores
    System.IO.Directory.Move(ClaseCompartida.carpetaimg_absoluta + "proveedores/" + carpetaempleadoAnterior + "/articulos", @"../../img/proveedores/" + n_carpeta + "/articulos");


    // Borra la carpeta
     folderPath = ClaseCompartida.carpetaimg_absoluta + "proveedores/" + carpetaempleadoAnterior + "";
     Directory.Delete(folderPath, true);

}*/



/*
   internal void modificacionNombreCarpeta(string directorio, string carpetaempleadoAnterior, string n_carpeta)
   {   // Esto meter el id único en vez de nombre del empleado
       // Mueve la imagen
       string sourceFilePath = ClaseCompartida.carpetaimg_absoluta + directorio + "/" + carpetaempleadoAnterior + "/perfil/foto1.jpg";
       MessageBox.Show(sourceFilePath);
       string destinationFilePath = ClaseCompartida.carpetaimg_absoluta + directorio + "/" + n_carpeta + "/perfil/foto1.jpg";
       MessageBox.Show(destinationFilePath);
       File.Move(sourceFilePath, destinationFilePath);

       // Borra la carpeta
       string folderPath = ClaseCompartida.carpetaimg_absoluta + directorio + "/" + carpetaempleadoAnterior + " ";
       Directory.Delete(folderPath, true);

       // Crea nueva carpeta
       string n_folderPath = ClaseCompartida.carpetaimg_absoluta + directorio + "/" + n_carpeta + "/perfil";
       Directory.CreateDirectory(n_folderPath);

       // Mueve la imagen a la nueva carpeta
       sourceFilePath = ClaseCompartida.carpetaimg_absoluta + directorio + " /perfil/foto1.jpg";
       destinationFilePath = ClaseCompartida.carpetaimg_absoluta + directorio + "/" + n_carpeta + "/perfil/foto1.jpg";
       File.Move(sourceFilePath, destinationFilePath);

       // Borra la carpeta
       // folderPath = @"../../img/empleados/perfil";
       // Directory.Delete(folderPath, true);
   }
*/


/*
internal void insertCaracteristica(CheckBox check_seguronuevo, CheckBox check_seguro2, TextBox text_nombre, 
    TextBox text_nuevonombre, TextBox text_referencia, TextBox text_nuevareferencia, string tabla, 
    string nombreId, int valorId, string refPredeterminada, ListView listView1)
{

    //if (check_seguronuevo.Checked){

        string cadenaConexion = con.conexion();
        MySqlConnection conexionBD = new MySqlConnection(cadenaConexion);
        MySqlDataReader reader = null;

        try
        {
            string nombre = text_nuevonombre.Text;
            string referencia = text_nuevareferencia.Text;

           // if (text_nuevonombre.Text != "" && text_nuevareferencia.Text != ""){
                consultas.insertTablaCaracteristicasDinamico(tabla, nombreId, valorId, referencia, nombre);

               // cump.cumplimentarLista("ref", "nombre", tabla, listView1,'1');
                //limpiarCampos(text_nuevonombre, text_nuevareferencia, text_referencia, text_nombre, check_seguronuevo, check_seguro2);
               // limpiarCamposEliminar(text_nuevonombre,text_nuevareferencia,check_seguronuevo);
            //}else{ MessageBox.Show(ClaseCompartida.msgCamposEnBlanco);}
        }
        catch (MySqlException ex) { MessageBox.Show(ex.Message); }
        finally { conexionBD.Close(); }

    //} else{ MessageBox.Show(ClaseCompartida.msgCasillaSeguro); }
}*/