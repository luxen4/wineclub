using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using proyectovinos.ArticuloVino;
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


    }
}
