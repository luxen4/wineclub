using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CrystalDecisions.Shared.Json;
using MySql.Data.MySqlClient;
using proyectovinos.ArticuloVino;
using proyectovinos.Movimientos.AlmacenProveedor;
using proyectovinos.Socios;

namespace proyectovinos
{
    public partial class Form_CompraArticulosProveedor : Form
    {
        public Form_CompraArticulosProveedor()
        {
            InitializeComponent();
        }

        Class_AlmacenProveedor almacenProveedor = new Class_AlmacenProveedor();
        Class_Articulo articulo=new Class_Articulo();
        Consultas consultas = new Consultas();
        CumplimentarComboboxes cumpCombo = new CumplimentarComboboxes();
        Utilidades ut = new Utilidades();
        CumplimentarPictureBoxes cumplimentarPictureBoxes = new CumplimentarPictureBoxes();


        private int primeraVez=0;
        private int id_articulo = 0;

        private int id_proveedor = 0;
        private string refCompraProveedor = "", nombreProveedor = "";

        private int id_predeterminado = 0;
        private string refPredeterminada = "CPRO";
        private string refProveedor = "";

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }



        private void Form_CompraArticuloVino_Load(object sender, EventArgs e)
        {
            this.CenterToScreen();
            this.Top = this.Top + 19;
            cumpCombo.refrescarCombo("ref", "articulo", combo_refarticulo);
            id_predeterminado = consultas.referenciaPredeterminada("id_compraproveedor", "compraproveedor", refPredeterminada, text_refcompraproveedor);
            refCompraProveedor = refPredeterminada + id_predeterminado;
        }


        /// <summary>
        /// Método controlador que refresca el combobox de Proveedores  
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void combo_proveedor_SelectedIndexChanged(object sender, EventArgs e)
        {
            refProveedor = consultas.obtenerCualquierRefDesdeNombre("ref", "proveedor", "nombre", nombreProveedor);
            id_proveedor = consultas.obtenerCualquierId("id_proveedor", "proveedor", "ref", refProveedor);
            // cumplimentarPictureBoxes.cumplimentarPictureBoxProveedor(id_proveedor, pictureBox2);
        }

       
        /// <summary>
        /// Método que recorre la lista de compra a proveedor 
        /// </summary>
        /// <param name="id_compraproveedor">The identifier compraproveedor.</param>
        private void recorrerListaCompraProveedor(int id_compraproveedor)
        {
            // MessageBox.Show("Número de items: " +listView1.Items.Count);
            for (int i = 0; i < listView1.Items.Count; i++)
            {
                string refArticulo = listView1.Items[i].SubItems[0].Text;

                // Unidades a comprar
                int unidadesAcomprar = Int32.Parse(listView1.Items[i].SubItems[6].Text);

                // Precio Coste
                string precioCosteTexto = listView1.Items[i].SubItems[7].Text;
                precioCosteTexto = precioCosteTexto.Replace(",", ".");

                // Precio Venta
                string precioVentaTexto = listView1.Items[i].SubItems[9].Text;
                precioVentaTexto = precioVentaTexto.Replace(",", ".");


                // id del artículo
                int id_articulo = consultas.obtenerCualquierId("id_articulo", "articulo", "ref", refArticulo);

                int existenciasAlmacen = articulo.existenciasTotalesZona(1, id_articulo);
                int totalExistencias = existenciasAlmacen + unidadesAcomprar;

                int id_lineacompraproveedor = consultas.referenciaPredeterminada("id_lineacompraproveedor", "lineacompraproveedor", refPredeterminada, text_refcompraproveedor);
                insertarLineaCompraProveedor(id_lineacompraproveedor,id_compraproveedor, id_articulo, unidadesAcomprar, precioCosteTexto, precioVentaTexto);

                articulo.nuevaExistenciaAlmacenTienda(1, id_lineacompraproveedor, id_articulo, unidadesAcomprar);          // Ya está preparado para pasa a tienda
                articulo.nuevaExistenciaAlmacenTienda(2, id_lineacompraproveedor, id_articulo, 0);

            }
        }

    
        /// <summary>
        /// Método que inserta una linea de compra al proveedor     
        /// </summary>
        /// <param name="id_lineacompraproveedor">The identifier lineacompraproveedor.</param>
        /// <param name="id_compraproveedor">The identifier compraproveedor.</param>
        /// <param name="id_articulo">The identifier articulo.</param>
        /// <param name="existencias">The existencias.</param>
        /// <param name="preciocosteTexto">The preciocoste texto.</param>
        /// <param name="precioventaTexto">The precioventa texto.</param>
        private void insertarLineaCompraProveedor(int id_lineacompraproveedor,int id_compraproveedor, int id_articulo,int existencias,string preciocosteTexto,string precioventaTexto)
        {
            string refLineaCompraprovedor = "LCP" + id_lineacompraproveedor;

            ConexionBD con = new ConexionBD();
            string cadenaConexion = con.conexion();
            MySqlConnection conexionBD = new MySqlConnection(cadenaConexion);
            MySqlDataReader reader = null;

            try
            {
                string selectQuery = "insert into lineacompraproveedor (id_lineacompraproveedor,ref,id_compraproveedor, id_articulo, existencias, preciocoste, precioventa) values (" +
                    " " + id_lineacompraproveedor + 
                    ", '" + refLineaCompraprovedor + "'" +
                    ", " + id_compraproveedor + "" +
                    ", " + id_articulo + "" +
                    ", " + existencias + "" +
                    ", convert( '" + preciocosteTexto + "', decimal (7,2))" +
                    ", convert( '" + precioventaTexto + "', decimal (7,2))" +

                    ")";  
                // MessageBox.Show(selectQuery);

                MySqlCommand comando = new MySqlCommand(selectQuery);
                comando.Connection = conexionBD;
                conexionBD.Open();
                reader = comando.ExecuteReader();

               // MessageBox.Show("Nuevo Línea de compra proveedor creada");

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
     
        /// <summary>
        /// Método que deja los valores predeterminados de los campos   
        /// </summary>
        private void limpiarCampos()
        {
            combo_refarticulo.Text = "Seleccione";
            text_proveedor.Text = "";
            text_clasevino.Text = "";
            text_denominacion.Text = "";
            text_catalogacion.Text = "";
            text_unidadesalmacen.Text = "";
            text_unidadestienda.Text = "";
            text_formatocontenido.Text = "";
            text_empaquetado.Text = "";
            numericUpDown_unidadesacomprar.Enabled = false;
            numericUpDown_unidadesacomprar.Value = 0;
            numericUpDown_preciocoste.Value = 0;
            numeric_cantidad.Value = 0;
            pictureBox1.Image = null;   
            pictureBox3.Image = null;
        }


        private void button5_Click(object sender, EventArgs e)
        {
            limpiarCampos();
        }

        private string refArticulo="";
         
        /// <summary>
        /// Método controlador que añade un artículo a la lista de compra a un Proveedor // No compruebe si hay ya artículo ya que hay de varios precios
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void button1_Click(object sender, EventArgs e)
        {
            if (numericUpDown_unidadesacomprar.Value == 0){
                    MessageBox.Show("Campos en blanco!");
            }else{
                    
                string refArticulo = combo_refarticulo.Text;
                    try
                    {
                        decimal existenciasCompra = numericUpDown_unidadesacomprar.Value;
                        decimal precioCoste = numericUpDown_preciocoste.Value;
                        decimal totalArticulo = existenciasCompra * precioCoste;

                        cumplimentarItemsListViewCompraProveedor(refArticulo, totalArticulo.ToString());
                    }
                    catch (Exception ex){ MessageBox.Show("Error! " + ex);}

                limpiarCampos(); 
            }
        }


        /// <summary>
        /// Metodo que cumplimenta la lista de compra a Proveedores  
        /// </summary>
        /// <param name="referenciaArticulo">The referencia articulo.</param>
        /// <param name="totalArticulo">The total articulo.</param>
        private void cumplimentarItemsListViewCompraProveedor(string referenciaArticulo, string totalArticulo)
        {
            ListViewItem itemAgregar = new ListViewItem(referenciaArticulo);
            // itemAgregar.Checked = true;

            itemAgregar.SubItems.Add(text_clasevino.Text);
            itemAgregar.SubItems.Add(text_denominacion.Text);
            itemAgregar.SubItems.Add(text_catalogacion.Text);

            itemAgregar.SubItems.Add(text_empaquetado.Text);
            itemAgregar.SubItems.Add(text_formatocontenido.Text);
            itemAgregar.SubItems.Add(numericUpDown_unidadesacomprar.Value.ToString());
            itemAgregar.SubItems.Add(numericUpDown_preciocoste.Value.ToString());

            itemAgregar.SubItems.Add(totalArticulo);
            itemAgregar.SubItems.Add(numeric_cantidad.Value.ToString());

            listView1.Items.Add(itemAgregar);
        }


        private void listView1_ItemChecked(object sender, ItemCheckedEventArgs e)
        {
            if (primeraVez == 1)
            {
                DialogResult opcionSeleccionada = MessageBox.Show("Quiere borrar el registro?", "Aviso", MessageBoxButtons.YesNo);

                if (opcionSeleccionada == DialogResult.Yes)
                {
                    e.Item.Remove();
                    primeraVez = 0;
                }
            }
        }
    

        private void listView1_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            primeraVez = 1;
        }


        /// <summary>
        /// Función que implementa la información de un artículo desde su referencia.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            refArticulo = combo_refarticulo.Text;

            id_articulo = consultas.obtenerCualquierId("id_articulo", "articulo", "ref", refArticulo);
            string[] caracteristicasArticulos = articulo.nombreCaracteristicasArticulos(id_articulo);

            nombreProveedor = caracteristicasArticulos[0];
            text_proveedor.Text = nombreProveedor;

            string nombreClaseVino = caracteristicasArticulos[1];
            text_clasevino.Text = nombreClaseVino;
            text_denominacion.Text = caracteristicasArticulos[2];
            text_catalogacion.Text = caracteristicasArticulos[3];
            text_empaquetado.Text = caracteristicasArticulos[4];
            text_formatocontenido.Text = caracteristicasArticulos[5];

            id_proveedor = consultas.obtenerCualquierId("id_proveedor", "proveedor", "nombre", nombreProveedor);

            pictureBox1.Image = Image.FromFile(ClaseCompartida.carpetaimg_absoluta + "proveedores/" + id_proveedor + "/articulos/" + nombreClaseVino + "/" + refArticulo + ".jpg");


            cumplimentarPictureBoxes.cumplimentarPictureBox(refArticulo, pictureBox1);

            //
            int existenciasUbicacionAlmacen = articulo.existenciasTotalesZona(1, id_articulo);
            text_unidadesalmacen.Text = existenciasUbicacionAlmacen.ToString();

            int existenciasUbicaciontienda = articulo.existenciasTotalesZona(2, id_articulo);
            text_unidadestienda.Text = existenciasUbicaciontienda.ToString();
            //

        }

      
        /// <summary>
        /// Función que hace la compra de artículos a proveedores 
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void cOMPRARToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (listView1.Items.Count == 0)
            {
                MessageBox.Show("No tiene en la lista cargado ningún artículo");
                // btn_comprar.Enabled = false;
            }
            else
            {
                int id_empleado = 1;

                // fecha de la compra
                DateTime fechaActual = DateTime.Now;
                string fechaFormateada = ut.fechaTimeStam(fechaActual);

                // Registrar Compra al Proveedor
                almacenProveedor.registrarCompraProveedor(id_predeterminado, id_empleado, refCompraProveedor, fechaFormateada);  // ok

                recorrerListaCompraProveedor(id_predeterminado);

                listView1.Items.Clear();
                id_predeterminado = consultas.referenciaPredeterminada("id_compraproveedor", "compraproveedor", refPredeterminada, text_refcompraproveedor);
                refCompraProveedor = refPredeterminada + id_predeterminado;
                limpiarCampos();
            }
        }



        private void combo_refarticulo_SelectedIndexChanged(object sender, EventArgs e)
        {
            refArticulo = combo_refarticulo.Text;
         

            nombreProveedor = consultas.obtenerCualquierNombre("id_proveedor","proveedor","ref",refArticulo);
            id_proveedor = consultas.obtenerCualquierId("id_proveedor","articulo","ref",refArticulo);
            //cumplimentarPictureBoxes.cumplimentarPictureBoxProveedor(id_proveedor, pictureBox2);
            id_articulo = consultas.obtenerCualquierId("id_articulo", "articulo", "ref", refArticulo);


            //
            string[] nombres = consultas.nombresCaracteristicas(refArticulo);
            text_proveedor.Text = nombres[0];
            text_clasevino.Text = nombres[1];
            text_denominacion.Text = nombres[2];
            text_catalogacion.Text = nombres[3];
            text_formatocontenido.Text = nombres[4];   
            text_empaquetado.Text = nombres[5];


            CumplimentarPictureBoxes cumplimentarPictureBoxes = new CumplimentarPictureBoxes();
            cumplimentarPictureBoxes.cumplimentarPictureBoxProveedor(id_proveedor, pictureBox3);


            //
            string nombreimagen = consultas.obtenerCualquierRefDesdeNombre("nombreimagen", "articulo", "ref", refArticulo);
            pictureBox1.Image = Image.FromFile(ClaseCompartida.carpetaimg_absoluta + "proveedores/" + id_proveedor + "/articulos/" + nombres[1] + "/" + nombreimagen + "");

            //
            int existenciasAlmacen = articulo.existenciasTotalesZona(1, id_articulo);
            text_unidadesalmacen.Text = existenciasAlmacen.ToString();

            int existenciasTienda = articulo.existenciasTotalesZona(2, id_articulo);
            text_unidadestienda.Text = existenciasTienda.ToString();
            //

            articulo.existenciasTotalesZona(1, id_articulo); articulo.existenciasTotalesZona(2, id_articulo);

            numericUpDown_unidadesacomprar.Enabled = true;
        }
    }
}




/*
    // Preparación de la fecha
    string fecha = dateTimePicker_fechacompra.Text;
    string fechaCompra = ut.preparacionFecha(fecha);
*/
/*
    // Preparacion de la fecha
    DateTime fechaActual = DateTime.Now;
    string fechaFormateada = ut.fechaTimeStam(fechaActual);
*/
















/*
        // Método que comprueba si un item está repetido
        private bool comprobarItem(string refArticuloAnadir)
        {
            seEncuentra = false;
            for (int i = 0; i < listView1.Items.Count; i++)
            {
                if (refArticuloAnadir == listView1.Items[i].SubItems[0].Text)
                {

                    MessageBox.Show("Ya se encuentra referencia Artículo " + listView1.Items[i].SubItems[0].Text);

                    decimal sumaExistencias = Int32.Parse(listView1.Items[i].SubItems[4].Text) + numericUpDown_unidadesacomprar.Value;
                    listView1.Items[i].SubItems[4].Text = sumaExistencias.ToString();


                    decimal totalArticulo = Decimal.Parse(listView1.Items[i].SubItems[4].Text) * Decimal.Parse(listView1.Items[i].SubItems[5].Text);
                    listView1.Items[i].SubItems[6].Text = totalArticulo.ToString();
                    seEncuentra = true;
                    return seEncuentra;
                }
            }
            return seEncuentra;
            MessageBox.Show("Incluya todo ya que podría comprar a diferentes precios!");

        }*/
