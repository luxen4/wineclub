using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace proyectovinos.VentasDevoluciones
{
    internal class Class_VentasDevolucionesSocio
    {

        // Método que devuelve la linea de venta de un Socio
        public int lineaVentaSocio(int id_ventasocio, int id_articulo)
        {

            int id_lineaventasocio=0;
            ConexionBD con = new ConexionBD();
            string cadenaConexion = con.conexion();
            MySqlConnection conexionBD = new MySqlConnection(cadenaConexion);

            try
            {
                string selectQuery = "select l.id_lineaventasocio as resultado from lineaventasocio as l" +
                    " inner join articulo ar on ar.id_articulo=l.id_articulo " +
                    " where l.id_ventasocio = " + id_ventasocio + " and l.id_articulo=" + id_articulo + " ";

                conexionBD.Open();
                MySqlCommand command = new MySqlCommand(selectQuery, conexionBD);
                MySqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    id_lineaventasocio = Int32.Parse(reader.GetString("resultado"));
                }
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
            finally { conexionBD.Close(); }

            return id_lineaventasocio;
        }


        // Método que devuelve la linea de compra a un Proveedor
        public int lineaCompraProveedor(int id_lineaventasocio, int id_articulo)
        {
            int id_lineacompraproveedor = 0;
            ConexionBD con = new ConexionBD();
            string cadenaConexion = con.conexion();
            MySqlConnection conexionBD = new MySqlConnection(cadenaConexion);

            try
            {

                string selectQuery = "select l.id_lineacompraproveedor as id_lineacompraproveedor from lineacompraproveedor as l" +
                    " inner join compraproveedor c on c.id_compraproveedor = l.id_compraproveedor " +
                    " inner join lineaventasocio ls on ls.id_compraproveedor = c.id_compraproveedor " +
                    " where ls.id_lineaventasocio= " + id_lineaventasocio + " and ls.id_articulo= " + id_articulo + " ";


                conexionBD.Open();
                MySqlCommand command = new MySqlCommand(selectQuery, conexionBD);
                MySqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    id_lineacompraproveedor = Int32.Parse(reader.GetString("id_lineacompraproveedor"));
                }
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
            finally { conexionBD.Close(); }

            return id_lineacompraproveedor;
        }
    }
}
