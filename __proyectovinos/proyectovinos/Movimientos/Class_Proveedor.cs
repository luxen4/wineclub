using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace proyectovinos.Movimientos
{
    internal class Class_Proveedor
    {

        // Método... nombre de un Proveedor desde una ref de linea de compra a Proveedor
        public string nombreProveedor(string refLineaCompraProveedor)
        {
            string nombre = "";

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
                    nombre = reader.GetString("nombreproveedor");
                }

            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
            finally { conexionBD.Close(); }

            return nombre;
        }
    }
}
