using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using proyectovinos.ArticuloVino;

namespace proyectovinos.Articulo
{
    public partial class Form_EliminarArticuloVino : Form
    {
        public Form_EliminarArticuloVino()
        {
            InitializeComponent();
        }

        Consultas consultas = new Consultas();
        Class_Articulo articulo = new Class_Articulo();

        private int id_articulo = 0;
        private bool cargaLista = false;
        private string referencia = "";
        private int id_proveedor = 0;
        private string nombreClasevino = "";
        private string nombreImagen = "";

        private void Form_EliminarArticuloVino_Load(object sender, EventArgs e)
        {
            this.CenterToScreen();
            articulo.cumplimentarListaArticulos(listView1, '0');
            cargaLista = true;
        }





        private void listView1_ItemChecked(object sender, ItemCheckedEventArgs e)
        {
  
        }

        
        
        // Método que elimina un artículo si no se ha comprado a proveedor
        private void btn_eliminar_Click(object sender, EventArgs e)
        {
            if (check_seguroeliminar.Checked)
            {
                if (text_referenciaeliminar.Text != "")
                {
                    int existencias = existeArticuloUbicacionLineacompraProveedor();

                    if (existencias > 0)
                    {
                        MessageBox.Show("No eliminado... \nEl artículo tiene existencias en almacén y tienda");
                    }
                    else
                    {
                        bool eliminado = consultas.eliminarCaracteristica("articulo", "ref", text_referenciaeliminar.Text);

                       
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
            }else{
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

                MessageBox.Show(selectQuery);

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

        


        private void listView1_ItemChecked_1(object sender, ItemCheckedEventArgs e)
        {
            if (cargaLista == true)
            {
                referencia = e.Item.Text;

                int item = e.Item.Index;

                id_proveedor = consultas.obtenerCualquierId("id_proveedor", "proveedor", "nombre", listView1.Items[item].SubItems[3].Text);
                nombreClasevino = listView1.Items[item].SubItems[2].Text;
                nombreImagen = consultas.obtenerCualquierRefDesdeNombre("nombreimagen", "articulo", "ref", referencia);

                text_referenciaeliminar.Text = referencia;
                id_articulo = consultas.obtenerCualquierId("id_articulo", "articulo", "ref", referencia);
                articulo.articuloSeleccionado(e, text_referenciaeliminar, listView1, text_unidadesalmacen, text_unidadestienda, text_empaquetado, pictureBox1);

            }
        }
    }
}

// Eliminar imagen, no se puede que no hay permisos
//string folderPathFoto = @"../../img/proveedores/" + id_proveedor + "/articulos/" + nombreClasevino + "/" + nombreimagen;
//File.Delete(folderPathFoto); // MessageBox.Show("Foto eliminada: " + folderPathFoto);