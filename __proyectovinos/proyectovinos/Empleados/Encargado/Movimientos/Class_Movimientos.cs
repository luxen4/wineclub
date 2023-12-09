using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace proyectovinos.Movimientos
{
    internal class Class_Movimientos
    {
        // Método que registra una baja de existencias
        internal void registroBajaExistenciasUbicacion(int id_bajaexistencias, int id_empleado, int id_ubicacion, int id_lineacompraproveedor, int unidades, string fechacompra)
        {

            
            string refe = "BAJEXIS" + id_bajaexistencias;


            ConexionBD con = new ConexionBD();
            string cadenaConexion = con.conexion();
            MySqlConnection conexionBD = new MySqlConnection(cadenaConexion);
            MySqlDataReader reader = null;

            try
            {
                string selectQuery = "insert into bajaexistencias (id_bajaexistencias, ref, id_empleado, id_ubicacion, id_lineacompraproveedor,unidades, fecha) " +
                    "values (" + id_bajaexistencias + ",'" + refe + "'," + id_empleado + ",  " + id_ubicacion + ", " + id_lineacompraproveedor + "," + unidades + ", '" + fechacompra + "')";
                // MessageBox.Show(selectQuery);

                MySqlCommand comando = new MySqlCommand(selectQuery);
                comando.Connection = conexionBD;
                conexionBD.Open();
                reader = comando.ExecuteReader();

                MessageBox.Show(ClaseCompartida.msgInsertado);
                conexionBD.Close();

            }
            catch (MySqlException ex)
            {

                MessageBox.Show(ClaseCompartida.msgErrorGeneral);
            }
            finally { conexionBD.Close(); }
        }


        // Metodo que modifica las existencias de una linea de compra de proveedor en almacén
        public void ajusteExistenciasUbicacion(int id_lineacompraproveedor, int existencias, int id_ubicacion)
        {
            ConexionBD con = new ConexionBD();
            string cadenaConexion = con.conexion();
            MySqlConnection conexionBD = new MySqlConnection(cadenaConexion);
            MySqlDataReader reader = null;


            try
            {
                string selectQuery = "update ubicacionlineacompraproveedor SET " +
                    " existencias=" + existencias +
                    " WHERE id_lineacompraproveedor = " + id_lineacompraproveedor + " and id_ubicacion = " + id_ubicacion + " ";

                MySqlCommand comando = new MySqlCommand(selectQuery);
                comando.Connection = conexionBD;
                conexionBD.Open();
                reader = comando.ExecuteReader();

                 MessageBox.Show("Existencias de la linea modificadas en almacén");
            }

            catch (MySqlException ex) { MessageBox.Show(ex.Message); }
            finally { conexionBD.Close(); }
        }


    }
}
