using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace proyectovinos.Caracteristicas.empaquetado
{
    internal class Class_EmpaquetadoAperturaForms
    {

        public void modificarEmpaquetado()
        {
            Form_ModificarEmpaquetado form;
            if (Application.OpenForms["Form_ModificarEmpaquetado"] != null)
            {
                Application.OpenForms["Form_ModificarEmpaquetado"].Activate();
            }
            else
            {
                form = new Form_ModificarEmpaquetado();
                //formulario.MdiParent = this;
                form.Show();
            }
        }

        public void todosEmpaquetados()
        {
            Form_TodosEmpaquetados form;
            if (Application.OpenForms["Form_todosEmpaquetados"] != null)
            {
                Application.OpenForms["Form_todosEmpaquetados"].Activate();
            }
            else
            {
                form = new Form_TodosEmpaquetados();
                //formulario.MdiParent = this;
                form.Show();
            }
        }

        public void todosEmpaquetadosII()
        {
            Form_TodosEmpaquetadosII form;
            if (Application.OpenForms["Form_todosEmpaquetadosII"] != null)
            {
                Application.OpenForms["Form_todosEmpaquetadosII"].Activate();
            }
            else
            {
                form = new Form_TodosEmpaquetadosII();
                //formulario.MdiParent = this;
                form.Show();
            }
        }

        internal void eliminarEmpaquetado()
        {
            Form_EliminarEmpaquetado form;
            if (Application.OpenForms["Form_EliminarEmpaquetado"] != null)
            {
                Application.OpenForms["Form_EliminarEmpaquetado"].Activate();
            }
            else
            {
                form = new Form_EliminarEmpaquetado();
                //formulario.MdiParent = this;
                form.Show();
            }
        }

        internal void habilitarEmpaquetado()
        {
            Form_HabilitarEmpaquetados form;
            if (Application.OpenForms["Form_HabilitarEmpaquetados"] != null)
            {
                Application.OpenForms["Form_HabilitarEmpaquetados"].Activate();
            }
            else
            {
                form = new Form_HabilitarEmpaquetados();
                //formulario.MdiParent = this;
                form.Show();
            }
        }
    }
}
