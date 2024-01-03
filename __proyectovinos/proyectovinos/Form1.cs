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
        Class_AlmacenTiendaAperturaForms almacenTiendaAperturaForms = new Class_AlmacenTiendaAperturaForms();
        Class_VentasDevolucionesAperturaForms ventasDevolucionesSocio = new Class_VentasDevolucionesAperturaForms();
        Form_Logueo formularioLogueo;

        private void Form1_Load(object sender, EventArgs e)
        {
            this.CenterToScreen();
        }

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
                nuevaVentaToolStripMenuItem.Enabled = true ;
                nuevoSocioToolStripMenuItem.Enabled= true ;
            }
            else if (ClaseCompartida.roll == "Dueño")
            {
                duenoToolStripMenuItem.Enabled = true;
                encargadoToolStripMenuItem.Enabled = true;
                dependienteToolStripMenuItem.Enabled = true;
                perfilToolStripMenuItem.Enabled = true;
                loguinToolStripMenuItem.Text = "Log Out";
                nuevaVentaToolStripMenuItem.Enabled = true;
                nuevoSocioToolStripMenuItem.Enabled = true;
            }
            else if (ClaseCompartida.roll == "Encargado")
            {
                duenoToolStripMenuItem.Enabled= false;
                encargadoToolStripMenuItem.Enabled = true;
                dependienteToolStripMenuItem.Enabled = true;
                perfilToolStripMenuItem.Enabled = true;
                loguinToolStripMenuItem.Text = "Log Out";
                nuevaVentaToolStripMenuItem.Enabled = true;
                nuevoSocioToolStripMenuItem.Enabled = true;
            }
        }

        private void eMPLEADOSToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Class_EmpleadoAperturaForms apertura = new Class_EmpleadoAperturaForms();
            apertura.todosEmpleados();
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


        // CRISTAL REPORTS
        //________
            // Método que permite generar con Cristal Reports las ventas a socios
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

            // Método que permite generar con Cristal Reports las compras de proveedores   
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
        //________


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

        private void pROVEEDORESToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Class_ProveedorAperturaForms apertura = new Class_ProveedorAperturaForms();
            apertura.todosProveedores();
        }

        private void sALIRToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            DialogResult opcionSeleccionada = MessageBox.Show("Realmente desea salir?", "Aviso", MessageBoxButtons.YesNo);
            if (opcionSeleccionada == DialogResult.Yes)
            {
                Application.Exit();
            }
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
            nuevaDevoluciónToolStripMenuItem1.Enabled = true;
            nuevoSocioToolStripMenuItem.Enabled = true;
        }

        // Apertura de formularios de características

        private void formatoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Class_FormatoAperturaForms apertura = new Class_FormatoAperturaForms();
            apertura.todosFormatos();
        }

        private void empaquetadoToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            Class_EmpaquetadoAperturaForms apertura = new Class_EmpaquetadoAperturaForms();
            apertura.todosEmpaquetados();
        }

        private void catalogaciónToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Class_CatalogacionAperturaForms apertura = new Class_CatalogacionAperturaForms();
            apertura.todasCatalogaciones();
        }

        private void denominaciónToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Class_DenominacionAperturaForms apertura = new Class_DenominacionAperturaForms();
            apertura.todasDenominaciones();
        }

        private void claseVinnoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Class_ClaseVinoAperturaForms apertura = new Class_ClaseVinoAperturaForms();
            apertura.todasClasesVino();
        }

        private void variedadUvaToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Class_VariedadUvaAperturaForms variedaduva = new Class_VariedadUvaAperturaForms();
            variedaduva.todasVariedadesUva();
        }

        private void tipoDeUvaToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Class_TipoUvaAperturaForms apertura = new Class_TipoUvaAperturaForms();
            apertura.todosTiposUva();
        }
        //_____


        private void toolStripStatusLabel3_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cargosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Class_CargosAperturaForms rol = new Class_CargosAperturaForms();
            rol.todosRoles();
        }

        private void empleadosToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            Class_EmpleadoAperturaForms empleado = new Class_EmpleadoAperturaForms();
            empleado.todosEmpleados();
        }

        private void fijarPreciosArtículosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Class_VentasDevolucionesAperturaForms apertura = new Class_VentasDevolucionesAperturaForms();
            apertura.modificarArticuloVenta();
        }

        private void comprarAProveedoresToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Class_ProveedorAperturaForms proveedorAperturaForms = new Class_ProveedorAperturaForms();
            proveedorAperturaForms.comprarArticuloProveedor();
        }

        private void devoluciónAProveedoresToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Class_ProveedorAperturaForms proveedorAperturaForms = new Class_ProveedorAperturaForms();
            proveedorAperturaForms.devolucionArticuloProveedor();
        }

        private void nuevaVentaToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            ventasDevolucionesSocio.nuevaVentaSocio();
        }

        private void nuevoSocioToolStripMenuItem_Click(object sender, EventArgs e)
        {
            socioAperturaForms.nuevoSocio();
        }

        private void sOCIOSToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Class_SocioAperturaForms apertura = new Class_SocioAperturaForms();
            apertura.todosSocios();
        }

        private void verTodosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Class_ArticuloAperturaForms apertura = new Class_ArticuloAperturaForms();
            apertura.todosArticulosVino();
        }




        public int sumar(int primerNumero, int segundoNumero)
        {
            return primerNumero + segundoNumero;
        }
    }
}



















// html, pdp, ghost doc y documentaciones como enseñó Amparo

/*  https://www.elguille.info/colabora/net2005/svalsse_autenticacion_cifrada.htm */

/*
public static void DeleteFTPFolder(string Folderpath)
{
    FtpWebRequest request = (FtpWebRequest)WebRequest.Create(Folderpath);
    request.Method = WebRequestMethods.Ftp.RemoveDirectory;
    request.Credentials = new System.Net.NetworkCredential("wineclub", "Alberite*1"); ;
    request.GetResponse().Close();
}*/
