using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ejercicio_06
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnCalcular_Click(object sender, EventArgs e)
        {
            try
            {
                // Limpieza inicial: Antes de procesar, borramos el resultado anterior.
                // Esto asegura que si algo falla, no quede el promedio anterior visible.
                lblPromedio.Text = "";

                // Técnica 1: Validación de Obligatoriedad
                if (string.IsNullOrWhiteSpace(txtNum1.Text) ||
                    string.IsNullOrWhiteSpace(txtNum2.Text) ||
                    string.IsNullOrWhiteSpace(txtNum3.Text))
                    throw new ArgumentException("Todos los campos son obligatorios.");

                // Técnica 2: Validación de Tipo de Dato
                if (!double.TryParse(txtNum1.Text, out double n1) ||
                    !double.TryParse(txtNum2.Text, out double n2) ||
                    !double.TryParse(txtNum3.Text, out double n3))
                    throw new ArgumentException("Ingrese solo números válidos.");

                // Técnica 4: Validación de Rango (0 a 10)
                if (n1 < 0 || n1 > 10 || n2 < 0 || n2 > 10 || n3 < 0 || n3 > 10)
                    throw new ArgumentException("Las notas deben estar entre 0 y 10.");

                // Procesamiento y Salida
                double promedio = (n1 + n2 + n3) / 3;
                lblPromedio.Text = promedio.ToString("F2");
            }
            catch (ArgumentException ex)
            {
                // Importante: Al ocurrir un error, nos aseguramos de que el resultado esté vacío.
                lblPromedio.Text = "Error";
                MessageBox.Show(ex.Message, "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            catch (Exception ex)
            {
                lblPromedio.Text = "Error";
                MessageBox.Show("Error inesperado: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                // Mantenemos la limpieza de las cajas y el enfoque.
                txtNum1.Clear();
                txtNum2.Clear();
                txtNum3.Clear();
                txtNum1.Focus();
            }
        }
    }
}
