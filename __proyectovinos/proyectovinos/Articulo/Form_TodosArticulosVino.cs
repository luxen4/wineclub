using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Runtime.InteropServices.ComTypes;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using proyectovinos;
using proyectovinos.ArticuloVino;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using Image = System.Drawing.Image;

namespace proyectovinos
{
    public partial class Form_TodosArticulosVino : Form
    {

        public Form_TodosArticulosVino()
        {
            InitializeComponent();
        }

        private string referencia = "";
        private int existenciasAlmacen = 0, existenciasTienda = 0;
        private int id_articulo = 0;
        private int id_catalogacion = 0; 
        private int id_proveedor = 0;
        private int id_empaquetado = 0;
        private bool cargaLista = false;

        Class_ArticuloAperturaForms articuloAperturaForm = new Class_ArticuloAperturaForms();
        Consultas consultas = new Consultas();
        Class_Articulo articulo = new Class_Articulo();
        CumplimentarComboboxes combos = new CumplimentarComboboxes();
       

      

        private void Form_TodosArticulosVino_Load(object sender, EventArgs e)
        {
            this.CenterToScreen();
        }

        private void listView1_ItemChecked(object sender, ItemCheckedEventArgs e)
        {
            int item = e.Item.Index;
            id_proveedor = Int32.Parse(listView1.Items[item].SubItems[2].Text);
            if (cargaLista == true)
            {
                articulo.articuloSeleccionado(e, text_refarticulo, listView1, text_unidadesalmacen, text_unidadestienda, text_empaquetado, pictureBox1);
            }
        }




    // Para apertura de formularios

        private void nuevoArtículoVinoToolStripMenuItem_Click(object sender, EventArgs e)
        {   // Método que abre un formulario para crear un Artículo de Vino
            articuloAperturaForm.nuevoArticuloVino(); 
        }
        
        private void modificarToolStripMenuItem_Click(object sender, EventArgs e)
        {   // Método que abre un formulario para modificar un Artículo de Vino
            articuloAperturaForm.modificarArticuloVino(); 
        }
        
        private void eliminarToolStripMenuItem_Click(object sender, EventArgs e)
        {  // Método que abre un formulario para eliminar un Artículo de Vino
            articuloAperturaForm.eliminarArticuloVino(); 
        }
    //



        private void btn_deshabilitar_Click(object sender, EventArgs e)
        {
            if (check_seguro.Checked)
            {
                referencia = text_refarticulo.Text;
                consultas.habilitarDesabilitarCualquierReferencia("articulo", "ref", referencia, '0');

                cargaLista = false;
                articulo.cumplimentarListaArticulos(listView1, '1');
                cargaLista = true;
                articulo.limpiarCampos(text_unidadesalmacen, text_unidadestienda, text_empaquetado, check_seguro, pictureBox1);

                limpiarcampos();

              
            }
            else
            {
                MessageBox.Show(ClaseCompartida.msgCasillaSeguro);
            }
        }

  

     


        private void listView1_ItemChecked_1(object sender, ItemCheckedEventArgs e)
        {
            if (cargaLista == true)
            {
                referencia = e.Item.Text;
                text_refarticulo.Text = referencia;
                id_articulo = consultas.obtenerCualquierId("id_articulo", "articulo", "ref", referencia);
                articulo.articuloSeleccionado(e, text_refarticulo, listView1, text_unidadesalmacen, text_unidadestienda, text_empaquetado, pictureBox1);
            }
        }



        // Refrescar Combos
        private void combo_nombreproveedor_Click(object sender, EventArgs e)
        {
            combos.refrescarCombo("nombre", "proveedor", combo_nombreproveedor);
        }

        private void comboBox_nombrecatalogacion_Click(object sender, EventArgs e)
        {
            combos.refrescarCombo("nombre", "catalogacion", comboBox_nombrecatalogacion);
        }

        private void comboBox_nombreempaquetado_Click(object sender, EventArgs e)
        {
            combos.refrescarCombo("nombre", "empaquetado", comboBox_nombreempaquetado);
        }
        //



        //Combos
        private void combo_nombreproveedor_SelectedIndexChanged(object sender, EventArgs e)
        {//
            comboBox_nombrecatalogacion.Text = "Seleccione";
            comboBox_nombreempaquetado.Text = "Seleccione";
            id_proveedor = consultas.obtenerCualquierId("id_proveedor", "proveedor", "nombre", combo_nombreproveedor.Text);
        }

        private void comboBox_nombrecatalogacion_SelectedIndexChanged(object sender, EventArgs e)
        {//
            combo_nombreproveedor.Text = "Seleccione";
            comboBox_nombreempaquetado.Text = "Seleccione";
            id_catalogacion = consultas.obtenerCualquierId("id_catalogacion", "catalogacion", "nombre", comboBox_nombrecatalogacion.Text);
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {//
            combo_nombreproveedor.Text = "Seleccione";
            comboBox_nombrecatalogacion.Text = "Seleccione";
            id_empaquetado = consultas.obtenerCualquierId("id_empaquetado", "empaquetado", "nombre", comboBox_nombreempaquetado.Text);
        }


        //Botones
        private void button1_Click_1(object sender, EventArgs e)
        {//
            limpiarcampos();
            cargaLista = false;
            articulo.listaArticulos_Filtrados("id_proveedor", id_proveedor, listView1, '1');
            cargaLista = true;
        }



        private void button2_Click(object sender, EventArgs e)
        {//
            limpiarcampos();
            cargaLista = false;
            articulo.listaArticulos_Filtrados("id_catalogacion", id_catalogacion, listView1, '1');
            cargaLista = true;
        }
        private void button3_Click(object sender, EventArgs e)
        {//
            limpiarcampos();
            cargaLista = false;
            articulo.listaArticulos_Filtrados("id_empaquetado", id_empaquetado, listView1, '1');
            cargaLista = true;
        }



        private void limpiarcampos()
        {
            text_refarticulo.Text = "";
            text_unidadesalmacen.Text = "";
            text_unidadestienda.Text = "";
            text_empaquetado.Text = "";
            check_seguro.Checked = false;
            pictureBox1.Image = null;

            comboBox_nombrecatalogacion.Text = "Seleccione";
            comboBox_nombreempaquetado.Text = "Seleccione";
            combo_nombreproveedor.Text = "Seleccione";
            comboBox_nombrecatalogacion.Text = "Seleccione";
        }
       

        private void button4_Click(object sender, EventArgs e)
        {
            /*limpiarcampos();
            cargaLista = false;
            articulo.cumplimentarListaArticulos(listView1, '1');
            cargaLista = true;*/
        }

        private void actualizarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            limpiarcampos();
            cargaLista = false;
            articulo.cumplimentarListaArticulos(listView1, '1');
            cargaLista = true;
        }

        private void artículosInhabilitadosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Class_ArticuloAperturaForms apertura = new Class_ArticuloAperturaForms();
            apertura.articulosInhabilitados();
        }   
    }
}

