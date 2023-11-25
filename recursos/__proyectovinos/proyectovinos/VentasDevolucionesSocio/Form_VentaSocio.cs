using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;
using System.Web.Helpers;
using System.Web.UI.WebControls;
using System.Windows.Forms;
using System.Xml.Linq;
using CrystalDecisions.CrystalReports.Engine;
using MySql.Data.MySqlClient;
using MySqlX.XDevAPI.Relational;
using proyectovinos;
using proyectovinos.Socios;
using static System.Net.Mime.MediaTypeNames;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Tab;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ToolTip;
using Image = System.Drawing.Image;

using PdfSharp.Pdf;
using PdfSharp.Drawing;
using proyectovinos.VentasDevolucionesSocio;
using proyectovinos.Movimientos.AlmacenTienda;
using proyectovinos.Caracteristicas.proveedor;
using proyectovinos.ArticuloVino;
using iTextSharp.text.pdf;
using iTextSharp.text;
using PdfDocument = PdfSharp.Pdf.PdfDocument;
using PdfPage = PdfSharp.Pdf.PdfPage;
using Document = iTextSharp.text.Document;

namespace proyectovinos
{
    public partial class Form_VentaSocio : Form
    {
        public Form_VentaSocio()
        {
            InitializeComponent();
        }
       // private string referenciaArticulo = "";

        Class_Articulo articulo = new Class_Articulo();
        CumplimentarComboboxes cumpCombos = new CumplimentarComboboxes();
        CumplimentarPictureBoxes cumpPictureBoxes = new CumplimentarPictureBoxes();
        Consultas consultas = new Consultas();
        Class_Socio consultaSocios = new Class_Socio();
        Utilidades ut = new Utilidades();
        
        private string  nombreProveedor, refArticulo, refLinea;
        private int id_empleado = 0, id_proveedor = 0, id_socio = 0;

        public int primeravez = 0, id_articulo = 0;
        private bool seEncuentra = false;

      


        private void Form_Venta_Load(object sender, EventArgs e)
        {
            this.CenterToScreen();
            cumpCombos.refrescarCombo("ref", "articulo", combo_refarticulo);
            cumpCombos.cumplimenterComboboxSocio(combo_refsocio);
        }

    // 3 
        private void combo_reflinea_SelectedIndexChanged(object sender, EventArgs e)
        {
            refLinea = combo_reflinea.Text;
            int id_lineacompraproveedor = consultas.obtenerCualquierId("id_lineacompraproveedor", "lineacompraproveedor", "ref", refLinea);

            //
            Class_Articulo articulo = new Class_Articulo();
            int existenciasAlmacen = articulo.existenciasLineaZona(1, id_articulo, id_lineacompraproveedor);
            text_unidadesalmacen.Text = existenciasAlmacen.ToString();

            int existenciasTienda = articulo.existenciasLineaZona(2, id_articulo, id_lineacompraproveedor);
            text_unidadestienda.Text = existenciasTienda.ToString();

            decimal precioventa = articulo.precioCosteVentaArticulo(refLinea, "precioventa");
            text_precioventa.Text = precioventa.ToString();
            //

            numeric_cantidad.Enabled = true;
        }


        private string refSocio = "";
        

    // 4 Método que muestra la foto de socio a partir de su referencia
        private void combo_refsocio_SelectedIndexChanged(object sender, EventArgs e)
        {
            refSocio = combo_refsocio.Text;
            id_socio = consultas.obtenerCualquierId("id_socio","socio","ref",refSocio);

            ConexionBD con = new ConexionBD();
            string cadenaConexion = con.conexion();
            MySqlConnection conexionBD = new MySqlConnection(cadenaConexion);

            try
            {
                string selectQuery = "select nombre, apellidos from socio where id_socio= " + id_socio;

                conexionBD.Open();
                MySqlCommand command = new MySqlCommand(selectQuery, conexionBD);
                MySqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {

                    string nombre = reader.GetString("nombre");
                    string apellidos = reader.GetString("apellidos");
                    label_nombresocio.Text = apellidos + ", " + nombre;
                    string nombreApellidos = nombre + apellidos;
                    nombreApellidos = ut.limpiezaDeString(nombreApellidos);

                    try
                    {
                        pictureBox_perfilsocio.Image = Image.FromFile(ClaseCompartida.carpetaimg_absoluta + "socios/" + id_socio + "/perfil/foto1.jpg");
                    }
                    catch (Exception ex)
                    {
                        pictureBox_perfilsocio.Image = Image.FromFile(ClaseCompartida.carpetaimg_absoluta + "socios/predeterminada.jpg");
                    }
                }

            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
            finally { conexionBD.Close(); }
        }



       


    //5 Método que lista la descripción del artículo a comprar, No compruebe si hay ya artículo ya que hay de varios precios
        private void button_anadir_Click(object sender, EventArgs e)
        {
            string referenciaArticulo = refArticulo;
            string referenciaCompraProveedor = combo_reflinea.Text;
            bool aparece = comprobarItem(referenciaArticulo, referenciaCompraProveedor);

            if (aparece == false)
            {
                try
                {
                   // string refProducto = text_refArticulo.Text;
                    

                    string refsocio = combo_refsocio.Text;
                    string nombreSocio = label_nombresocio.Text;

                    decimal cantidad = numeric_cantidad.Value;
                    decimal totalArticulo = cantidad * Convert.ToDecimal(text_precioventa.Text);


                    if (
                        combo_reflinea.Text == "Seleccione" ||
                        cantidad == 0)
                    {
                        MessageBox.Show("Campos en blanco!");
                    }
                    else
                    {
                        ListViewItem itemAgregar = new ListViewItem(refArticulo);
                        // itemAgregar.Checked = true;
                        itemAgregar.SubItems.Add(refLinea);
                        itemAgregar.SubItems.Add(text_proveedor.Text);
                        itemAgregar.SubItems.Add(text_catalogacion.Text);
                        itemAgregar.SubItems.Add(cantidad.ToString());
                        itemAgregar.SubItems.Add(text_precioventa.Text);
                        itemAgregar.SubItems.Add(totalArticulo.ToString());
                        listView1.Items.Add(itemAgregar);
                        
                        limpiarCampos();
                    }
                }
                catch (Exception ex)
                {
                    // MessageBox.Show("Cumplimente todos los campos, por favor!" + ex);
                }
            }
            else
            {
                MessageBox.Show("No incluyo en esta parte");
            }

            seEncuentra = false;

           
            combo_reflinea.Enabled = false;
            numeric_cantidad.Value = 0;
        }


        private string refPredeterminada = "VSO";


        // 6 Método que registra la compra a un Socio 
        private void button2_Click(object sender, EventArgs e)
        {
            int id_predeterminado = consultas.idMax("id_ventasocio", "ventasocio") + 1;

            // id_empleado
            string refEmpleado = ClaseCompartida.refe;
            id_empleado = consultas.obtenerCualquierId("id_empleado","empleado","ref", refEmpleado);

            // id_socio
            string refSocio = combo_refsocio.Text;
            id_socio = consultas.obtenerCualquierId("id_socio","socio","ref",refSocio);

            // fecha de la compra
            DateTime fechaActual = DateTime.Now;
            string fechaFormateada = ut.fechaTimeStam(fechaActual);

            bool insertadoVentaSocio = consultaSocios.registrarVentaSocio(id_predeterminado, id_empleado, id_socio, fechaFormateada);

            if (insertadoVentaSocio==true) { 
            
            }



            if (combo_refsocio.Text != "Seleccione")
            {
                for (int i = 0; i < listView1.Items.Count; i++)
                {
                    int id_lineaventasocio = consultas.idMax("id_lineaventasocio", "lineaventasocio") + 1;
                    int id_ventasocio = consultas.idMax("id_ventasocio", "ventasocio");
                    int id_compraproveedor = consultas.obtenerCualquierId("id_compraproveedor","lineacompraproveedor","ref",refLinea);

                    refArticulo = listView1.Items[i].SubItems[0].Text;
                    id_articulo = consultas.obtenerCualquierId("id_articulo","articulo","ref",refArticulo);

                    int unidadesAcomprar = Int32.Parse(listView1.Items[i].SubItems[4].Text);

                    // Precio Venta por artículo, no meto el total ya que escaparía el precio de venta del artículo en ese momento 
                    string precioVentaTexto = listView1.Items[i].SubItems[5].Text;
                    precioVentaTexto = precioVentaTexto.Replace(",", ".");

                    bool insertado = insertarLineaVentaSocio(id_lineaventasocio, id_ventasocio, id_compraproveedor, id_articulo, unidadesAcomprar, precioVentaTexto);

                        //Resta de existencias en tienda
                        if (insertado == true)
                        {
                            string unidadesArticuloTexto = listView1.Items[i].SubItems[4].Text;

                            // Existencias en tienda
                            string refLinea = listView1.Items[i].SubItems[1].Text;
                            int id_lineacompraproveedor = consultas.obtenerCualquierId("id_lineacompraproveedor", "lineacompraproveedor", "ref", refLinea);

                            int unidadesTienda = articulo.existenciasTiendaArticulo(id_lineacompraproveedor, id_articulo);
                            int totalExistenciasTienda = unidadesTienda - Int32.Parse(unidadesArticuloTexto);

                            // Ajuste existencias en tienda
                            Class_AlmacenTienda almacenTienda = new Class_AlmacenTienda();
                            almacenTienda.ajusteExistenciasCualquierUbicacion(id_lineacompraproveedor, totalExistenciasTienda, id_articulo, "tienda");

                        }
                        else {
                            MessageBox.Show("Línea de venta no insertada");
                        }
                }

                // Emitir el ticket, leer el ListView
                // aPdf();

                limpiarCampos();

                listView1.Items.Clear();
                combo_reflinea.Enabled=false;

            }
            else
            {
                MessageBox.Show("Seleccione Sócio");
            }

        }

        // Método que inserta una linea de compra al proveedor
        private bool insertarLineaVentaSocio(int id_lineaventasocio, int id_ventasocio, int id_compraproveedor, int id_articulo, int unidades, string precioventaTexto)
        {
           
            string refLineaVentaSocio = "LVP" + id_lineaventasocio;

            ConexionBD con = new ConexionBD();
            string cadenaConexion = con.conexion();
            MySqlConnection conexionBD = new MySqlConnection(cadenaConexion);
            MySqlDataReader reader = null;

            try
            {
                string selectQuery = "insert into lineaventasocio (id_lineaventasocio, ref,id_ventasocio, id_compraproveedor, id_articulo, unidades, precioventa) " +
                    " values (" + id_lineaventasocio +
                    ",'" + refLineaVentaSocio + "'" +
                    ", " + id_ventasocio + "" +
                    ", " + id_compraproveedor + "" +
                    ", " + id_articulo + "" +
                    ", " + unidades +  "" +
                    ", convert( '" + precioventaTexto + "', decimal (7,2)) )" ;
               

                MySqlCommand comando = new MySqlCommand(selectQuery);
                comando.Connection = conexionBD;
                conexionBD.Open();
                reader = comando.ExecuteReader();

                // MessageBox.Show("Nueva Línea de Venta de Socio creada");
                conexionBD.Close();
                return true;
            }
            catch (MySqlException ex)
            {
                MessageBox.Show(ex.Message);
                conexionBD.Close();
                return false;
            }
            finally
            {
                conexionBD.Close();
            }
           
        }


        // Metodo que comprueba si un item se encuentra repetido
        private bool comprobarItem(string referenciaArticulo, string referenciaCompraProveedor)
        {
            seEncuentra = false;
            for (int i = 0; i < listView1.Items.Count; i++)
            {
                if (listView1.Items[i].SubItems[0].Text == referenciaArticulo && listView1.Items[i].SubItems[1].Text == referenciaCompraProveedor)
                {

                    MessageBox.Show("Ya se encuentra referencia Artículo " + listView1.Items[i].SubItems[0].Text);
                    MessageBox.Show("Ya se encuentra referencia Compra Proveedor " + listView1.Items[i].SubItems[1].Text);

                    decimal sumaCantidades = Int32.Parse(listView1.Items[i].SubItems[4].Text) + numeric_cantidad.Value;
                    listView1.Items[i].SubItems[4].Text = sumaCantidades.ToString();


                    decimal totalArticulo = Decimal.Parse(listView1.Items[i].SubItems[4].Text) * Decimal.Parse(listView1.Items[i].SubItems[5].Text);
                    listView1.Items[i].SubItems[6].Text = totalArticulo.ToString();
                    seEncuentra = true;
                    return seEncuentra;
                }
            }
            return seEncuentra;
        }

        // Cerrar formulario
        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }



    // Método que al incrementar el botón de cantidad, compruebe que hay suficientes para vender
        private void numeric_cantidad_ValueChanged(object sender, EventArgs e)
        {
               decimal cantidadUbicaciontienda = Decimal.Parse(text_unidadestienda.Text);
               
               decimal unidadesCompra = numeric_cantidad.Value;
               if (unidadesCompra > cantidadUbicaciontienda)
               {
                       MessageBox.Show("No hay tantas existencias en tienda, saque del almacén!");
                       numeric_cantidad.Value = Decimal.Parse(text_unidadestienda.Text);
               }
               else { 
                    decimal total = numeric_cantidad.Value * Decimal.Parse( text_precioventa.Text);
                    text_total.Text = total.ToString();
                    button_anadir.Enabled = true;
               }
        }


        private void button5_Click(object sender, EventArgs e)
        {
            limpiarCampos();
        }


        // Método que borra el item seleccionado del listView
        private void listView1_ItemChecked(object sender, ItemCheckedEventArgs e)
        {
            if (primeravez == 1) {
                DialogResult opcionSeleccionada = MessageBox.Show("Quiere borrar el registro?", "Aviso", MessageBoxButtons.YesNo);

                if (opcionSeleccionada == DialogResult.Yes)
                {
                    e.Item.Remove();
                    primeravez = 0;
                }
            }
        }


        //Code to Export data to PDF file
        public void aPdf()
        {
            MessageBox.Show("pdf");

            PdfDocument document = new PdfDocument();


            //You will have to add Page in PDF Document
            PdfPage page = document.AddPage();

            //For drawing in PDF Page you will nedd XGraphics Object
            XGraphics gfx = XGraphics.FromPdfPage(page);

            //For Test you will have to define font to be used
            XFont font = new XFont("Verdana", 20, XFontStyle.Bold);

            //Finally use XGraphics & font object to draw text in PDF Page
            gfx.DrawString("My First PDF Document", font, XBrushes.Black,
            new XRect(0, 0, page.Width, page.Height), XStringFormats.Center);


            //Specify file name of the PDF file
            string filename = "FirstPDFDocument.pdf";

            //Save PDF File
            document.Save(filename);


            //Load PDF File for viewing
            Process.Start(filename);


            // https://procodeguide.com/dotnet/create-pdf-file-in-csharp-net/
        }





        private void button_limpiar_Click(object sender, EventArgs e)
        {
            limpiarCampos();
        }


        // Método que limpia los campos
        private void limpiarCampos()
        {
            combo_refarticulo.Text = "Seleccione";
            combo_reflinea.Text = "Seleccione";
            combo_reflinea.Enabled = false;
            text_proveedor.Text = "";
            text_clasevino.Text = "";
            text_denominacion.Text = "";
            text_catalogacion.Text = "";
            text_unidadesalmacen.Text = "";
            text_unidadestienda.Text = "";
            text_formatocontenido.Text = "";
            text_empaquetado.Text = "";
            numeric_cantidad.Value = 0;
            numeric_cantidad.Enabled = false;
            text_precioventa.Text = "0";
            text_total.Text = "0";

            numeric_cantidad.Value = 0;

            button_anadir.Enabled = false;
            pictureBox1.Image = null;
            pictureBox_perfilsocio.Image = null;
            combo_refsocio.Text = "Seleccione";


        }

        private void listView1_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            primeravez = 1;
        }

        // // Carga para el artículo 2
        private void cargaArticulo2ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            text_proveedor.Text = "CAMPO VIEJO";
            text_catalogacion.Text = "2021";
            combo_reflinea.Text = "LCP12";
            combo_refarticulo.Text = "ART11";
            text_clasevino.Text = "ROSADO";
            text_denominacion.Text = "D.O. Ca Rioja";
            //Debería por base de datos
            text_unidadesalmacen.Text = "75";
            text_unidadestienda.Text = "25";
            text_formatocontenido.Text = "Estandar 3/4";
            text_empaquetado.Text = "Botella";
            text_precioventa.Text = "4.65";
            numeric_cantidad.Enabled = true;
            numeric_cantidad.Value = 3;
            text_total.Text = "0";
            combo_refsocio.Text = "SOC6";

        }

        private void button3_Click(object sender, EventArgs e)
        {






        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            // https://www.youtube.com/watch?v=WUDUMuJMN74

            FileStream fs = new FileStream(@"../aaaaaa.pdf", FileMode.Create);
            Document doc = new Document(PageSize.LETTER, 5, 5, 7, 7);
            PdfWriter pw = PdfWriter.GetInstance(doc, fs);

            doc.Open();

            // Titulo y autor
            doc.AddAuthor("wirebox");
            doc.AddTitle("PDF Generado");

            // Definir fuente
            iTextSharp.text.Font standarFont = new iTextSharp.text.
                Font(iTextSharp.text.Font.FontFamily.HELVETICA, 8, iTextSharp.text.Font.NORMAL, BaseColor.BLACK);









            PdfPTable table = new PdfPTable(3);
            table.DefaultCell.Border = iTextSharp.text.Rectangle.NO_BORDER;


            string referenciaVenta = "", nombreSocio = "", apellidosSocio = "", refSocio = "", fecha = "";

            string refVenta = ClaseCompartida.refVentaSocio;

           ConexionBD con = new ConexionBD();
            string cadenaConexion = con.conexion();
            MySqlConnection conexionBD = new MySqlConnection(cadenaConexion);

            try
            {
                string selectQuery = "select v.ref as referenciaventasocio, v.fecha as fecha, s.nombre as nombresocio, s.apellidos as apellidossocio,s.ref as referenciasocio " +
                   " from socio as s " +

                   " inner join ventasocio as v on v.id_socio = s.id_socio " +
                   " where v.ref = '" + refVenta + "' ";

                conexionBD.Open();
                MySqlCommand command = new MySqlCommand(selectQuery, conexionBD);
                MySqlDataReader reader = command.ExecuteReader();


                while (reader.Read())
                {
                    referenciaVenta = reader.GetString("referenciaventasocio");
                    fecha = reader.GetString("fecha");
                    nombreSocio = reader.GetString("nombresocio");
                    apellidosSocio = reader.GetString("apellidossocio");
                    refSocio = reader.GetString("referenciasocio");



                    // Necesitamos consultar en ubicacionlineacompraproveedor con la ref
                    // int id_articulo = Int32.Parse(reader.GetString("id_articulo"));

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


            /*
            Image jpg = Image.GetInstance("C:" + "/aaa.png");

            Paragraph paragraph = new Paragraph(@"su quis, bland?");
            paragraph.Alignment = Element.ALIGN_JUSTIFIED;
            jpg.ScaleToFit(250f, 250f);
            jpg.Alignment = Image.TEXTWRAP | Image.ALIGN_RIGHT;
            jpg.IndentationLeft = 9f;
            jpg.SpacingAfter = 9f;
            jpg.BorderWidthTop = 36f;
            // jpg.BorderColorTop = Color.Azure;

            doc.Add(jpg);
            */

            Paragraph paraHeader_1 = new Paragraph("Factura");
            paraHeader_1.Alignment = Element.ALIGN_CENTER;
            paraHeader_1.Font.Size = 25;
            paraHeader_1.SpacingAfter = 10f;
            doc.Add(paraHeader_1);




           // doc.Add(paragraph);





            /*
            Paragraph refVenta = new Paragraph("Ref: " + referenciaVenta);
            refVenta.Alignment = Element.ALIGN_CENTER;
            refVenta.SpacingAfter = 1f;
            doc.Add(refVenta);




            Paragraph fecha1 = new Paragraph("Fecha: " + fecha);
            fecha1.Alignment = Element.ALIGN_CENTER;
            fecha1.SpacingAfter = 10f;
            doc.Add(fecha1);


            Paragraph datosSocio = new Paragraph("Datos Socio");
            datosSocio.Alignment = Element.ALIGN_LEFT;
            datosSocio.SpacingAfter = 1f;
            datosSocio.IndentationLeft = 30f;
            doc.Add(datosSocio);


            Paragraph nombreyapellidos = new Paragraph("Nombre y Apellidos: " + nombreSocio + " " + apellidosSocio);
            nombreyapellidos.Alignment = Element.ALIGN_LEFT;
            nombreyapellidos.SpacingAfter = 1f;
            nombreyapellidos.IndentationLeft = 30f;
            doc.Add(nombreyapellidos);




            Paragraph refSocio1 = new Paragraph("Ref.: " + refSocio );
            refSocio1.Alignment = Element.ALIGN_LEFT;
            refSocio1.SpacingAfter = 10f;
            refSocio1.IndentationLeft = 30f;
            doc.Add(refSocio1);


            */

            table = new PdfPTable(3);
            //actual width of table in points
            //table.LockedWidth = true; //fix the absolute width of the table

            //relative col widths in proportions - 1/3 and 2/3

            float[] widths1 = new float[] { 3f, 4f, 3f };

            table.SetWidths(widths1);

            //leave a gap before and after the table
            table.SpacingBefore = 30f;
            table.SpacingAfter = 30f;

            table.HorizontalAlignment = 1;


            table.AddCell("Datos Cliente" + "\n " + nombreSocio + " " + apellidosSocio + "\n " + refSocio);
            table.AddCell("Factura: " + referenciaVenta + "\n Fecha: " + fecha);
            table.AddCell("Datos Empresa: \n WINE CLUB\n 0000000A\n dirección\n superlaya50@gmail.com");



            doc.Add(table);







            table = new PdfPTable(5);
            table.TotalWidth = 600f;  //actual width of table in points
                                      //table.LockedWidth = true; //fix the absolute width of the table

            //relative col widths in proportions - 1/3 and 2/3

            float[] widths = new float[] { 1f, 4f, 1f, 1f, 1f };

            table.SetWidths(widths);

            //leave a gap before and after the table
            table.SpacingBefore = 30f;
            table.SpacingAfter = 30f;

            table.HorizontalAlignment = 1;


            table.AddCell("Ref.");
            table.AddCell("Descripción Artículo");
            table.AddCell("Ud");
            table.AddCell("Precio/ud");
            table.AddCell("Total");
            //doc.Add(table);




            /*ConexionBD*/
            con = new ConexionBD();
            /*string*/
            cadenaConexion = con.conexion();
            /*MySqlConnection*/
            conexionBD = new MySqlConnection(cadenaConexion);

            double subtotal = 0, total = 0;


            try
            {
                string selectQuery = "select v.ref as referenciaventasocio, a.ref as referenciaarticulo, cv.nombre as nombreclasevino, p.nombre as nombreproveedor, " +
                   " c.nombre as nombrecatalogacion, l.unidades as unidades, l.precioventa as precioventa, " +
                   " emp.nombre as formato, f.nombre as contenido from articulo as a " +

                   " inner join lineaventasocio as l on a.id_articulo = l.id_articulo " +
                   " inner join ventasocio as v on v.id_ventasocio = l.id_ventasocio " +
                   " inner join empaquetado as emp on emp.id_empaquetado=a.id_empaquetado " +

                   "inner join formatocontenido as f on f.id_formatocontenido = a.id_formatocontenido " +
                   "inner join clasevino as cv on cv.id_claseVino = a.id_claseVino " +
                   "inner join proveedor as p on p.id_proveedor = a.id_proveedor " +
                   "inner join catalogacion as c on c.id_catalogacion = a.id_catalogacion " +
                   "inner join denominacion as d on d.id_denominacion = a.id_denominacion where v.ref = '" + refVenta + "' order by p.nombre asc";

                conexionBD.Open();
                MySqlCommand command = new MySqlCommand(selectQuery, conexionBD);
                MySqlDataReader reader = command.ExecuteReader();


                while (reader.Read())
                {
                    string referenciaArticulo = reader.GetString("referenciaarticulo");
                    string descripcion = reader.GetString("nombreproveedor") +
                        reader.GetString("nombreclasevino") + " " +
                        reader.GetString("nombrecatalogacion");

                    string unidades = reader.GetString("unidades");
                    string precioVenta = reader.GetString("precioventa");
                    total = Convert.ToDouble(unidades) * Convert.ToDouble(precioVenta);

                    subtotal = subtotal + total;


                    table.AddCell(referenciaArticulo.ToString());
                    table.AddCell(descripcion.ToString());
                    table.AddCell(unidades.ToString());
                    table.AddCell(precioVenta.ToString());
                    table.AddCell(total.ToString());


                    // Necesitamos consultar en ubicacionlineacompraproveedor con la ref
                    // int id_articulo = Int32.Parse(reader.GetString("id_articulo"));

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

            doc.Add(table);





            Paragraph subtotal1 = new Paragraph("Subtotal........." + subtotal + "€");
            subtotal1.Alignment = Element.ALIGN_RIGHT;
            subtotal1.SpacingAfter = 1f;
            subtotal1.IndentationRight = 60f;
            doc.Add(subtotal1);

            Paragraph iva = new Paragraph("IVA (21%).........." + subtotal * 0.21 + "€");
            iva.Alignment = Element.ALIGN_RIGHT;
            iva.SpacingAfter = 1f;
            iva.IndentationRight = 60f;
            doc.Add(iva);


            Paragraph totalFactura = new Paragraph("Total........." + subtotal * 1.21 + "€");
            totalFactura.Alignment = Element.ALIGN_RIGHT;
            totalFactura.SpacingAfter = 1f;
            totalFactura.IndentationRight = 60f;
            doc.Add(totalFactura);




            table = new PdfPTable(3);

            table.TotalWidth = 180f;
            table.LockedWidth = true;
            table.HorizontalAlignment = 0;
            doc.Add(table);


            // https://www.mikesdotnetting.com/article/87/itextsharp-working-with-images


            doc.Close();
            pw.Close();
            MessageBox.Show("Hecho");























        }

        private void combo_refarticulo_SelectedIndexChanged(object sender, EventArgs e)
        {
            refArticulo = combo_refarticulo.Text;

            id_articulo = consultas.obtenerCualquierId("id_articulo", "articulo", "ref", refArticulo);
            string [] caracteristicasArticulos = articulo.nombreCaracteristicasArticulos(id_articulo);

            nombreProveedor=caracteristicasArticulos[0];
            text_proveedor.Text = nombreProveedor;

            string nombreClaseVino=caracteristicasArticulos[1];
            text_clasevino.Text = nombreClaseVino;
            text_denominacion.Text = caracteristicasArticulos[2];
            text_catalogacion.Text = caracteristicasArticulos[3];
            text_empaquetado.Text = caracteristicasArticulos[4];
            text_formatocontenido.Text = caracteristicasArticulos[5];

            id_proveedor = consultas.obtenerCualquierId("id_proveedor", "proveedor", "nombre", nombreProveedor);

            pictureBox1.Image = Image.FromFile(ClaseCompartida.carpetaimg_absoluta + "proveedores/" + id_proveedor + "/articulos/" + nombreClaseVino + "/" + refArticulo + ".jpg");



            combo_reflinea.Items.Clear();
            cumpPictureBoxes.cumplimentarPictureBox(refArticulo, pictureBox1);
            cumpCombos.refrescarComboboxLineaCompraProveedorDesdeId_articulo(id_articulo, combo_reflinea);
            combo_reflinea.Enabled = true;



            //
            int existenciasUbicacionAlmacen = articulo.existenciasTotalesZona(1, id_articulo);
            text_unidadesalmacen.Text = existenciasUbicacionAlmacen.ToString();

            int existenciasUbicaciontienda = articulo.existenciasTotalesZona(2, id_articulo);
            text_unidadestienda.Text = existenciasUbicaciontienda.ToString();
            //


            combo_reflinea.Enabled = true;
        }

        private void combo_reflinea_MouseHover(object sender, EventArgs e)
        {
            if (combo_reflinea.Items.Count==0) {
                MessageBox.Show("Pase existencias de Almacén a tienda");
            }
        }

        // Carga para el artículo 1
        private void cargaArticulo1ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            text_proveedor.Text = "MARQUÉS DE CÁCERES";
            text_catalogacion.Text = "Crianza 2019";
            combo_reflinea.Text = "LCP10";
            combo_refarticulo.Text = "ART10";
            text_clasevino.Text = "TINTO";
            text_denominacion.Text = "D.O. Ca Rioja";
            //Debería por base de datos
                text_unidadesalmacen.Text = "75";
                text_unidadestienda.Text = "25";
                text_formatocontenido.Text = "Estandar 3/4";
                text_empaquetado.Text = "Botella";
                text_precioventa.Text = "10.65";
            numeric_cantidad.Enabled = true;
            numeric_cantidad.Value = 5;
            text_total.Text = "0";
            combo_refsocio.Text = "SOC6";
        }


        private void deAlmacénATiendaToolStripMenuItem_Click(object sender, EventArgs e)
        { 
            Class_AlmacenTiendaAperturaForms almacenTiendaAperturaForms = new Class_AlmacenTiendaAperturaForms();
            almacenTiendaAperturaForms.movimientoAlmacenTienda();
        }
      
        private void compraAProveedorToolStripMenuItem_Click(object sender, EventArgs e)
        {   Class_ProveedorAperturaForms proveedorAperturaForms=new Class_ProveedorAperturaForms();
            proveedorAperturaForms.comprarArticuloProveedor();
        }
    }

}




