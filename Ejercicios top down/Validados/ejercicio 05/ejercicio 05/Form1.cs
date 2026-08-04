using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ejercicio_05
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnConvertir_Click(object sender, EventArgs e)
        {
            try
            {
                // 1. Validación de Obligatoriedad
                // Verifica si el campo está vacío o tiene solo espacios.
                if (string.IsNullOrWhiteSpace(txtFahrenheit.Text))
                    throw new ArgumentException("El campo Fahrenheit no puede estar vacío.");

                // 2. Validación de Tipo de Dato
                // Intenta convertir el texto a número sin que el programa se bloquee.
                if (!double.TryParse(txtFahrenheit.Text, out double f))
                    throw new ArgumentException("Por favor, ingrese un valor numérico válido.");

                // 3. Validación de Rango
                // Evita valores físicamente imposibles (menores al cero absoluto).
                if (f < -459.67)
                    throw new ArgumentException("La temperatura no puede ser inferior al cero absoluto (-459.67 °F).");

                // 4. Lógica de Conversión
                double c = (f - 32) * 5 / 9;
                lblCelsius.Text = c.ToString("F2") + " °C";
            }
            catch (ArgumentException ex)
            {
                // Captura específicamente los errores de validación definidos arriba.
                MessageBox.Show(ex.Message, "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            catch (Exception ex)
            {
                // Captura cualquier otro error inesperado del sistema.
                MessageBox.Show("Error inesperado: " + ex.Message, "Error Crítico", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                // Se ejecuta para dejar la interfaz lista para el siguiente uso.
                txtFahrenheit.Clear();
                txtFahrenheit.Focus();
            }

        }
    }
}
