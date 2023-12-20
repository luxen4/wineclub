
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Web.Services.Protocols;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using proyectovinos.Movimientos.AlmacenTienda;

namespace proyectovinos.ArticuloVino
{


    public class Class_Articulo
    {
        // Función que cumplimenta la lista de artículos
        public void cumplimentarListaArticulos(ListView listView1, char activo)
        {
            listView1.Items.Clear();

            ConexionBD con = new ConexionBD();
            string cadenaConexion = con.conexion();
            MySqlConnection conexionBD = new MySqlConnection(cadenaConexion);


            try
            {
                string selectQuery = "select a.id_articulo as id_articulo , a.ref," +
                   " t.nombre as nombretipouva, cv.nombre as nombreclasevino, p.nombre as nombreproveedor, " +
                   " c.nombre as nombrecatalogacion, d.nombre as nombredenominacion, " +
                   " emp.nombre as formato, f.nombre as contenido, a.minalmacen as minalmacen, a.maxalmacen as maxalmacen, a.mintienda as mintienda, a.maxtienda as maxtienda from articulo as a " +
                   " inner join empaquetado as emp on emp.id_empaquetado=a.id_empaquetado " +
                   "inner join formatocontenido as f on f.id_formatocontenido = a.id_formatocontenido " +
                   "inner join clasevino as cv on cv.id_claseVino = a.id_claseVino " +
                   "inner join tipouva as t on t.id_tipouva = a.id_tipouva " +
                   "inner join proveedor as p on p.id_proveedor = a.id_proveedor " +
                   "inner join catalogacion as c on c.id_catalogacion = a.id_catalogacion " +
                   "inner join denominacion as d on d.id_denominacion = a.id_denominacion where a.activo = '" + activo + 
                   "' order by a.ref asc";

                // MessageBox.Show(selectQuery);

                conexionBD.Open();
                MySqlCommand command = new MySqlCommand(selectQuery, conexionBD);
                MySqlDataReader reader = command.ExecuteReader();


                while (reader.Read())
                {
                    ListViewItem itemAgregar = new ListViewItem(reader.GetString("ref"));
                    string referencia = reader.GetString("ref");
                    // itemAgregar.Checked = true;
                    itemAgregar.SubItems.Add(reader.GetString("nombretipouva"));
                    itemAgregar.SubItems.Add(reader.GetString("nombreclasevino"));
                    
                    itemAgregar.SubItems.Add(reader.GetString("nombreproveedor"));
                    itemAgregar.SubItems.Add(reader.GetString("nombrecatalogacion"));
                    itemAgregar.SubItems.Add(reader.GetString("nombredenominacion"));

                    itemAgregar.SubItems.Add(reader.GetString("formato"));
                    itemAgregar.SubItems.Add(reader.GetString("contenido"));

                    itemAgregar.SubItems.Add(reader.GetString("minalmacen"));
                    itemAgregar.SubItems.Add(reader.GetString("maxalmacen"));
                    itemAgregar.SubItems.Add(reader.GetString("mintienda"));
                    itemAgregar.SubItems.Add(reader.GetString("maxtienda"));


                    // Necesitamos consultar en ubicacionlineacompraproveedor con la ref
                    int id_articulo = Int32.Parse(reader.GetString("id_articulo"));
                    itemAgregar.SubItems.Add(existenciasRefUbicaciones(id_articulo, 1).ToString());
                    itemAgregar.SubItems.Add(existenciasRefUbicaciones(id_articulo, 2).ToString());

                    listView1.Items.Add(itemAgregar);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                conexionBD.Close();
            }
        }



        // Método que guarda la imagen de un articulo y la presenta en un PictureBox
        public void agregarImagenPredeterminada(int id_proveedor, string nombreclasevino, string nombreImagen, PictureBox pictureBox_articulo)
        {
            pictureBox_articulo.Image = Image.FromFile(ClaseCompartida.carpetaimg_absoluta + "proveedores/botellapredeterminada.jpg");
            pictureBox_articulo.Image.Save(ClaseCompartida.carpetaimg_absoluta + "proveedores/" + id_proveedor + "/articulos/" + nombreclasevino + "/" + nombreImagen, System.Drawing.Imaging.ImageFormat.Jpeg);
        }

        // Método que guarda la imagen de un articulo predeterminada y la presenta en un PictureBox
        public void agregarImagen(int id_proveedor, string nombreclasevino, string nombreImagen, PictureBox pictureBox_articulo)
        {
            pictureBox_articulo.Image.Save(ClaseCompartida.carpetaimg_absoluta + "proveedores/" + id_proveedor + "/articulos/" + nombreclasevino + "/" + nombreImagen, System.Drawing.Imaging.ImageFormat.Jpeg);
            pictureBox_articulo.Image = Image.FromFile(ClaseCompartida.carpetaimg_absoluta + "proveedores/" + id_proveedor + "/articulos/" + nombreclasevino + "/" + nombreImagen);

        }




        // Aviso de falta de existencias
        internal void comprobarFaltaExistenciasArticulo(int id_articulo)
        {

            int[] existenciasPredeterminadas = existenciasPredeterminadasArticuloUbicacion(id_articulo);

            int existenciasUbicaciontienda = existenciasTotalesZona(2, id_articulo);
            int existenciasUbicacionAlmacen = existenciasTotalesZona(1, id_articulo);


            if (existenciasUbicaciontienda < existenciasPredeterminadas[2])
            {
                MessageBox.Show("Reservas mínimas en tienda (min " + existenciasPredeterminadas[2] + "), " +
                    "saque del almacén! \n MOVIMIENTOS-->De Almacén a Tienda");
            }

            if (existenciasUbicacionAlmacen < existenciasPredeterminadas[0])
            {
                MessageBox.Show("Reservas mínimas en Almacén " + existenciasPredeterminadas[0] + ", compre al proveedor!");
            }
        }



        // Método que devuelve el precio de venta de un artículo
        public decimal precioCosteVentaArticulo(string refLinea, string atributo_precio)
        {

            decimal precioVentaArticulo = 0;

            ConexionBD con = new ConexionBD();
            string cadenaConexion = con.conexion();
            MySqlConnection conexionBD = new MySqlConnection(cadenaConexion);

            try
            {
                string selectQuery = "select " + atributo_precio + " as precio  from lineacompraproveedor " +
                    " where ref ='" + refLinea + "' ";

                 // MessageBox.Show(selectQuery);

                conexionBD.Open();
                MySqlCommand command = new MySqlCommand(selectQuery, conexionBD);
                MySqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    precioVentaArticulo = Decimal.Parse(reader.GetString("precio"));
                }
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
            finally { conexionBD.Close(); }

            return precioVentaArticulo;
        }




        // Existencias Predeterminadas de un artículo en almacén y Tienda
        public int[] existenciasPredeterminadasArticuloUbicacion(int id_articulo)
        {

            int[] existencias = new int[4];

            ConexionBD con = new ConexionBD();
            string cadenaConexion = con.conexion();
            MySqlConnection conexionBD = new MySqlConnection(cadenaConexion);

            try
            {
                string selectQuery = "select minalmacen, maxalmacen, mintienda, maxtienda from articulo where id_articulo = " + id_articulo + " ";

                conexionBD.Open();
                MySqlCommand command = new MySqlCommand(selectQuery, conexionBD);
                MySqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {

                    int minalmacen = Int32.Parse(reader.GetString("minalmacen")); existencias[0] = minalmacen;
                    int maxalmacen = Int32.Parse(reader.GetString("maxalmacen")); existencias[1] = maxalmacen;

                    int mintienda = Int32.Parse(reader.GetString("mintienda")); existencias[2] = mintienda;
                    int maxtienda = Int32.Parse(reader.GetString("maxtienda")); existencias[3] = maxtienda;
                }
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
            finally { conexionBD.Close(); }

            return existencias;
        }


        // Método que ajusta las existencias en tienda
        public void ajusteExistenciasTienda(ListView listView1, int i)
        {

            string unidadesArticuloTexto = listView1.Items[i].SubItems[4].Text;

            string refArticulo = listView1.Items[i].SubItems[0].Text;
            Consultas consultas = new Consultas();
            int id_articulo = consultas.obtenerCualquierId("id_articulo", "articulo", "ref", refArticulo);

            // Existencias en tienda
            string refLinea = listView1.Items[i].SubItems[1].Text;
            int id_lineacompraproveedor = consultas.obtenerCualquierId("id_lineacompraproveedor", "lineacompraproveedor", "ref", refLinea);

            int unidadesTienda = existenciasTiendaArticulo(id_lineacompraproveedor, id_articulo);
            int totalExistenciasTienda = unidadesTienda - Int32.Parse(unidadesArticuloTexto);

            // Ajuste existencias en tienda
            Class_AlmacenTienda almacenTienda = new Class_AlmacenTienda();
            almacenTienda.ajusteExistenciasCualquierUbicacion(id_lineacompraproveedor, totalExistenciasTienda, id_articulo, "tienda");

        }


        // Método que devuelve el nº de existencias de un artículo en la tienda
        public int existenciasTiendaArticulo(int id_lineacompraproveedor, int id_articulo)
        {

            int existencias = 0;

            ConexionBD con = new ConexionBD();
            string cadenaConexion = con.conexion();
            MySqlConnection conexionBD = new MySqlConnection(cadenaConexion);

            try
            {
                string selectQuery = "select existencias as existencias from ubicacionlineacompraproveedor " +
                    "where id_lineacompraproveedor=" + id_lineacompraproveedor + " and id_articulo= " + id_articulo + " and id_ubicacion = " + 2 + " ";

                conexionBD.Open();
                MySqlCommand command = new MySqlCommand(selectQuery, conexionBD);
                MySqlDataReader reader = command.ExecuteReader();


                while (reader.Read())
                {
                    existencias = Int32.Parse(reader.GetString("existencias"));
                }
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
            finally { conexionBD.Close(); }

            return existencias;
        }



        // Método que devuelve el número de artículos que tiene una clase de vino
        public int existeArticuloConCaracteristica(string id_articulo, string nombreTabla, string atributoWhere, int valorAributoWhere)
        {
            int numRegistros = 0;

            ConexionBD con = new ConexionBD();
            string cadenaConexion = con.conexion();
            MySqlConnection conexionBD = new MySqlConnection(cadenaConexion);
            MySqlDataReader reader = null;

            try
            {
                string selectQuery = "SELECT count('" + id_articulo + "') as numregistros from " + nombreTabla + " " +
                    "where " + atributoWhere + " = " + valorAributoWhere + " ;";

                // MessageBox.Show(selectQuery);

                conexionBD.Open();
                MySqlCommand command = new MySqlCommand(selectQuery, conexionBD);
                reader = command.ExecuteReader();

                while (reader.Read())
                {
                    numRegistros = Int32.Parse(reader.GetString("numregistros"));
                }
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
            finally { conexionBD.Close(); }

            return numRegistros;
        }


        // Método que Registra una nueva linea de proveedor en una ubicación
        public void nuevaExistenciaAlmacenTienda(int id_ubicacion, int id_lineacompraproveedor, int id_articulo, int existencias)
        {
            ConexionBD con = new ConexionBD();
            string cadenaConexion = con.conexion();
            MySqlConnection conexionBD = new MySqlConnection(cadenaConexion);

            try
            {
                string selectquery = "insert into ubicacionlineacompraproveedor (id_ubicacion, id_lineacompraproveedor, id_articulo, existencias) " +
                                      "values (" + id_ubicacion + ", " + id_lineacompraproveedor + "," + id_articulo + ", " + existencias + ");";

                // MessageBox.Show(selectquery);

                MySqlCommand comando = new MySqlCommand(selectquery);
                comando.Connection = conexionBD;
                conexionBD.Open();
                MySqlDataReader reader = comando.ExecuteReader();

            }
            catch (MySqlException ex) { MessageBox.Show(ex.Message); }
            finally { conexionBD.Close(); }
        }



        // Metodo que devuelve las existencias en almacén o tienda de un artículo
        public int existenciasTotalesZona(int id_ubicacion, int id_articulo)
        {
            string ubicacion = "";
            int existencias = 0;

            if (id_ubicacion == 1)
            {
                ubicacion = "Almacén";
            }
            if (id_ubicacion == 2)
            {
                ubicacion = "Tienda";
            }


            ConexionBD con = new ConexionBD();
            string cadenaConexion = con.conexion();
            MySqlConnection conexionBD = new MySqlConnection(cadenaConexion);

            try
            {
                string selectQuery = "select ub.existencias as existencias from ubicacionlineacompraproveedor as ub where " +
                    " id_ubicacion = " + id_ubicacion + "" +
                    " and id_articulo = " + id_articulo + " ";

                conexionBD.Open();
                MySqlCommand command = new MySqlCommand(selectQuery, conexionBD);
                MySqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    existencias = existencias + Int32.Parse(reader.GetString("existencias"));
                }
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
            finally { conexionBD.Close(); }

            // MessageBox.Show("Existencias en " + ubicacion + ": " + existencias);

            return existencias;
        }


        /// <summary>
        /// Obteners the reference articulo desde id_proveedor y el id_catalogacion.
        /// </summary>
        /// <param name="id_proveedor">The identifier proveedor.</param>
        /// <param name="id_catalogacion">The identifier catalogacion.</param>
        /// <returns></returns>
        public string obtenerRefArticulo(int id_proveedor, int id_catalogacion)
        {
            string referencia = "";

            ConexionBD con = new ConexionBD();
            string cadenaConexion = con.conexion();
            MySqlConnection conexionBD = new MySqlConnection(cadenaConexion);

            try
            {
                string selectQuery = "select ref as referencia from articulo a where " +
                    " id_proveedor = " + id_proveedor + "" +
                    " and id_catalogacion = " + id_catalogacion + " ";

                conexionBD.Open();
                MySqlCommand command = new MySqlCommand(selectQuery, conexionBD);
                MySqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    referencia = reader.GetString("referencia");
                }
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
            finally { conexionBD.Close(); }

            return referencia;
        }



        // Método que devuelve las existencias de un artículo en una zona de la tienda
        public int existenciasLineaZona(int id_ubicacion, int id_articulo, int id_lineacompraproveedor)
        {

            string ubicacion = "";
            int existencias = 0;

            if (id_ubicacion == 1)
            {
                ubicacion = "Almacén";
            }
            if (id_ubicacion == 2)
            {
                ubicacion = "Tienda";
            }

            ConexionBD con = new ConexionBD();
            string cadenaConexion = con.conexion();
            MySqlConnection conexionBD = new MySqlConnection(cadenaConexion);

            try
            {
                string selectQuery = "select ub.existencias as existencias from ubicacionlineacompraproveedor as ub where " +
                    " id_ubicacion = " + id_ubicacion + "" +
                    " and id_lineacompraproveedor = " + id_lineacompraproveedor + "" +
                    " and id_articulo = " + id_articulo + " ";

                conexionBD.Open();
                MySqlCommand command = new MySqlCommand(selectQuery, conexionBD);
                MySqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    existencias = existencias + Int32.Parse(reader.GetString("existencias"));
                }
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
            finally { conexionBD.Close(); }

            // MessageBox.Show("Existencias en " + ubicacion + ": " + existencias);

            return existencias;
        }



        // Metodo que devuelve las existencias totales de un artículo en una ubicación (para listado de todos los artículos)
        public int existenciasRefUbicaciones(int id_articulo, int id_ubicacion)
        {
            int existencias = 0;

            ConexionBD con = new ConexionBD();
            string cadenaConexion = con.conexion();
            MySqlConnection conexionBD = new MySqlConnection(cadenaConexion);

            try
            {
                string selectQuery = "select existencias as existencias from ubicacionlineacompraproveedor " +
                    "where id_articulo= " + id_articulo + " and id_ubicacion = " + id_ubicacion + " ";

                conexionBD.Open();
                MySqlCommand command = new MySqlCommand(selectQuery, conexionBD);
                MySqlDataReader reader = command.ExecuteReader();


                while (reader.Read())
                {
                    existencias = existencias + Int32.Parse(reader.GetString("existencias"));
                }
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
            finally { conexionBD.Close(); }

            return existencias;
        }

        // 2veces usado
        // Método que cumplimenta los datos de un Artículo seleccionado dispuesto a eliminar
        internal void articuloSeleccionado(ItemCheckedEventArgs e, TextBox text_refarticulo, ListView listView1, TextBox text_unidadesalmacen, TextBox text_unidadestienda, TextBox text_empaquetado, PictureBox pictureBox1)
        {
            string refArticulo = e.Item.Text;
            text_refarticulo.Text = refArticulo;

            int existenciasAlmacen = Int32.Parse(listView1.Items[e.Item.Index].SubItems[11].Text);
            text_unidadesalmacen.Text = existenciasAlmacen.ToString();

            int existenciasTienda = Int32.Parse(listView1.Items[e.Item.Index].SubItems[12].Text);
            text_unidadestienda.Text = existenciasTienda.ToString();
            text_empaquetado.Text = listView1.Items[e.Item.Index].SubItems[6].Text + " " + listView1.Items[e.Item.Index].SubItems[7].Text;

            CumplimentarPictureBoxes cump = new CumplimentarPictureBoxes();
            cump.cumplimentarPictureBox(refArticulo, pictureBox1);
        }

        internal void limpiarCampos(TextBox text_unidadesalmacen, TextBox text_unidadestienda, TextBox text_empaquetado, CheckBox check_seguro, PictureBox pictureBox1)
        {
            text_unidadesalmacen.Text = "";
            text_unidadestienda.Text = "";
            text_empaquetado.Text = "";
            check_seguro.Checked = false;
            pictureBox1.Image = null;
        }


        // Metodo que devuelve artículos filtrados por el nombre de una característica
        internal void listaArticulos_Filtrados(string nombreAtributo, int valorAtributo, ListView listView1, char activo)
        {
            listView1.Items.Clear();

            ConexionBD con = new ConexionBD();
            string cadenaConexion = con.conexion();
            MySqlConnection conexionBD = new MySqlConnection(cadenaConexion);

            try
            {
                string selectQuery = "select a.id_articulo as id_articulo , a.ref, cv.nombre as nombreclasevino," +
                    "t.nombre as nombretipouva," +
                    " p.nombre as nombreproveedor, " +
                    "c.nombre as nombrecatalogacion, d.nombre as nombredenominacion, " +
                   " emp.nombre as formato, f.nombre as contenido, " +
                   "a.minalmacen as minalmacen, " +
                   "a.maxalmacen as maxalmacen, " +
                   "a.mintienda as mintienda, " +
                   "a.maxtienda as maxtienda from articulo as a " +

                   " inner join empaquetado as emp on emp.id_empaquetado=a.id_empaquetado " +
                   "inner join formatocontenido as f on f.id_formatocontenido = a.id_formatocontenido " +
                   "inner join clasevino as cv on cv.id_claseVino = a.id_claseVino " +
                   "inner join tipouva as t on t.id_tipouva = a.id_tipouva " +
                   "inner join proveedor as p on p.id_proveedor = a.id_proveedor " +
                   "inner join catalogacion as c on c.id_catalogacion = a.id_catalogacion " +
                   "inner join denominacion as d on d.id_denominacion = a.id_denominacion where a." + nombreAtributo + "=" + valorAtributo + " and a.activo = '" + activo + "' order by p.nombre asc";

               // MessageBox.Show(selectQuery);

                conexionBD.Open();
                MySqlCommand command = new MySqlCommand(selectQuery, conexionBD);
                MySqlDataReader reader = command.ExecuteReader();


                while (reader.Read())
                {
                    ListViewItem itemAgregar = new ListViewItem(reader.GetString("ref"));
                    string referencia = reader.GetString("ref");
                    // itemAgregar.Checked = true;
                    itemAgregar.SubItems.Add(reader.GetString("nombretipouva"));
                    itemAgregar.SubItems.Add(reader.GetString("nombreclasevino"));
                    itemAgregar.SubItems.Add(reader.GetString("nombreproveedor"));


                    itemAgregar.SubItems.Add(reader.GetString("nombrecatalogacion"));
                    itemAgregar.SubItems.Add(reader.GetString("nombredenominacion"));

                    itemAgregar.SubItems.Add(reader.GetString("formato"));
                    itemAgregar.SubItems.Add(reader.GetString("contenido"));

                    itemAgregar.SubItems.Add(reader.GetString("minalmacen"));
                    itemAgregar.SubItems.Add(reader.GetString("maxalmacen"));
                    itemAgregar.SubItems.Add(reader.GetString("mintienda"));
                    itemAgregar.SubItems.Add(reader.GetString("maxtienda"));


                    // Necesitamos consultar en ubicacionlineacompraproveedor con la ref
                    int id_articulo = Int32.Parse(reader.GetString("id_articulo"));
                    itemAgregar.SubItems.Add(existenciasRefUbicaciones(id_articulo, 1).ToString());
                    itemAgregar.SubItems.Add(existenciasRefUbicaciones(id_articulo, 2).ToString());

                    listView1.Items.Add(itemAgregar);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                conexionBD.Close();
            }
        }

        // Existencias maximas en tienda
        internal int maxTienda(int id_articulo)
        {
            string ubicacion = "";
            int existencias = 0;

            ConexionBD con = new ConexionBD();
            string cadenaConexion = con.conexion();
            MySqlConnection conexionBD = new MySqlConnection(cadenaConexion);

            try
            {
                string selectQuery = "select a.maxtienda as existencias from articulo as a " +
                    " where id_articulo = " + id_articulo + " ";

                conexionBD.Open();
                MySqlCommand command = new MySqlCommand(selectQuery, conexionBD);
                MySqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    existencias = existencias + Int32.Parse(reader.GetString("existencias"));
                }
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
            finally { conexionBD.Close(); }

            // MessageBox.Show("Existencias en " + ubicacion + ": " + existencias);

            return existencias;
        }



        public string[] nombreCaracteristicasArticulos(int id_articulo)
        {
            string[] nombresCaracteristicas = new string[6];

            ConexionBD con = new ConexionBD();
            string cadenaConexion = con.conexion();
            MySqlConnection conexionBD = new MySqlConnection(cadenaConexion);


            try
            {
                string selectQuery = "select a.id_articulo as id_articulo , a.ref," +
                   " t.nombre as nombretipouva, cv.nombre as nombreclasevino, p.nombre as nombreproveedor, " +
                   " c.nombre as nombrecatalogacion, d.nombre as nombredenominacion, " +
                   " emp.nombre as formato, f.nombre as contenido from articulo as a " +

                   " inner join empaquetado as emp on emp.id_empaquetado=a.id_empaquetado " +
                   "inner join formatocontenido as f on f.id_formatocontenido = a.id_formatocontenido " +
                   "inner join clasevino as cv on cv.id_claseVino = a.id_claseVino " +
                   "inner join tipouva as t on t.id_tipouva = a.id_tipouva " +
                   "inner join proveedor as p on p.id_proveedor = a.id_proveedor " +
                   "inner join catalogacion as c on c.id_catalogacion = a.id_catalogacion " +
                   "inner join denominacion as d on d.id_denominacion = a.id_denominacion where a.id_articulo = " + id_articulo ;

                // MessageBox.Show(selectQuery);

                conexionBD.Open();
                MySqlCommand command = new MySqlCommand(selectQuery, conexionBD);
                MySqlDataReader reader = command.ExecuteReader();


                while (reader.Read())
                {
                    nombresCaracteristicas[0] = reader.GetString("nombreproveedor");
                    nombresCaracteristicas[1] = reader.GetString("nombreclasevino");
                    nombresCaracteristicas[2] = reader.GetString("nombredenominacion");
                    nombresCaracteristicas[3] = reader.GetString("nombrecatalogacion");
                    nombresCaracteristicas[4] = reader.GetString("contenido");
                    nombresCaracteristicas[5] = reader.GetString("formato");
                }
                conexionBD.Close();
                return nombresCaracteristicas;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                conexionBD.Close();
                return null;
            }
            finally
            {
                conexionBD.Close();
            }

        }
    }
}





















/*
public void salvarImagenEnCarpetaProveedor(int id_proveedor, string nombreclasevinoAntigua, string nombreclasevinoNueva, string nombreImagen, PictureBox pictureBox_articulo) {
    try
    {
        // string folderPath = @"C:\MyFoldera";
        string folderPath = @"../../img/proveedores/" + id_proveedor + "/articulos/" + nombreclasevinoNueva;

        MessageBox.Show(folderPath);
        if (!Directory.Exists(folderPath))
        {
            Directory.CreateDirectory(folderPath);
            Console.WriteLine(folderPath);

            if (pictureBox_articulo.Image != null)
            {
                agregarImagen(id_proveedor, nombreclasevinoAntigua, nombreclasevinoNueva, nombreImagen, pictureBox_articulo);
            }
            else
            {
                agregarImagenPredeterminada(id_proveedor, nombreclasevinoNueva, pictureBox_articulo);
            }

        }
        else
        {
            if (pictureBox_articulo.Image != null)
            {
                agregarImagen(id_proveedor, nombreclasevinoAntigua, nombreclasevinoNueva, nombreImagen, pictureBox_articulo);
            }
            else
            {
                agregarImagenPredeterminada(id_proveedor, nombreclasevinoNueva, pictureBox_articulo);
            }
        }
    }
    catch (Exception ex)
    {
        MessageBox.Show("Ocurrio un Error :\n " + ex);
    }
}
*/


/*
// Método que guarda la imagen de un articulo y la presenta en un PictureBox
private void agregarImagenPredeterminada(int id_proveedor, string nombrecatalogacion, PictureBox pictureBox_articulo)
{
    pictureBox_articulo.Image = Image.FromFile(@"../../img/proveedores/botellapredeterminada.jpg");
    pictureBox_articulo.Image.Save(@"../../img/proveedores/" + id_proveedor + "/articulos/" + nombrecatalogacion + "/botellapredeterminada.jpg", System.Drawing.Imaging.ImageFormat.Jpeg);
}

// Método que guarda la imagen de un articulo predeterminada y la presenta en un PictureBox
private void agregarImagen(int id_proveedor, string nombreclasevinoAntigua, string nombreclasevinoNueva, string nombreImagen, PictureBox pictureBox_articulo)
{
    MessageBox.Show("entroo " + @"../../img/proveedores/" + id_proveedor + "/articulos/" + nombreclasevinoAntigua + "/" + nombreImagen);
    pictureBox_articulo.Image = Image.FromFile(@"../../img/proveedores/" + id_proveedor + "/articulos/" + nombreclasevinoAntigua + "/" + nombreImagen);
    pictureBox_articulo.Image.Save(@"../../img/proveedores/" + id_proveedor + "/articulos/" + nombreclasevinoNueva + "/" + nombreImagen, System.Drawing.Imaging.ImageFormat.Jpeg);

}*/
