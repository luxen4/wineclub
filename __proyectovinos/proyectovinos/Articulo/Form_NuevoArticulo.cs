using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

using MySql.Data.MySqlClient;
using proyectovinos.ArticuloVino;
using proyectovinos.Caracteristicas.catalogacion;
using proyectovinos.Caracteristicas.clasesvino;
using proyectovinos.Caracteristicas.contenido;
using proyectovinos.Caracteristicas.Denominacion;
using proyectovinos.Caracteristicas.empaquetado;
using proyectovinos.Caracteristicas.proveedor;
using proyectovinos.Caracteristicas.tipouva;

namespace proyectovinos
{
    public partial class Form_NuevoArticulo : Form
    {
        public object Presentacion { get; private set; }

        public Form_NuevoArticulo()
        {
            InitializeComponent();
        }

        private int id_proveedor = 0;
        private string referencia = "";

        private int id_predeterminado = 0;
        private string tabla = "articulo";
        private string nombreId = "id_articulo";
        private string refPredeterminada = "ART";
       
        Consultas consultas = new Consultas();
        CumplimentarComboboxes cumpCombo = new CumplimentarComboboxes();
        Utilidades ut = new Utilidades();
        Class_Articulo articulo = new Class_Articulo();

        private void Form2_Load(object sender, EventArgs e)
        {
            this.CenterToScreen();
            id_predeterminado = consultas.referenciaPredeterminada(nombreId, tabla, refPredeterminada, text_referencianuevo);
            limpiarCampos();
        }
    
        // Registro de Nuevo Articulo de vino
        private void button2_Click(object sender, EventArgs e)
        {
            bool cumplimentados = camposCumplimentados();

            if (cumplimentados == true)
            {
                referencia = text_referencianuevo.Text;
                id_proveedor = consultas.obtenerCualquierId("id_proveedor","proveedor","nombre",combo_proveedor.Text);                                  
                bool insertado = insertarEnTablaArticuloVino();


                if (insertado == true){
                    string nombreimagen = ut.limpiezaDeString(referencia) + ".jpg";
                    string nombrecatalogacion = combo_clasedevino.Text.ToLower();

                    salvarImagenEnCarpetaProveedor(id_proveedor, nombreimagen, nombrecatalogacion);
                    id_predeterminado = consultas.referenciaPredeterminada(nombreId, tabla, refPredeterminada, text_referencianuevo);
                    limpiarCampos();
                }
                else {
                    MessageBox.Show("Artículo no insertado!");
                }
            }
            else {
                MessageBox.Show(ClaseCompartida.msgCamposEnBlanco);
            }
                
        }
        
        // Método que solo inserta un articuloVino en la tabla
        private bool insertarEnTablaArticuloVino()
        {
            //... a método que solo haga una consulta y devuelva un array
            int id_claseVino = consultas.obtenerCualquierId("id_clasevino", "clasevino", "nombre", combo_clasedevino.Text);
            int id_tipoUva = consultas.obtenerCualquierId("id_tipouva", "tipouva", "nombre", combo_tipouva.Text);
            int id_proveedor = consultas.obtenerCualquierId("id_proveedor", "proveedor", "nombre", combo_proveedor.Text);
            int id_catalogacion = consultas.obtenerCualquierId("id_catalogacion", "catalogacion", "nombre", combo_catalogacion.Text);
            int id_denominacion = consultas.obtenerCualquierId("id_denominacion", "denominacion", "nombre", combo_denominacion.Text);
            int id_empaquetado = consultas.obtenerCualquierId("id_empaquetado", "empaquetado", "nombre", combo_empaquetado.Text);
            int id_formatocontenido = consultas.obtenerCualquierId("id_formatocontenido", "formatocontenido", "nombre", combo_formatocontenido.Text);
            //

                // Esto irá a un método
                    string minalmacenTexto = (numeric_minalmacen.Value).ToString();  // Decimal
                    int minalmacen = Int32.Parse(minalmacenTexto);

                    string maxalmacenTexto = (numeric_maxalmacen.Value).ToString();  // Decimal
                    int maxalmacen = Int32.Parse(maxalmacenTexto);


                    string mintiendaTexto = (numeric_mintienda.Value).ToString();  // Decimal
                    int mintienda = Int32.Parse(mintiendaTexto);

                    string maxTiendaTexto = (numeric_maxalmacen.Value).ToString();  // Decimal
                    int maxtienda = Int32.Parse(maxTiendaTexto);
                ////
              
            bool insertado = true;


            ConexionBD con = new ConexionBD();
            string cadenaConexion = con.conexion();
            MySqlConnection conexionBD = new MySqlConnection(cadenaConexion);
            MySqlDataReader reader = null;


            string nombreimagen = ut.limpiezaDeString(text_referencianuevo.Text) + ".jpg";
            try
                {
                    string consulta = "insert into articulo (id_articulo, ref, id_tipouva, id_claseVino, id_proveedor, id_catalogacion, id_denominacion, id_empaquetado, " +
                        "id_formatocontenido," +
                        " minalmacen, maxalmacen, mintienda, maxtienda, nombreImagen, activo) " +
                                        "values (" +
                                        "  '" + id_predeterminado + "'" +
                                        ", '" + referencia + "'" +
                                        ", " + id_tipoUva + "" +
                                        ", " + id_claseVino + "" +
                                        ", " + id_proveedor + "" +
                                        ", " + id_catalogacion + "" +
                                        ", " + id_denominacion + "" +
                                        ", " + id_empaquetado + "" +
                                        ", " + id_formatocontenido + "" +
                                        ", " + minalmacen + "" +
                                        ", " + maxalmacen + "" +
                                        ", " + mintienda + "" +
                                        ", " + maxtienda + "" +
                                        ", '" + nombreimagen + "'" +
                                         ", '1'" +
                                        ")";       
                     MessageBox.Show(consulta);                                        
                
                    MySqlCommand comando = new MySqlCommand(consulta);
                    comando.Connection = conexionBD;
                    conexionBD.Open();
                    reader = comando.ExecuteReader();

                    MessageBox.Show("Nuevo Artículo en el Inventario");
                    insertado = true;

                }
                catch (MySqlException ex) {
                    insertado = false;
                    MessageBox.Show(ex.Message);}
                finally { conexionBD.Close();  }

            return insertado;
        }


        // Método que guardar la imagen en un directorio, si no existe, lo crea */
        private void salvarImagenEnCarpetaProveedor(int id_proveedor, string nombreImagen, string nombreclasevino)
        {
            try{
                // string folderPath = @"C:\MyFoldera";
                string folderPath = ClaseCompartida.carpetaimg_absoluta + "proveedores/" + id_proveedor + "/articulos/" + nombreclasevino;

                if (!Directory.Exists(folderPath))
                {
                    Directory.CreateDirectory(folderPath);
                    Console.WriteLine(folderPath);

                    if (pictureBox_articulo.Image != null){ 
                        articulo.agregarImagen(id_proveedor, nombreclasevino, nombreImagen, pictureBox_articulo);
                    }else{
                        articulo.agregarImagenPredeterminada(id_proveedor, nombreclasevino,nombreImagen, pictureBox_articulo);
                    }

                }else{
                    if (pictureBox_articulo.Image != null) {
                        articulo.agregarImagen(id_proveedor, nombreclasevino, nombreImagen,pictureBox_articulo);
                    }else{
                        articulo.agregarImagenPredeterminada(id_proveedor, nombreclasevino,nombreImagen, pictureBox_articulo);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ocurrio un Error :\n " + ex);
            }
        }



        // Metodo que inserta una imagen en el picturebox
        private void button6_Click(object sender, EventArgs e)
        {
            ut.selecionarImagen(pictureBox_articulo);
        }
        

        // Método que guarda una imagen de articuloVino en la carpeta de proveedor
        private void button5_Click(object sender, EventArgs e)
        {
            limpiarCampos();
        }

        private void button_cerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }



        // Contenido
        private void button8_Click(object sender, EventArgs e)
        {
            Class_ContenidoAperturaForms contenido = new Class_ContenidoAperturaForms();
            contenido.todosContenidos();
        }

        // Empaquetado
        private void button9_Click(object sender, EventArgs e)
        {
            Class_EmpaquetadoAperturaForms empaquetado = new Class_EmpaquetadoAperturaForms();
            empaquetado.todosEmpaquetados();
        }

    // Limpieza de campos (sacar a una clase junto con el de Modificar)
        private void limpiarCampos()
        {
            //text_referencia.Text = "";
            combo_clasedevino.Text = "Seleccione";
            combo_tipouva.Text = "Seleccione";
            combo_proveedor.Text = "Seleccione";
            combo_catalogacion.Text = "Seleccione";
            combo_denominacion.Text = "Seleccione";
            combo_empaquetado.Text = "Seleccione";
            combo_formatocontenido.Text = "Seleccione";
            numeric_minalmacen.Value = 0;
            numeric_maxalmacen.Value = 0;
            numeric_mintienda.Value = 0;
            numeric_maxtienda.Value = 0;
            pictureBox_articulo.Image = null;
        }




 
        private void combo_clasedevino_MouseClick(object sender, MouseEventArgs e)
        {
            cumpCombo.refrescarCombo("nombre", "clasevino", combo_clasedevino);
        }

        private void combo_proveedor_MouseClick(object sender, MouseEventArgs e)
        {
            cumpCombo.refrescarCombo("nombre", "proveedor", combo_proveedor);
        }

        private void combo_denominacion_MouseClick(object sender, MouseEventArgs e)
        {
            cumpCombo.refrescarCombo("nombre", "denominacion", combo_denominacion);
        }

        private void combo_formatocontenido_MouseClick(object sender, MouseEventArgs e)
        {
            cumpCombo.refrescarCombo("nombre", "formatocontenido", combo_formatocontenido);
        }

        private void combo_tipouva_MouseClick(object sender, MouseEventArgs e)
        {
            cumpCombo.refrescarCombo("nombre", "tipouva", combo_tipouva);
        }

        private void combo_catalogacion_MouseClick(object sender, MouseEventArgs e)
        {
            cumpCombo.refrescarCombo("nombre", "catalogacion", combo_catalogacion);
        }

        private void combo_empaquetado_MouseClick(object sender, MouseEventArgs e)
        {
            cumpCombo.refrescarCombo("nombre", "empaquetado", combo_empaquetado);
        }


        private void button10_Click(object sender, EventArgs e)
        {
            Class_ClaseVinoAperturaForms claseVino = new Class_ClaseVinoAperturaForms();
            claseVino.todasClasesVino();
        }

        private void button12_Click(object sender, EventArgs e)
        {
            Class_ProveedorAperturaForms proveedor = new Class_ProveedorAperturaForms();
            proveedor.nuevoProveedor();
        }

        private void button13_Click(object sender, EventArgs e)
        {
            Class_DenominacionAperturaForms denominacion = new Class_DenominacionAperturaForms();
            //denominacion.todasDenominaciones();
            denominacion.todasDenominacionesII();
        }

        private void button14_Click(object sender, EventArgs e)
        {
            Class_ContenidoAperturaForms contenido = new Class_ContenidoAperturaForms();
            //contenido.todosContenidos();
            contenido.todosContenidosII();
        }

        private void button15_Click(object sender, EventArgs e)
        {
            Class_TipoUvaAperturaForms tipoUva = new Class_TipoUvaAperturaForms();
            tipoUva.todosTiposUva();
        }

        private void button16_Click(object sender, EventArgs e)
        {
            Class_CatalogacionAperturaForms apertura = new Class_CatalogacionAperturaForms();
            apertura.todasCatalogaciones();
        }

        private void button17_Click(object sender, EventArgs e)
        {
            Class_EmpaquetadoAperturaForms empaquetado = new Class_EmpaquetadoAperturaForms();
            empaquetado.todosEmpaquetados();
        }

        private void combo_clasedevino_Click(object sender, EventArgs e)
        {
        cumpCombo.refrescarCombo("nombre", "clasevino",combo_clasedevino);
        }

        private void combo_proveedor_Click(object sender, EventArgs e)
        {
        cumpCombo.refrescarCombo("nombre", "proveedor", combo_proveedor);
        }

        private void combo_denominacion_Click(object sender, EventArgs e)
        {
        cumpCombo.refrescarCombo("nombre", "denominacion", combo_denominacion);
        }

        private void combo_formatocontenido_Click(object sender, EventArgs e)
        {
        cumpCombo.refrescarCombo("nombre", "formatocontenido", combo_formatocontenido);
        }

        private void combo_tipouva_Click(object sender, EventArgs e)
        {
        cumpCombo.refrescarCombo("nombre", "tipouva", combo_tipouva);
        }

        private void combo_catalogacion_Click(object sender, EventArgs e)
        {
        cumpCombo.refrescarCombo("nombre", "catalogacion", combo_catalogacion);
        }

        private void combo_empaquetado_Click(object sender, EventArgs e)
        {
        cumpCombo.refrescarCombo("nombre", "empaquetado", combo_empaquetado);
        }



        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void verTodosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Class_ArticuloAperturaForms articulo = new Class_ArticuloAperturaForms();
            articulo.todosArticulosVinoII();
        }


        // Método que precarga u Proveedor
        private void checkBox1_CheckedChanged_1(object sender, EventArgs e)
        {
            if (check_demo.Checked)
            {
                //text_referencianuevo.Text = "ART11";
                combo_clasedevino.Text = "ROSADO";
                combo_tipouva.Text = "Cabernet Sauvignon";
                combo_proveedor.Text = "CAMPO VIEJO";
                combo_catalogacion.Text = "2021";
                combo_denominacion.Text = "D.O. Ca Rioja";
                combo_empaquetado.Text = "Botella";
                combo_formatocontenido.Text = "Estandar 3/4";
                numeric_minalmacen.Value = 10;
                numeric_maxalmacen.Value = 75;
                numeric_mintienda.Value = 5;
                numeric_maxtienda.Value = 25;
                pictureBox_articulo.Image = Image.FromFile(ClaseCompartida.carpetaimg_absoluta + "proveedores/art11campoviejorosado.jpg");
            }
            else
            {
                limpiarCampos();
            }
        }

        private bool camposCumplimentados()
        {
            if (text_referencianuevo.Text == "" 
                    || combo_clasedevino.Text == "Seleccione" 
                    || combo_catalogacion.Text == "Seleccione"
                    || combo_denominacion.Text == "Seleccione"
                    || combo_empaquetado.Text == "Seleccione"
                    || combo_proveedor.Text == "Seleccione"
                    || combo_tipouva.Text == "Seleccione"
                    || combo_formatocontenido.Text == "Seleccione"

                    || numeric_minalmacen.Value == 0
                    || numeric_maxalmacen.Value == 0
                    || numeric_mintienda.Value == 0
                    || numeric_maxtienda.Value == 0 )
            {
                return false;
            }
            else
            {
                return true;
            }
        }
    }
}



/* Ayuda en 
 *  https://codigosdeprogramacion.com/2020/01/08/conexion-de-csharp-a-base-de-datos-en-mysql/  tutorial
    https://dev.mysql.com/downloads/file/?id=514520  el conector
 */


/* Imagenes  https://www.youtube.com/watch?v=3fNLnrTqJ28 */



/* https://www.delftstack.com/es/howto/csharp/how-to-create-a-folder-in-csharp/ */

/* https://es.stackoverflow.com/questions/419650/como-guardar-im%C3%A1genes-en-una-carpeta-de-recursos-en-c-y-llamarla-mediante-su-ur */




// Para FTP
// awardspace
/*  string From = @"../../img/proveedores/aaa.jpg";
  string To = "ftp://ftpupload.net/htdocs/wineclub/rueba.jpg";

  using (WebClient client = new WebClient())
  {
      client.Credentials = new NetworkCredential("epiz_31803423", "rYPHq8acqd4Y");
      client.UploadFile(To, WebRequestMethods.Ftp.UploadFile, From);
  }
  // https://www.c-sharpcorner.com/article/working-with-ftp-using-c-sharp/
*/


/*
//string From = @"../../img/proveedores/aaa.jpg";
string From = @"../../img/proveedores/" + id_proveedor + "/articulos/" + nombreclasevino + "/" + nombreImagen;
string To = "ftp://files.000webhost.com/public_html/img/proveedores/" + id_proveedor + "/articulos/" + nombreclasevino + "/" + nombreImagen;

using (WebClient client = new WebClient())
{
    client.Credentials = new NetworkCredential("wineclub", "Alberite*1");
    client.UploadFile(To, WebRequestMethods.Ftp.UploadFile, From);
}

   // DeleteFTPFolder("ftp://files.000webhost.com/public_html/img/proveedores-copia/");

*/