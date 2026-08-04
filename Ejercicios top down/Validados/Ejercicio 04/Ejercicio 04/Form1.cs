using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Ejercicio_04
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void btnCalcular_Click(object sender, EventArgs e)
        {
            // Variable para saber qué campo causó el error
            TextBox campoConError = null;

            try
            {
                // Validación de obligatoriedad
                if (string.IsNullOrWhiteSpace(txtNum1.Text))
                {
                    campoConError = txtNum1;
                    throw new ArgumentException("El número 1 no puede estar vacío.");
                }
                if (string.IsNullOrWhiteSpace(txtNum2.Text))
                {
                    campoConError = txtNum2;
                    throw new ArgumentException("El número 2 no puede estar vacío.");
                }

                // Validación de tipo de dato
                if (!double.TryParse(txtNum1.Text, out double n1))
                {
                    campoConError = txtNum1;
                    throw new ArgumentException("El número 1 debe ser un número decimal (usa punto).");
                }
                if (!double.TryParse(txtNum2.Text, out double n2))
                {
                    campoConError = txtNum2;
                    throw new ArgumentException("El número 2 debe ser un número decimal (usa punto).");
                }

                // LO NUEVO: Validación de división por cero (Técnica 6 - Reglas de negocio)
                if (n2 == 0)
                {
                    campoConError = txtNum2;  // El error está en el segundo número
                    throw new ArgumentException("No se puede dividir entre cero.");
                }

                // Si llegamos aquí, todo es válido
                double suma = n1 + n2;
                double resta = n1 - n2;
                double multiplicacion = n1 * n2;
                double division = n1 / n2;

                lblSuma.Text = suma.ToString("F2");
                lblResta.Text = resta.ToString("F2");
                lblMultiplicacion.Text = multiplicacion.ToString("F2");
                lblDivision.Text = division.ToString("F2");
            }
            catch (ArgumentException ex)
            {
                MessageBox.Show("DATO INCORRECTO: " + ex.Message,
                                "Validación fallida",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Warning);

                // LO NUEVO: Enfocamos el campo que causó el error
                if (campoConError != null)
                {
                    // Borramos el contenido para que el usuario empiece de cero
                    campoConError.Text = "";
                    campoConError.Focus();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("ERROR INESPERADO: " + ex.Message,
                                "Error crítico",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Error);

                // Limpiamos todos los labels por seguridad
                lblSuma.Text = "";
                lblResta.Text = "";
                lblMultiplicacion.Text = "";
                lblDivision.Text = "";
            }

        }
    }
}
