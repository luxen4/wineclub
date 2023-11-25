using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using proyectovinos.Articulo;
using proyectovinos.Empleados.usuariocontrasena;

namespace proyectovinos.Empleados
{
    internal class Class_EmpleadoAperturaForms
    {

        Form_TodosEmpleados formularioTodosEmpleados;
        Form_ModificarEmpleado formularioModificarEmpleado;



        public void todosEmpleados()
        {
            if (Application.OpenForms["Form_TodosEmpleados"] != null)
            {
                Application.OpenForms["Form_TodosEmpleados"].Activate();
            }
            else
            {
                formularioTodosEmpleados = new Form_TodosEmpleados();
                //formulario.MdiParent = this;
                formularioTodosEmpleados.Show();
            }
        }
        public void modificarEmpleado()
        {
            if (Application.OpenForms["Form_ModificarEmpleado"] != null)
            {
                Application.OpenForms["Form_ModificarEmpleado"].Activate();
            }
            else
            {
                formularioModificarEmpleado = new Form_ModificarEmpleado();
                //formulario.MdiParent = this;
                formularioModificarEmpleado.Show();
            }
        }

        Form_ModificarEmpleadoUsuarioContrasena formularioModificarEmpleadoUsuarioContrasena;
        public void modificarEmpleadoUsuarioContrasena()
        {
            if (Application.OpenForms["Form_ModificarEmpleadoUsuarioContrasena"] != null)
            {
                Application.OpenForms["Form_ModificarEmpleadoUsuarioContrasena"].Activate();
            }
            else
            {
                formularioModificarEmpleadoUsuarioContrasena = new Form_ModificarEmpleadoUsuarioContrasena();
                //formulario.MdiParent = this;
                formularioModificarEmpleadoUsuarioContrasena.Show();
            }
        }


        // Método que abre el formulario de Articulos inhabilitados con posibilidad de habilitarlos
        public void empleadosInhabilitados()
        {
            Form_HabilitarEmpleados form;
            if (Application.OpenForms["Form_HabilitarEmpleados"] != null)
            {
                Application.OpenForms["Form_HabilitarEmpleados"].Activate();
            }
            else
            {
                form = new Form_HabilitarEmpleados();
                //formulario.MdiParent = this;
                form.Show();
            }
        }

        internal void eliminarEmpleado()
        {
            Form_EliminarEmpleado form;
            if (Application.OpenForms["Form_EliminarEmpleado"] != null)
            {
                Application.OpenForms["Form_EliminarEmpleado"].Activate();
            }
            else
            {
                form = new Form_EliminarEmpleado();
                //formulario.MdiParent = this;
                form.Show();
            }
        }
    }
}
