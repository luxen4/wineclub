using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace proyectovinos
{
    internal class ConexionBD
    {/*
        // Conexión a base de datos en: localhost
        public string conexion()
        {
            string servidor = "localhost";
            string bd = "wineclub";
            string usuario = "root";
            string password = "";

            string cadenaConexion = "Database=" + bd + "; Data Source=" + servidor + "; User Id=" + usuario + "; Password=" + password + "";

            return cadenaConexion;
        }*/

        /*
        // Conexión a base de datos en: sql8.freesqldatabase.com
        public string conexion()
        {
            string connectionString = "server=sql8.freesqldatabase.com;user id=sql8645869;password='6eSruLBwCW';database=sql8645869";

            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    MessageBox.Show("Successfully connected to MySQL");
                }
                catch (MySqlException ex)
                {
                    MessageBox.Show("Error: " + ex.ToString());
                }
            }
            return connectionString;
        }*/


        //OK
        // Para las 2 formas de base de datos
        public string conexion()
        {
            string cadenaConexion = "";

            if (ClaseCompartida.baseDatos == "freesqldatabase.com")
            {
                //MessageBox.Show("Remoto");
                cadenaConexion = "server=sql8.freesqldatabase.com;user id=sql8645869;password='6eSruLBwCW';database=sql8645869";
            }
            else {
                //MessageBox.Show("Local");
                string servidor = "localhost";
                string bd = "wineclub";
                string usuario = "root";
                string password = "";

                cadenaConexion = "Database=" + bd + "; Data Source=" + servidor + "; User Id=" + usuario + "; Password=" + password + "";
            }
            return cadenaConexion;
        }


        /*
        // Clever-cloud (excede las conexiones con poco)
        public string conexion()
        {
            // https://console.clever-cloud.com/users/me/addons/addon_9b02c7a6-79b5-4519-8e28-de0de59d4b90
            string cadenaConexion = "";

            if (ClaseCompartida.baseDatos == "freesqldatabase.com")
            {
                //MessageBox.Show("Remoto");
                cadenaConexion = "server=sql8.freesqldatabase.com;user id=sql8645869;password='6eSruLBwCW';database=sql8645869";
            }
            else
            {
                //MessageBox.Show("Local");
                string servidor = "bbbdckmuz2jqfir8pv9h-mysql.services.clever-cloud.com";
                string bd = "bbbdckmuz2jqfir8pv9h";
                string usuario = "ue1fwidxhtq3h2qa";
                string password = "cnz3x6wfxz0u2jB7Mod9";

                cadenaConexion = "Database=" + bd + "; Data Source=" + servidor + "; User Id=" + usuario + "; Password=" + password + "";
            }
            return cadenaConexion;
        }*/


        // bat-cave
        /*
        public string conexion()
        {
            string cadenaConexion = "";

            if (ClaseCompartida.baseDatos == "freesqldatabase.com")
            {
                //MessageBox.Show("Remoto");
                cadenaConexion = "server=sql8.freesqldatabase.com;user id=sql8645869;password='6eSruLBwCW';database=sql8645869";
            }
            else
            {
                //MessageBox.Show("Local");
                string servidor = "fdb1031.batcave.net";
                string bd = "4378530_wineclub";
                string usuario = "4378530_wineclub";
                string password = "alberite1";

                cadenaConexion = "Database=" + bd + "; Data Source=" + servidor + "; User Id=" + usuario + "; Password=" + password + "";
            }
            return cadenaConexion;
        }*/





        /*
        // prueba awardspace
        public string conexion()
        {
            string cadenaConexion = "";

            
                //MessageBox.Show("Local");
                string servidor = "fdb1030.awardspace.net";
                string bd = "3714088_wineclub";
                string usuario = "3714088_wineclub";
                string password = "alberite2";

                cadenaConexion = "Database=" + bd + "; Data Source=" + servidor + "; User Id=" + usuario + "; Password=" + password + "";
            



            //string connectionString = "server=fdb1030.awardspace.net;user id=3714088_wineclub;password='alberite2';database=3714088_wineclub";

            using (MySqlConnection conn = new MySqlConnection(cadenaConexion))
            {
                try
                {
                    conn.Open();
                    MessageBox.Show("Successfully connected to MySQL");
                }
                catch (MySqlException ex)
                {
                    MessageBox.Show("Error: " + ex.ToString());
                }
            }

     








            return cadenaConexion;
        }   */

    }
}






