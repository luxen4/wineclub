using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;




using proyectovinos.Movimientos;
using proyectovinos.Reportes.ExistenciasArticulosAlmacenTienda;
using proyectovinos.Caracteristicas.clasesvino;
using proyectovinos.Caracteristicas.Denominacion;
using proyectovinos.Caracteristicas.catalogacion;
using proyectovinos.Caracteristicas.proveedor;
using proyectovinos.Empleados;
using proyectovinos.ArticuloVino;
using proyectovinos.Socios;
using proyectovinos.Caracteristicas.tipouva;
using proyectovinos.VentasDevoluciones;
using proyectovinos.VentasDevolucionesSocio;
using proyectovinos.Movimientos.AlmacenTienda;
using proyectovinos.Reportes.TodosArticulos;
using proyectovinos.Reportes.comprasproveedores;
using proyectovinos.Caracteristicas.contenido;
using proyectovinos.Caracteristicas.empaquetado;
using proyectovinos.Caracteristicas.variedaduva;
using MySql.Data.MySqlClient;
using System.Net;
using proyectovinos.Roles;
using System.IO;
using iTextSharp.text;
using iTextSharp.text.pdf;
using System.Data.SqlClient;
using proyectovinos;
using System.Activities.Statements;
using System.Reflection;
using Image = iTextSharp.text.Image;

namespace proyectovinos
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();


        }

        // AperturaFormulariosArticulo apertura = new AperturaFormulariosArticulo();
        Class_AlmacenTiendaAperturaForms almacenTiendaAperturaForms = new Class_AlmacenTiendaAperturaForms();

        Class_VentasDevolucionesAperturaForms ventasDevolucionesSocio = new Class_VentasDevolucionesAperturaForms();
        // Form_VentaSocio formularioVenta;
        Form_Logueo formularioLogueo;

        public static void DeleteFTPFolder(string Folderpath)
        {
            FtpWebRequest request = (FtpWebRequest)WebRequest.Create(Folderpath);
            request.Method = WebRequestMethods.Ftp.RemoveDirectory;
            request.Credentials = new System.Net.NetworkCredential("wineclub", "Alberite*1"); ;
            request.GetResponse().Close();
        }


        private void Form1_Load(object sender, EventArgs e)
        {
            this.CenterToScreen();    
            /*
            if (Application.OpenForms["Form_Logueo"] != null)
            {
                Application.OpenForms["Form_Logueo"].Activate();
            }
            else
            {
                formularioLogueo = new Form_Logueo();
                // formularioLogueo.MdiParent = this;
                formularioLogueo.Show();
            }*/


            /*
            if (radio_archivoslocal.Checked) {
                ClaseCompartida.alojamientoarchivos = "local";
            } else if (radio_archivos000webhost.Checked) {
                ClaseCompartida.alojamientoarchivos = "000webhost.com";
            }*/

        }

        /*
        private void button1_Click(object sender, EventArgs e)
        {
            DialogResult opcionSeleccionada = MessageBox.Show("Realmente desea salir?", "Aviso", MessageBoxButtons.YesNo);
            if (opcionSeleccionada == DialogResult.Yes)
            {
                Application.Exit();
            }
        }*/
        private void verTodasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Class_ClaseVinoAperturaForms clasevinoAperturaForms = new Class_ClaseVinoAperturaForms();
            clasevinoAperturaForms.todasClasesVino();
        }

        private void tipoUvaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Class_TipoUvaAperturaForms tipoUvaAperturaForms = new Class_TipoUvaAperturaForms();
            tipoUvaAperturaForms.todosTiposUva();
        }

        private void catalogacionesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Class_CatalogacionAperturaForms catalogacionAperturaFormularios = new Class_CatalogacionAperturaForms();
            catalogacionAperturaFormularios.todasCatalogaciones();
        }

        private void denominacionesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Class_DenominacionAperturaForms denominacion = new Class_DenominacionAperturaForms();
            denominacion.todasDenominaciones();
        }

        private void verTodosToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void verTodosArticulosDeVinoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Class_ArticuloAperturaForms articuloAperturaForm = new Class_ArticuloAperturaForms();
            articuloAperturaForm.todosArticulosVino();
        }

        private void pROVEEDORESToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Class_ProveedorAperturaForms apertura = new Class_ProveedorAperturaForms();
            apertura.todosProveedores();
        }



        //public bool primeraVez = true;

        // Función que habilita y deshabilita enlaces de menú según el logueo de cada usuario
        private void Form1_MouseHover(object sender, EventArgs e)
        {
            toolStripStatusLabel1.Text = "Usuario: " + ClaseCompartida.nombre + " " + ClaseCompartida.apellido1 + " " + ClaseCompartida.apellido2;
            toolStripStatusLabel2.Text = "Cargo: " + ClaseCompartida.roll;

            if (ClaseCompartida.roll == "Dependiente")
            {
                duenoToolStripMenuItem.Enabled = false;
                encargadoToolStripMenuItem.Enabled = false;
                dependienteToolStripMenuItem.Enabled = true;
                perfilToolStripMenuItem.Enabled = true;
                loguinToolStripMenuItem.Text = "Log Out";
            }
            else if (ClaseCompartida.roll == "Dueño")
            {
                duenoToolStripMenuItem.Enabled = true;
                encargadoToolStripMenuItem.Enabled = true;
                dependienteToolStripMenuItem.Enabled = true;
                perfilToolStripMenuItem.Enabled = true;
                loguinToolStripMenuItem.Text = "Log Out";
            }
            else if (ClaseCompartida.roll == "Encargado")
            {
                duenoToolStripMenuItem.Enabled= false;
                encargadoToolStripMenuItem.Enabled = true;
                dependienteToolStripMenuItem.Enabled = true;
                perfilToolStripMenuItem.Enabled = true;
                loguinToolStripMenuItem.Text = "Log Out";
            }
        }




        private void claseDeVinoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Class_ClaseVinoAperturaForms apertura = new Class_ClaseVinoAperturaForms();
            apertura.todasClasesVino();
        }

        private void tipoDeUvaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            /*Class_TipoUvaAperturaForms apertura = new Class_TipoUvaAperturaForms();
            apertura.todosTiposUva();*/
            Class_TipoUvaAperturaForms apertura = new Class_TipoUvaAperturaForms();
            apertura.todosTiposUvaII();
        }

        private void catalogaciónToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Class_CatalogacionAperturaForms apertura = new Class_CatalogacionAperturaForms();
            apertura.todasCatalogaciones();
        }

        private void denominaciónToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Class_DenominacionAperturaForms apertura = new Class_DenominacionAperturaForms();
            apertura.todasDenominaciones();
        }

        private void eMPLEADOSToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Class_EmpleadoAperturaForms apertura = new Class_EmpleadoAperturaForms();
            apertura.todosEmpleados();
        }

        private void movimientosToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Class_ProveedorAperturaForms proveedorAperturaForms = new Class_ProveedorAperturaForms();
            proveedorAperturaForms.comprarArticuloProveedor();
        }

        private void devoluciónAProveedorToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Class_ProveedorAperturaForms proveedorAperturaForms = new Class_ProveedorAperturaForms();
            proveedorAperturaForms.devolucionArticuloProveedor();
        }

        private void fijarPreciosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Class_VentasDevolucionesAperturaForms apertura = new Class_VentasDevolucionesAperturaForms();
            apertura.modificarArticuloVenta();
        }

        private void formatoContenidoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Class_FormatoAperturaForms apertura = new Class_FormatoAperturaForms();
            apertura.todosFormatos();
        }

        private void empaquetadoToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Class_EmpaquetadoAperturaForms apertura = new Class_EmpaquetadoAperturaForms();
            apertura.todosEmpaquetados();
        }

        private void eMPLEADOSToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Class_EmpleadoAperturaForms emp = new Class_EmpleadoAperturaForms();
            emp.todosEmpleados();
        }

        private void variedadDeUvaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Class_VariedadUvaAperturaForms variedaduva = new Class_VariedadUvaAperturaForms();
            variedaduva.todasVariedadesUva();
        }

        private void toolStripStatusLabel3_Click(object sender, EventArgs e)
        {
            Class_EmpleadoAperturaForms apertura = new Class_EmpleadoAperturaForms();
            apertura.modificarEmpleadoUsuarioContrasena();
        }

        private void toolStripStatusLabel4_Click(object sender, EventArgs e)
        {
            deslogueo();
        }


        // Modificar Usuario y Contraseña
        private void cambioDeUsuarioYContraseñaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Class_EmpleadoAperturaForms apertura = new Class_EmpleadoAperturaForms();
            apertura.modificarEmpleadoUsuarioContrasena();
        }

        private void radioButton2_MouseClick(object sender, MouseEventArgs e)
        {
            ClaseCompartida.baseDatos = "localhost";
        }

        private void radioButton1_MouseClick(object sender, MouseEventArgs e)
        {
            ClaseCompartida.baseDatos = "freesqldatabase.com";
        }

        private void nuevoArtículoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Class_ArticuloAperturaForms apertura = new Class_ArticuloAperturaForms();
            apertura.nuevoArticuloVino();
        }

        private void todosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Class_ArticuloAperturaForms apertura = new Class_ArticuloAperturaForms();
            apertura.todosArticulosVino();
        }

        private void modificarToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Class_ArticuloAperturaForms apertura = new Class_ArticuloAperturaForms();
            apertura.modificarArticuloVino();
        }

        private void desdeAlmacénATiendaToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            almacenTiendaAperturaForms.movimientoAlmacenTienda();
        }

        private void desdeTiendaAAlmacénToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            almacenTiendaAperturaForms.movimientoTiendaAlmacen();
        }

        private void modificarStockUbicaciónToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            almacenTiendaAperturaForms.existenciasRotas();
        }

        private void nuevaVentaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ventasDevolucionesSocio.nuevaVentaSocio();
        }


        private void verTodosToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            Class_SocioAperturaForms apertura = new Class_SocioAperturaForms();
            apertura.todosSocios();
        }

        // CRISTAL REPORTS

        private void todasVentasSociosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Report_TodasVentasSocios reporteTodosArticulos;
            if (Application.OpenForms["Report_TodosArticulos"] != null)
            {
                Application.OpenForms["Report_TodosArticulos"].Activate();
            }
            else
            {
                reporteTodosArticulos = new Report_TodasVentasSocios();
                //formulario.MdiParent = this;
                reporteTodosArticulos.Show();
            }
        }


        // Método que permite generar con Cristal Reports el Reporte de inventario de Artículos    
        private void inventarioToolStripMenuItem_Click(object sender, EventArgs e)
        {

            Report_InventarioArticulos reporte;
            if (Application.OpenForms["Report_InventarioArticulos"] != null)
            {
                Application.OpenForms["Report_InventarioArticulos"].Activate();
            }
            else
            {
                reporte = new Report_InventarioArticulos();
                //formulario.MdiParent = this;
                reporte.Show();
            }
        }

        private void todasComprasProveedoresToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Report_TodasComprasProveedores reporte;
            if (Application.OpenForms["Report_TodasComprasProveedores"] != null)
            {
                Application.OpenForms["Report_TodasComprasProveedores"].Activate();
            }
            else
            {
                reporte = new Report_TodasComprasProveedores();
                //formulario.MdiParent = this;
                reporte.Show();
            }
        }

        private void nuevaVentaToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            ventasDevolucionesSocio.nuevaVentaSocio();
        }

        private void dEVOLUCIONESToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ventasDevolucionesSocio.nuevaDevolucionSocio();
        }


        Class_SocioAperturaForms socioAperturaForms = new Class_SocioAperturaForms();
        private void nuevoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            socioAperturaForms.nuevoSocio();
        }

        private void modificarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            socioAperturaForms.modificarSocio();
        }

        Class_VentasDevolucionesAperturaForms devolucion = new Class_VentasDevolucionesAperturaForms();
        private void nuevaDevoluciónToolStripMenuItem1_Click(object sender, EventArgs e)
        {

            devolucion.nuevaDevolucionSocio();
        }

        private void todosProveedoresIIToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Class_ProveedorAperturaForms apertura = new Class_ProveedorAperturaForms();
            apertura.todosProveedores();
        }

        private void todosIIToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Class_ArticuloAperturaForms apertura = new Class_ArticuloAperturaForms();
            apertura.todosArticulosVino();
        }

        private void todasDenominacionesIIToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Class_DenominacionAperturaForms apertura = new Class_DenominacionAperturaForms();
            apertura.todasDenominaciones();
        }

        private void todosFormatoContenidoIIToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Class_FormatoAperturaForms apertura = new Class_FormatoAperturaForms();
            apertura.todosFormatos();
        }

        private void todasCatalogacionesIIToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Class_CatalogacionAperturaForms apertura = new Class_CatalogacionAperturaForms();
            apertura.todasCatalogaciones();
        }

        private void todasClasesDeVinoIIToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Class_ClaseVinoAperturaForms apertura = new Class_ClaseVinoAperturaForms();
            apertura.todasClasesVino();
        }

        private void todosEmpaquetadosIIToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Class_EmpaquetadoAperturaForms apertura = new Class_EmpaquetadoAperturaForms();
            apertura.todosEmpaquetados();
        }


        private void todasVariedadesDeUvaIIToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Class_VariedadUvaAperturaForms variedad = new Class_VariedadUvaAperturaForms();
            variedad.todasVariedadesUva();
        }

        private void aRTICULOSToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Class_ArticuloAperturaForms apertura = new Class_ArticuloAperturaForms();
            apertura.todosArticulosVino();
        }

        private void pROVEEDORESToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Class_ProveedorAperturaForms apertura = new Class_ProveedorAperturaForms();
            apertura.todosProveedores();
        }

        private void todosProveedoresToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            Class_ProveedorAperturaForms apertura = new Class_ProveedorAperturaForms();
            apertura.todosProveedores();
        }

        private void rOLESCARGOSToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Class_RollAperturaForms rol = new Class_RollAperturaForms();
            rol.todosRolesII();
        }



        private void sALIRToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            DialogResult opcionSeleccionada = MessageBox.Show("Realmente desea salir?", "Aviso", MessageBoxButtons.YesNo);
            if (opcionSeleccionada == DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        private void toolStripStatusLabel3_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }





        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            if (loguinToolStripMenuItem.Text == "Log In")
            {
                // Se loguea
                logueo();
            }
            else if (loguinToolStripMenuItem.Text == "Log Out")
            {
                // se desloguea
                deslogueo();
            }
        }

        private void logueo()
        {
            if (Application.OpenForms["Form_Logueo"] != null)
            {
                Application.OpenForms["Form_Logueo"].Activate();
            }
            else
            {
                formularioLogueo = new Form_Logueo();
                //formulario.MdiParent = this;
                formularioLogueo.Show();
            }
        }

        private void deslogueo()
        {
            duenoToolStripMenuItem.Enabled = false;
            artículosToolStripMenuItem.Enabled = false;

            encargadoToolStripMenuItem.Enabled = false;
            dependienteToolStripMenuItem.Enabled = false;
            perfilToolStripMenuItem.Enabled = false;
            ClaseCompartida.nombre = "";
            ClaseCompartida.apellido1 = "";
            ClaseCompartida.apellido2 = "";
            ClaseCompartida.contrasena = "";
            ClaseCompartida.usuario = "";
            ClaseCompartida.refe = "";
            ClaseCompartida.roll = "";

            toolStripStatusLabel1.Text = "";
            toolStripStatusLabel2.Text = "";

            loguinToolStripMenuItem.Enabled = true;
            loguinToolStripMenuItem.Text = "Log In";
        }
    }
}



















// html, pdp, ghost doc y documentaciones como enseñó Amparo

/*  https://www.elguille.info/colabora/net2005/svalsse_autenticacion_cifrada.htm */
