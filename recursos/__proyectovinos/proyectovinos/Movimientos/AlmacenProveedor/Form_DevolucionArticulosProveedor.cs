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

namespace proyectovinos.Movimientos
{
    public partial class Form_DevolucionArticulosProveedor : Form
    {
        public Form_DevolucionArticulosProveedor()
        {
            InitializeComponent();
        }

        Consultas consultas = new Consultas();
        Utilidades ut = new Utilidades();
        Class_AlmacenProveedor alm = new Class_AlmacenProveedor(); 
        Class_Movimientos mov = new Class_Movimientos();

        private int existenciasAlmacen = 0, existenciasTienda=0, id_lineacompraproveedor=0;
        private string refCompraProveedor = "";
        private int id_compraproveedor = 0;
        private int id_articulo = 0, id_proveedor = 0;

        private void Form_DevolucionAlmacenProveedor_Load(object sender, EventArgs e)
        {
            this.CenterToScreen();
            CumplimentarComboboxes cump = new CumplimentarComboboxes();
            cump.cumplimenterComboboxCualquiereReferencia("ref","compraproveedor",combo_refcompraproveedor);
        }

     
        // Método 
        private void combo_reflineacompraproveedor_SelectedIndexChanged(object sender, EventArgs e)
        {
            string refLineaCompraProveedor = combo_reflineacompraproveedor.Text;
            id_lineacompraproveedor = consultas.obtenerCualquierId("id_lineaCompraProveedor","lineacompraproveedor","ref",refLineaCompraProveedor);

            id_articulo = consultas.obtenerCualquierId("id_articulo","lineacompraproveedor","ref",refLineaCompraProveedor);
            string refArticulo = consultas.obtenerCualquierRefDesdeId("ref","articulo","id_articulo",id_articulo);

           
            CumplimentarPictureBoxes cump = new CumplimentarPictureBoxes();
            cump.cumplimentarPictureBox(refArticulo, pictureBox1);

            Class_Proveedor proveedor = new Class_Proveedor();
            proveedor.nombreProveedor(refLineaCompraProveedor);

            id_proveedor = consultas.obtenerCualquierId("id_proveedor","articulo","ref",refArticulo);
            cump.cumplimentarPictureBoxProveedor(id_proveedor, pictureBox2);

            text_refarticulo.Text = refArticulo;



            //
            string[] nombres = consultas.nombresCaracteristicas(refArticulo);
            text_proveedor.Text = nombres[0];
            text_clasevino.Text = nombres[1];
            text_denominacion.Text = nombres[2];
            text_catalogacion.Text = nombres[3];
            text_formatocontenido.Text = nombres[4];
            text_empaquetado.Text = nombres[5];

            //

            string nombreimagen = consultas.obtenerCualquierRefDesdeNombre("nombreimagen", "articulo", "ref", refArticulo);
            pictureBox1.Image = Image.FromFile(ClaseCompartida.carpetaimg_absoluta + "proveedores/" + id_proveedor + "/articulos/" + nombres[1] + "/" + nombreimagen + "");

       
            Class_Articulo articulo = new Class_Articulo();


            //
            existenciasAlmacen = articulo.existenciasLineaZona(1, id_articulo, id_lineacompraproveedor);

            text_existenciasalmacen.Text = existenciasAlmacen.ToString();
            text_unidadesalmacen.Text = existenciasAlmacen.ToString();

            existenciasTienda = articulo.existenciasLineaZona(2, id_articulo, id_lineacompraproveedor);
            text_existenciastienda.Text = existenciasTienda.ToString();

            decimal precioCoste = articulo.precioCosteVentaArticulo(refLineaCompraProveedor, "preciocoste");
            text_preciocoste.Text = precioCoste.ToString();
            //

            numeric_cantidad.Enabled = true;

        }

        // Método que refresca las lineas de una Compra a Proveedor a partir de su referencia
        private void combo_refcompraproveedor_SelectedIndexChanged(object sender, EventArgs e)
        {
            refCompraProveedor = combo_refcompraproveedor.Text;
            id_compraproveedor = consultas.obtenerCualquierId("id_compraproveedor", "compraproveedor", "ref", refCompraProveedor);
            combo_reflineacompraproveedor.Items.Clear();
            alm.refLineasCompraProveedor(id_compraproveedor, id_articulo, combo_reflineacompraproveedor);

            string fecha = consultas.obtenerCualquierRefDesdeNombre("fechacompra","compraproveedor","ref",refCompraProveedor);
            dateTimePicker_fechacompra.Text = fecha;
        }





        // Método que evalua si se alcanza el maximo de existencias a devolver aproveedor desde almacén
        private void numericUpDown_unidadesdevolver_ValueChanged(object sender, EventArgs e)
        {
            decimal unidadesDevolver = numeric_cantidad.Value;

            if (unidadesDevolver > existenciasAlmacen)
            {
                MessageBox.Show("No hay tantas existencias en el almacén!");
                numeric_cantidad.Value = Decimal.Parse(numeric_cantidad.Text);
            }
            else
            {
                if (text_preciocoste.Text!="") { 
                decimal total = numeric_cantidad.Value * Decimal.Parse(text_preciocoste.Text);
                text_total.Text = total.ToString();
                button_anadir.Enabled = true;
                }
                
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            limpiarcampos();
        }


        // Método controlador encargado de hacer una devolución a Proveedor y ajustar existencias en almacén
        private void button_anadir_Click(object sender, EventArgs e)
        {
            int id_empleado = consultas.obtenerCualquierId("id_empleado","empleado","ref",ClaseCompartida.refe);
            int unidades = Int32.Parse(numeric_cantidad.Text);

            // fecha de la compra mete la hora
            DateTime fechaActual = DateTime.Now;
            string fechacompra = ut.fechaTimeStam(fechaActual);


            int existencias = existenciasAlmacen - Int32.Parse(numeric_cantidad.Text);
         
            alm.registrarDevolucionProveedor(id_empleado,id_lineacompraproveedor, unidades, fechacompra);
            mov.ajusteExistenciasUbicacion(id_lineacompraproveedor, existencias, 1);
            limpiarcampos();
        }

        private void limpiarcampos()
        {
            combo_refcompraproveedor.Text = "Seleccione";
            combo_reflineacompraproveedor.Text = "Seleccione";
            text_refarticulo.Text = "";
            text_unidadesalmacen.Text = "0";
            text_proveedor.Text = "";
            text_clasevino.Text = "";
            text_denominacion.Text = "";
            text_catalogacion.Text = "";
            text_existenciasalmacen.Text = "";
            text_existenciastienda.Text = "";
            text_preciocoste.Text = "";
            text_total.Text = "";
            text_formatocontenido.Text = "";
            text_empaquetado.Text = "";
            numeric_cantidad.Enabled = false;
            numeric_cantidad.Value = 0;
            text_preciocoste.Text = "0";
            numeric_cantidad.Value = 0;
            pictureBox1.Image = null;
            pictureBox2.Image = null;
        }
    }
}

/*
string fecha = dateTimePicker_fechacompra.Text;
string fechacompra = ut.preparacionFecha(fecha);
*/