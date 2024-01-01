using System;
using System.Activities.Expressions;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using proyectovinos.ArticuloVino;
using proyectovinos.Socios;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using ComboBox = System.Windows.Forms.ComboBox;
using ListView = System.Windows.Forms.ListView;
using TextBox = System.Windows.Forms.TextBox;

namespace proyectovinos
{
    public class CumplimentarComboboxes
    {
        public string Number { get; }
        public string Owner { get; set; }
        public decimal Balance { get; }


        public void MakeDeposit(decimal amount, DateTime date, string note)
        {
        }

        public void MakeWithdrawal(decimal amount, DateTime date, string note)
        {
        }


        Class_Articulo articulo = new Class_Articulo();
        Consultas consultas = new Consultas();
        ConexionBD con = new ConexionBD();
        Utilidades ut = new Utilidades();
      

        public void cumplimentarComboboxRefVentaSocio(ComboBox comboBox_refcompraproveedor)
        {
            string cadenaConexion = con.conexion();
            MySqlConnection conexionBD = new MySqlConnection(cadenaConexion);

            try
            {
                string selectQuery = "select DISTINCT ref from ventasocio";
                conexionBD.Open();
                MySqlCommand command = new MySqlCommand(selectQuery, conexionBD);
                MySqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    comboBox_refcompraproveedor.Items.Add(reader.GetString("ref"));
                    comboBox_refcompraproveedor.Text = "Seleccione";
                }

            }
            catch (Exception ex)
            { MessageBox.Show(ex.Message);}
            finally { conexionBD.Close(); }
        }


        /// <summary>
        /// Método que cumplimenta el combobox de Artículo 
        /// </summary>
        /// <param name="atributo">The atributo.</param>
        /// <param name="nombreTabla">The nombre tabla.</param>
        /// <param name="combo_articulovino">The combo articulovino.</param>
        public void cumplimenterComboboxCualquiereReferencia(string atributo, string nombreTabla, ComboBox combo_articulovino)
        {

            string cadenaConexion = con.conexion();
            MySqlConnection conexionBD = new MySqlConnection(cadenaConexion);


            try
            {
                string selectQuery = "select " + atributo + "  from " + nombreTabla + "  order by ref asc";
                conexionBD.Open();
                MySqlCommand command = new MySqlCommand(selectQuery, conexionBD);
                MySqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    combo_articulovino.Items.Add(reader.GetString("ref"));
                }
                combo_articulovino.Text = "Seleccione";

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

     
        /// <summary>
        /// Bloque que rellena el combobox de referencia de Socio  
        /// </summary>
        /// <param name="combo_socio">The combo socio.</param>
        public void cumplimenterComboboxSocio(ComboBox combo_socio)
        {
            string cadenaConexion = con.conexion();
            MySqlConnection conexionBD = new MySqlConnection(cadenaConexion);


            try
            {
                string selectQuery = "select ref as ref from socio";
                conexionBD.Open();
                MySqlCommand command = new MySqlCommand(selectQuery, conexionBD);
                MySqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    combo_socio.Items.Add(reader.GetString("ref"));
                    combo_socio.Text = "Seleccione";
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

        // Refrescar Comboboxes

        //  Método que refresca el combobox de Articulo cuando se cambie el proveedor 
        public void refrescarComboboxArticuloDesdeNombreProveedor(ComboBox combo_proveedor, ComboBox combo_articulovino)
        {

            combo_articulovino.Items.Clear();

            // Saber qué id_proveedor se ha seleccionado
            int id_proveedor = consultas.obtenerCualquierId("id_proveedor", "proveedor", "nombre", combo_proveedor.Text);


            string cadenaConexion = con.conexion();
            MySqlConnection conexionBD = new MySqlConnection(cadenaConexion);


            try
            {
                string selectQuery = "select ref from articulo where id_proveedor = " + id_proveedor + " order by ref asc";
                conexionBD.Open();
                MySqlCommand command = new MySqlCommand(selectQuery, conexionBD);
                MySqlDataReader reader = command.ExecuteReader();


                while (reader.Read())
                {
                    combo_articulovino.Items.Add(reader.GetString("ref"));
                }
                combo_articulovino.Text = "Seleccione";

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


        // Especial
        public void refrescarComboNombreEmpleado(ComboBox comboBox_roll, ComboBox comboBox_empleado)
        {
         
            comboBox_empleado.Items.Clear();

            // Saber qué id_roll se ha seleccionado
            int id_rollempleado = consultas.obtenerCualquierId("id_rollempleado", "rollempleado", "nombre", comboBox_roll.Text);


            string cadenaConexion = con.conexion();
            MySqlConnection conexionBD = new MySqlConnection(cadenaConexion);


            try
            {
                string selectQuery = "select nombre as nombre, apellido1 as apellido1, apellido2 as apellido2 from empleado where id_rollempleado = " + id_rollempleado + " order by ref asc";

                conexionBD.Open();
                MySqlCommand command = new MySqlCommand(selectQuery, conexionBD);
                MySqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    comboBox_empleado.Items.Add(reader.GetString("nombre") + " " + reader.GetString("apellido1") + " " + reader.GetString("apellido2"));
                }
                comboBox_empleado.Text = "Seleccione";

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

    
        /// <summary>
        /// Método que cumplimenta los datos de una referencia de articulo vino  
        /// </summary>
        /// <param name="combo_articulovino">The combo articulovino.</param>
        /// <param name="text_unidadesalmacen">The text unidadesalmacen.</param>
        /// <param name="text_unidadestienda">The text unidadestienda.</param>
        /// <param name="pictureBox1">The picture box1.</param>
        /// <param name="combo_proveedor">The combo proveedor.</param>
        /// <param name="text_empaquetado">The text empaquetado.</param>
        public void comboArticuloChanged(ComboBox combo_articulovino, TextBox text_unidadesalmacen,
            TextBox text_unidadestienda, PictureBox pictureBox1, ComboBox combo_proveedor, TextBox text_empaquetado)
        {
             string referenciaArticuloVino = combo_articulovino.Text; 

            text_empaquetado.Text = consultas.obtenerCualquierNombre("id_empaquetado", "empaquetado", "ref", referenciaArticuloVino);


            // Saber qué proveeedor es para ir a su carpeta
            string nombreProveedor = combo_proveedor.Text;
            nombreProveedor = ut.limpiezaDeString(nombreProveedor);

            // Saber la clase de vino desde el id_articulovino
            string nombreClaseVino = consultas.obtenerCualquierNombre("id_clasevino", "clasevino", "ref", referenciaArticuloVino);

            // La imagen
            pictureBox1.Image = Image.FromFile(ClaseCompartida.carpetaimg_absoluta + "proveedores/" + nombreProveedor + "" + "/articulos/" + nombreClaseVino + "/" + referenciaArticuloVino + ".jpg");

        }


        public void comboReferenciaCompraProveedorChanged(ComboBox combo_articulovino, TextBox text_unidadesalmacen, 
            TextBox text_unidadestienda, PictureBox pictureBox1, ComboBox combo_proveedor, TextBox text_empaquetado, ComboBox combo_refcompraproveedor)
        {

            string referenciaArticulo = combo_articulovino.Text;
            string nombreEmpaquetado = consultas.obtenerCualquierNombre("id_empaquetado", "empaquetado", "ref", referenciaArticulo);
            text_empaquetado.Text = nombreEmpaquetado;


            // Saber qué proveeedor es para ir a su carpeta
            string nombreProveedor = combo_proveedor.Text;
            nombreProveedor = ut.limpiezaDeString(nombreProveedor);
            string nombreClaseVino = consultas.obtenerCualquierNombre("id_clasevino", "clasevino", "ref", referenciaArticulo);

            // La imagen
            pictureBox1.Image = Image.FromFile(ClaseCompartida.carpetaimg_absoluta + "proveedores/" + nombreProveedor + "" + "/articulos/" + nombreClaseVino + "/" + combo_articulovino.Text + ".jpg");

        }

        /// <summary>
        /// Método que refresca el combobos de Artículos de una venta de a Socio 
        /// </summary>
        /// <param name="combo_refventasocio">The combo refventasocio.</param>
        /// <param name="combo_articulovino">The combo articulovino.</param>
        public void refrescarComboboxArticuloDesdeRefCompraProveedor(ComboBox combo_refventasocio, ComboBox combo_articulovino)
        {
            combo_articulovino.Items.Clear();

            string refVentasocio = combo_refventasocio.Text;
            string cadenaConexion = con.conexion();
            MySqlConnection conexionBD = new MySqlConnection(cadenaConexion);


            try
            {
                string selectQuery = "select DISTINCT ar.ref as referencia from articulo ar " +
                    " inner join lineaventasocio as l on l.id_articulo = ar.id_articulo " +
                    " inner join ventasocio as v on v.id_ventasocio = l.id_ventasocio " +
                    " where v.ref = '" + refVentasocio + "' order by ar.ref asc";

                conexionBD.Open();
                MySqlCommand command = new MySqlCommand(selectQuery, conexionBD);
                MySqlDataReader reader = command.ExecuteReader();


                while (reader.Read())
                {
                    combo_articulovino.Items.Add(reader.GetString("referencia"));
                }
                combo_articulovino.Text = "Seleccione";

            }
            catch (Exception ex){ MessageBox.Show(ex.Message); }
            finally{ conexionBD.Close(); }
        }
     
        /// <summary>
        /// Método genérico que cumplimenta un Combobox con los nombres de cualquier atributo de una tabla 
        /// </summary>
        /// <param name="atributo">The atributo.</param>
        /// <param name="nombreTabla">The nombre tabla.</param>
        /// <param name="combo_">The combo.</param>
        public void refrescarCombo(string atributo, string nombreTabla, ComboBox combo_)
        {
            combo_.Items.Clear();

            string cadenaConexion = con.conexion();
            MySqlConnection conexionBD = new MySqlConnection(cadenaConexion);

            try
            {
                string selectQuery = "select " + atributo + " as resultado from " + nombreTabla + " where activo='1' order by ref asc" ;
                conexionBD.Open();
                MySqlCommand command = new MySqlCommand(selectQuery, conexionBD);
                MySqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    combo_.Items.Add(reader.GetString("resultado"));
                }
                combo_.Text = "Seleccione";

            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
            finally { conexionBD.Close(); }
        }

   
        /// <summary>
        /// Método que refresca el combo de referencia de compra a proveedor desde venta y artículo    
        /// </summary>
        /// <param name="id_ventasocio">The identifier ventasocio.</param>
        /// <param name="id_articulo">The identifier articulo.</param>
        /// <param name="comboBox_refcompraproveedor">The combo box refcompraproveedor.</param>
        public void refrescarComboRefCompraProveedor(int id_ventasocio, int id_articulo, ComboBox comboBox_refcompraproveedor)
        {
            comboBox_refcompraproveedor.Items.Clear();
            string cadenaConexion = con.conexion();
            MySqlConnection conexionBD = new MySqlConnection(cadenaConexion);

            try
            {
                string selectQuery = "select DISTINCT (com.ref) as referencia from compraproveedor as com " +
                    " inner join lineacompraproveedor as l on l.id_compraproveedor=com.id_compraproveedor " +
                    " inner join articulo ar on ar.id_articulo=l.id_articulo " +
                    " inner join lineaventasocio lv on ar.id_articulo=lv.id_articulo " +
                    " where lv.id_ventasocio= " + id_ventasocio + " and lv.id_articulo= " + id_articulo + "";

                conexionBD.Open();
                MySqlCommand command = new MySqlCommand(selectQuery, conexionBD);
                MySqlDataReader reader = command.ExecuteReader();


                while (reader.Read())
                {
                    comboBox_refcompraproveedor.Items.Add(reader.GetString("referencia"));
                }
                comboBox_refcompraproveedor.Text = "Seleccione";

            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
            finally { conexionBD.Close(); }

        }

     
        /// <summary>
        /// Función que refresca el combo de compra de proveedor  
        /// </summary>
        /// <param name="id_articulo">The identifier articulo.</param>
        /// <param name="comboBox_refcompraproveedor">The combo box refcompraproveedor.</param>
        public void refrescarComboRefCompraProveedor2(int id_articulo, ComboBox comboBox_refcompraproveedor)
        {
            comboBox_refcompraproveedor.Items.Clear();

            string cadenaConexion = con.conexion();
            MySqlConnection conexionBD = new MySqlConnection(cadenaConexion);

            try
            {
                string selectQuery = "select DISTINCT (com.ref) as referencia from compraproveedor as com " +
                    " inner join lineacompraproveedor as l on l.id_compraproveedor=com.id_compraproveedor " +
                    " inner join articulo ar on ar.id_articulo=l.id_articulo " +
                    " where l.id_articulo= " + id_articulo + "";

               // MessageBox.Show(selectQuery);
                conexionBD.Open();
                MySqlCommand command = new MySqlCommand(selectQuery, conexionBD);
                MySqlDataReader reader = command.ExecuteReader();


                while (reader.Read())
                {
                    comboBox_refcompraproveedor.Items.Add(reader.GetString("referencia"));
                }
                comboBox_refcompraproveedor.Text = "Seleccione";

            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
            finally { conexionBD.Close(); }
        }


        public void refrescarComboRefCompraProveedorMovimientoAlmacenTienda(int id_articulo, ComboBox comboBox_refcompraproveedor)
        {
            comboBox_refcompraproveedor.Items.Clear();


            string cadenaConexion = con.conexion();
            MySqlConnection conexionBD = new MySqlConnection(cadenaConexion);

            try
            {
                string selectQuery = "select distinct (com.ref) as referencia from compraproveedor as com " +
                    " inner join ubicacionlineacompraproveedor as ub on ub.id_compraproveedor=com.id_compraproveedor " +
                    " where ub.id_articulo= " + id_articulo + "";

                conexionBD.Open();
                MySqlCommand command = new MySqlCommand(selectQuery, conexionBD);
                MySqlDataReader reader = command.ExecuteReader();


                while (reader.Read())
                {
                    comboBox_refcompraproveedor.Items.Add(reader.GetString("referencia"));
                }
                comboBox_refcompraproveedor.Text = "Seleccione";

            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
            finally { conexionBD.Close(); }
        }

      
        /// <summary>
        /// Método que cumplimenta en un ComboBox en nombre de un empleado
        /// </summary>
        /// <param name="comboBox_empleado">The combo box empleado.</param>
        public void cumplimentarComboNombreEmpleado(ComboBox comboBox_empleado)
        {

            string cadenaConexion = con.conexion();
            MySqlConnection conexionBD = new MySqlConnection(cadenaConexion);

            try
            {
                string selectQuery = "select nombre as nombre,apellido1 as apellido1,apellido2 as apellido2 from empleado order by apellido1 asc";
                
                conexionBD.Open();
                MySqlCommand command = new MySqlCommand(selectQuery, conexionBD);
                MySqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    comboBox_empleado.Items.Add(reader.GetString("nombre") + " " + reader.GetString("apellido1") + " " + reader.GetString("apellido2"));
                }
                comboBox_empleado.Text = "Seleccione";

            }
            catch (Exception ex){ MessageBox.Show(ex.Message); }
            finally{  conexionBD.Close();  }
        }
  
        /// <summary>
        /// Método que cumplimenta el comboBox de nombre de Catalogaciones que tiene un Proveeedor  
        /// </summary>
        /// <param name="refProveedor">The reference proveedor.</param>
        /// <param name="combo_nombrecatalogacion">The combo nombrecatalogacion.</param>
        public void refrescarComboboxCatalogacionArticuloDesdeNombreProveedor(string refProveedor, ComboBox combo_nombrecatalogacion)
        {

            string cadenaConexion = con.conexion();
            MySqlConnection conexionBD = new MySqlConnection(cadenaConexion);

            try
            {
                string selectQuery = "select c.nombre as nombrecatalogacion from catalogacion c " +
                    " inner join articulo as a on a.id_catalogacion = c.id_catalogacion " +
                    " inner join proveedor as p on p.id_proveedor = a.id_proveedor " +
                    " where p.ref = '" + refProveedor + "' order by c.nombre asc";

                conexionBD.Open();
                MySqlCommand command = new MySqlCommand(selectQuery, conexionBD);
                MySqlDataReader reader = command.ExecuteReader();


                while (reader.Read())
                {
                    combo_nombrecatalogacion.Items.Add(reader.GetString("nombrecatalogacion"));
                    if (reader.GetString("nombrecatalogacion")=="") {
                        MessageBox.Show("Compre existencias al Proveedor");
                    }
                }
                combo_nombrecatalogacion.Text = "Seleccione";

            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
            finally { conexionBD.Close(); }
        }


        
        /// <summary>
        /// Función que cumplimenta el comboBox de referencias de lineas de compra a proveedor que tiene un artículo  
        /// </summary>
        /// <param name="id_articulo">The identifier articulo.</param>
        /// <param name="combo_reflinea">The combo reflinea.</param>
        public void refrescarComboboxLineaCompraProveedorDesdeId_articulo(int id_articulo, ComboBox combo_reflinea)
        {
            combo_reflinea.Items.Clear();

            string cadenaConexion = con.conexion();
            MySqlConnection conexionBD = new MySqlConnection(cadenaConexion);

            try
            {     
                string selectQuery = "select l.ref from lineacompraproveedor l " +
                    " inner join ubicacionlineacompraproveedor as ub on ub.id_lineacompraproveedor = l.id_lineacompraproveedor" +
                    
                    " where ub.id_articulo = '" + id_articulo + "' " +
                    " and ub.existencias > 0 " +
                    " and ub.id_ubicacion = 2 order by l.ref asc";
                //MessageBox.Show(selectQuery);

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
   
        /// <summary>
        /// Método que cumplimenta el comboBox de referencias de lineas de compra a proveedor que tiene un artículo. Referencias con existencias en tienda > 0   
        /// </summary>
        /// <param name="id_articulo">The identifier articulo.</param>
        /// <param name="combo_reflinea">The combo reflinea.</param>
        public void refrescarComboboxRefCompraProveedorDesdeId_articulo(int id_articulo, ComboBox combo_reflinea)
        {
            combo_reflinea.Items.Clear();

            string cadenaConexion = con.conexion();
            MySqlConnection conexionBD = new MySqlConnection(cadenaConexion);

            try
            {
                string selectQuery = "select c.ref from compraproveedor c " +

                    " inner join lineacompraproveedor as l on l.id_compraproveedor = c.id_compraproveedor" +
                    " where l.id_articulo = " + id_articulo + " order by l.ref asc";

                //MessageBox.Show(selectQuery);

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
    }
}