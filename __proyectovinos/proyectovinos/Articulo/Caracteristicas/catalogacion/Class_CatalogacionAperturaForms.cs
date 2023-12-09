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
    }
}
