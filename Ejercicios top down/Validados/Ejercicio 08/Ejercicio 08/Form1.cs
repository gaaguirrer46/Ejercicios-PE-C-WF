using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Ejercicio_08
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
                // Limpieza de estado inicial
                // Evita que resultados de cálculos previos confundan al usuario si ocurre un error ahora.
                lblComision.Text = "$0.00";
                lblTotal.Text = "$0.00";

                // 1. Técnica 1: Validación de Obligatoriedad (Presencia)
                // Verificamos que ninguno de los cuatro campos esté vacío o contenga solo espacios.
                if (string.IsNullOrWhiteSpace(txtSueldoBase.Text) ||
                    string.IsNullOrWhiteSpace(txtVenta1.Text) ||
                    string.IsNullOrWhiteSpace(txtVenta2.Text) ||
                    string.IsNullOrWhiteSpace(txtVenta3.Text))
                    throw new ArgumentException("Todos los campos (Sueldo y las 3 Ventas) son obligatorios.");

                // --- NUEVA VALIDACIÓN: Técnica 7: Caracteres Permitidos (Whitelist) ---
                // Explicación: Esta es una técnica de "higiene" y seguridad. Antes de intentar convertir 
                // el texto a número, verificamos que el usuario no haya ingresado caracteres extraños, 
                // símbolos o scripts maliciosos. 
                // En este caso, usamos una Expresión Regular (Regex) para permitir únicamente dígitos 
                // y el separador decimal (punto o coma según la región). Esto detiene al "intruso" 
                // en la puerta antes de que el sistema intente procesar basura (GIGO).
                string patronNumerico = @"^[1-9]+([\.,][1-9]+)?$";
                if (!System.Text.RegularExpressions.Regex.IsMatch(txtSueldoBase.Text, patronNumerico) ||
                    !System.Text.RegularExpressions.Regex.IsMatch(txtVenta1.Text, patronNumerico) ||
                    !System.Text.RegularExpressions.Regex.IsMatch(txtVenta2.Text, patronNumerico) ||
                    !System.Text.RegularExpressions.Regex.IsMatch(txtVenta3.Text, patronNumerico))
                    throw new ArgumentException("Los campos solo deben contener números y un separador decimal.");

                // 2. Técnica 2: Validación de Tipo de Dato (Conversión)
                // Usamos TryParse para una conversión segura que no genere excepciones internas pesadas.
                if (!double.TryParse(txtSueldoBase.Text, out double sBase) ||
                    !double.TryParse(txtVenta1.Text, out double v1) ||
                    !double.TryParse(txtVenta2.Text, out double v2) ||
                    !double.TryParse(txtVenta3.Text, out double v3))
                    throw new ArgumentException("Uno o más valores no tienen un formato numérico válido.");

                // 3. Técnica 4: Validación de Rango (Límites)
                // El sueldo y las ventas no pueden ser negativos en un contexto contable real.
                if (sBase < 0 || v1 < 0 || v2 < 0 || v3 < 0)
                    throw new ArgumentException("Los valores monetarios no pueden ser negativos.");

                // 4. Lógica de Negocio y Procesamiento
                double comision = (v1 + v2 + v3) * 0.10;
                double total = sBase + comision;

                // 5. Salida de Datos
                lblComision.Text = comision.ToString("C2"); // "C2" da formato de moneda local
                lblTotal.Text = total.ToString("C2");
            }
            catch (ArgumentException ex)
            {
                lblComision.Text = "Error";
                lblTotal.Text = "Error";
                MessageBox.Show(ex.Message, "Validación de Entrada", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            catch (Exception ex)
            {
                lblComision.Text = "Error Crítico";
                MessageBox.Show("Error inesperado: " + ex.Message, "Fallo del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                // Restablecemos la interfaz para la siguiente captura
                txtSueldoBase.Clear();
                txtVenta1.Clear();
                txtVenta2.Clear();
                txtVenta3.Clear();
                txtSueldoBase.Focus();
            }
        }
    }
}
