using System;
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
using proyectovinos.Movimientos.AlmacenProveedor;
using proyectovinos.Movimientos.AlmacenTienda;

namespace proyectovinos.VentasDevolucionesSocio
{
    public partial class Form_ModificarPreciosLineaCompraProveedor : Form
    {
        public Form_ModificarPreciosLineaCompraProveedor()
        {
            InitializeComponent();
            this.CenterToScreen();
        }

        //Class_AlmacenTienda almacenTienda = new Class_AlmacenTienda();
        Class_Articulo articulo = new Class_Articulo();
        Consultas consultas = new Consultas();
        CumplimentarComboboxes cumpCombos = new CumplimentarComboboxes();
        Utilidades ut = new Utilidades();
        CumplimentarPictureBoxes cumpPictures = new CumplimentarPictureBoxes();


        private int id_proveedor = 0;
        private string nombreProveedor, refArticulo, nombreCatalogacion, refLinea;
        private string refProveedor = "";

        private void combo_reflinea_SelectedIndexChanged(object sender, EventArgs e)
        {
            refLinea = combo_reflinea.Text;

          /*  string fecha = consultas.fechaCompraProveedor(refLinea);   // MessageBox.Show(fecha);
            dateTimePicker_fechacompra.Text = fecha;*/

            string refLineaCompraProveedor = combo_reflinea.Text;
            int id_lineacompraproveedor = consultas.obtenerCualquierId("id_lineacompraproveedor", "lineacompraproveedor", "ref", refLineaCompraProveedor);

            int existenciasLineaAlmacen = articulo.existenciasLineaZona(1, id_articulo, id_lineacompraproveedor);
            text_unidadesalmacen.Text = existenciasLineaAlmacen.ToString();

            int existenciasLineaTienda = articulo.existenciasLineaZona(2, id_articulo, id_lineacompraproveedor);
            text_unidadestienda.Text = existenciasLineaTienda.ToString();


            string nombreFormato = consultas.obtenerCualquierNombre("id_formatocontenido", "formatocontenido", "ref", refArticulo);
            text_formatocontenido.Text = nombreFormato;

            string nombreEmpaquetado = consultas.obtenerCualquierNombre("id_empaquetado", "empaquetado", "ref", refArticulo);
            text_empaquetado.Text = nombreEmpaquetado;


            articulo.existenciasTotalesZona(1, id_articulo);
            articulo.existenciasTotalesZona(2, id_articulo);


            // Unidades compradas en esa línea
            string[] datos = unidadesPreciosLinea(refLinea);
            

          //  numeric_cantidad.Value = Decimal.Parse(datos[0]);
          //  numericUpDown_preciocoste.Value = Decimal.Parse(datos[1]);
            numeric_precioventa.Value = Decimal.Parse(datos[2]);
            //
        }

        private void Form_ModificarPreciosLineaCompraProveedor_Load(object sender, EventArgs e)
        {
            this.CenterToScreen();
           
            cumpCombos.refrescarCombo("ref", "articulo", combo_refarticulo);
        }


        // Método que devuelve un array con los datos de existencias y precios de una línea de compra de provvedor
        private string[] unidadesPreciosLinea(string refLinea)
        {
            string[] datos = new string [3];

            ConexionBD con = new ConexionBD();
            string cadenaConexion = con.conexion();
            MySqlConnection conexionBD = new MySqlConnection(cadenaConexion);

                try
                {
                    string selectQuery = "select existencias, preciocoste, precioventa from lineacompraproveedor where ref='" + refLinea + "'";

                MessageBox.Show(selectQuery);

                    conexionBD.Open();
                    MySqlCommand command = new MySqlCommand(selectQuery, conexionBD);
                    MySqlDataReader reader = command.ExecuteReader();


                    while (reader.Read())
                    {
                        string existencias = reader.GetString("existencias"); datos[0] = existencias; 
                        string preciocoste = reader.GetString("preciocoste"); datos[1] = preciocoste;
                        string precioventa = reader.GetString("precioventa"); datos[2] = precioventa;
                    }

                }
                catch (Exception ex){ MessageBox.Show(ex.Message);}
                finally { conexionBD.Close(); }

            MessageBox.Show(datos[0]);
            return datos;
        }

        private int id_articulo = 0;

        private void modificarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("a modificar!!!");
            string refLinea = combo_reflinea.Text;
            // int existencias = Int32.Parse(numeric_cantidad.Value.ToString()); //existencias = existencias.Replace(",", "."); 
            // string preciocoste = numericUpDown_preciocoste.Value.ToString();    preciocoste = preciocoste.Replace(",", ".");
            string precioventa = numeric_precioventa.Value.ToString(); precioventa = precioventa.Replace(",", ".");

            Class_AlmacenTienda almacenTienda = new Class_AlmacenTienda();
            almacenTienda.ajusteExistenciasLineaCompraProveedor(/*existencias, preciocoste,*/ precioventa, refLinea);

            limpiarCampos();
        }

        private void limpiarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            limpiarCampos();
        }

        private void combo_refarticulo_SelectedIndexChanged(object sender, EventArgs e)
        {
            combo_reflinea.Enabled = true;

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

    

            combo_reflinea.Items.Clear();
            cumpPictures.cumplimentarPictureBox(refArticulo, pictureBox1);
            cumpPictures.cumplimentarPictureBoxProveedor(id_proveedor,pictureBox2);
            cumpCombos.refrescarComboboxLineaCompraProveedorDesdeId_articulo(id_articulo, combo_reflinea);
            combo_reflinea.Enabled = true;



            //
            int existenciasUbicacionAlmacen = articulo.existenciasTotalesZona(1, id_articulo);
            text_unidadesalmacen.Text = existenciasUbicacionAlmacen.ToString();

            int existenciasUbicaciontienda = articulo.existenciasTotalesZona(2, id_articulo);
            text_unidadestienda.Text = existenciasUbicaciontienda.ToString();
            //


            combo_reflinea.Enabled = true;

        }
        
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            refLinea = combo_reflinea.Text;
            int id_lineacompraproveedor = consultas.obtenerCualquierId("id_lineacompraproveedor", "lineacompraproveedor", "ref", refLinea);

            //
            Class_Articulo articulo = new Class_Articulo();
            int existenciasAlmacen = articulo.existenciasLineaZona(1, id_articulo, id_lineacompraproveedor);
            text_unidadesalmacen.Text = existenciasAlmacen.ToString();

            int existenciasTienda = articulo.existenciasLineaZona(2, id_articulo, id_lineacompraproveedor);
            text_unidadestienda.Text = existenciasTienda.ToString();

            // Hacer Tabla de cuándo se ha hecho este movimiento

            string unidadesCompradas = consultas.obtenerCualquierRefDesdeNombre("existencias","lineacompraproveedor","id_articulo",id_articulo.ToString());
            text_unidadescompradas.Text = unidadesCompradas;

            //decimal preciocoste = articulo.precioCosteVentaArticulo(refLinea, "preciocoste"); 
            string preciocoste = consultas.obtenerCualquierRefDesdeNombre("preciocoste", "lineacompraproveedor", "id_articulo", id_articulo.ToString());
            text_preciocoste.Text = preciocoste;


            decimal precioventa = articulo.precioCosteVentaArticulo(refLinea, "precioventa");
          
            numeric_precioventa.Text = precioventa.ToString();
        }
      
        
            // Método que deja los campos en modo predeterminado
            private void limpiarCampos()
            {
            combo_refarticulo.Text = "Seleccione";
            combo_reflinea.Text = "Seleccione";
                text_proveedor.Text = "";
            text_proveedor.Text = "";
                text_catalogacion.Enabled=false;
                combo_reflinea.Enabled=false;
                text_clasevino.Text = "";
                text_catalogacion.Text = "";
                text_denominacion.Text = "";
                text_formatocontenido.Text = "";
                text_unidadesalmacen.Text = "";
                text_unidadestienda.Text = "";
            text_unidadescompradas.Text = "0";
            text_preciocoste.Text = "0";
            numeric_precioventa.Text = "0";
                                                    
                text_empaquetado.Text = "";
                pictureBox1.Image = null;
            }
        
    }
}
