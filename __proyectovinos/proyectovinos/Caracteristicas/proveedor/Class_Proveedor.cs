using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace proyectovinos.Caracteristicas.proveedor
{
    internal class Class_Proveedor
    {

        internal void cumplimentarListaProveedores(ListView listView1, char activo)
        {
            listView1.Items.Clear();

            ConexionBD con = new ConexionBD();
            string cadenaConexion = con.conexion();
            MySqlConnection conexionBD = new MySqlConnection(cadenaConexion);

            try
            {
                string selectQuery = "select ref, nombre, direccion, localidad, provincia, telefono, email from proveedor where activo ='" + activo + "' ";
                conexionBD.Open();
                MySqlCommand command = new MySqlCommand(selectQuery, conexionBD);
                MySqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    ListViewItem itemAgregar = new ListViewItem(reader.GetString("ref"));
                    itemAgregar.Checked = false;
                    itemAgregar.SubItems.Add(reader.GetString("nombre"));
                    itemAgregar.SubItems.Add(reader.GetString("direccion"));
                    itemAgregar.SubItems.Add(reader.GetString("localidad"));
                    itemAgregar.SubItems.Add(reader.GetString("provincia"));
                    itemAgregar.SubItems.Add(reader.GetString("telefono"));
                    itemAgregar.SubItems.Add(reader.GetString("email"));
                    listView1.Items.Add(itemAgregar);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                conexionBD.Close();
            }
        }

        internal void limpiezaCampos(CheckBox check_seguro, TextBox textBox_nombreproveedor, PictureBox pictureBox1)
        {
            check_seguro.Checked = false;
            textBox_nombreproveedor.Text = "";
            pictureBox1.Image = null;
        }


        // Método... nombre de un Proveedor desde una ref de linea de compra a Proveedor
        public void nombreProveedor(string refLineaCompraProveedor, TextBox text_proveedor)
        {
            ConexionBD con = new ConexionBD();
            string cadenaConexion = con.conexion();
            MySqlConnection conexionBD = new MySqlConnection(cadenaConexion);

            try
            {
                string selectQuery = "select p.nombre as nombreproveedor from lineacompraproveedor l " +
                    " inner join articulo as a on a.id_articulo = l.id_articulo " +
                    " inner join proveedor as p on p.id_proveedor = a.id_proveedor " +
                    " where l.ref = '" + refLineaCompraProveedor + "' order by l.ref asc"; MessageBox.Show("ojoo");

                conexionBD.Open();
                MySqlCommand command = new MySqlCommand(selectQuery, conexionBD);
                MySqlDataReader reader = command.ExecuteReader();


                while (reader.Read())
                {
                    text_proveedor.Text = reader.GetString("nombreproveedor");
                }

            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
            finally { conexionBD.Close(); }
        }


    }
}

