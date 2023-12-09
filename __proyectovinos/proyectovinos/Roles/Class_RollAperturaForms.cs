using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace proyectovinos.Roles
{
    internal class Class_RollAperturaForms
    {

        public void todosRolesII()
        {
            Form_TodosRoles form;
            if (Application.OpenForms["Form_TodosRoles"] != null)
            {
                Application.OpenForms["Form_TodosRoles"].Activate();
            }
            else
            {
                form = new Form_TodosRoles();
                //formulario.MdiParent = this;
                form.Show();
            }
        }
    }
}
