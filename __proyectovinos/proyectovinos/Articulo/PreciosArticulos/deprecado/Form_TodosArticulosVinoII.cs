using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using proyectovinos.ArticuloVino;

namespace proyectovinos.Articulo
{
    public partial class Form_TodosArticulosVinoII : Form
    {
        public Form_TodosArticulosVinoII()
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


        private string nombreClasevino = "";
        private string nombreImagen = "";




        Class_ArticuloAperturaForms articuloAperturaForm = new Class_ArticuloAperturaForms();
        Consultas consultas = new Consultas();
        Class_Articulo articulo = new Class_Articulo();
        CumplimentarComboboxes combos = new CumplimentarComboboxes();

        private void listView1_ItemChecked(object sender, ItemCheckedEventArgs e)
        {
            int item = e.Item.Index;
            //id_proveedor = Int32.Parse(listView1.Items[item].SubItems[2].Text);
            id_proveedor = consultas.obtenerCualquierId("id_proveedor", "proveedor", "nombre", listView1.Items[item].SubItems[3].Text);
                
            if (cargaLista == true)
            {
                articulo.articuloSeleccionado(e, text_referencia, listView1, text_unidadesalmacen, text_unidadestienda, text_empaquetado, pictureBox1);
            }
                nombreClasevino = listView1.Items[item].SubItems[2].Text;
                nombreImagen = consultas.obtenerCualquierRefDesdeNombre("nombreimagen", "articulo", "ref", referencia);

                text_referencia.Text = referencia;
                id_articulo = consultas.obtenerCualquierId("id_articulo", "articulo", "ref", referencia);
                articulo.articuloSeleccionado(e, text_referencia, listView1, text_unidadesalmacen, text_unidadestienda, text_empaquetado, pictureBox1);

        }

        private void nuevoToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            articuloAperturaForm.nuevoArticuloVino();
        }


        // Método que abre un formulario para modificar un Artículo de Vino
        private void modificarToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            articuloAperturaForm.modificarArticuloVino();
        }

        //      
        /// <summary>
        /// Método que elimina un artículo si no se ha comprado a proveedor   
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void eliminarToolStripMenuItem1_Click(object sender, EventArgs e)
        {
                if (check_seguro.Checked)
                {
                    if (text_referencia.Text != "")
                    {
                        int existencias = existeArticuloUbicacionLineacompraProveedor();

                        if (existencias > 0)
                        {
                            MessageBox.Show("No eliminado... \nEl artículo tiene existencias en almacén y tienda");
                        }
                        else
                        {
                            bool eliminado = consultas.eliminarCaracteristica("articulo", "ref", text_referencia.Text);


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
                    MessageBox.Show(ClaseCompartida.msgCasillaSeguro);
                }
            
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

        private void desahilitarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (check_seguro.Checked)
            {
                referencia = text_referencia.Text;
                consultas.habilitarDesabilitarCualquierReferencia("articulo", "ref", referencia, '0');

                cargaLista = false;
                articulo.cumplimentarListaArticulos(listView1, '1');
                cargaLista = true;
                articulo.limpiarCampos(text_unidadesalmacen, text_unidadestienda, text_empaquetado, check_seguro, pictureBox1);
            }
            else
            {
                MessageBox.Show(ClaseCompartida.msgCasillaSeguro);
            }
        }

        private void habilitarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (text_referencia.Text != "")
            {
                if (existenciasAlmacen == 0 && existenciasTienda == 0)
                {
                    if (check_seguro.Checked)
                    {
                        referencia = text_referencia.Text;
                        consultas.habilitarDesabilitarCualquierReferencia("articulo", "ref", referencia, '1');
                        articulo.cumplimentarListaArticulos(listView1, '0');
                        articulo.limpiarCampos(text_unidadesalmacen, text_unidadestienda, text_empaquetado, check_seguro, pictureBox1);
                    }
                    else
                    {
                        MessageBox.Show(ClaseCompartida.msgCasillaSeguro);
                    }
                }
                else
                {
                    MessageBox.Show("No puede eliminar este artículo ya que hay existencias en la Vinoteca");
                }
            }
            else
            {
                MessageBox.Show(ClaseCompartida.msgCamposEnBlanco);
            }
        }

        private void actualizarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            limpiarcampos();
            cargaLista = false;
            articulo.cumplimentarListaArticulos(listView1, '1');
            cargaLista = true;
        }

        private void Form_TodosArticulosVinoII_Load(object sender, EventArgs e)
        {
            this.CenterToScreen();
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            
            // Cuando se seleccione el radiobutton que muestre los habilitados
            limpiarcampos();
            cargaLista = false;
            listView1.Clear();
            articulo.cumplimentarListaArticulos(listView1, '1');
            cargaLista = true;
            

            habilitarToolStripMenuItem.Enabled = false;
            desabilitarToolStripMenuItem.Enabled = true;
            //actualizarToolStripMenuItem.Enabled = true;
            eliminarToolStripMenuItem1.Enabled = false;
            

        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            // Cuando se seleccione el radiobutton que muestre los habilitados
            limpiarcampos();
            cargaLista = false;
            articulo.cumplimentarListaArticulos(listView1, '0');
            cargaLista = true;

            eliminarToolStripMenuItem1.Enabled = true;
            habilitarToolStripMenuItem.Enabled = true;
            desabilitarToolStripMenuItem.Enabled = false;
            //actualizarToolStripMenuItem.Enabled = true;
        }

        private void limpiarcampos()
        {
            text_referencia.Text = "";
            text_unidadesalmacen.Text = "";
            text_unidadestienda.Text = "";
            text_empaquetado.Text = "";
            check_seguro.Checked = false;
            pictureBox1.Image = null;
        }
    }
}
