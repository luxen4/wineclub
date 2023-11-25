using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.Windows.Forms;
using System.Drawing;

namespace proyectovinos.Caracteristicas.tipouva
{
    internal class Class_TipoUva
    {
        ConexionBD con = new ConexionBD();

        // Método que cumplimenta Cualquier lista con ref y nombre *DINÁMICO*
        public void cumplimentarListaTipoUva(ListView listView1,char activo)
        {   listView1.Items.Clear();

            
            string cadenaConexion = con.conexion();
            MySqlConnection conexionBD = new MySqlConnection(cadenaConexion);

            try
            {
                string selectQuery = "select t.ref as referencia, t.nombre as nombre, v.nombre as variedaduva " +
                    " from tipouva t" +
                    " inner join variedaduva v on v.id_variedaduva=t.id_variedaduva where t.activo='" + activo + "' " +
                    " order by t.nombre asc";

                conexionBD.Open();
                MySqlCommand command = new MySqlCommand(selectQuery, conexionBD);
                MySqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    ListViewItem itemAgregar = new ListViewItem(reader.GetString("referencia"));
                    // itemAgregar.Checked = true;
                    itemAgregar.SubItems.Add(reader.GetString("nombre"));
                    itemAgregar.SubItems.Add(reader.GetString("variedaduva"));

                    listView1.Items.Add(itemAgregar);
                }

            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
            finally { conexionBD.Close(); }

        }

        Utilidades ut = new Utilidades();

        internal void controladorHabilitarTipoUva(CheckBox check_segurodeshabilitar, TextBox text_referenciadeshabilitar, TextBox text_nombredeshabilitar, string tabla, ListView listView1, char activo)
        {
            if (check_segurodeshabilitar.Checked)
            {
                if (text_nombredeshabilitar.Text == "" || text_referenciadeshabilitar.Text == "")
                {
                    MessageBox.Show(ClaseCompartida.msgCamposEnBlanco);
                }
                else
                {
                    ut.habilitarOnOff_Caracteristica(tabla, "ref", text_referenciadeshabilitar.Text, activo);
                    cumplimentarListaTipoUva(listView1, '1');// No tocar que tiene estructura propia
                    ut.limpiarCamposNuevoDeshabilitar(check_segurodeshabilitar, text_referenciadeshabilitar, text_nombredeshabilitar);
                }
            }
            else
            {
                MessageBox.Show(ClaseCompartida.msgCasillaSeguro);
            }
        }

        // Método que agrega un Tipo de Uva
        internal void insertTipoUva(int id_tipouva, string referencia, string nombre, int id_variedaduva, char activo)
        {
                string cadenaConexion = con.conexion();
                MySqlConnection conexionBD = new MySqlConnection(cadenaConexion);
                MySqlDataReader reader = null;

                try
                {
                    string selectQuery = "insert into tipouva (id_tipouva, ref, nombre, id_variedaduva, activo) " +
                        "values (" + id_tipouva + ", '" + referencia + "','" + nombre + "',  " + id_variedaduva + ",'1')"; 
                MessageBox.Show(selectQuery);

                    MySqlCommand comando = new MySqlCommand(selectQuery);
                    comando.Connection = conexionBD;
                    conexionBD.Open();
                    reader = comando.ExecuteReader();

                    MessageBox.Show(ClaseCompartida.msgInsertado);
                    conexionBD.Close();

                }
                catch (MySqlException ex)
                {
                    MessageBox.Show(ClaseCompartida.msgRegistroIgual);
                }
                finally { conexionBD.Close(); }
            
        }

        internal void modificarTipoUva(string referenciamodificar, string nombremodificar, int id_variedaduva, string referencia, ListView listView1)
        {
            ConexionBD con = new ConexionBD();
            string cadenaConexion = con.conexion();
            MySqlConnection conexionBD = new MySqlConnection(cadenaConexion);
            MySqlDataReader reader = null;

            try
            {
                string selectQuery = "update tipouva SET " +
                    "ref='" + referenciamodificar + "'" + ", " +
                    "nombre='" + nombremodificar + "'" + ", " +
                    "id_variedaduva=" + id_variedaduva +  
                    " WHERE ref = " + "'" + referencia + "' ";

                MessageBox.Show(selectQuery);

                MySqlCommand comando = new MySqlCommand(selectQuery);
                comando.Connection = conexionBD;
                conexionBD.Open();
                reader = comando.ExecuteReader();

                MessageBox.Show(ClaseCompartida.msgModificado);
            }

            catch (MySqlException ex) { MessageBox.Show(ex.Message); }
            finally { conexionBD.Close(); }
        }
    }
}
