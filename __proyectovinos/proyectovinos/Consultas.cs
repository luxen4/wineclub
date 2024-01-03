using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using ListView = System.Windows.Forms.ListView;

namespace proyectovinos
{
    public class Consultas
    {

        //  ConexionBD con = new ConexionBD();

        // Método que devuelve el id de un registro desde un atributo cualquiera de cualquier tabla

        /// <summary>
        /// Obteners the cualquier identifier.
        /// </summary>
        /// <param name="nombreId">The nombre identifier.</param>
        /// <param name="nombreTabla">The nombre tabla.</param>
        /// <param name="whereAtributo">The where atributo.</param>
        /// <param name="valorAtributo">The valor atributo.</param>
        /// <returns></returns>
        public int obtenerCualquierId(string nombreId, string nombreTabla, string whereAtributo, string valorAtributo)
        {
            int id = 0;
            ConexionBD con = new ConexionBD();
            string cadenaConexion = con.conexion();
            MySqlConnection conexionBD = new MySqlConnection(cadenaConexion);

            try
            {
                string selectQuery = "select " + nombreId + " as resultado from " + nombreTabla + " where " + whereAtributo + " = '" + valorAtributo + "' ";

                conexionBD.Open();
                MySqlCommand command = new MySqlCommand(selectQuery, conexionBD);
                MySqlDataReader reader = command.ExecuteReader();  

                while (reader.Read())
                {
                    id = Int32.Parse(reader.GetString("resultado"));
                }
            }
            catch (Exception ex) { 
                MessageBox.Show(ex.Message); }
            finally { conexionBD.Close(); }

            return id;
        }


        /// <summary>
        /// Método que devuelve un registro de una tabla desde otro registro de la misma tabla
        /// </summary>
        /// <param name="referencia"></param>
        /// <param name="nombreTabla"></param>
        /// <param name="whereAtributo"></param>
        /// <param name="valorAtributo"></param>
        /// <returns></returns>
        public string obtenerCualquierRefDesdeNombre(string referencia, string nombreTabla, string whereAtributo, string valorAtributo)
        {
            string reff = "";
            ConexionBD con = new ConexionBD();
            string cadenaConexion = con.conexion();
            MySqlConnection conexionBD = new MySqlConnection(cadenaConexion);

            try
            {
                string selectQuery = "select " + referencia + " as referencia from " + nombreTabla + " where " + whereAtributo + " = '" + valorAtributo + "' ";
                
                conexionBD.Open();
                MySqlCommand command = new MySqlCommand(selectQuery, conexionBD);
                MySqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    reff = reader.GetString("referencia");
                }
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
            finally { conexionBD.Close(); }

            return reff;
        }


        /// <summary>
        /// Método que devuelve la ref desde un nombre
        /// </summary>
        /// <param name="refe"></param>
        /// <param name="nombreTabla"></param>
        /// <param name="whereAtributo"></param>
        /// <param name="valorAtributo"></param>
        /// <returns></returns>
        public string obtenerCualquierRefDesdeId(string refe, string nombreTabla, string whereAtributo, int valorAtributo)
        {
            string referencia = "";
            ConexionBD con = new ConexionBD();
            string cadenaConexion = con.conexion();
            MySqlConnection conexionBD = new MySqlConnection(cadenaConexion);

            try
            {
                string selectQuery = "select " + refe + " as ref from " + nombreTabla + " where " + whereAtributo + " = " + valorAtributo + " ";
                //MessageBox.Show(selectQuery);
                conexionBD.Open();
                MySqlCommand command = new MySqlCommand(selectQuery, conexionBD);
                MySqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    referencia = reader.GetString("ref");
                }
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
            finally { conexionBD.Close(); }

            return referencia;
        }


        /// <summary>
        /// Método que devuelve el nombre del registro de una tabla desde su referencia 
        /// </summary>
        /// <param name="atributoInner"></param>
        /// <param name="nombreTabla"></param>
        /// <param name="whereAtributo"></param>
        /// <param name="referenciaArticulo"></param>
        /// <returns></returns>
        public string obtenerCualquierNombre(string atributoInner, string nombreTabla, string whereAtributo, string referenciaArticulo)
        {
            string nombre = "";
            ConexionBD con = new ConexionBD();
            string cadenaConexion = con.conexion();
            MySqlConnection conexionBD = new MySqlConnection(cadenaConexion);

            try
            {
                string selectQuery = "select c.nombre as nombre from " + nombreTabla + " as c " +
                   " inner join articulo as a on a." + atributoInner + " = c." + atributoInner + "" +
                   " where a." + whereAtributo + " = '" + referenciaArticulo + "' ";

                conexionBD.Open();
                MySqlCommand command = new MySqlCommand(selectQuery, conexionBD);
                MySqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    nombre = reader.GetString("nombre");
                }
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
            finally { conexionBD.Close(); }

            return nombre;
        }

        /// <summary>
        /// Método genérico que elimina un registro de una tabla desde su referencia 
        /// </summary>
        /// <param name="tabla"></param>
        /// <param name="whereAtributo"></param>
        /// <param name="valorAtributo"></param>
        public void eliminarCualquierId(string tabla, string whereAtributo, int valorAtributo)
        {
            ConexionBD con = new ConexionBD();
            string cadenaConexion = con.conexion();
            MySqlConnection conexionBD = new MySqlConnection(cadenaConexion);
            MySqlDataReader reader = null;

            try
            {
                string selectQuery = "update " + tabla + " SET " + "activo= '0' WHERE " + whereAtributo + " = " + "" + valorAtributo + " ";

                MySqlCommand comando = new MySqlCommand(selectQuery);
                comando.Connection = conexionBD;
                conexionBD.Open();
                reader = comando.ExecuteReader();
                //MessageBox.Show("Eliminado");

            }
            catch (MySqlException ex) {
                MessageBox.Show(ex.Message); }
            finally {  conexionBD.Close(); }
        }

        
        /// <summary>
        /// Método genérico que elimina un registro desde su referencia en cualquier tabla
        /// </summary>
        /// <param name="tabla"></param>
        /// <param name="whereAtributo"></param>
        /// <param name="valorAtributo"></param>
        /// <param name="activo"></param>
        public void habilitarDesabilitarCualquierReferencia(string tabla, string whereAtributo, string valorAtributo, char activo)
        {
            ConexionBD con = new ConexionBD();
            string cadenaConexion = con.conexion();
            MySqlConnection conexionBD = new MySqlConnection(cadenaConexion);
            MySqlDataReader reader = null;

            try
            {
                string selectQuery = "update " + tabla + " SET " + "activo= '" + activo + "' WHERE " + whereAtributo + " = " + "'" + valorAtributo + "' ";

                MySqlCommand comando = new MySqlCommand(selectQuery);
                comando.Connection = conexionBD;
                conexionBD.Open();
                reader = comando.ExecuteReader();
                //MessageBox.Show(ClaseCompartida.msgModificado);

            }
            catch (MySqlException ex){
                MessageBox.Show(ex.Message);
            }finally { conexionBD.Close();}
        }


        /// <summary>
        /// Método genérico que modifica cualquier tabla
        /// </summary>
        /// <param name="nombreTabla"></param>
        /// <param name="nuevareferencia"></param>
        /// <param name="nuevonombre"></param>
        /// <param name="whereAtributo"></param>
        /// <param name="atributoValor"></param>
        /// <param name="listView1"></param>
        public void modificarCualquierTabla(string nombreTabla, string nuevareferencia, string nuevonombre, string whereAtributo, string atributoValor, ListView listView1)
        {
            ConexionBD con = new ConexionBD();
            string cadenaConexion = con.conexion();
            MySqlConnection conexionBD = new MySqlConnection(cadenaConexion);
            MySqlDataReader reader = null;

            try
            {
                string selectQuery = "update " + nombreTabla + " SET " +
                    "ref='" + nuevareferencia + "'" + ", " +
                    "nombre='" + nuevonombre + "'" +
                    " WHERE " + whereAtributo + " = " + "'" + atributoValor + "' ";  
                
                MySqlCommand comando = new MySqlCommand(selectQuery);
                comando.Connection = conexionBD;
                conexionBD.Open();
                reader = comando.ExecuteReader();  
            }

            catch (MySqlException ex){ MessageBox.Show(ex.Message); }
            finally {  conexionBD.Close(); }
        }


        /// <summary>
        /// Método que inserta un nuevo registro en cualquier tabla de caracteristicas de vino
        /// </summary>
        /// <param name="nombreTabla"></param>
        /// <param name="nombreId"></param>
        /// <param name="valorId"></param>
        /// <param name="valorReferencia"></param>
        /// <param name="valorNombre"></param>
        /// <returns></returns>
        public bool insertTablaCaracteristicasDinamico(string nombreTabla, string nombreId, int valorId, string valorReferencia, string valorNombre)
        {
            ConexionBD con = new ConexionBD();
            string cadenaConexion = con.conexion();
            MySqlConnection conexionBD = new MySqlConnection(cadenaConexion);
            MySqlDataReader reader = null;

            try
            {
                string selectQuery = "insert into " + nombreTabla + " (" + nombreId + ", ref,nombre,activo) " +
                    "values (" + valorId + ", '" + valorReferencia + "','" + valorNombre + "','1')";

                MySqlCommand comando = new MySqlCommand(selectQuery);
                comando.Connection = conexionBD;
                conexionBD.Open();
                reader = comando.ExecuteReader(); 

                //MessageBox.Show(ClaseCompartida.msgInsertado);
                conexionBD.Close();
                return true;

            }
            catch (MySqlException ex) { 
                MessageBox.Show(ClaseCompartida.msgRegistroIgual);
                conexionBD.Close();
                return false;
            } finally { conexionBD.Close(); 
            }
        }
              
        /// <summary>
        /// Método que devuelve el id máximo de una tabla de la base de datos.
        /// </summary>
        /// <param name="nombreId_Atributo">The nombre identifier atributo.</param>
        /// <param name="nombreTabla">The nombre tabla.</param>
        /// <returns></returns>
        public int idMax(string nombreId_Atributo, string nombreTabla)
        {
            int id = 0; 
            ConexionBD con = new ConexionBD();
            string cadenaConexion = con.conexion();
            MySqlConnection conexionBD = new MySqlConnection(cadenaConexion);
            MySqlDataReader reader = null;

            try
            {
                string selectQuery = "SELECT max(" + nombreId_Atributo  + ") as maxid from " + nombreTabla + ";";

                conexionBD.Open();
                MySqlCommand command = new MySqlCommand(selectQuery, conexionBD);
                reader = command.ExecuteReader();

                while (reader.Read())
                {
                    id = Int32.Parse(reader.GetString("maxid"));
                }
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
            finally { conexionBD.Close(); }

            return id;
        }


        /// <summary>
        /// Método que devuelve el último id de una tabla
        /// </summary>
        /// <param name="nombreId"></param>
        /// <param name="tabla"></param>
        /// <param name="refe"></param>
        /// <param name="text_nuevareferencia"></param>
        /// <returns></returns>
        public int referenciaPredeterminada(string nombreId,string tabla, string refe, System.Windows.Forms.TextBox text_nuevareferencia)
        {
            int max_id = idMax(nombreId, tabla);
            string referencia = refe + (max_id + 1);
            text_nuevareferencia.Text = referencia;
            return max_id + 1;
        }



        /// <summary>
        /// Método que devuelve los nombres de las Caracteristicas de vino desde la referencia de artículo
        /// </summary>
        /// <param name="referencia"></param>
        /// <returns></returns>
        public string[] nombresCaracteristicas(string referencia)
        {
            string[] nombres = new string[6];
            ConexionBD con = new ConexionBD();
            string cadenaConexion = con.conexion();
            MySqlConnection conexionBD = new MySqlConnection(cadenaConexion);

            try
            {
                string selectQuery = "select t.nombre as tipouva, cl.nombre as clasevino, p.nombre as proveedor, cat.nombre as catalogacion," +
                    "d.nombre as denominacion, e.nombre as empaquetado, f.nombre as formatocontenido from articulo a" +
                   " inner join tipouva as t on t.id_tipouva = a.id_tipouva"  +
                   " inner join clasevino as cl on cl.id_clasevino = a.id_clasevino" +
                   " inner join proveedor as p on p.id_proveedor = a.id_proveedor" +
                   " inner join catalogacion as cat on cat.id_catalogacion = a.id_catalogacion" +
                   " inner join denominacion as d on d.id_denominacion = a.id_denominacion" +
                   " inner join empaquetado as e on e.id_empaquetado = a.id_empaquetado" +
                   " inner join formatocontenido as f on f.id_formatocontenido = a.id_formatocontenido" +
                   " where a.ref= '" + referencia + "' ";

                conexionBD.Open();
                MySqlCommand command = new MySqlCommand(selectQuery, conexionBD);
                MySqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {   nombres[0] = reader.GetString("proveedor");
                    nombres[1] = reader.GetString("clasevino");
                    nombres[2] = reader.GetString("denominacion");
                    nombres[3] = reader.GetString("catalogacion");
                    nombres[4] = reader.GetString("empaquetado");
                    nombres[5] = reader.GetString("formatocontenido");
                }
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
            finally { conexionBD.Close(); }

            return nombres;
        }


        /// <summary>
        /// Método que elimina cualquier Registro desde su referencia   
        /// </summary>
        /// <param name="tabla">The tabla.</param>
        /// <param name="whereAtributo">The where atributo.</param>
        /// <param name="valorAtributo">The valor atributo.</param>
        /// <returns></returns>
        internal bool eliminarCaracteristica(string tabla, string whereAtributo, string valorAtributo)
        {
            ConexionBD con = new ConexionBD();
            string cadenaConexion = con.conexion();
            MySqlConnection conexionBD = new MySqlConnection(cadenaConexion);
            MySqlDataReader reader = null;

            try
            {
                string selectQuery = "delete from " + tabla + " WHERE " + whereAtributo + " = " + "'" + valorAtributo + "'";
               
                MySqlCommand comando = new MySqlCommand(selectQuery);
                comando.Connection = conexionBD;
                conexionBD.Open();
                reader = comando.ExecuteReader();
                conexionBD.Close();
                return true;

            }
            catch (MySqlException ex)
            {
                MessageBox.Show(ex.Message);
                conexionBD.Close();
                return false;
            }
            finally { conexionBD.Close(); }
        }
    }
}














































