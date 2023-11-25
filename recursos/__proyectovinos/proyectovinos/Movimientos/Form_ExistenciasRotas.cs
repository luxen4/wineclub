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
    public partial class Form_ExistenciasRotas : Form
    {
        public Form_ExistenciasRotas()
        {
            InitializeComponent();
        }

        Consultas consultas = new Consultas();
        Utilidades ut = new Utilidades();   
        Class_Movimientos mov = new Class_Movimientos();
        Class_Articulo articulo = new Class_Articulo();
        Class_AlmacenProveedor alm = new Class_AlmacenProveedor();

        private int id_lineacompraproveedor = 0;
        private int existencias = 0;
        private int id_ubicacion = 0;


        private string refCompraProveedor = "", nombreProveedor = "";

        private int id_predeterminado = 0, id_compraproveedor = 0;
        private string refPredeterminada = "EXROT";
        private int id_proveedor = 0;

        // Igual que el devolver a proveedor  (SIMPLIFICAR)

        private void Form_ExistenciasRotas_Load(object sender, EventArgs e)
        {
            this.CenterToScreen();
            CumplimentarComboboxes cump = new CumplimentarComboboxes();
            cump.cumplimenterComboboxCualquiereReferencia("ref", "compraproveedor", combo_refcompraproveedor);

            cump.refrescarCombo("ref", "articulo", combo_refarticulo);
            id_predeterminado = consultas.referenciaPredeterminada("id_bajaexistencias", "bajaexistencias", refPredeterminada, text_refcompraproveedor);
            refCompraProveedor = refPredeterminada + id_predeterminado;
        }



        private void combo_refcompraproveedor_SelectedIndexChanged(object sender, EventArgs e)
        {
            refCompraProveedor = combo_refcompraproveedor.Text;
            id_compraproveedor = consultas.obtenerCualquierId("id_compraproveedor", "compraproveedor", "ref", refCompraProveedor);
            combo_reflineacompraproveedor.Enabled = true;
            combo_reflineacompraproveedor.Items.Clear();
            alm.refLineasCompraProveedor(id_compraproveedor, id_articulo, combo_reflineacompraproveedor);
        }
  
       


        private void button_anadir_Click(object sender, EventArgs e)
        {
            int id_empleado = consultas.obtenerCualquierId("id_empleado", "empleado", "ref", ClaseCompartida.refe);
            int unidades = Int32.Parse(numeric_cantidad.Text);

            // fecha de la compra
            DateTime fechaActual = DateTime.Now;
            string fechaFormateada = ut.fechaTimeStam(fechaActual);

            if (radio_almacen.Checked)
            {
                id_ubicacion = 1;
                existencias = Int32.Parse(text_unidadesalmacen.Text);
                existencias = existencias - Int32.Parse(numeric_cantidad.Text);
            }
            else if(radio_tienda.Checked){
                id_ubicacion = 2;
                existencias = Int32.Parse(text_unidadestienda.Text);
                existencias = existencias - Int32.Parse(numeric_cantidad.Text);
            }

            id_predeterminado = consultas.referenciaPredeterminada("id_bajaexistencias", "bajaexistencias", refPredeterminada, text_refcompraproveedor);
            
            mov.registroBajaExistenciasUbicacion(id_predeterminado, id_empleado, id_ubicacion,id_lineacompraproveedor,unidades, fechaFormateada);
            mov.ajusteExistenciasUbicacion(id_lineacompraproveedor, existencias, id_ubicacion);

            limpiarCampos();
            numeric_cantidad.Value = 0;

        }
        CumplimentarPictureBoxes cumplimentarPictureBoxes = new CumplimentarPictureBoxes();
        CumplimentarComboboxes cumplimentarComboboxes = new CumplimentarComboboxes();

        private string refArticulo = "";
        private int id_articulo = 0;

        private void combo_refcompraproveedor_Click(object sender, EventArgs e)
        {
            if (combo_refcompraproveedor.Items.Count==0)
            {
                MessageBox.Show("No hay ha habido compra a Proveedor para este artículo");
            }
            combo_reflineacompraproveedor.Enabled = false;
        }

        private void combo_refarticulo_SelectedIndexChanged(object sender, EventArgs e)
        {
            combo_refcompraproveedor.Enabled = true;
            refArticulo = combo_refarticulo.Text;
            id_articulo = consultas.obtenerCualquierId("id_articulo", "articulo", "ref", refArticulo);
            cumplimentarComboboxes.refrescarComboboxRefCompraProveedorDesdeId_articulo(id_articulo, combo_refcompraproveedor);
            
            nombreProveedor = consultas.obtenerCualquierNombre("id_proveedor", "proveedor", "ref", refArticulo);
            id_proveedor = consultas.obtenerCualquierId("id_proveedor", "articulo", "ref", refArticulo);
            cumplimentarPictureBoxes.cumplimentarPictureBoxProveedor(id_proveedor, pictureBox2);
         

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

            //
            int existenciasAlmacen = articulo.existenciasTotalesZona(1, id_articulo);
            text_unidadesalmacen.Text = existenciasAlmacen.ToString();

            int existenciasTienda = articulo.existenciasTotalesZona(2, id_articulo);
            text_unidadestienda.Text = existenciasTienda.ToString();
            //

            articulo.existenciasTotalesZona(1, id_articulo); articulo.existenciasTotalesZona(2, id_articulo);
            numeric_cantidad.Enabled = true;
        }

        private string refLineaCompraproveedor = "";

        private void combo_reflineacompraproveedor_SelectedIndexChanged(object sender, EventArgs e)
        {
            refLineaCompraproveedor = combo_reflineacompraproveedor.Text;
            id_lineacompraproveedor = consultas.obtenerCualquierId("id_lineacompraproveedor","lineacompraproveedor","ref", refLineaCompraproveedor);
            decimal precioCoste = articulo.precioCosteVentaArticulo(combo_reflineacompraproveedor.Text, "preciocoste");
            text_preciocoste.Text = precioCoste.ToString();
        }

        private void limpiarCampos()
        {
            combo_refcompraproveedor.Text = "Seleccione";
            text_proveedor.Text = "";
            combo_refarticulo.Text = "Seleccione";
            text_clasevino.Text = "";
            combo_reflineacompraproveedor.Text = "";
            text_denominacion.Text = "";
            text_formatocontenido.Text = "";
            text_empaquetado.Text = "";
            text_catalogacion.Text = "";
            text_unidadesalmacen.Text = "";
            text_unidadestienda.Text = "";
            
            text_empaquetado.Text = "";
            pictureBox1.Image = null;

            combo_reflineacompraproveedor.Enabled = false;
        }

        private void numeric_cantidad_ValueChanged(object sender, EventArgs e)
        {
            int unidadesDevolver = Int32.Parse(numeric_cantidad.Value.ToString());


            if (radio_almacen.Checked) {
                bool comprobacion = comprobar(unidadesDevolver, text_unidadesalmacen);
                if (comprobacion==false && unidadesDevolver != 0) {
                    MessageBox.Show("No hay tantas existencias en el almacén!");
                }

            } else if(radio_tienda.Checked){
                bool comprobacion = comprobar(unidadesDevolver, text_unidadestienda);
                if (comprobacion == false && unidadesDevolver != 0)
                {
                    MessageBox.Show("No hay tantas existencias en el almacén!");
                }
            }

        }


        private bool comprobar(int unidadesDevolver, TextBox textBox) {

            if (unidadesDevolver != 0) { 
             if (unidadesDevolver > Int32.Parse(textBox.Text))
            {
                numeric_cantidad.Value = Int32.Parse(numeric_cantidad.Text) - 1;
                return false;
                
            }
            else
            {
                decimal total = numeric_cantidad.Value * Decimal.Parse(text_preciocoste.Text.ToString());
                text_total.Text = total.ToString();
                button_anadir.Enabled = true;
                return true;
            }
             
            }
            
            return false;
        
        }



    }
}
