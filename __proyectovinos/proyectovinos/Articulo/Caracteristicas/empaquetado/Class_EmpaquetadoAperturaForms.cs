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
    }
}
