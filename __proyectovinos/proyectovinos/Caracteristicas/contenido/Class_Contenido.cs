using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace proyectovinos.Caracteristicas.contenido
{
    internal class Class_Contenido
    {
        internal void cumplimentarListaFormatoContenido(ListView listView1)
        {

            listView1.Items.Clear();
            ConexionBD con = new ConexionBD();
            string cadenaConexion = con.conexion();
            MySqlConnection conexionBD = new MySqlConnection(cadenaConexion);

            try
            {
                string selectQuery = "select * from formatocontenido where activo='1'";
                conexionBD.Open();
                MySqlCommand command = new MySqlCommand(selectQuery, conexionBD);
                MySqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    ListViewItem itemAgregar = new ListViewItem(reader.GetString("ref"));
                    // itemAgregar.Checked = true;
                    itemAgregar.SubItems.Add(reader.GetString("nombre"));
                    itemAgregar.SubItems.Add(reader.GetString("contenido"));
                    listView1.Items.Add(itemAgregar);
                }
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
            finally { conexionBD.Close(); }
        }

        internal bool insertFormatoContenido(int id_predeterminado, TextBox text_nuevareferencia, TextBox text_nuevonombre, TextBox text_nuevocontenido)
        {
            ConexionBD con = new ConexionBD();
            string cadenaConexion = con.conexion();
            MySqlConnection conexionBD = new MySqlConnection(cadenaConexion);
            MySqlDataReader reader = null;

            try
            {
                string selectQuery = "insert into formatocontenido ( id_formatocontenido , ref, nombre, contenido, activo) " +
                    "values (" + id_predeterminado +
                    ", '" + text_nuevareferencia.Text +
                    "'," + "'" + text_nuevonombre.Text + "','" + text_nuevocontenido.Text + "', '1')"; 
                // MessageBox.Show(selectQuery);

                MySqlCommand comando = new MySqlCommand(selectQuery);
                comando.Connection = conexionBD;
                conexionBD.Open();
                reader = comando.ExecuteReader();

                // MessageBox.Show("Registro Insertado");
                conexionBD.Close();

                return true;

            }
            catch (MySqlException ex)
            {
                MessageBox.Show(ClaseCompartida.msgRegistroIgual);
               
            }
            finally { conexionBD.Close(); }

            return true;
        }
    }
}
