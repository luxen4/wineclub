using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace proyectovinos.Movimientos.AlmacenTienda
{
    internal class Class_AlmacenTiendaAperturaForms
    {

        // Método que que abre un formulario para pasar artículos de Almacén a Tienda
        public void movimientoAlmacenTienda()
        {   Form_Movimiento_AlmacenTienda formularioMovimiento_AlmacenTienda;
            if (Application.OpenForms["Form_Movimiento_AlmacenTienda"] != null)
            {
                Application.OpenForms["Form_Movimiento_AlmacenTienda"].Activate();
            }
            else
            {
                formularioMovimiento_AlmacenTienda = new Form_Movimiento_AlmacenTienda();
                //formulario.MdiParent = this;
                formularioMovimiento_AlmacenTienda.Show();
            }
        }

        // Método que que abre un formulario para pasar artículos de Tienda a Almacén
        public void movimientoTiendaAlmacen()
        {
            Form_Movimiento_TiendaAlmacen formularioMovimiento_TiendaAlmacen;
            if (Application.OpenForms["Form_Movimiento_TiendaAlmacen"] != null)
            {
                Application.OpenForms["Form_Movimiento_TiendaAlmacen"].Activate();
            }
            else
            {
                formularioMovimiento_TiendaAlmacen = new Form_Movimiento_TiendaAlmacen();
                //formulario.MdiParent = this;
                formularioMovimiento_TiendaAlmacen.Show();
            }
        }

       // Función que abre el formulario de existencias rotas
        public void existenciasRotas()
        {   Form_ExistenciasRotas formularioExistenciasRotas;
            if (Application.OpenForms["Form_ExistenciasRotas"] != null)
            {
                Application.OpenForms["Form_ExistenciasRotas"].Activate();
            }
            else
            {
                formularioExistenciasRotas = new Form_ExistenciasRotas();
                //formulario.MdiParent = this;
                formularioExistenciasRotas.Show();
            }
        }
    }
}
