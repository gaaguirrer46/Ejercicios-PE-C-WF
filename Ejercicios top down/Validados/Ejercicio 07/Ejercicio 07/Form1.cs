using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Ejercicio_07
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
                // Limpieza de estado: Evita que el resultado anterior persista si hay un error actual.
                lblResultado.Text = "";

                // Técnica 1: Validación de Obligatoriedad (Presencia)
                if (string.IsNullOrWhiteSpace(txtMinutos.Text))
                    throw new ArgumentException("El campo de minutos es obligatorio.");

                // Técnica 2: Validación de Tipo de Dato (Conversión)
                // Se usa int.TryParse para evitar que el programa "explote" con letras o símbolos.
                if (!int.TryParse(txtMinutos.Text, out int totalMin))
                    throw new ArgumentException("Debe ingresar un número entero válido.");

                // --- NUEVA EXPLICACIÓN: Técnica 4: Validación de Rango y Longitud (Límites) ---
                // En este contexto, la técnica se enfoca en los "Límites Físicos y de Desbordamiento". 
                // Según las fuentes, el error más común es validar solo el "valor ideal" y olvidar el "valor extremo".
                // 1. Límite Inferior: El tiempo transcurrido no puede ser negativo; un valor menor a 0 sería un 
                //    error semántico (lógico) que produciría un resultado absurdo.
                // 2. Límite Superior: Aunque un 'int' aguanta hasta 2 mil millones, promediar o convertir 
                //    cantidades astronómicas de minutos puede no tener sentido para tu negocio. Poner un tope 
                //    previene errores de desbordamiento y asegura que el software sea predecible.
                if (totalMin < 0)
                    throw new ArgumentException("Los minutos no pueden ser un valor negativo.");

                if (totalMin > 1000000) // Ejemplo de límite: 1 millón de minutos
                    throw new ArgumentException("La cantidad de minutos excede el límite permitido por el sistema.");

                // Procesamiento
                int horas = totalMin / 60;
                int minResto = totalMin % 60;

                // Salida
                lblResultado.Text = horas + " horas y " + minResto + " minutos";
            }
            catch (ArgumentException ex)
            {
                lblResultado.Text = "Error";
                MessageBox.Show(ex.Message, "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            catch (Exception ex)
            {
                lblResultado.Text = "Error Crítico";
                MessageBox.Show("Ocurrió un error inesperado: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                // Técnica de Limpieza: Restablece el control para una nueva entrada.
                txtMinutos.Clear();
                txtMinutos.Focus();
            }
        }
    }
}
