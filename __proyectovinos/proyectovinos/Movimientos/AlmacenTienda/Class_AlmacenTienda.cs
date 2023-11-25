using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.Windows.Forms;
using System.IO;
using System.Drawing;

namespace proyectovinos.Movimientos.AlmacenTienda
{
    internal class Class_AlmacenTienda
    {
        // Método que modifica las existencias, preciocoste y precioventa de una linea de compra de Proveedor
            public void ajusteExistenciasLineaCompraProveedor(/* int existencias, string preciocoste,*/ string precioventa, string refLinea)
            {
            ConexionBD con = new ConexionBD();
            string cadenaConexion = con.conexion();
            MySqlConnection conexionBD = new MySqlConnection(cadenaConexion);
                  MySqlDataReader reader = null;

            try
            {
                string selectQuery = "update lineacompraproveedor SET " +
                  /*   "  existencias= " + existencias + "" +
                   ", preciocoste=convert( '" + preciocoste + "', decimal (7,2))" + */
                    "  precioventa=convert( '" + precioventa + "', decimal (7,2))" +
                    " WHERE ref =  '" + refLinea + "' ";

                // MessageBox.Show(selectQuery);
                MySqlCommand comando = new MySqlCommand(selectQuery);
                comando.Connection = conexionBD;
                conexionBD.Open();
                reader = comando.ExecuteReader();

                // MessageBox.Show("Datos en línea modificados");
            }

            catch (MySqlException ex) { MessageBox.Show(ex.Message); }
            finally { conexionBD.Close(); }


        }
        

        // Método que ajusta las existencias de un articulo en una ubicación
        public bool ajusteExistenciasCualquierUbicacion(int id_lineacompraproveedor, decimal totalExistencias, int id_articulo, string zona)
        {
            bool ajuste = false;

            int ubicacion = 0;

            if (zona == "almacen"){ ubicacion = 1;
            } else if (zona == "tienda") { ubicacion = 2; }

            ConexionBD con = new ConexionBD();
            string cadenaConexion = con.conexion();
            MySqlConnection conexionBD = new MySqlConnection(cadenaConexion);

            try
            {
                string selectquery = "update ubicacionlineacompraproveedor set " +
                    " existencias = " + totalExistencias + " " +
                        " where id_ubicacion = " + ubicacion + 
                        " and id_lineacompraproveedor =" + id_lineacompraproveedor +
                        " and id_articulo = " + id_articulo + "";

               // MessageBox.Show(selectquery);

                MySqlCommand comando = new MySqlCommand(selectquery);
                comando.Connection = conexionBD;
                conexionBD.Open();
                MySqlDataReader reader = comando.ExecuteReader();
                // MessageBox.Show("Existencias del articulo modificadas en " + zona);

                conexionBD.Close();
                return true;

            }
            catch (MySqlException ex) { 
                MessageBox.Show(ex.Message);
                Consultas consultas = new Consultas();
                string refe = consultas.obtenerCualquierRefDesdeId("ref","articulo","id_artículo",id_articulo);
                MessageBox.Show("Artículo con ref: " + refe  + ", no insertado!");

                conexionBD.Close();
                return false;
            }
            finally { conexionBD.Close(); }
        }


        // Método que cumplimenta un combobox de ref. de artículos desde ref.compraProveedor 
        public void cumplimentarComboRefArticulosDesdeComboRefCompraProveedor(string refCompraProveedor, ComboBox combo_articulo)
        {
            ConexionBD con = new ConexionBD();
            string cadenaConexion = con.conexion();
            MySqlConnection conexionBD = new MySqlConnection(cadenaConexion);

            try
            {
                string selectQuery = "select com.ref as referenciacompraproveedor from compraproveedor as com " +
                    " inner join lineacompraproveedor as l on l.id_compraproveedor=com.id_compraproveedor " +
                    " inner join articulo ar on ar.id_articulo=l.id_articulo " +
                    " where com.ref= '" + refCompraProveedor + "' ";


                conexionBD.Open();
                MySqlCommand command = new MySqlCommand(selectQuery, conexionBD);
                MySqlDataReader reader = command.ExecuteReader();


                while (reader.Read())
                {
                    combo_articulo.Items.Add(reader.GetString("referenciacompraproveedor"));
                }
                combo_articulo.Text = "Seleccione";

            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
            finally { conexionBD.Close(); }
        }



        public void cumplimentarComboRefProveedorDesdeComboRefCompraProveedor(string refCompraProveedor, ComboBox combo_proveedor)
        {
            ConexionBD con = new ConexionBD();
            string cadenaConexion = con.conexion();
            MySqlConnection conexionBD = new MySqlConnection(cadenaConexion);

            try
            {
                string selectQuery = "select p.ref as referencia from compraproveedor as com " +
                    " inner join lineacompraproveedor as l on l.id_compraproveedor=com.id_compraproveedor " +
                    " inner join proveedor p on p.id_proveedor=l.id_proveedor " +
                    " where com.ref= '" + refCompraProveedor + "' ";


                conexionBD.Open();
                MySqlCommand command = new MySqlCommand(selectQuery, conexionBD);
                MySqlDataReader reader = command.ExecuteReader();


                while (reader.Read())
                {
                    combo_proveedor.Items.Add(reader.GetString("referencia"));
                }
                combo_proveedor.Text = "Seleccione";

            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
            finally { conexionBD.Close(); }
        }


        //      
        /// <summary>
        /// Método que devuelve la información de una linea de Compra a proveedor   .
        /// </summary>
        /// <param name="id_articulo">The identifier articulo.</param>
        /// <param name="combo_reflinea">The combo reflinea.</param>
        public void refrescarComboboxLineaCompraProveedor(int id_articulo, ComboBox combo_reflinea)
        {
            ConexionBD con = new ConexionBD();
            string cadenaConexion = con.conexion();
            MySqlConnection conexionBD = new MySqlConnection(cadenaConexion);

            try
            {

                /// Referencias con existencias en tienda > 0
                string selectQuery = "select l.ref from lineacompraproveedor l " +
                    " inner join ubicacionlineacompraproveedor as ub on ub.id_lineacompraproveedor = l.id_lineacompraproveedor" +
                    " where l.id_articulo = '" + id_articulo + "' and ub.id_ubicacion = 1 order by l.ref asc";

                // MessageBox.Show("AAA: " + selectQuery);

                conexionBD.Open();
                MySqlCommand command = new MySqlCommand(selectQuery, conexionBD);
                MySqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    combo_reflinea.Items.Add(reader.GetString("ref"));
                }
                combo_reflinea.Text = "Seleccione";

            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
            finally { conexionBD.Close(); }
        }





        internal void ajusteCantidadesLineasZonas(ComboBox combo_reflineacompraproveedor, int existenciasAlmacen, int existenciasTienda, int unidadesAmover,
            string tipoMovimiento, int id_articulo)
        {
            int totalExistenciasAlmacen = 0, totalExistenciasTienda = 0;

            if (tipoMovimiento == "tienda-almacen")
            {
                // Saber la cantidad que hay en el almacén y en tienda
                totalExistenciasAlmacen = existenciasAlmacen + unidadesAmover;
                totalExistenciasTienda = existenciasTienda - unidadesAmover;
            }
            else if(tipoMovimiento == "almacen-tienda") {

                totalExistenciasAlmacen = existenciasAlmacen - unidadesAmover;
                totalExistenciasTienda = existenciasTienda + unidadesAmover;
            }
            

            // Ajuste de cantidades
            Consultas consultas = new Consultas();
            string refLineaCompraProveedor = combo_reflineacompraproveedor.Text;
            int id_lineacompraproveedor = consultas.obtenerCualquierId("id_lineacompraproveedor", "lineacompraproveedor", "ref", refLineaCompraProveedor);

            bool ajusteAlmacen = ajusteExistenciasCualquierUbicacion(id_lineacompraproveedor, totalExistenciasAlmacen, id_articulo, "almacen");
            bool ajusteTienda = ajusteExistenciasCualquierUbicacion(id_lineacompraproveedor, totalExistenciasTienda, id_articulo, "tienda");
            //

            if (ajusteAlmacen==true && ajusteTienda==true) {
                MessageBox.Show("Existencias modificadas en Almacén y Tienda");
            }

        }
    }
}
