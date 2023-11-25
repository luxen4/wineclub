            /*
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


            string referenciaVenta = "", nombreSocio="", apellidosSocio="", refSocio="", fecha="";

            ConexionBD con = new ConexionBD();
            string cadenaConexion = con.conexion();
            MySqlConnection conexionBD = new MySqlConnection(cadenaConexion);

            try
            {
                string selectQuery = "select v.ref as referenciaventasocio, v.fecha as fecha, s.nombre as nombresocio, s.apellidos as apellidossocio,s.ref as referenciasocio " +
                   " from socio as s " +
                   
                   " inner join ventasocio as v on v.id_socio = s.id_socio " +
                   " where v.ref = 'VSO5'";

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
            

            Paragraph paraHeader_1 = new Paragraph("Factura");
            paraHeader_1.Alignment = Element.ALIGN_CENTER;
            paraHeader_1.Font.Size =25;
            paraHeader_1.SpacingAfter = 10f;
            doc.Add(paraHeader_1);


          

            doc.Add(paragraph);





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
            table.AddCell("Datos Empresa: \n WINE CLUB\n 0000000A\n dirección\n superlaya50@gmail.com"  );

            

            doc.Add(table);







            table = new PdfPTable(5);
            table.TotalWidth = 600f;  //actual width of table in points
            //table.LockedWidth = true; //fix the absolute width of the table

     //relative col widths in proportions - 1/3 and 2/3

            float[] widths = new float[] { 1f, 4f ,1f, 1f, 1f};

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

            


            /*ConexionBD con = new ConexionBD();
            /*string cadenaConexion = con.conexion();
            /*MySqlConnection conexionBD = new MySqlConnection(cadenaConexion);

            double subtotal = 0, total=0;
           

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
                   "inner join denominacion as d on d.id_denominacion = a.id_denominacion where v.ref = 'VSO5' order by p.nombre asc";

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


            Paragraph totalFactura = new Paragraph("Total........." + subtotal*1.21 + "€");
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
            
        
    }

}
*/

/*

private void button1_Click_3(object sender, EventArgs e)
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


    // Encabezado de columnas
    PdfPTable tblEjemplo = new PdfPTable(3);
    tblEjemplo.WidthPercentage = 100;

    //Configurando el título de nuestras columnas
    PdfPCell clNombre = new PdfPCell(new Phrase("Nombre", standarFont));
    clNombre.BorderWidth = 0;
    clNombre.BorderWidthBottom = 0.75f;

    PdfPCell clGrado = new PdfPCell(new Phrase("Grado", standarFont));
    clGrado.BorderWidth = 0;
    clGrado.BorderWidthBottom = 0.75f;


    PdfPCell clEdad = new PdfPCell(new Phrase("Edad", standarFont));
    clEdad.BorderWidth = 0;
    clEdad.BorderWidthBottom = 0.75f;


    tblEjemplo.AddCell(clNombre);
    tblEjemplo.AddCell(clGrado);
    tblEjemplo.AddCell(clEdad);


    // AGREGADO DATOS

    for (int i = 0; i < 3; i++)
    {
        clNombre = new PdfPCell(new Phrase("nombre", standarFont));
        clNombre.BorderWidth = 0;


        clGrado = new PdfPCell(new Phrase("grado", standarFont));
        clGrado.BorderWidth = 0;

        clEdad = new PdfPCell(new Phrase("edad", standarFont));
        clEdad.BorderWidth = 0;


        tblEjemplo.AddCell(clNombre);
        tblEjemplo.AddCell(clGrado);
        tblEjemplo.AddCell(clEdad);

        doc.Add(tblEjemplo);
    }



    PdfPTable table = new PdfPTable(3);

    PdfPCell cell = new PdfPCell(new Phrase("Header spanning 3 columns"));

    cell.Colspan = 3;

    cell.HorizontalAlignment = 1; //0=Left, 1=Centre, 2=Right

    table.AddCell(cell);

    table.AddCell("Col 1 Row 1");
    table.AddCell("Col 2 Row 1");
    table.AddCell("Col 3 Row 1");

    table.AddCell("Col 1 Row 2");
    table.AddCell("Col 2 Row 2");
    table.AddCell("Col 3 Row 2");

    doc.Add(table);




    table = new PdfPTable(2);

    //actual width of table in points

    table.TotalWidth = 216f;

    //fix the absolute width of the table

    table.LockedWidth = true;



    //relative col widths in proportions - 1/3 and 2/3

    float[] widths = new float[] { 1f, 2f };

    table.SetWidths(widths);

    table.HorizontalAlignment = 0;

    //leave a gap before and after the table

    table.SpacingBefore = 20f;
    table.SpacingAfter = 30f;



    cell = new PdfPCell(new Phrase("Products"));

    cell.Colspan = 2;

    cell.Border = 0;

    cell.HorizontalAlignment = 1;

    table.AddCell(cell);

    string connect = "Server=.\\SQLEXPRESS;Database=Northwind;Trusted_Connection=True;";
    using (SqlConnection conn = new SqlConnection(connect))
    {
        string query = "SELECT ProductID, ProductName FROM Products";
        SqlCommand cmd = new SqlCommand(query, conn);
        try
        {
            conn.Open();

            using (SqlDataReader rdr = cmd.ExecuteReader())

            {
                while (rdr.Read())

                {
                    table.AddCell(rdr[0].ToString());
                    table.AddCell(rdr[1].ToString());
                }
            }
        }

        catch (Exception ex) { }
        doc.Add(table);
    }









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
           "inner join denominacion as d on d.id_denominacion = a.id_denominacion where a.ref = 'ART1' order by p.nombre asc";
        //'" + activo + "' order
        // MessageBox.Show(selectQuery);

        conexionBD.Open();
        MySqlCommand command = new MySqlCommand(selectQuery, conexionBD);
        MySqlDataReader reader = command.ExecuteReader();


        while (reader.Read())
        {
            string referencia = reader.GetString("ref");
            string claseVino = reader.GetString("nombreclasevino");
            string proveedor = reader.GetString("nombreproveedor");
            string catalogacion = reader.GetString("nombrecatalogacion");
            string denominacion = reader.GetString("nombredenominacion");
            string formato = reader.GetString("formato");
            string contenido = reader.GetString("contenido");

            table.AddCell(referencia.ToString());
            table.AddCell(claseVino.ToString());
            table.AddCell(proveedor.ToString());
            table.AddCell(catalogacion.ToString());
            table.AddCell(denominacion.ToString());
            table.AddCell(formato.ToString());
            table.AddCell(contenido.ToString());


            // Necesitamos consultar en ubicacionlineacompraproveedor con la ref
            int id_articulo = Int32.Parse(reader.GetString("id_articulo"));

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













    table = new PdfPTable(4);

    table.TotalWidth = 400f;

    table.LockedWidth = true;

    PdfPCell header = new PdfPCell(new Phrase("Header"));

    header.Colspan = 4;

    table.AddCell(header);

    table.AddCell("Cell 1");

    table.AddCell("Cell 2");

    table.AddCell("Cell 3");

    table.AddCell("Cell 4");

    PdfPTable nested = new PdfPTable(1);

    nested.AddCell("Nested Row 1");

    nested.AddCell("Nested Row 2");

    nested.AddCell("Nested Row 3");

    PdfPCell nesthousing = new PdfPCell(nested);

    nesthousing.Padding = 0f;

    table.AddCell(nesthousing);

    PdfPCell bottom = new PdfPCell(new Phrase("bottom"));

    bottom.Colspan = 3;

    table.AddCell(bottom);

    doc.Add(table);


    table = new PdfPTable(3);

    table.TotalWidth = 144f;

    table.LockedWidth = true;

    table.HorizontalAlignment = 0;

    PdfPCell left = new PdfPCell(new Paragraph("Rotated"));

    left.Rotation = 90;

    table.AddCell(left);

    PdfPCell middle = new PdfPCell(new Paragraph("Rotated"));

    middle.Rotation = -90;

    table.AddCell(middle);

    table.AddCell("Not Rotated");

    doc.Add(table);


    // https://www.mikesdotnetting.com/article/87/itextsharp-working-with-images







    doc.Close();
    pw.Close();
    MessageBox.Show("Hecho");
}

*/



/*
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


/*
            Paragraph paraHeader_1 = new Paragraph("Factura");
paraHeader_1.Alignment = Element.ALIGN_CENTER;
paraHeader_1.Font.Size = 25;
paraHeader_1.SpacingAfter = 10f;
doc.Add(paraHeader_1);

*/


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
/*
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




/*ConexionBD
con = new ConexionBD();
/*string
cadenaConexion = con.conexion();
/*MySqlConnection
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

*/


