using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace proyectovinos.Roles
{
    internal class Class_CargosAperturaForms
    {
        public void todosRoles()
        {
            Form_TodosCargos form;
            if (Application.OpenForms["Form_TodosCargos"] != null)
            {
                Application.OpenForms["Form_TodosCargos"].Activate();
            }
            else
            {
                form = new Form_TodosCargos();
                //formulario.MdiParent = this;
                form.Show();
            }
        }
    }
}
