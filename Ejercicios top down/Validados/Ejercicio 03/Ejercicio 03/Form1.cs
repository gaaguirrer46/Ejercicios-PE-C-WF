using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Ejercicio_03
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void btnCalcular_Click(object sender, EventArgs e)
        {
            try
            {
                // Validación de obligatoriedad
                if (string.IsNullOrWhiteSpace(txtCateto1.Text))
                    throw new ArgumentException("El cateto 1 no puede estar vacío.");
                if (string.IsNullOrWhiteSpace(txtCateto2.Text))
                    throw new ArgumentException("El cateto 2 no puede estar vacío.");

                // Validación de tipo de dato
                if (!double.TryParse(txtCateto1.Text, out double c1))
                    throw new ArgumentException("El cateto 1 debe ser un número decimal (usa punto).");
                if (!double.TryParse(txtCateto2.Text, out double c2))
                    throw new ArgumentException("El cateto 2 debe ser un número decimal (usa punto).");

                // Validación de regla de negocio: los catetos deben ser positivos
                if (c1 <= 0)
                    throw new ArgumentException("El cateto 1 debe ser mayor que cero.");
                if (c2 <= 0)
                    throw new ArgumentException("El cateto 2 debe ser mayor que cero.");

                // Límite para evitar desbordamiento
                if (c1 > 1e6 || c2 > 1e6)
                    throw new ArgumentException("Los catetos no pueden ser mayores a 1,000,000.");

                // Cálculo
                double hip = Math.Sqrt(c1 * c1 + c2 * c2);

                // Verificar que el resultado sea un número válido
                if (double.IsInfinity(hip) || double.IsNaN(hip))
                    throw new InvalidOperationException("El cálculo produjo un resultado inválido.");

                // Mostrar resultado
                lblHipotenusa.Text = hip.ToString("F2");
            }
            catch (ArgumentException ex)
            {
                MessageBox.Show("DATO INCORRECTO: " + ex.Message,
                                "Validación fallida",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Warning);
                txtCateto1.Focus();
                txtCateto1.SelectAll();
            }
            catch (InvalidOperationException ex)
            {
                MessageBox.Show("ERROR DE CÁLCULO: " + ex.Message,
                                "Error en operación",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Warning);
            }
            catch (Exception ex)
            {
                MessageBox.Show("ERROR INESPERADO: " + ex.Message,
                                "Error crítico",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Error);
            }
            finally
            {
                // La limpieza se hace aquí, siempre se ejecuta haya o no error
                // Así no repetimos código en cada catch
                lblHipotenusa.Text = "";
            }
        }
    }
}
