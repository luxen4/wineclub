using System.Windows.Forms;

namespace proyectovinos.Caracteristicas.contenido
{
    internal class Class_FormatoAperturaForms
    {
        public void todosFormatos()
        {
            Form_TodosFormatos formularioTodosFormatos;
            if (Application.OpenForms["Form_TodosFormatos"] != null)
            {
                Application.OpenForms["Form_TodosFormatos"].Activate();
            }
            else
            {
                formularioTodosFormatos = new Form_TodosFormatos();
                //formulario.MdiParent = this;
                formularioTodosFormatos.Show();
            }
        }
    }
}
