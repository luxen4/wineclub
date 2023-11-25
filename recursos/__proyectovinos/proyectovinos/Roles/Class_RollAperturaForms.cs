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
        
       

        public void todosRoles()
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

        public void modificarRol()
        {
            Form_ModificarRoll form;
            if (Application.OpenForms["Form_ModificarRol"] != null)
            {
                Application.OpenForms["Form_ModificarRol"].Activate();
            }
            else
            {
                form = new Form_ModificarRoll();
                //formulario.MdiParent = this;
                form.Show();
            }
        }

        internal void eliminarRoll()
        {
            Form_EliminarRoll form;
            if (Application.OpenForms["Form_EliminarRoll"] != null)
            {
                Application.OpenForms["Form_EliminarRoll"].Activate();
            }
            else
            {
                form = new Form_EliminarRoll();
                //formulario.MdiParent = this;
                form.Show();
            }
        }

        internal void habilitarRoll()
        {
            Form_HabilitarRoll form;
            if (Application.OpenForms["Form_HabilitarRoll"] != null)
            {
                Application.OpenForms["Form_HabilitarRoll"].Activate();
            }
            else
            {
                form = new Form_HabilitarRoll();
                //formulario.MdiParent = this;
                form.Show();
            }
        }
    }
}
