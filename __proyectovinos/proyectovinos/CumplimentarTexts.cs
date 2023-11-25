using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.Windows.Forms;

namespace proyectovinos
{
    internal class CumplimentarTexts
    {

        // Igual para Caracteristicas de vino se puede hacer DINÁMICO
        public void refrescarTextDinamico( TextBox text_nuevareferencia, TextBox text_nuevonombre,
           string nombreTabla, string whereAtributo, string atributoValor)
        {


            ConexionBD con = new ConexionBD();
            string cadenaConexion = con.conexion();
            MySqlConnection conexionBD = new MySqlConnection(cadenaConexion);


            try
            {
                string selectQuery = "select ref as referenciaactual, nombre as nombre from " + nombreTabla +
                        " where " + whereAtributo + " = '" + atributoValor + "'";

                conexionBD.Open();
                MySqlCommand command = new MySqlCommand(selectQuery, conexionBD);
                MySqlDataReader reader = command.ExecuteReader();


                while (reader.Read())
                {
                    text_nuevareferencia.Text = reader.GetString("referenciaactual");
                    text_nuevonombre.Text = reader.GetString("nombre");
                }
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
            finally { conexionBD.Close(); }
        }
    }
}
