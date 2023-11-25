using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace proyectovinos.Caracteristicas.catalogacion
{
    internal class Class_CatalogacionAperturaForms
    {


        public void modificarCatalogacion()
        {
            Form_ModificarCatalogacion form;
            if (Application.OpenForms["Form_ModificarCatalogacion"] != null)
            {
                Application.OpenForms["Form_ModificarCatalogacion"].Activate();
            }
            else
            {
                form = new Form_ModificarCatalogacion();
                //formulario.MdiParent = this;
                form.Show();
            }
        }

        public void todasCatalogaciones()
        {
            Form_TodasCatalogaciones form;
            if (Application.OpenForms["Form_TodasCatalogaciones"] != null)
            {
                Application.OpenForms["Form_TodasCatalogaciones"].Activate();
            }
            else
            {
                form = new Form_TodasCatalogaciones();
                //formulario.MdiParent = this;
                form.Show();
            }
        }

        public void todasCatalogacionesII()
        {
            Form_TodasCatalogacionesII form;
            if (Application.OpenForms["Form_TodasCatalogacionesII"] != null)
            {
                Application.OpenForms["Form_TodasCatalogacionesII"].Activate();
            }
            else
            {
                form = new Form_TodasCatalogacionesII();
                //formulario.MdiParent = this;
                form.Show();
            }
        }

        internal void eliminarCatalogacion()
        {
            Form_EliminarCatalogacion form;
            if (Application.OpenForms["Form_EliminarCatalogacion"] != null)
            {
                Application.OpenForms["Form_EliminarCatalogacion"].Activate();
            }
            else
            {
                form = new Form_EliminarCatalogacion();
                //formulario.MdiParent = this;
                form.Show();
            }
        }

        internal void habilitarCatalogacion()
        {
            Form_HabilitarCatalogacion form;
            if (Application.OpenForms["Form_HabilitarCatalogacion"] != null)
            {
                Application.OpenForms["Form_TodasCatalogaciones"].Activate();
            }
            else
            {
                form = new Form_HabilitarCatalogacion();
                //formulario.MdiParent = this;
                form.Show();
            }
        }
    }
}
