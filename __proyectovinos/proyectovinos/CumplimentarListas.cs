using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using ListView = System.Windows.Forms.ListView;

namespace proyectovinos
{
    public class CumplimentarListas
    {
        public string Number { get; }
        public string Owner { get; set; }
        public decimal Balance { get; }

        //ConexionBD con = new ConexionBD();


        public void MakeDeposit(decimal amount, DateTime date, string note)
        {
        }

        public void MakeWithdrawal(decimal amount, DateTime date, string note)
        {
        }



    // Método que rellena una lista de Proveedores 
        public void cumplimentarListaProveedor(ListView listView1)
        {
            listView1.Items.Clear();

            ConexionBD con = new ConexionBD();
            string cadenaConexion = con.conexion();
            MySqlConnection conexionBD = new MySqlConnection(cadenaConexion);

            try
            {
                string selectQuery = "select ref as referencia, nombre as nombreproveedor from proveedor";
                conexionBD.Open();
                MySqlCommand command = new MySqlCommand(selectQuery, conexionBD);
                MySqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    ListViewItem itemAgregar = new ListViewItem(reader.GetString("referencia"));
                    // itemAgregar.Checked = true;
                    itemAgregar.SubItems.Add(reader.GetString("nombreproveedor"));
                    listView1.Items.Add(itemAgregar);
                }
            }
            catch (Exception ex){ MessageBox.Show(ex.Message); }
            finally { conexionBD.Close(); }
        }


    // Método que rellena una lista de artículos
        public void cumplimentarListaArticulosVino(ListView listView1)
        {
            ConexionBD con = new ConexionBD();
            string cadenaConexion = con.conexion();
            MySqlConnection conexionBD = new MySqlConnection(cadenaConexion);

            try
            {
                string selectQuery = "select ar.ref as referencia, c.nombre as nombrecatalogacion, pr.nombre as nombreproveedor from articulovino as ar " +
                    "inner join catalogacion as c on ar.id_catalogacion= c.id_catalogacion " +
                    "inner join proveedor as pr on pr.id_proveedor = ar.id_proveedor";


                conexionBD.Open();
                MySqlCommand command = new MySqlCommand(selectQuery, conexionBD);
                MySqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    ListViewItem itemAgregar = new ListViewItem(reader.GetString("referencia"));
                    itemAgregar.Checked = false;
                    itemAgregar.SubItems.Add(reader.GetString("nombrecatalogacion"));
                    itemAgregar.SubItems.Add(reader.GetString("nombreproveedor"));
                    listView1.Items.Add(itemAgregar);
                }

            }
            catch (Exception ex){ MessageBox.Show(ex.Message); }
            finally { conexionBD.Close(); }
        }


        // Método genérico que cumplimenta cualquier lista con ref y nombre
        public void cumplimentarLista(string atributoRef, string atributoNombre, string nombreTabla, ListView listView1, char activo)
        {
            
            listView1.Items.Clear();

            ConexionBD con = new ConexionBD();
            string cadenaConexion = con.conexion();
            MySqlConnection conexionBD = new MySqlConnection(cadenaConexion);

            try
            {
                string selectQuery = "select " + atributoRef + " as referencia," + atributoNombre + " as nombre from " + nombreTabla + " " +
                    "where activo='" + activo + "'"; 

                conexionBD.Open();
                MySqlCommand command = new MySqlCommand(selectQuery, conexionBD);
                MySqlDataReader reader = command.ExecuteReader();   

                while (reader.Read())
                {
                    ListViewItem itemAgregar = new ListViewItem(reader.GetString("referencia"));
                    // itemAgregar.Checked = true;
                    itemAgregar.SubItems.Add(reader.GetString("nombre"));
                    
                    listView1.Items.Add(itemAgregar);
                }
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
            finally { conexionBD.Close(); }
        }
    }


    }

