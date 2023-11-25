using System;
using System.Activities.Expressions;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Text;
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
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TreeView;

namespace proyectovinos
{
    public partial class Form_ModificarArticulo : Form
    {

        Utilidades ut = new Utilidades();
        Consultas consultas = new Consultas();
        CumplimentarComboboxes cumplimentarComboboxes = new CumplimentarComboboxes();
        CumplimentarPictureBoxes cumplimentarPictureBoxes= new CumplimentarPictureBoxes();
        Class_Articulo articulo = new Class_Articulo();
 
        private int id_proveedor = 0, id_catalogacion = 0, id_empaquetado = 0;
        private string nombreProveedor = "", nombreClaseVinoOriginal;
        private bool cargarLista = true;
        private bool haCambiado = false;

        public string referenciaArticulo = "";
        private string nombreimagenNueva = "";


        public Form_ModificarArticulo()
        {
            InitializeComponent();
        }


        private void FormModificarArticuloVino_Load(object sender, EventArgs e)
        {
            this.CenterToScreen();
            articulo.cumplimentarListaArticulos(listView1, '1');
        }


        // Método que permite seleccionar una imagen del PC y agregarla al picturebox
        private void button12_Click(object sender, EventArgs e)
        {
            cumplimentarPictureBoxes.buscarImagenPicturebox(sender, e, pictureBox2);
        }

        private string nombreimagenAntigua= "";

        // Método que cumplimenta en los huecos los detalles de un Artículo de vino
        private void listView1_ItemChecked(object sender, ItemCheckedEventArgs e)
        {
            nombreimagenAntigua = e.Item.Text + ".jpg";

            if (cargarLista == true)
            {
                referenciaArticulo = e.Item.Text;
                cumplimentarPictureBoxes.cumplimentarPictureBox(referenciaArticulo, pictureBox2);

                int item = e.Item.Index;

                text_referencianueva.Text = listView1.Items[item].SubItems[0].Text;
                combo_tipouva.Text = listView1.Items[item].SubItems[1].Text;
                combo_clasedevino.Text = listView1.Items[item].SubItems[2].Text;
                nombreClaseVinoOriginal = listView1.Items[item].SubItems[2].Text;
                nombreProveedor = listView1.Items[item].SubItems[3].Text;
                id_proveedor = consultas.obtenerCualquierId("id_proveedor", "proveedor", "nombre", nombreProveedor);
                combo_catalogacion.Text = listView1.Items[item].SubItems[4].Text;
                combo_denominacion.Text = listView1.Items[item].SubItems[5].Text;
                combo_empaquetado.Text = listView1.Items[item].SubItems[6].Text;
                combo_formato.Text = listView1.Items[item].SubItems[7].Text;

                numeric_minalmacen.Value = Decimal.Parse(listView1.Items[item].SubItems[8].Text);
                numeric_maxalmacen.Value = Decimal.Parse(listView1.Items[item].SubItems[9].Text);
                numeric_mintienda.Value = Decimal.Parse(listView1.Items[item].SubItems[10].Text);
                numeric_maxtienda.Value = Decimal.Parse(listView1.Items[item].SubItems[11].Text);

                label_nombreproveedor.Text = listView1.Items[item].SubItems[3].Text;

            }
        }


        private void modificarArticulo()
        {

            string referencia = text_referencianueva.Text;
            int id_claseVino = consultas.obtenerCualquierId("id_clasevino", "clasevino", "nombre", combo_clasedevino.Text);
            int id_tipoUva = consultas.obtenerCualquierId("id_tipouva", "tipouva", "nombre", combo_tipouva.Text);
           // id_proveedor = consultas.obtenerCualquierId("id_proveedor", "proveedor", "nombre", combo_proveedor.Text);
            int id_catalogacion = consultas.obtenerCualquierId("id_catalogacion", "catalogacion", "nombre", combo_catalogacion.Text);
            int id_denominacion = consultas.obtenerCualquierId("id_denominacion", "denominacion", "nombre", combo_denominacion.Text);
            int id_empaquetado = consultas.obtenerCualquierId("id_empaquetado", "empaquetado", "nombre", combo_empaquetado.Text);
            int id_formatocontenido = consultas.obtenerCualquierId("id_formatocontenido", "formatocontenido", "nombre", combo_formato.Text);

            string minAlmacenTexto = (numeric_minalmacen.Value).ToString();  // Decimal
            int minalmacen = Int32.Parse(minAlmacenTexto);

            string maxAlmacenTexto = (numeric_maxalmacen.Value).ToString();  // Decimal
            int maxalmacen = Int32.Parse(maxAlmacenTexto);

            string mintiendaTexto = (numeric_mintienda.Value).ToString();  // Decimal
            int mintienda = Int32.Parse(mintiendaTexto);

            string maxtiendaTexto = (numeric_maxtienda.Value).ToString();  // Decimal
            int maxtienda = Int32.Parse(maxtiendaTexto);

            string referenciaActual = referenciaArticulo;


            ConexionBD con = new ConexionBD();
            string cadenaConexion = con.conexion();
            MySqlConnection conexionBD = new MySqlConnection(cadenaConexion);
            MySqlDataReader reader = null;

            try
            {
                string consulta = "update articulo SET ref=" + "'" + referencia + "'" +
                    ", id_tipoUva=" + id_tipoUva + "" +
                    ", id_claseVino=" + id_claseVino + "" +
               /*     ", id_proveedor=" + id_proveedor + "" +  */
                    ", id_catalogacion=" + id_catalogacion + "" +
                    ", id_denominacion=" + id_denominacion + "" +
                    ", id_empaquetado=" + id_empaquetado + "" +
                    ", id_formatocontenido=" + id_formatocontenido + "" +
                    ", minalmacen=" + minalmacen + "" +
                    ", maxalmacen=" + maxalmacen + "" +
                    ", mintienda=" + mintienda + "" +
                    ", maxtienda=" + maxtienda + "" +
                    ", nombreimagen='" + nombreimagenNueva + "'" +
                    " WHERE ref =" + "'" + referenciaActual + "' "; //  MessageBox.Show(consulta);

                MySqlCommand comando = new MySqlCommand(consulta);
                comando.Connection = conexionBD;
                conexionBD.Open();
                reader = comando.ExecuteReader();

                MessageBox.Show("Datos modificados");
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


        // Método que pone los campos a valores predeterminados
        private void limpiarCampos()
        {
            text_referencianueva.Text = "";
            combo_tipouva.Text = "Seleccione";
            combo_clasedevino.Text = "Seleccione";
            combo_catalogacion.Text = "Seleccione";
            combo_denominacion.Text = "Seleccione";
            combo_empaquetado.Text = "Seleccione";
            combo_formato.Text = "Seleccione";
            numeric_minalmacen.Value = 0;
            numeric_maxalmacen.Value = 0;
            pictureBox2.Image = null;
        }



      
        private void combo_tipouva_Click(object sender, EventArgs e)
        {
            cumplimentarComboboxes.refrescarCombo("nombre", "tipouva", combo_tipouva);
        }

        private void combo_clasedevino_Click(object sender, EventArgs e)
        {
            cumplimentarComboboxes.refrescarCombo("nombre", "clasevino", combo_clasedevino);
        }

        private void combo_catalogacion_Click(object sender, EventArgs e)
        {
            cumplimentarComboboxes.refrescarCombo("nombre", "catalogacion", combo_catalogacion);
        }

        private void combo_denominacion_Click(object sender, EventArgs e)
        {
        cumplimentarComboboxes.refrescarCombo("nombre", "denominacion", combo_denominacion);
        }

        private void combo_empaquetado_Click(object sender, EventArgs e)
        {
        cumplimentarComboboxes.refrescarCombo("nombre", "empaquetado", combo_empaquetado);
        }

        private void combo_formato_Click(object sender, EventArgs e)
        {
            cumplimentarComboboxes.refrescarCombo("nombre", "formatocontenido", combo_formato);
        }

    


        private void button2_Click(object sender, EventArgs e)
        {
            Class_TipoUvaAperturaForms apertura = new Class_TipoUvaAperturaForms();
            apertura.todosTiposUva();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Class_ClaseVinoAperturaForms apertura = new Class_ClaseVinoAperturaForms();
            apertura.todasClasesVino();
        }

        private void button14_Click(object sender, EventArgs e)
        {
            Class_CatalogacionAperturaForms apertura = new Class_CatalogacionAperturaForms();
            apertura.todasCatalogaciones();
        }

        private void button13_Click_1(object sender, EventArgs e)
        {
            Class_DenominacionAperturaForms apertura = new Class_DenominacionAperturaForms();
            apertura.todasDenominaciones();
        }

        private void button16_Click(object sender, EventArgs e)
        {
            Class_EmpaquetadoAperturaForms apertura = new Class_EmpaquetadoAperturaForms();
            apertura.todosEmpaquetados();
        }

        private void button17_Click(object sender, EventArgs e)
        {
            Class_ContenidoAperturaForms apertura = new Class_ContenidoAperturaForms();
            apertura.todosContenidos();
        }



        // Método que permite modificar un artículo
        private void button1_Click(object sender, EventArgs e)
        {
            bool camposOK = camposCumplimentados();

            if (camposOK == true)
            {
                nombreimagenNueva = ut.limpiezaDeString(text_referencianueva.Text) + ".jpg";
                modificarArticulo();

                nombreClaseVinoOriginal = ut.limpiezaDeString(nombreClaseVinoOriginal);

                string nombreClaseVinoNueva = combo_clasedevino.Text;
                nombreClaseVinoNueva = ut.limpiezaDeString(nombreClaseVinoNueva);

                if (haCambiado == true)
                {
                   

                    pictureBox2.Image.Save(ClaseCompartida.carpetaimg_absoluta + "proveedores/" + id_proveedor + "/articulos/" + nombreClaseVinoOriginal + "/" + nombreimagenNueva, System.Drawing.Imaging.ImageFormat.Jpeg);
                
                }
                else { }


                // Cambio de tipo de vino 
                if (nombreClaseVinoOriginal == nombreClaseVinoNueva) {
                    // Cambia de nombre la imagen
                    string sourceFilePath = ClaseCompartida.carpetaimg_absoluta + "proveedores/" + id_proveedor + "/articulos/" + nombreClaseVinoOriginal + "/" + nombreimagenAntigua + "";
                    string destinationFilePath = ClaseCompartida.carpetaimg_absoluta + "proveedores/" + id_proveedor + "/articulos/" + nombreClaseVinoOriginal + "/" + nombreimagenNueva + "";

                    MessageBox.Show(sourceFilePath);
                    MessageBox.Show(destinationFilePath);
                    File.Move(sourceFilePath, destinationFilePath);


                }
                else
                {

                    System.IO.Directory.Move(ClaseCompartida.carpetaimg_absoluta + "proveedores/" + id_proveedor + "/articulos/" + nombreClaseVinoOriginal,
                        ClaseCompartida.carpetaimg_absoluta + "proveedores/" + id_proveedor + "/articulos/" + nombreClaseVinoNueva + "");
                
                 // Cambia de nombre la imagen
                    string sourceFilePath = ClaseCompartida.carpetaimg_absoluta + "proveedores/" + id_proveedor + "/articulos/" + nombreClaseVinoNueva + "/" + nombreimagenAntigua + "";
                    string destinationFilePath = ClaseCompartida.carpetaimg_absoluta + "proveedores/" + id_proveedor + "/articulos/" + nombreClaseVinoNueva + "/" + nombreimagenNueva + "";

                    MessageBox.Show(sourceFilePath);
                    MessageBox.Show(destinationFilePath);
                    File.Move(sourceFilePath, destinationFilePath);

                    MessageBox.Show("Cambio nombre de imagen");
                
                }

                cargarLista = false;
                articulo.cumplimentarListaArticulos(listView1, '1');
                cargarLista = true;
                limpiarCampos();
            }
            else {
                MessageBox.Show("¡Campos sin cumplimentar!");
            }
        }

        // Metodo que asegura que los campos se encuentran cumplimentados
        private bool camposCumplimentados()
        {
            if (text_referencianueva.Text == "" ||
             combo_catalogacion.Text == "Seleccione" || combo_clasedevino.Text == "Seleccione" || combo_tipouva.Text == "Seleccione" ||
             combo_denominacion.Text == "Seleccione" || combo_empaquetado.Text == "Seleccione" || combo_formato.Text == "Seleccione")
            {
                return false;
            }
            else
            {
                return true;
            }
        }

            
    

        private void button_limpiar_Click(object sender, EventArgs e)
        {
            limpiarCampos();
        }


        private void combo_nombreproveedor_SelectedIndexChanged(object sender, EventArgs e)
        {
            id_proveedor = consultas.obtenerCualquierId("id_proveedor", "proveedor", "nombre", combo_filtronombreproveedor.Text);
        }

        private void comboBox_nombrecatalogacion_SelectedIndexChanged(object sender, EventArgs e)
        {
            id_catalogacion = consultas.obtenerCualquierId("id_catalogacion", "catalogacion", "nombre", comboBox_filtronombrecatalogacion.Text);
        }

    

        private void comboBox_nombreempaquetado_SelectedIndexChanged(object sender, EventArgs e)
        {
            id_empaquetado = consultas.obtenerCualquierId("id_empaquetado", "empaquetado", "nombre", comboBox_nombreempaquetado.Text);
        }



        // Filtros

        private void button3_Click(object sender, EventArgs e)
        {
            articulo.listaArticulos_Filtrados("id_proveedor", id_proveedor, listView1, '1');
        }
    
        private void button1_Click_1(object sender, EventArgs e)
        {
            articulo.listaArticulos_Filtrados("id_catalogacion", id_catalogacion, listView1, '1');
        }

        private void button6_Click(object sender, EventArgs e)
        {
            combo_filtronombreproveedor.Text = "Seleccione";
            comboBox_filtronombrecatalogacion.Text = "Seleccione";
            articulo.listaArticulos_Filtrados("id_empaquetado", id_empaquetado, listView1, '1');
        }


        private void combo_filtronombreproveedor_Click(object sender, EventArgs e)
        {
            comboBox_filtronombrecatalogacion.Text = "Seleccione";
            cumplimentarComboboxes.refrescarCombo("nombre", "proveedor", combo_filtronombreproveedor);
        }

        private void comboBox_filtronombrecatalogacion_Click(object sender, EventArgs e)
        {
            combo_filtronombreproveedor.Text = "Seleccione";
            cumplimentarComboboxes.refrescarCombo("nombre", "catalogacion", comboBox_filtronombrecatalogacion);
        }

        private void comboBox_nombreempaquetado_Click(object sender, EventArgs e)
        {
            cumplimentarComboboxes.refrescarCombo("nombre", "empaquetado", comboBox_nombreempaquetado);
        }


        private void pictureBox2_BackgroundImageChanged(object sender, EventArgs e)
        {
            haCambiado = true;
            MessageBox.Show("Ha cambiado");
        }
    }
}

// Prueba: Campos en blanco y cambio de clase de vino para cambio de carpeta, cambio de imagen y base de datos con registros modificados
// Otros que se vea conveniente



/*
/*  
// Eliminar imagen
MessageBox.Show("La carpeta es la misma, solo se borra la imagen y se mete la nueva"); // Eliminar la imagen y meter la nueva
string folderPathFoto = @"../../img/proveedores/" + id_proveedor + "/articulos/" + nombreClaseVinoOriginal + "/" + nombreimagen;
File.Delete(folderPathFoto); // MessageBox.Show("Foto eliminada: " + folderPathFoto);

// Grave  la imagen nueva
pictureBox1.Image.Save(@"../../img/proveedores/" + id_proveedor + 
"/articulos/" + nombreClaseVinoOriginal + "/" + nombreimagen, System.Drawing.Imaging.ImageFormat.Jpeg);
*/


/*
 
            /*
            // Cambia de nombre la imagen
            string sourceFilePath = @"../../img/proveedores/" + id_proveedor + "/articulos/" + nombreClaseVinoOriginal + "/" + nombreimagenAntigua + "";
            string destinationFilePath = @"../../img/proveedores/" + id_proveedor + "/articulos/" + nombreClaseVinoOriginal + "/" + nombreimagenNueva + "";
            File.Move(sourceFilePath, destinationFilePath);
            */




/*
//////////
// Cambia de nombre la imagen
string sourceFilePath = @"../../img/proveedores/" + id_proveedor + "/articulos/" + nombreClaseVinoOriginal + "/" + nombreimagenAntigua + "";
string destinationFilePath = @"../../img/proveedores/" + id_proveedor + "/articulos/" + nombreClaseVinoOriginal + "/" + nombreimagenNueva + "";
File.Move(sourceFilePath, destinationFilePath);


string nombreclasevino = ut.limpiezaDeString(combo_clasedevino.Text.ToLower());
// Si cambia la clase de vino
if (nombreClaseVinoOriginal == nombreclasevino)
{


}
else
{
    System.IO.Directory.Move(@"../../img/proveedores/" + id_proveedor + "/articulos/" + nombreClaseVinoOriginal,
        @"../../img/proveedores/" + id_proveedor + "/articulos/" + nombreclasevino + "");
}
///////////
///
*/

/*
//MessageBox.Show(@"../../img/proveedores/" + id_proveedor + "/articulos/" + nombreClaseVinoOriginal + "/" + nombreimagenNueva);
//pictureBox1.Image.Save(@"../../img/proveedores/" + id_proveedor + "/articulos/" + nombreClaseVinoNueva + "/" + nombreimagenNueva, System.Drawing.Imaging.ImageFormat.Jpeg);
//No vamos a cambiar el nombre
 */