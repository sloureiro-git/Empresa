using System.Collections;
using Entidades;
using Logica;
using Persistencia;

namespace Presentacion
{
    public partial class Menu_Principal : Form
    {

        public Menu_Principal()
        {
            InitializeComponent();
        }

        private void buttonALTA_Click(object sender, EventArgs e)
        {
            try
            {
                if (checkBoxJORNALERO.Checked)
                {

                    LogicaEmpleados.AltaJornalero(int.Parse(textBoxCedula.Text), textBoxNombre.Text, double.Parse(textBoxSueldo_base.Text), textBoxEspecialidad.Text, int.Parse(textBoxHoras_extra.Text));


                }
                else
                {
                    LogicaEmpleados.AltaEmpleado(int.Parse(textBoxCedula.Text), textBoxNombre.Text, double.Parse(textBoxSueldo_base.Text));
                }
                obtenerEmpleados();
            }
            catch
            {
                MessageBox.Show("EL DATO INGRESADO ES INCORRECTO");
            }

        }

        private void buttonBAJA_Click(object sender, EventArgs e)
        {
            LogicaEmpleados.BajaEmpleados(int.Parse(textBoxCedula.Text));
            obtenerEmpleados();
        }

        private void buttonACTUALIZAR_Click(object sender, EventArgs e)
        {

            LogicaEmpleados.ActualizarEmpleado(int.Parse(textBoxCedula.Text), textBoxNombre.Text, double.Parse(textBoxSueldo_base.Text));
            obtenerEmpleados();

        }

        private void listBoxLISTA_SelectedIndexChanged(object sender, EventArgs e)
        {

            if (listBoxLISTA.SelectedItems.Count > 0)
            {
                limpiarTextBox();
                Empleado ItemSeleccionadoEmpleado = listBoxLISTA.SelectedItems[0] as Empleado;

                textBoxCedula.Text = ItemSeleccionadoEmpleado.Cedula.ToString();
                textBoxNombre.Text = ItemSeleccionadoEmpleado.Nombre;
                textBoxSueldo_base.Text = ItemSeleccionadoEmpleado.SueldoBase.ToString();
                labelEmpleado.Text = ItemSeleccionadoEmpleado.SueldoLiquido().ToString();
                if (ItemSeleccionadoEmpleado is Jornalero)
                {
                    Jornalero ItemSeleccionadoJornalero = listBoxLISTA.SelectedItems[0] as Jornalero;

                    checkBoxJORNALERO.Checked = true;
                    textBoxEspecialidad.Text = ItemSeleccionadoJornalero.Especialidad;
                    textBoxHoras_extra.Text = ItemSeleccionadoJornalero.HorasExtras.ToString();

                }
            }

        }

        public void obtenerEmpleados()
        {
            listBoxLISTA.Items.Clear();
            listBoxLISTA.DisplayMember = "Display";

            ArrayList Empleados = LogicaEmpleados.DevolverEmpleados();

            for (int i = 0; i < Empleados.Count; i++)
            {
                listBoxLISTA.Items.Add(Empleados[i]);

            }

        }

        public void limpiarTextBox()
        {
            textBoxCedula.Clear();
            textBoxNombre.Clear();
            textBoxSueldo_base.Clear();
            checkBoxJORNALERO.Checked = false;
            textBoxEspecialidad.Clear();
            textBoxHoras_extra.Clear();
        }
    }
}
