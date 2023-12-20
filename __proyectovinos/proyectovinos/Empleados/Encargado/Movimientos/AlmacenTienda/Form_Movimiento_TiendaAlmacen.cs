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
using proyectovinos.Caracteristicas.proveedor;
using proyectovinos.Movimientos.AlmacenTienda;

namespace proyectovinos
{
    public partial class Form_Movimiento_TiendaAlmacen : Form
    {
        public Form_Movimiento_TiendaAlmacen()
        {
            InitializeComponent();
        }

        Class_Articulo articulo = new Class_Articulo();
        Consultas consultas = new Consultas();
        CumplimentarComboboxes cumpCombo = new CumplimentarComboboxes();
        Utilidades ut = new Utilidades();

        private int id_proveedor = 0;
        private string nombreProveedor, refArticulo, nombreCatalogacion;
        private int id_articulo = 0;


        private void Form_Movimiento_TiendaAlmacen_Load(object sender, EventArgs e)
        {
            this.CenterToScreen();
            //cumpCombo.refrescarCombo("nombre", "proveedor", combo_nombreproveedor);
            cumpCombo.refrescarCombo("ref", "articulo", combo_refarticulo);
        }

        private void button5_Click(object sender, EventArgs e)
        {
            limpiarCampos();
        }


        private void compraAProveedorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Class_ProveedorAperturaForms proveedorAperturaForms = new Class_ProveedorAperturaForms();
            proveedorAperturaForms.comprarArticuloProveedor();
        }


        // Metodo que ajusta las cantidades de almacén y tienda
        private void btn_traspasoAlmacen_Click(object sender, EventArgs e)
        {
            try
            {
                if (combo_reflineacompraproveedor.Text != "Seleccione")
                {
                    if (numericUpDown_unidadesamover.Value != 0)
                    {
                        int existenciasAlmacen = Convert.ToInt32(text_unidadesalmacen.Text);    // Si es negativo da error (que no sea menor de 0)

                        if (existenciasAlmacen != 0)
                        {
                            int existenciasTienda = Convert.ToInt32(text_unidadestienda.Text);
                            string empaquetado = text_empaquetado.Text;
                            int unidadesAmover = (int)numericUpDown_unidadesamover.Value;

                            Class_AlmacenTienda almacenTienda = new Class_AlmacenTienda();
                            almacenTienda.ajusteCantidadesLineasZonas(combo_reflineacompraproveedor, existenciasAlmacen, existenciasTienda, unidadesAmover,
                                "tienda-almacen", id_articulo);

                            limpiarCampos();

                        }
                        else
                        {
                            MessageBox.Show("Existencias en almacen 0, compre al proveedor");
                        }
                    }
                    else
                    {
                        MessageBox.Show("Incremente Existencias a trasladar!");
                    }
                }
                else
                {
                    MessageBox.Show("No ha seleccionado una Línea de Compra a Proveedor");
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("" + ex);
            }

        }

        private void combo_refarticulo_SelectedIndexChanged(object sender, EventArgs e)
        {
            refArticulo = combo_refarticulo.Text;
            id_articulo = consultas.obtenerCualquierId("id_articulo", "articulo", "ref", refArticulo);

            nombreProveedor = consultas.obtenerCualquierNombre("id_proveedor", "proveedor", "ref", refArticulo);
            id_proveedor = consultas.obtenerCualquierId("id_proveedor", "proveedor", "nombre", nombreProveedor);


            //
            string[] nombres = consultas.nombresCaracteristicas(refArticulo);
            text_proveedor.Text = nombres[0];
            string nombreClaseVino = nombres[1];
            text_clasevino.Text = nombreClaseVino;
            text_denominacion.Text = nombres[2];
            text_catalogacion.Text = nombres[3];
            text_formatocontenido.Text = nombres[4]; 
            text_empaquetado.Text = nombres[5];
            pictureBox1.Image = Image.FromFile(ClaseCompartida.carpetaimg_absoluta + "proveedores/" + id_proveedor + "/articulos/" + nombreClaseVino + "/" + refArticulo + ".jpg");
            CumplimentarPictureBoxes cumplimentarPictureBoxes = new CumplimentarPictureBoxes();
            cumplimentarPictureBoxes.cumplimentarPictureBoxProveedor(id_proveedor, pictureBox2);
            //


           // string existMaxTienda = consultas.obtenerCualquierRefDesdeId("maxtienda", "articulo", "id_articulo", id_articulo);
            //text_existmaximas.Text = existMaxTienda;

            combo_reflineacompraproveedor.Items.Clear();
            Class_AlmacenTienda alm = new Class_AlmacenTienda();
            alm.refrescarComboboxLineaCompraProveedor(id_articulo, combo_reflineacompraproveedor, 2);


            //
            int existenciasUbicacionAlmacen = articulo.existenciasTotalesZona(1, id_articulo);
            text_unidadesalmacen.Text = existenciasUbicacionAlmacen.ToString();

            int existenciasUbicaciontienda = articulo.existenciasTotalesZona(2, id_articulo);
            text_unidadestienda.Text = existenciasUbicaciontienda.ToString();
            //

         

            combo_reflineacompraproveedor.Enabled = true;
        }

        private void combo_reflineacompraproveedor_SelectedIndexChanged(object sender, EventArgs e)
        {
            Class_Articulo articulo = new Class_Articulo();
            string refLinea = combo_reflineacompraproveedor.Text;
            int id_lineacompraproveedor = consultas.obtenerCualquierId("id_lineacompraproveedor", "lineacompraproveedor", "ref", refLinea);

            int existenciasLineaAlmacen = articulo.existenciasLineaZona(1, id_articulo, id_lineacompraproveedor);
            text_unidadesalmacen.Text = existenciasLineaAlmacen.ToString();

            int existenciasLineaTienda = articulo.existenciasLineaZona(2, id_articulo, id_lineacompraproveedor);
            text_unidadestienda.Text = existenciasLineaTienda.ToString();


            articulo.existenciasTotalesZona(1, id_articulo);
            articulo.existenciasTotalesZona(2, id_articulo);
            numericUpDown_unidadesamover.Enabled = true;
            //



            //
            int existenciasAlmacen = articulo.existenciasLineaZona(1, id_articulo, id_lineacompraproveedor);
            text_unidadesalmacen.Text = existenciasAlmacen.ToString();

            int existenciasTienda = articulo.existenciasLineaZona(2, id_articulo, id_lineacompraproveedor);
            text_unidadestienda.Text = existenciasTienda.ToString();
            //


            if (text_unidadesalmacen.Text == "0")
            {
                MessageBox.Show("No hay existencias en almacén, comuníquese con el Proveedor!");
            }


            numericUpDown_unidadesamover.Enabled = true;
            btn_traspasoAlmacen.Enabled = true;
        }

        private void numericUpDown_unidadesamover_ValueChanged(object sender, EventArgs e)
        {

            if (numericUpDown_unidadesamover.Value > 0)
            {

                if (Int32.Parse(numericUpDown_unidadesamover.Value.ToString()) > Int32.Parse(text_unidadestienda.Text))
                {
                    MessageBox.Show("No hay más existencias");
                    numericUpDown_unidadesamover.Value = numericUpDown_unidadesamover.Value - 1;
                }
                else
                {
                    // Deja incrementar
                }
            }
        }

        private void compraAProveedoresToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Class_ProveedorAperturaForms apertura = new Class_ProveedorAperturaForms();
            apertura.comprarArticuloProveedor();
        }

        private void button5_Click_1(object sender, EventArgs e)
        {
            limpiarCampos();
        }

        private void limpiarCampos()
        {
            combo_reflineacompraproveedor.Text = "Seleccione";
            combo_refarticulo.Text = "Seleccione";
            text_proveedor.Text = "";
            text_clasevino.Text = "";
            text_denominacion.Text = "";
            text_catalogacion.Text = "";
            text_formatocontenido.Text = "";
            text_unidadesalmacen.Text = "";
            text_unidadestienda.Text = "";
            numericUpDown_unidadesamover.Value = 0;
            text_empaquetado.Text = "";
            pictureBox1.Image = null;

            combo_reflineacompraproveedor.Enabled = false;
            text_catalogacion.Enabled = false;

            numericUpDown_unidadesamover.Enabled = false;
            btn_traspasoAlmacen.Enabled = false;
        }
    }
}


