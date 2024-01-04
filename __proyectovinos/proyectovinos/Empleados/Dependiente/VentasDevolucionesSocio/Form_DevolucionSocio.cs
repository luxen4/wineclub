using System;
using System.Activities.Statements;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using proyectovinos.ArticuloVino;
using proyectovinos.Movimientos.AlmacenTienda;
using proyectovinos.Socios;
using proyectovinos.VentasDevoluciones;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace proyectovinos
{
    public partial class Form_DevolucionSocio : Form
    {
        public Form_DevolucionSocio()
        {
            InitializeComponent();
        }

        // Propiedades 
        private int id_lineacompraproveedor = 0;
        private int id_lineaventasocio = 0;
        private int unidadesAmover = 0;
        private int id_socio = 0;
        private string refVentaSocio = "";
        private int unidadescompro = 0;
        private int unidadesdevolvio = 0;  
        private string clasevino = "";

        // Clases
        Class_Articulo articulo=new Class_Articulo();
        Consultas consultas = new Consultas();
        CumplimentarComboboxes cumpCombos = new CumplimentarComboboxes();
        Class_Socio consultaSocios = new Class_Socio();
        Class_AlmacenTienda almacenTienda = new Class_AlmacenTienda();


        Class_Socio socio = new Class_Socio();
        Utilidades ut = new Utilidades();


        private int id_predeterminado = 0;
        private string refDevolucionSocio = "";
        private string refPredeterminada = "DEVSOC";

        private int id_articulo = 0, id_ventasocio = 0;
      

        public int primeravez { get; private set; }

        private void Form_Devolucion_Load(object sender, EventArgs e)
        {
            this.CenterToScreen();
            cumpCombos.cumplimentarComboboxRefVentaSocio(combo_refventasocio);

            id_predeterminado = consultas.referenciaPredeterminada("id_devolucionsocio", "devolucionsocio", refPredeterminada, text_refdevolucionsocio);
            refDevolucionSocio = refPredeterminada + id_predeterminado;
        }


        /// <summary>
        /// Método Controlados que dirige la inserción de artículos a almacén desde una devolución de Socio
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button_devolver_Click(object sender, EventArgs e)
        {

            if (numeric_cantidad.Value != 0)
            {
                try
                {   /*  Por si metemos el campo
                    string fechanacimiento = dateTime_fechanacimiento.Text;
                    string fechanacimiento = ut.preparacionFecha(fechanacimiento);
                    */

                    // Unidades a devolver
                    string catidadDevolverTexto = (numeric_cantidad.Value).ToString();  // Decimal
                    int cantidadDevolver = Int32.Parse(catidadDevolverTexto);

                    // Precio unidad
                    string precioUnidadTexto = (text_preciounidad.Text).ToString();  // Decimal
                    decimal precioUnidad = Decimal.Parse(precioUnidadTexto);

                    // Total a devolver al cliente
                    decimal totalArticulo = cantidadDevolver * precioUnidad;
                    text_total.Text = totalArticulo.ToString();

                    
                    // sacar el id_lineaventasocio
                    string refVentaSocio=combo_refventasocio.Text;
                    int id_ventasocio = consultas.obtenerCualquierId("id_ventasocio","ventasocio","ref",refVentaSocio);

                    Class_VentasDevolucionesSocio vent = new Class_VentasDevolucionesSocio();
                    id_lineaventasocio = vent.lineaVentaSocio(id_ventasocio, id_articulo);
                    id_lineacompraproveedor = vent.lineaCompraProveedor(id_lineaventasocio, id_articulo);

                    unidadesAmover = (int)numeric_cantidad.Value;

                    insertarDevolucionSocio();

                    //Existencias que hay de ese artículo en almacén y sumar
                    int existenciasAlmacen = articulo.existenciasLineaZona(1, id_articulo, id_lineacompraproveedor);

                   
                    int totalExistenciasAlmacen = existenciasAlmacen + unidadesAmover;
                  //  string refCompraproveedor = combo_proveedor.Text;

                    almacenTienda.ajusteExistenciasCualquierUbicacion(id_lineacompraproveedor, totalExistenciasAlmacen, id_articulo, "almacen");

                    limpiarCampos();

                    id_predeterminado = consultas.referenciaPredeterminada("id_devolucionsocio", "devolucionsocio", refPredeterminada, text_refdevolucionsocio);
                    refDevolucionSocio = refPredeterminada + id_predeterminado;
                    text_refdevolucionsocio.Text = refPredeterminada + id_predeterminado;


                }
                catch (Exception ex)
                {
                    MessageBox.Show("Cumplimente todos los campos");
                }

            }
            else {
                MessageBox.Show("Unidades a devolver no pueden ser 0");
            }
             
        }


        /// <summary>
        /// Función que inserta una devolucion de socio.
        /// </summary>
        /// <returns></returns>
        private bool insertarDevolucionSocio()
        {
            /*
           // fecha de la compra no mete la hora
           DateTime fechaActual = DateTime.Now;
           string fechaFormateada = ut.fechaTimeStam(fechaActual);
           */

            // fecha de la compra mete la hora
            DateTime fechaActual = DateTime.Now;
            string fechaFormateada = ut.fechaTimeStam(fechaActual);


            ConexionBD con = new ConexionBD();
            string cadenaConexion = con.conexion();

            MySqlConnection conexionBD = new MySqlConnection(cadenaConexion);
            MySqlDataReader reader = null;

            try
            {
                string selectQuery = 
                    "insert into devolucionsocio (id_devolucionsocio,id_ventasocio, ref, id_lineaventasocio, unidades, fecha) " +
                    "values (" + id_predeterminado + ",  " + id_ventasocio + ", '" + refDevolucionSocio + "', '" + id_lineaventasocio + "','" + unidadesAmover + "' ,'"  + fechaFormateada + "')";
                    // MessageBox.Show(selectQuery);

                MySqlCommand comando = new MySqlCommand(selectQuery);
                comando.Connection = conexionBD;
                conexionBD.Open();
                reader = comando.ExecuteReader();

                MessageBox.Show(ClaseCompartida.msgInsertado);
                return true;
            }
            catch (MySqlException ex)
            {
                MessageBox.Show(ex.Message);
                conexionBD.Close();
                return false;
            }
            finally
            {
                conexionBD.Close();
            }
        }



        /// <summary>
        /// Método controlador que dirige la puesta de información de un Socio
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void combo_refcompraproveedor_SelectedIndexChanged(object sender, EventArgs e)
        {
            refVentaSocio = combo_refventasocio.Text;
            id_socio = consultaSocios.obtener_id_socioDesdeRefVentaSocio(refVentaSocio); 

            string [] datosSocio = socio.datosSocioo(id_socio);
            label_nombresocio.Text = datosSocio[1] + ", " + datosSocio[0];

            /* Forma antigua
            CumplimentarPictureBoxes cumplimentarPicture = new CumplimentarPictureBoxes();
            cumplimentarPicture.agregarImagenPictureBox(id_socio, pictureBox_perfilsocio);
            */

            string folderPathPropia = ClaseCompartida.carpetaimg_absoluta + "socios/" + id_socio + "/perfil/foto1.jpg";
            string folderPathPredeterminada = ClaseCompartida.carpetaimg_absoluta + "socios/predeterminada.jpg";
            ut.cargarImagen(pictureBox_perfilsocio, folderPathPropia, folderPathPredeterminada);


            cumpCombos.refrescarComboboxArticuloDesdeRefCompraProveedor(combo_refventasocio, combo_articulo);
            combo_articulo.Enabled = true;
        }

        /// <summary>
        /// Método controlador que dirige la puesta de información de un artículo 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void combo_articulovino_SelectedIndexChanged(object sender, EventArgs e)
        {

            string refArticulo = combo_articulo.Text;
            string refVentaSocio = combo_refventasocio.Text; 
            
            id_articulo = consultas.obtenerCualquierId("id_articulo","articulo","ref",refArticulo);
            id_ventasocio = consultas.obtenerCualquierId("id_ventasocio","ventasocio","ref",refVentaSocio);

            id_ventasocio = consultas.obtenerCualquierId("id_ventasocio", "ventasocio", "ref", refVentaSocio);

            int id_proveedor = consultas.obtenerCualquierId("id_proveedor","articulo","ref",refArticulo);


            // Cumplimentar los text con los nombres de las características
            string[] nombres = consultas.nombresCaracteristicas(refArticulo);
            text_proveedor.Text = nombres[0];
            string nombreClasevino =  nombres[1];
            text_clasevino.Text = nombreClasevino;
            text_denominacion.Text = nombres[2];
            text_catalogacion.Text = nombres[3];
            text_formatocontenido.Text = nombres[4];
            text_empaquetado.Text = nombres[5];
            //

            // existencias en las zonas
            text_unidadesalmacen.Text = articulo.existenciasTotalesZona(1,id_articulo).ToString();
            text_unidadestienda.Text = articulo.existenciasTotalesZona(2,id_articulo).ToString();

            // unidades que compró y que ya devolvió
            unidadescompro = unidadesCompro(id_ventasocio, id_articulo);
            textBox_compro.Text = unidadescompro.ToString();

            unidadesdevolvio = unidadesDevolvio(id_ventasocio, id_lineaventasocio);
            textBox_devolvio.Text = unidadesdevolvio.ToString();
            //
         

            text_preciounidad.Text = precioUnidad( id_ventasocio ,id_articulo);

            // Mostrar la Imagen del artículo seleccionado en el pictureBox
            /*string nombreimagen = consultas.obtenerCualquierRefDesdeNombre("nombreimagen","articulo","ref",refArticulo);
            try
            {
                pictureBox_producto.Image = System.Drawing.Image.FromFile(ClaseCompartida.carpetaimg_absoluta + "proveedores/" + id_proveedor + "/articulos/" + nombreClasevino + "/" + nombreimagen);
            }
            catch (Exception ex)
            {
                pictureBox_producto.Image = Image.FromFile(ClaseCompartida.carpetaimg_absoluta + "proveedores/botellapredeterminada.jpg");
            }*/

            string nombreimagen = consultas.obtenerCualquierRefDesdeNombre("nombreimagen", "articulo", "ref", refArticulo);

            string folderPathPropia = ClaseCompartida.carpetaimg_absoluta + "proveedores/" + id_proveedor + "/articulos/" + nombreClasevino + "/" + nombreimagen;
            string folderPathPredeterminada = ClaseCompartida.carpetaimg_absoluta + "proveedores/botellapredeterminada.jpg";
            ut.cargarImagen(pictureBox_producto, folderPathPropia, folderPathPredeterminada);



        }


        /// <summary>
        /// Función que devuelve las unidades de un artículo que devolvio un socio.
        /// </summary>
        /// <param name="id_ventasocio">The identifier ventasocio.</param>
        /// <param name="id_lineaventasocio">The identifier lineaventasocio.</param>
        /// <returns></returns>
        private int unidadesDevolvio(int id_ventasocio, int id_lineaventasocio)
        {
            int unidades = 0;

            ConexionBD con = new ConexionBD();
            string cadenaConexion = con.conexion();
            MySqlConnection conexionBD = new MySqlConnection(cadenaConexion);

            try
            {
                string selectQuery = "select sum(unidades) as unidades from devolucionsocio where " +
                    " id_ventasocio = " + id_ventasocio + "";

                //MessageBox.Show(selectQuery);

                conexionBD.Open();
                MySqlCommand command = new MySqlCommand(selectQuery, conexionBD);
                MySqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    unidades = Int32.Parse(reader.GetString("unidades"));
                }
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
            finally { conexionBD.Close(); }

            MessageBox.Show("Devolvio->" + unidades);
            return unidades;
        }



        /// <summary>
        /// Método que devuelve las unidades que compró un socio
        /// </summary>
        /// <param name="id_ventasocio"></param>
        /// <param name="id_articulo"></param>
        /// <returns></returns>
        private int unidadesCompro(int id_ventasocio, int id_articulo)
        {
            int unidades = 0;

            ConexionBD con = new ConexionBD();
            string cadenaConexion = con.conexion();
            MySqlConnection conexionBD = new MySqlConnection(cadenaConexion);

            try
            {
                string selectQuery = "select unidades as unidades from lineaventasocio where " +
                    " id_ventasocio = " + id_ventasocio + " and id_articulo=" + id_articulo + "";

                conexionBD.Open();
                MySqlCommand command = new MySqlCommand(selectQuery, conexionBD);
                MySqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    unidades = Int32.Parse(reader.GetString("unidades"));
                }
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
            finally { conexionBD.Close(); }

            return unidades;
        }


        /// <summary>
        /// Función que devuelve el precio de venta de un artículo.
        /// </summary>
        /// <param name="id_ventasocio">The identifier ventasocio.</param>
        /// <param name="id_articulo">The identifier articulo.</param>
        /// <returns></returns>
        public string precioUnidad(int id_ventasocio, int id_articulo)
            {
                string resultado = "";

            ConexionBD con = new ConexionBD();
            string cadenaConexion = con.conexion();
            MySqlConnection conexionBD = new MySqlConnection(cadenaConexion);
                MySqlDataReader reader = null;

                try
                {
                    string selectQuery = "SELECT precioVenta from lineaventasocio where id_articulo = " + id_articulo + " and id_ventasocio=" + id_ventasocio + ";";
                   // MessageBox.Show(selectQuery);
                    conexionBD.Open();
                    MySqlCommand command = new MySqlCommand(selectQuery, conexionBD);
                    reader = command.ExecuteReader();

                    while (reader.Read())
                    {
                        resultado = reader.GetString("precioVenta");
                    }
                }
                catch (Exception ex) { MessageBox.Show(ex.Message); }
                finally { conexionBD.Close(); }

                return resultado;
            }
        

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            primeravez = 1;
        }

        private void listView1_ItemChecked(object sender, ItemCheckedEventArgs e)
        {
            if (primeravez == 1)
            {
                DialogResult opcionSeleccionada = MessageBox.Show("Quiere borrar el registro?", "Aviso", MessageBoxButtons.YesNo);

                if (opcionSeleccionada == DialogResult.Yes)
                {
                    // MessageBox.Show("ojoo" + e.Item.Text);  // Al principio sale
                    e.Item.Remove();
                    primeravez = 0;
                }
            }
        }

        /// <summary>
        /// Handles the ValueChanged event of the numeric_cantidad control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void numeric_cantidad_ValueChanged(object sender, EventArgs e)
        {
            if ((unidadesdevolvio + numeric_cantidad.Value) > unidadescompro)
            {
                MessageBox.Show("No puede devolver más de las que compró");
                numeric_cantidad.Value = numeric_cantidad.Value - 1;
            }
            else {
                decimal total = numeric_cantidad.Value * Decimal.Parse(text_preciounidad.Text);
                text_total.Text = total.ToString();
            }
        }


        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        // Limpieza de campos
        private void limpiarCampos()
        {  
            combo_refventasocio.Text = "";
            combo_articulo.Text = "";
            text_proveedor.Text = ""; 
            text_clasevino.Text = "";        
            text_denominacion.Text = "";   
            text_catalogacion.Text = "";
            label_nombresocio.Text = "Nombre de Socio";
           // combo_refcompraproveedor.Text = "";
            
            numeric_cantidad.Value = 0;
            text_unidadesalmacen.Text = "";
            text_unidadestienda.Text = "";
            textBox_compro.Text = "";
            text_empaquetado.Text = "";
            textBox_devolvio.Text = "";
            text_preciounidad.Text = "";
            text_total.Text = "";
            pictureBox_producto.Image = null;
            pictureBox_perfilsocio.Image = null;

            //text_refdevolucionsocio.Text = "";

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

    }
}

/*  
    string precioVentaTexto = text_preciounidad.Text;
    precioVentaTexto = precioVentaTexto.Replace(",", ".");
*/


 
 