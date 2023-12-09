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
using ListViewItem = System.Windows.Forms.ListViewItem;

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

        private string nombreClasevino = "", nombreImagen;

        private void listView1_ItemChecked_1(object sender, ItemCheckedEventArgs e)
        {
            foreach (ListViewItem item in listView1.Items)
            {
                if (item != e.Item) // Verificar si el elemento no es el actualmente seleccionado
                {
                    item.Checked = false; // Deseleccionar todos los demás elementos
                }
            }

            if (cargaLista == true)
            {
                referencia = e.Item.Text;
                text_refarticulo.Text = referencia;
                id_articulo = consultas.obtenerCualquierId("id_articulo", "articulo", "ref", referencia);
                articulo.articuloSeleccionado(e, text_refarticulo, listView1, text_unidadesalmacen, text_unidadestienda, text_empaquetado, pictureBox1);
            
            


            int item = e.Item.Index;
            //id_proveedor = Int32.Parse(listView1.Items[item].SubItems[2].Text);
            id_proveedor = consultas.obtenerCualquierId("id_proveedor", "proveedor", "nombre", listView1.Items[item].SubItems[3].Text);

            articulo.articuloSeleccionado(e, text_refarticulo, listView1, text_unidadesalmacen, text_unidadestienda, text_empaquetado, pictureBox1);
            
            nombreClasevino = listView1.Items[item].SubItems[2].Text;
            nombreImagen = consultas.obtenerCualquierRefDesdeNombre("nombreimagen", "articulo", "ref", referencia);

            text_refarticulo.Text = referencia;

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



        //Combos: cuando se selecciona uno de ellos, los demás se ponen en modo predeterminado
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

        // Función que refresca el listview de articulos filtrando por proveedor
        private void button1_Click_1(object sender, EventArgs e)
        {//
            limpiarcampos();
            cargaLista = false;
            articulo.listaArticulos_Filtrados("id_proveedor", id_proveedor, listView1, '1');
            cargaLista = true;
        }


        // Función que refresca el listview de articulos filtrando por catalogación
        private void button2_Click(object sender, EventArgs e)
        {//
            limpiarcampos();
            cargaLista = false;
            articulo.listaArticulos_Filtrados("id_catalogacion", id_catalogacion, listView1, '1');
            cargaLista = true;
        }

        // Función que refresca el listview de articulos filtrando por empaquetado
        private void button3_Click(object sender, EventArgs e)
        {//
            limpiarcampos();
            cargaLista = false;
            articulo.listaArticulos_Filtrados("id_empaquetado", id_empaquetado, listView1, '1');
            cargaLista = true;
        }


        // Función que deja los campos en modo predeterminado
        private void limpiarcampos()
        {
            text_refarticulo.Text = "";
            text_unidadesalmacen.Text = "";
            text_unidadestienda.Text = "";
            text_empaquetado.Text = "";
            pictureBox1.Image = null;

            comboBox_nombrecatalogacion.Text = "Seleccione";
            comboBox_nombreempaquetado.Text = "Seleccione";
            combo_nombreproveedor.Text = "Seleccione";
            comboBox_nombrecatalogacion.Text = "Seleccione";
        }
       

        // Función que actualiza el listview de artículos habilitados
        private void actualizarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            limpiarcampos();
            cargaLista = false;
            articulo.cumplimentarListaArticulos(listView1, '1');
            cargaLista = true;
        }

        private void radio_deshabilitados_CheckedChanged(object sender, EventArgs e)
        {
            cargaLista = false;
            articulo.cumplimentarListaArticulos(listView1, '0');
            cargaLista = true;
        }

        private void radio_habilitados_CheckedChanged(object sender, EventArgs e)
        {
            cargaLista = false;
            articulo.cumplimentarListaArticulos(listView1, '1');
            cargaLista = true;
        }

        private void desabilitarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult opcionSeleccionada = MessageBox.Show("¿Realmente desea deshabilitar un registro?", "Aviso", MessageBoxButtons.YesNo);
            if (opcionSeleccionada == DialogResult.Yes)
            {
                if (referencia != "")
                {
                    consultas.habilitarDesabilitarCualquierReferencia("articulo", "ref", referencia, '0');

                    cargaLista = false;
                    articulo.cumplimentarListaArticulos(listView1, '1');
                    cargaLista = true;
                   
                }
                else
                {
                    MessageBox.Show(ClaseCompartida.msgCamposEnBlanco);
                }
            }
            else
            {
                MessageBox.Show("Tenga cuidado!");
            }
        }

        private void habilitarToolStripMenuItem_Click(object sender, EventArgs e)
        {

            DialogResult opcionSeleccionada = MessageBox.Show("¿Realmente desea habilitar un registro?", "Aviso", MessageBoxButtons.YesNo);
            if (opcionSeleccionada == DialogResult.Yes)
            {
                if (referencia != "")
                {
                    consultas.habilitarDesabilitarCualquierReferencia("articulo", "ref", referencia, '1');
                    cargaLista = false;
                    articulo.cumplimentarListaArticulos(listView1, '0');
                    cargaLista = true;
                    
                }
                else
                {
                    MessageBox.Show(ClaseCompartida.msgCamposEnBlanco);
                }
            }
            else
            {
                MessageBox.Show("Tenga cuidado!");
            }



        }

        private void eliminarToolStripMenuItem1_Click(object sender, EventArgs e)
        {

            DialogResult opcionSeleccionada = MessageBox.Show("¿Realmente desea habilitar un registro?", "Aviso", MessageBoxButtons.YesNo);
            if (opcionSeleccionada == DialogResult.Yes)
            {

                if (referencia != "")
                {      
                    int existencias = existeArticuloUbicacionLineacompraProveedor();

                    if (existencias > 0)
                    {
                        MessageBox.Show("No eliminado... \nEl artículo tiene existencias en almacén y tienda");
                    }
                    else
                    {
                        bool eliminado = consultas.eliminarCaracteristica("articulo", "ref", text_refarticulo.Text);

                        if (eliminado == true)
                        {
                            cargaLista = false;
                            Class_Articulo articulo = new Class_Articulo();
                            articulo.cumplimentarListaArticulos(listView1, '0');
                            // Eliminar imagen, no se puede que no hay permisos
                            string folderPathFoto = ClaseCompartida.carpetaimg_absoluta + "proveedores/" + id_proveedor + "/articulos/" + nombreClasevino + "/" + nombreImagen;
                            MessageBox.Show("Foto eliminada: " + folderPathFoto);
                            File.Delete(folderPathFoto);
                            cargaLista = true;
                        }
                    }
                }
                else
                {
                    MessageBox.Show(ClaseCompartida.msgCamposEnBlanco);
                }
            }
            else
            {
                MessageBox.Show("Tenga cuidado!");
            }
        }

        private void artículosInhabilitadosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Class_ArticuloAperturaForms apertura = new Class_ArticuloAperturaForms();
            // apertura.articulosInhabilitados();
        }


        private void nuevoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            articuloAperturaForm.nuevoArticuloVino();
        }

        private void modificarToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            articuloAperturaForm.modificarArticuloVino();
        }


        // Metodo que devuelve el número de lineas de compra de un Artículo a un Proveedor
        private int existeArticuloUbicacionLineacompraProveedor()
        {
            int numRegistros = 0;

            ConexionBD con = new ConexionBD();
            string cadenaConexion = con.conexion();
            MySqlConnection conexionBD = new MySqlConnection(cadenaConexion);
            MySqlDataReader reader = null;

            try
            {
                string selectQuery = "SELECT count(id_articulo) as numregistros from ubicacionlineacompraproveedor " +
                    "where id_articulo = " + id_articulo + " ;";
                // MessageBox.Show(selectQuery);

                conexionBD.Open();
                MySqlCommand command = new MySqlCommand(selectQuery, conexionBD);
                reader = command.ExecuteReader();

                while (reader.Read())
                {
                    numRegistros = Int32.Parse(reader.GetString("numregistros"));
                }
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
            finally { conexionBD.Close(); }

            return numRegistros;
        }
    }
}

