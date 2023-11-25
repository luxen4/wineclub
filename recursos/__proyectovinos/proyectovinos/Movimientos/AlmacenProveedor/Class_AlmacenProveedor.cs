﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace proyectovinos.Movimientos.AlmacenProveedor
{
    internal class Class_AlmacenProveedor
    {

        // Método que registra la compra de un Artículo a un Proveedor
        public void registrarCompraProveedor(int id_predeterminado, int id_empleado, string referenciaCompra, string fechacompra)
        {

            ConexionBD con = new ConexionBD();
            string cadenaConexion = con.conexion();
            MySqlConnection conexionBD = new MySqlConnection(cadenaConexion);
            MySqlDataReader reader = null;

            try
            {
                string selectQuery = "insert into compraproveedor (id_compraproveedor, id_empleado, ref, fechaCompra) " +
                    " values(" + id_predeterminado + "" +
                    ", " + id_empleado + "" +
                    ", '" + referenciaCompra + "'" +
                    ", '" + fechacompra + "')";

                //MessageBox.Show(selectQuery);

                MySqlCommand comando = new MySqlCommand(selectQuery);
                comando.Connection = conexionBD;
                conexionBD.Open();
                reader = comando.ExecuteReader();

                MessageBox.Show("Compras de Proveedores Registradas!");
            }
            catch (MySqlException ex) { MessageBox.Show(ex.Message); }
            finally { conexionBD.Close(); }
        }



        // Método que registra la devolución a un Proveedor
        public void registrarDevolucionProveedor(int id_empleado, int id_lineacompraproveedor, int unidades, string fechacompra)
        {

            ConexionBD con = new ConexionBD();
            string cadenaConexion = con.conexion();
            MySqlConnection conexionBD = new MySqlConnection(cadenaConexion);
            MySqlDataReader reader = null;


            try
            {
                string consulta = "insert into devolucionproveedor (id_empleado, id_lineacompraproveedor, unidades, fecha) " +
                    "values (" + id_empleado + ", " + id_lineacompraproveedor + ", " + unidades + ", '" + fechacompra + "')";

                MySqlCommand comando = new MySqlCommand(consulta);
                comando.Connection = conexionBD;
                conexionBD.Open();
                reader = comando.ExecuteReader();

                MessageBox.Show("Artículos devueltos a proveedor!");
                conexionBD.Close();

            }
            catch (MySqlException ex)
            {
                MessageBox.Show("Ya se encuentra un registro igual!");

            }
            finally { conexionBD.Close(); }
        }


        // Método que cumplimenta las referencias de lineas de compra de Proveedores
        public void refLineasCompraProveedor(int id_compraproveedor, int id_articulo, ComboBox combo_reflineacompraproveedor)
        {
            ConexionBD con = new ConexionBD();
            string cadenaConexion = con.conexion();
            MySqlConnection conexionBD = new MySqlConnection(cadenaConexion);

            try
            {
                string selectQuery = "select ref from lineacompraproveedor " +
                    "where id_compraproveedor = " + id_compraproveedor + /*" and id_articulo=" + id_articulo +*/" order by ref asc";
                conexionBD.Open();
                MySqlCommand command = new MySqlCommand(selectQuery, conexionBD);
                MySqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    combo_reflineacompraproveedor.Items.Add(reader.GetString("ref"));
                }
                combo_reflineacompraproveedor.Text = "Seleccione";

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally { conexionBD.Close(); }
        }



    }
}
