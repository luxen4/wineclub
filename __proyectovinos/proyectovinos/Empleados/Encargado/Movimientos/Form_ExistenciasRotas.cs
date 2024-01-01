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

        private string refLineaCompraproveedor = "";


        private string refCompraProveedor = ""; 
        private string nombreProveedor = "";

        private int id_predeterminado = 0, id_compraproveedor = 0;
        private string refPredeterminada = "EXROT";
        private int id_proveedor = 0;

        // Igual que el devolver a proveedor  (SIMPLIFICAR)

        private void Form_ExistenciasRotas_Load(object sender, EventArgs e)
        {
            this.CenterToScreen();
            this.Top = this.Top + 19;
            CumplimentarComboboxes cump = new CumplimentarComboboxes();
            cump.cumplimenterComboboxCualquiereReferencia("ref", "compraproveedor", combo_refcompraproveedor);

            cump.refrescarCombo("ref", "articulo", combo_refarticulo);
            id_predeterminado = consultas.referenciaPredeterminada("id_bajaexistencias", "bajaexistencias", refPredeterminada, text_refcompraproveedor);
            refCompraProveedor = refPredeterminada + id_predeterminado;
        }


        /// <summary>
        /// Función que cumplimenta el combo de ref de lineas de una compra de proveedor.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void combo_refcompraproveedor_SelectedIndexChanged(object sender, EventArgs e)
        {
            text_preciocoste.Text = "";
            combo_reflineacompraproveedor.Enabled = true;
            refCompraProveedor = combo_refcompraproveedor.Text;
            id_compraproveedor = consultas.obtenerCualquierId("id_compraproveedor", "compraproveedor", "ref", refCompraProveedor);
            combo_reflineacompraproveedor.Enabled = true;
            combo_reflineacompraproveedor.Items.Clear();
            alm.refLineasCompraProveedor(id_compraproveedor, id_articulo, combo_reflineacompraproveedor);
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
            text_preciocoste.Text = "";
            combo_refcompraproveedor.Enabled = true;
           
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
            
        }


        /// <summary>
        /// Función que aporta la información de un artículo y su linea de compra al proveedor
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void combo_reflineacompraproveedor_SelectedIndexChanged(object sender, EventArgs e)
        {
            numeric_cantidad.Enabled = true;
            refLineaCompraproveedor = combo_reflineacompraproveedor.Text;
            id_lineacompraproveedor = consultas.obtenerCualquierId("id_lineacompraproveedor","lineacompraproveedor","ref",refLineaCompraproveedor);

            decimal precioCoste = articulo.precioCosteVentaArticulo(refLineaCompraproveedor, "preciocoste");
            text_preciocoste.Text = precioCoste.ToString();

            int existenciasLineaAlmacen = articulo.existenciasLineaZona(1, id_articulo, id_lineacompraproveedor);
            text_unidadesalmacen.Text = existenciasLineaAlmacen.ToString();

            int existenciasLineaTienda = articulo.existenciasLineaZona(2, id_articulo, id_lineacompraproveedor);
            text_unidadestienda.Text = existenciasLineaTienda.ToString();
        }


        private void limpiarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            limpiarCampos();
        }

        //       
        /// <summary>
        /// Función que comprueba las existencias de un artículo antes de darlas de baja 
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void numeric_cantidad_ValueChanged(object sender, EventArgs e)
        {
            //MessageBox.Show(numeric_cantidad.Value.ToString());
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
                    MessageBox.Show("No hay tantas existencias en tienda!");
                }
            }

        }

        /// <summary>
        /// Controlador para modificar la baja de existencias.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void modificarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (combo_refarticulo.Text != "Seleccione" && combo_refcompraproveedor.Text != "Seleccione" && combo_reflineacompraproveedor.Text != "Seleccione")
            {

                bool permiteDescontar = comprobar2();
                //bool permiteDescontar = true;

                if (permiteDescontar == true)
                {

                    DialogResult opcionSeleccionada = MessageBox.Show("Realmente desea dara de baja las existencias de este artículo?", "Aviso", MessageBoxButtons.YesNo);

                    if (opcionSeleccionada == DialogResult.Yes)

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
                        else if (radio_tienda.Checked)
                        {
                            id_ubicacion = 2;
                            existencias = Int32.Parse(text_unidadestienda.Text);
                            existencias = existencias - Int32.Parse(numeric_cantidad.Text);
                        }

                        id_predeterminado = consultas.referenciaPredeterminada("id_bajaexistencias", "bajaexistencias", refPredeterminada, text_refcompraproveedor);


                        if (unidades == 0)
                        {
                            MessageBox.Show("Incremente unidades");

                        }
                        else {
                            if (existencias < 0)
                            {
                                MessageBox.Show("Imposible tener en la ubicación existencias negativas!");
                            }
                            else { 
                                mov.registroBajaExistenciasUbicacion(id_predeterminado, id_empleado, id_ubicacion, id_lineacompraproveedor, unidades, fechaFormateada);
                                mov.ajusteExistenciasUbicacion(id_lineacompraproveedor, existencias, id_ubicacion);

                                limpiarCampos();
                                numeric_cantidad.Value = 0;
                            }
                        }

                    }
                    else
                    {
                        MessageBox.Show("Tenga cuidado!");
                    }
                }
                else
                {
                    
                }

            }
            else {
                MessageBox.Show(ClaseCompartida.msgCamposEnBlanco);
            }
        }

        private bool comprobar2()
        {
            bool permiteDescontar = true; 
            int unidadesAlmacen = Int32.Parse(text_unidadesalmacen.Text);
            int unidadesTienda = Int32.Parse(text_unidadestienda.Text);
            // Por si se mete a mano en el numeric y no se detecta el onchange

            if (radio_almacen.Checked)
            {
                if (numeric_cantidad.Value > unidadesAlmacen)
                {
                    MessageBox.Show("No puede descontar más unidades de las que contiene el almacén");
                    permiteDescontar = false;
                }
            }
            else if (radio_tienda.Checked)
            {
                if (numeric_cantidad.Value > unidadesTienda)
                {
                    MessageBox.Show("No puede descontar más unidades de las que contiene la tienda");
                    permiteDescontar = false;
                }
            }
            return permiteDescontar;
        }




        /// <summary>
        /// Función que comprueba si las unidades a dar de baja son mayor que las que se tiene
        /// </summary>
        /// <param name="unidadesDevolver">The unidades devolver.</param>
        /// <param name="textBox">The text box.</param>
        /// <returns></returns>
        private bool comprobar(int unidadesDevolver, TextBox textBox) {

            if (unidadesDevolver != 0) { 
                if (unidadesDevolver > Int32.Parse(textBox.Text))
                {
                    //numeric_cantidad.Value = Int32.Parse(numeric_cantidad.Text) - 1;
                    numeric_cantidad.Value = Int32.Parse(numeric_cantidad.Text);
                    return false;
                
                }
                else
                {
                    decimal total = numeric_cantidad.Value * Decimal.Parse(text_preciocoste.Text.ToString());
                    text_total.Text = total.ToString();
                    return true;
                }
            }
            return false;
        }

        /// <summary>
        /// Apertura de formulario para compras a Proveedores.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void comprasAProveedoresToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Class_ProveedorAperturaForms proveedorAperturaForms = new Class_ProveedorAperturaForms();
            proveedorAperturaForms.comprarArticuloProveedor();
        }


        // Función que pone todos los campos en modo predeterminado
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
            pictureBox2.Image = null;

            combo_reflineacompraproveedor.Enabled = false;

            combo_refcompraproveedor.Enabled = false;
            combo_reflineacompraproveedor.Enabled = false;

            numeric_cantidad.Enabled = false;
        }



    }
}
