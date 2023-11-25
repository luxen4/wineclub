using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using iTextSharp.text.pdf;
using iTextSharp.text;
using MySql.Data.MySqlClient;
using System.Diagnostics;

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

        internal void mostrarFactura(string refVen) { 
        

            // https://www.youtube.com/watch?v=WUDUMuJMN74

            string refVenta = refVen;

                //FileStream fs = new FileStream(@"../aaaaaa.pdf", FileMode.Create);
            FileStream fs = new FileStream(ClaseCompartida.carpetafacturas_absoluta + refVenta + ".pdf", FileMode.Create);
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

                string refVenta1 = ClaseCompartida.refVentaSocio;

                ConexionBD con = new ConexionBD();
                string cadenaConexion = con.conexion();
                MySqlConnection conexionBD = new MySqlConnection(cadenaConexion);

                try
                {
                    string selectQuery = "select v.ref as referenciaventasocio, v.fecha as fecha, s.nombre as nombresocio, s.apellidos as apellidossocio,s.ref as referenciasocio " +
                       " from socio as s " +

                       " inner join ventasocio as v on v.id_socio = s.id_socio " +
                       " where v.ref = '" + refVenta1 + "' ";

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


                Paragraph paraHeader_1 = new Paragraph("Factura");
                paraHeader_1.Alignment = Element.ALIGN_CENTER;
                paraHeader_1.Font.Size = 25;
                paraHeader_1.SpacingAfter = 10f;
                doc.Add(paraHeader_1);

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

            //Load PDF File for viewing
            //Process.Start(ClaseCompartida.carpetafacturas_absoluta + refVenta + ".pdf");

        }
    }
    
}

